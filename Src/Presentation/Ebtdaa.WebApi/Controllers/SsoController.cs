using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Application.Sso.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public SsoController(IConfiguration configurations, IEbtdaaDbContext dbContext)
        {
            _dbContext = dbContext;
            configuration = configurations;

        }

        [HttpPost]
        public async Task<IActionResult> getNationalID([FromBody] ssoData data)
        {
            string? NationalID = data.NationalID;
            var Name = data.Name;
            var result=
                await _dbContext.Factories
               .Include(x => x.FactoryLocations)
               .ThenInclude(x => x.City)
               .Where(r=>r.OwnerIdentity==NationalID)
               .FirstOrDefaultAsync();
            if(result==null)
                return Redirect("https://preprod.partners.mim.gov.sa/#/Login");
            else
                return Redirect("https://preprod.partners.mim.gov.sa");


            //return Ok("nafath callback Result nationalID=" + data.NationalID + "    Name=" + data.Name);
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
