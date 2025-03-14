using API.Accounts.Application.Extensions;
using API.Accounts.Extensions;
using API.Accounts.Infrastructure.Extensions;
using API.Shared.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAccountsInfrastructure(builder.Configuration)
    .AddAccountsApplicationLayer()
    .AddAccountsPresentationLayer();

var app = builder.Build();

await app.SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
