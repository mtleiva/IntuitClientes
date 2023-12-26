using IntuitClientes.Repositories.Interfaces;
using IntuitClientes.Repositories.Repositories;
using IntuitClientes.Services.Interfaces;
using IntuitClientes.Services.Services;
using IntuitClientes.CrossCutting.Logging;
using NLog.Web;
using IntuitClientes.CrossCutting.Mapper;
using Microsoft.EntityFrameworkCore;
using IntuitClientes.Domain.Context;
using NLog;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Host.UseNLog();
builder.Services.AddSingleton<ILog, NLogger>();
builder.Services.AddSingleton<ILoggingManager, NLogger>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

try
{

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Program has stopped because there was an exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}