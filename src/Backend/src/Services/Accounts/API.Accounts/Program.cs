using API.Accounts.Application.Extensions;
using API.Accounts.Extensions;
using API.Accounts.Infrastructure.Extensions;
using API.Shared.Common.Constants;
using API.Shared.Web.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAccountsInfrastructure(builder.Configuration)
    .AddAccountsApplicationLayer()
    .AddAccountsPresentationLayer(builder.Configuration);

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
        options.Title = "API.Accounts Docs";
        options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
        options.Theme = ScalarTheme.Purple;
        //options.CustomCss = ScalarCSSThemes.CustomTheme;
    });
}

//app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
