using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Interface.RepositoryInterface.Security;
using StarTech.Application.Interface.ServiceInterface.Security;
using StarTech.Model.Security;
using StarTech.Model.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _repository;
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public SecurityService(ISecurityRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecuritySettings:JwtSettings:key"]));
        }
      
        public async Task<TokenResponseDto> Login(UserLoginDTO model)
        {
           var token=await _repository.Login(model);

            if (token == null) throw new NotImplementedException("username or password is invalid");

            double tokenExpiryTime = double.Parse(_config["SecuritySettings:JwtSettings:tokenExpirationInMinutes"]);
            var key = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecuritySettings:JwtSettings:key"])), SecurityAlgorithms.HmacSha512Signature);
            var expire = DateTime.Now.AddMinutes(tokenExpiryTime);
            var tokenHandler = new JwtSecurityTokenHandler();
            Claim[] claims = {
                    new Claim("UserName", token.UserName.ToString()),
                    new Claim("LoginID", token.LoginID.ToString()),
                    new Claim("LoginPassword", token.LoginPassword),
                    new Claim("EmpCode", token.EmpCode.ToString()),
                    new Claim("CompanyID", token.CompanyID.ToString()),
                    new Claim("CompanyName", token.CompanyName?.ToString()),
                    new Claim("IsActive", token.IsActive.ToString()),
                    new Claim("IsActive", token.IsActive.ToString()),
                    };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = key,
                Expires = DateTime.Now.AddMinutes(tokenExpiryTime)
            };

            var newtoken = tokenHandler.CreateToken(tokenDescriptor);

            var encodedToken = tokenHandler.WriteToken(newtoken);
            token.Token = encodedToken;
            return token;
        }

        public async Task<bool> ChangePassword(ChangePasswordModel ent)=>await _repository.ChangePassword(ent);
    }
}
