
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Application.Interface.RepositoryInterface.Security;
using StarTech.BLL.Repository.HR;
using StarTech.BLL.Repository.Payroll;
using StarTech.BLL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarTech.BLL.DependancyInjection;
public static class RepositoriesRegister
{
    public static void AddRepositoryServices(this IServiceCollection services) =>
        services.AddSingleton<DapperContext>()
        .AddScoped<IEmployeeRepository, EmployeeRepository>()
        .AddScoped<ISecurityRepository, SecurityRepository>()
        .AddScoped<ILeaveRepository, LeaveRepository>()
        .AddScoped<IBasicEntryRepository, BasicEntryRepository>()
        .AddScoped<ISalaryRepository, SalaryRepository>()
        .AddScoped<IAttendanceRepository, AttendanceRepository>()
        ;
       
        
}


