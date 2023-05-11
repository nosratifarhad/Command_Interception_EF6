using CommandInterceptionWebApplication.Domain;
using CommandInterceptionWebApplication.Services;
using CommandInterceptionWebApplication.Services.Contracts;
using CommandInterceptionWebApplication.Infra.Repositories.WriteRepositories.ProductWriteRepositories;
using CommandInterceptionWebApplication.Infra.Repositories.ReadRepositories.ProductReadRepositories;
using CommandInterceptionWebApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using CommandInterceptionWebApplication.Infra.Interceptors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();

#endregion Dependency Injection

#region Add DbContext

//builder.Services.AddSingleton<EFConnectionInterceptor>();
builder.Services.AddSingleton<EFTransactionInterceptor>();

builder.Services.AddDbContext<DefaultDbContext>((provider, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.AddInterceptors(provider.GetRequiredService<EFTransactionInterceptor>());
});

#endregion Add DbContext

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
