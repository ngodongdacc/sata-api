using Microsoft.EntityFrameworkCore;
using SATO.Application.Interfaces;
using SATO.Application.Services;
using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using SATO.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddSingleton(configuration);
builder.Services.AddDbContext<SatoDbContext>(dbContextOptions =>
            dbContextOptions.UseMySql(configuration.GetConnectionString("ConnectionDefault"),
               new MySqlServerVersion(new Version(5, 7, 0))));

//Config map Interface with Service

builder.Services.AddScoped<IUnitOfWork<SatoDbContext>, UnitOfWork<SatoDbContext>>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITempRepository, TempRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
//Config map Automapper Library
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: "SuperHeroOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("SuperHeroOrigins");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
