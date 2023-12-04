
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using StarTech.Application.Command;
using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Application.Interface.ServiceInterface.Security;
using StarTech.Application.Services.HR;
using StarTech.Application.Services.Payroll;
using StarTech.Application.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.DependencyInjection;

public static class ServiceRegister
{
    [Obsolete]
    public static void AddApplicationService(this IServiceCollection services) =>

         services.AddScoped<IEmployeeService, EmployeeService>()
                 .AddScoped<ISecurityService, SecurityService>()
                 .AddScoped<ILeaveService, LeaveService>()
                 .AddScoped<IBasicEntryService, BasicEntryService>()
                 .AddScoped<ISalaryService, SalaryService>()
                 .AddScoped<IAttendanceService, AttendanceService>()

                 .AddMediatR(typeof(SystemLoginCommand).Assembly)
                 .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<SystemLoginCommand>()) ;
}

