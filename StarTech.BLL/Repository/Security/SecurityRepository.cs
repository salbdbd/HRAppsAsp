
using Microsoft.Data.SqlClient;
using StarTech.Application.Interface.RepositoryInterface.Security;
using StarTech.Model.Attendance;
using StarTech.Model.Security;
using StarTech.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Security
{
    public class SecurityRepository : ISecurityRepository
    {
        public async Task<TokenResponseDto> Login(UserLoginDTO model)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var user = con.Query<TokenResponseDto>("usp_UserLogin",
                        param: new 
                        { 
                            UserName = model.UserName, 
                            Password = model.Password 
                        },

                  commandType: CommandType.StoredProcedure  ).FirstOrDefault();
                  return user;
            }
        }

        public async Task<bool> ChangePassword(ChangePasswordModel ent)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                var leaveEntryObj = new
                {
                    ent.UserID,
                    ent.OldPassword,
                    ent.NewPassword,
                    ent.CompanyID
                };
                int rowaffect = con.Execute("Usp_Aps_ChangePassword", param: leaveEntryObj, commandType: CommandType.StoredProcedure);
                return rowaffect > 0;
            }
        }

    }
}
