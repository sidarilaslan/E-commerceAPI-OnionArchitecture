using E_commerceAPI.Application;
using E_commerceAPI.Application.Middlewares.Exceptions;
using E_commerceAPI.Infrastructure;
using E_commerceAPI.Infrastructure.Filters;
using E_commerceAPI.Infrastructure.Services.Token;
using E_commerceAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

Serilog.Core.Logger log = new LoggerConfiguration()
      .MinimumLevel.Information()
      .WriteTo.Console()
      .WriteTo.File("c:\\temp\\log.txt", rollingInterval: RollingInterval.Day).Enrich.FromLogContext()
      .CreateLogger();

builder.Host.UseSerilog(log);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        AccessTokenOptions tokenOptions = builder.Configuration.GetSection("AccessTokenOptions").Get<AccessTokenOptions>();
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = tokenOptions.Audience,
            ValidIssuer = tokenOptions.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
            ClockSkew = TimeSpan.Zero,
        };
    });


builder.Services.AddControllers(options =>
{
    options.Filters.Add<RolePermissionFilter>();
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.User?.Identity?.IsAuthenticated == true)
    {
        string username = context.User.Identity.Name;
        string userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        LogContext.PushProperty("UserName", username);
        LogContext.PushProperty("UserId", userId);
    }
    await next();
});

app.MapControllers();

app.Run();
