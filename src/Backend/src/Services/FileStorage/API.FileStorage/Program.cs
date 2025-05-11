using API.FileStorage.Application.Extensions;
using API.FileStorage.Extensions;
using API.FileStorage.Infrastructure.Extensions;
using API.Shared.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.AddLogging();
builder.ConfigureTelemetryLogging();

builder.Services
    .AddFilesPresentationLayer(builder.Configuration)
    .AddFilesApplicationLayer(builder.Configuration)
    .AddFilesInfrastructureLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
