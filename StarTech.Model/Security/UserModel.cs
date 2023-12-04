using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Security
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginID { get; set; }
        public string LoginPassword { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string EmpCode { get; set; }
        public string IsActive { get; set; }
        public int ClientId { get; set; }
        public string ModifierName { get; set; }
        public string Token { get; set; }
    }
}
