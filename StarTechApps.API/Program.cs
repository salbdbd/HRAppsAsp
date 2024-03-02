using MediatR;
using Microsoft.OpenApi.Models;
using StarTech.Application.Common.Mailing;
using StarTech.Application.DependencyInjection;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.BLL.Common;
using StarTech.BLL.DBConfiguration;
using StarTech.BLL.DependancyInjection;
using StarTech.BLL.Repository.Payroll;
using StarTechApps.API.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddConfigurations();
//Database Connection Configure For Dapper.
var conStr = new ConnectionString
{
    Server = builder.Configuration["DatabaseSettings:ConnectionString"]

};
//Connection.Initialize(conStr);
//var emailConfig = builder.Configuration
//        .GetSection("MailSettings")
//        .Get<MailSettings>();
//builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<ISalaryRepository, SalaryRepository>();
builder.Services.AddApplicationService();// Dependency Injection For Service Interfaces
builder.Services.AddAuthService(builder.Configuration);// For JWT Token
builder.Services.AddRepositoryServices();//For Repository Interface
builder.Services.AddApiVersioningExtension();//Versioning
builder.Services.ConfigureCors(); //Cors Policy
builder.Services.ConfigureIISIntegration();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Daily Star", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{}
    }
    });

});
builder.Services.Configure<IISOptions>(options =>
{
    options.AutomaticAuthentication = false;
});

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  //  c.EnableFilter();
    c.DisplayRequestDuration();
    //c.IndexStream = () => GetType().Assembly.GetManifestResourceStream("CustomUIIndex.Swagger.index.html");
    c.InjectStylesheet("/swagger-ui/custom.css");
    //c.InjectStylesheet(typeof(SwaggerConfig).Assembly,
    //  "ProjectName.FolderName.SwaggerHeader.css"));
});
app.UseCors("!starTech");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
