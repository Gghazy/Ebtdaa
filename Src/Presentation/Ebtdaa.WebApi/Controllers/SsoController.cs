using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Application.Sso.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Runtime.InteropServices;
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
        private readonly IHttpClientFactory _httpClientFactory ;
        public SsoController(IConfiguration configurations, 
            IEbtdaaDbContext dbContext
            ,
             IHttpClientFactory  httpClientFactory)
        {
            _dbContext = dbContext;
            configuration = configurations;
            _httpClientFactory = httpClientFactory;


        }

        [HttpPost]
        public async Task getNationalID()
        {
            var r =  User.Claims.ToList();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string nationalId = User.FindFirst("nationalId")?.Value;
            string arabicName = User.FindFirst("arabicName")?.Value;
            string englishName = User.FindFirst("englishName")?.Value;

            
            var result =
                await _dbContext.Factories
               .Include(x => x.FactoryLocations)
               .ThenInclude(x => x.City)
               .Where(r=>r.OwnerIdentity== nationalId)
               .FirstOrDefaultAsync();
            var tokenResult = "";
            if (nationalId != null)
            {
                var authClaims = new List<Claim>
            {

                  new Claim(ClaimTypes.NameIdentifier,userId!=null?userId:""),
                  new Claim("nationalId",nationalId!=null?nationalId:""),
                  new Claim("arabicName",arabicName!=null?arabicName:""),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);
                 tokenResult = new JwtSecurityTokenHandler().WriteToken(token);

            }
            var url = "https://preprod.partners.mim.gov.sa/#/pages/factories-list"; //
            string urlWithToken = $"{url}?token={tokenResult}";

            var Loginurl = "https://preprod.partners.mim.gov.sa/#/Login"; //
            //string urlWithToken = $"{url}?token={tokenResult}";

            if (result==null)
                 Process.Start(new ProcessStartInfo(Loginurl) { UseShellExecute = true });
               else
                 Process.Start(new ProcessStartInfo(urlWithToken) { 
                     UseShellExecute = true }
                 );


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

        [HttpGet]
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


           // string base64String = Convert.ToBase64String(key);
          
           
           //  var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
           // string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string serviceToken = GenerateRandomString(16) + timestamp;
; 
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
