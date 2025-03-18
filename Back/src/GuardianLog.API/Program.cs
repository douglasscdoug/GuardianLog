using System.Text.Json.Serialization;
using GuardianLog.Application;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Helpers;
using GuardianLog.Repo;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(GuardianLogProfile));

builder.Services.AddScoped<IGeralRepository, GeralRepository>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.MaxDepth = 64;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
