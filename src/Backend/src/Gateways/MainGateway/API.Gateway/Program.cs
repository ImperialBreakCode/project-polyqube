using API.Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGatewayPresentationLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("https://localhost:7210/swagger/v1/swagger.json", "Account endpoints");
    });
}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.UseExceptionHandler();

app.MapReverseProxy();

app.Run();
