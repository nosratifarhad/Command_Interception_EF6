using Microsoft.Extensions.Configuration;
using System.Runtime;
using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Helpers;
using CommandInterceptionWebApplication.Services;
using CommandInterceptionWebApplication.Services.Contracts;
using CommandInterceptionWebApplication.Infra.Repositorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DIC

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();

#endregion DIC

#region Add Redis Option 


#endregion Add Redis Option 

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
