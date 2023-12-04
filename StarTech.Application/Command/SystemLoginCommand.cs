using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using StarTech.Application.Interface.ServiceInterface.Security;
using StarTech.Model.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Command;

public class SystemLoginCommand : UserLoginDTO, IRequest<TokenResponseDto>
{
    public class Handler : IRequestHandler<SystemLoginCommand, TokenResponseDto>
    {
        private readonly ISecurityService _service;
        public Handler(ISecurityService service)
        {
            _service = service;
        }

        public async Task<TokenResponseDto> Handle(SystemLoginCommand command, CancellationToken cancellationToken)
        {
            var token = await _service.Login(command);
            return token;

        }
    }
}