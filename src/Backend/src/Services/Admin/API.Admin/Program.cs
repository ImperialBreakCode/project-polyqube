using API.Admin.Application.Extensions;
using API.Admin.Extensions;
using API.Admin.Infrastructure.Extensions;
using API.Shared.Web.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddLogging();
builder.ConfigureTelemetryLogging();

builder.Services
    .AddAdminPresentationLayer(builder.Configuration)
    .AddAdminInfrastructure(builder.Configuration)
    .AddAdminApplicationLayer();

var app = builder.Build();

await app.SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandlers();

app.Run();
