using StarTech.Model.Security;
using StarTech.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarTech.Application.Interface.ServiceInterface.Security
{
    public interface ISecurityService
    {
        Task<TokenResponseDto> Login(UserLoginDTO model);
        Task<bool> ChangePassword(ChangePasswordModel ent);
    }
}
