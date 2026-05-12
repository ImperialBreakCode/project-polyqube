using API.Chats.Application.Extensions;
using API.Chats.Extensions;
using API.Chats.Feature.Chats.Hubs;
using API.Chats.Infrastructure.Extensions;
using API.Shared.Common.Constants;
using API.Shared.Web.Extensions;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.AddLogging();
builder.ConfigureTelemetryLogging();

builder.Services
    .AddChatsPresentationLayer(builder.Configuration)
    .AddChatsApplicationLayer(builder.Configuration)
    .AddChatsInfrastructure(builder.Configuration);

var app = builder.Build();

await app.SeedDatabase();

app.UseCors(CorsPolicies.CorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    app.UseSwaggerUI();

    app.MapScalarApiReference(options =>
    {
        options.Title = "API.Chats Docs";
        options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
        options.Theme = ScalarTheme.Purple;
        //options.CustomCss = ScalarCSSThemes.CustomTheme;
    });
}

//app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/api/v1/hubs/chat");

app.UseExceptionHandlers();

app.Run();
