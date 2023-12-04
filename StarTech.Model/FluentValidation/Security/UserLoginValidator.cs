using FluentValidation;
using StarTech.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.FluentValidation.Security
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
           // RuleFor(x => x.UserName).NotNull().NotEmpty().Length(2, 50);
            RuleFor(x => x.UserName).NotNull().NotEmpty().Length(2, 50).Must(a=>a?.ToLower().Contains("ss")==true);
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("......pass");
            ;
        }

    }
}
