using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.LogIn.Dtos;
using Ebtdaa.Application.LogIn.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Common.Consts;
using Ebtdaa.Application.Factories.Dtos;

namespace Ebtdaa.Application.LogIn.Handllers
{
    public class LoginService : ILoginService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public LoginService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<FactoryResualtDto> Factories;
        //public async Task<BaseResponse<List<FactoryResualtDto>>> OnGet()
        //{

        //    var setting = _dbContext.Settings.FirstOrDefault(s => s.Name == Const.Enviroment);
        //    if (setting == null)
        //    {
        //       Console.Write("Setting null");
        //    }
        //    else
        //    {
        //        Console.Write(setting.Value);
        //    }
        //    if (setting != null && setting.Value == Const.TestEnviroment)
        //    {
                
        //        var nationalIDCliam = _context.User.Claims.FirstOrDefault(c => c.Type == Const.NationalIDClaimName);
        //        try
        //        {

        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        if (nationalIDCliam == null)
        //        {
        //            var claims = new List<Claim>
        //            {
        //                new Claim(Const.UserNameClaimName, Const.TestCustomerName),
        //                new Claim(Const.NationalIDClaimName, Const.NationalID+ "")
        //            };

        //            var claimsIdentity = new ClaimsIdentity(
        //                claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //            var authProperties = new AuthenticationProperties
        //            {

        //            };

        //            await _context.SignInAsync(
        //                CookieAuthenticationDefaults.AuthenticationScheme,
        //                new ClaimsPrincipal(claimsIdentity),
        //                authProperties);
                    
        //                var getCRs = await GetAll(Const.NationalID.ToString());
        //                Factories = getCRs.Data;  
        //        }
        //        else
        //        {
        //            nationalIDCliam = _context.User.Claims.FirstOrDefault(c => c.Type == Const.NationalIDClaimName);
        //            //var customerName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == Const.UserNameClaimName);            
        //            var getCRs = await GetAll(nationalIDCliam.Value);
        //            Factories = getCRs.Data;    
        //        }
        //    }
        //     else
        //     {
        //        var nationalIDCliam = _context.User.Claims.FirstOrDefault(c => c.Type == Const.NationalIDClaimName);
        //        if (nationalIDCliam == null)
        //        {
        //            _context.Response.Redirect("https://ebtda.sa/", true);
        //            _context.Request.HttpContext.Response.Redirect("https://ebtda.sa/", true);
        //            //return Redirect("https://ebtda.sa/");
        //        }
        //        else
        //        {
        //            var nationalIDTemp = nationalIDCliam.Value;
        //            var userNameCliam = _context.User.Claims.FirstOrDefault(c => c.Type == Const.UserNameClaimName);
        //            //TempData[Const.TopBarDataTempName] = "مرحبا :" + userNameCliam.Value;
        //            try
        //            {
        //                var customerName = _context.User.Claims.FirstOrDefault(c => c.Type == Const.UserNameClaimName);
        //                var getCRs = await GetAll(nationalIDTemp);

        //                Factories = getCRs.Data;                      
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //        }
        //     }
        //    return new BaseResponse<List<FactoryResualtDto>>
        //    {
        //        Data = Factories
        //    };
        //}
        public async Task<BaseResponse<List<FactoryResualtDto>>> GetAll(string ownerIdentity)
        {
            var respose = _mapper.Map<List<FactoryResualtDto>>(await _dbContext.Factories.Where(f => f.OwnerIdentity == ownerIdentity).ToListAsync());

            return new BaseResponse<List<FactoryResualtDto>>
            {
                Data = respose
            };
        }
    }
}
