using API.Gateway.Extensions;
using API.Shared.Web.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddLogging();
builder.ConfigureTelemetryLogging();
builder.Services.AddGatewayPresentationLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("http://localhost:8080/openapi/v1.json", "Account endpoints");
    });
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseSerilogRequestLogging();

app.UseExceptionHandlers();

app.MapReverseProxy();

app.UseRateLimiter();

app.Run();
