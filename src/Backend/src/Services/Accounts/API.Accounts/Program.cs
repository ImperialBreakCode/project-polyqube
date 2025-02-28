using API.Accounts.Application.Extensions;
using API.Accounts.Infrastructure.Extensions;
using API.Shared.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAccountsInfrastructure(builder.Configuration)
    .AddAccountsApplicationLayer()
    .ConfigureWebServices();

var app = builder.Build();

app.SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
