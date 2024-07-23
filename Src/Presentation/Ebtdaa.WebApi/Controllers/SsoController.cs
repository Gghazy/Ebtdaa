using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Sso.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IEbtdaaDbContext _dbContext;
        public SsoController(IConfiguration configurations, 
            IEbtdaaDbContext dbContext
            ,
             IHttpClientFactory  httpClientFactory)
        {
            _dbContext = dbContext;
            configuration = configurations;
            


        }
        [HttpGet("redirectoUrl")]
        public async Task<IActionResult> redirectoUrl(string url)
        {
            return Redirect(url); 

        }

        [HttpPost]
        public async Task<IActionResult> getNationalID()
        {

            string urlRedirect = configuration.GetValue<string>("AppUrl");
            string urlError = "/errorPage";
            try
            {
                Boolean isAuthorizeUser = false;

                var r = User.Claims.ToList();
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string nationalId = User.FindFirst("national_id")?.Value;
                string arabicName = User.FindFirst("first_name_ar")?.Value;
                string englishName = User.FindFirst("first_name_en")?.Value;
                nationalId= "1012955132";
                if (nationalId == null)
                {
                    // return Redirect(urlRedirect + urlError + "?errorM=1");
                    return RedirectToAction("redirectoUrl", new { url = urlRedirect + urlError + "?errorM=1" });


                }


                var result =
                    await _dbContext.Factories
                   .Include(x => x.FactoryLocations)
                   .ThenInclude(x => x.City)
                   .Where(r => r.OwnerIdentity == nationalId)
                   .FirstOrDefaultAsync();

                if (result != null)
                {
                    urlRedirect = urlRedirect + "/pages/factories-list";
                    isAuthorizeUser = true;
                }
                else
                {
                    var result2 =
                     await _dbContext.Inspectors
                    .Where(r => r.OwnerIdentity == nationalId)
                    .FirstOrDefaultAsync();
                    if (result2 != null)
                    {
                        urlRedirect = urlRedirect + "/Inspector/factories-list";
                        isAuthorizeUser = true;
                    }
                    else
                    {
                        //Admin Area

                    }
                }

                if (isAuthorizeUser == false)
                {
                    return RedirectToAction("redirectoUrl", new { url = urlRedirect + urlError + "?errorM=2" });
                    //return Redirect(urlRedirect + urlError + "?errorM=2");
                }

                //create Token
                var tokenResult = "";
                if (nationalId != null)
                {


                    var authClaims = new List<Claim>
            {

                  new Claim(ClaimTypes.NameIdentifier,userId!=null?userId:""),
                  new Claim("national_id",nationalId!=null?nationalId:""),
                  new Claim("arabic_name",arabicName!=null?arabicName:""),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    var token = GetToken(authClaims);
                    tokenResult = new JwtSecurityTokenHandler().WriteToken(token);

                }
                string urlWithToken = $"{urlRedirect}?token={tokenResult}";

                return RedirectToAction("redirectoUrl", new { url = urlWithToken });

                //return Redirect(urlWithToken);
            }catch(Exception e)
            {
                return RedirectToAction("redirectoUrl", new { url = urlRedirect + urlError + "?errorM=1" });

            }

        }

        protected JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var date = TimeSpan.FromTicks(DateTime.Now.Ticks);

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("SecretKey")));
            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                expires: DateTime.Now.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;

        }

        [HttpGet("loginbynafathData")]
        public async Task<IActionResult> loginbynafath()
        {
            LoginDataRequest result=new LoginDataRequest();
            var ServiceKey = configuration.GetValue<string>("ServiceKey");
            var ServiceIV = configuration.GetValue<string>("ServiceIV");
            var SigningKey = configuration.GetValue<string>("ServicePK");
            var SigningUuid = configuration.GetValue<string>("ServiceUuid");

            byte[] key = Convert.FromBase64String(ServiceKey);
            byte[] iv = Convert.FromBase64String(ServiceIV);
            byte[] SigningKeybyte = Convert.FromBase64String(SigningKey);

            string privateKey = DecryptStringFromBytes_Aes(SigningKeybyte, key, iv);

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string serviceToken = GenerateRandomString(16) + timestamp;
            string serviceSignature = GenerateHmacSha256(serviceToken, privateKey);
           
            result.token = serviceToken;
            result.signature = serviceSignature;
            result.uuid = SigningUuid;
            return Ok(new BaseResponse<LoginDataRequest>
            {
                Data = result,
            });



        }
        private string GenerateRandomString(int length)
        {
            const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int numberOfChars = AllowedChars.Length;

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                char[] randomChars = new char[length];
                for (int i = 0; i < length; i++)
                {
                    randomChars[i] = AllowedChars[randomBytes[i] % numberOfChars];
                }

                return new string(randomChars);
            }


        }
         private string GenerateHmacSha256(string message, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmacsha256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private  byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}
