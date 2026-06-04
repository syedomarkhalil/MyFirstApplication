using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Helpers;
using TvFlixApp.Application.Models;
using TvFlixApp.Infrastructure;
using TvFlixApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
var services = builder.Services;

// read the appsettings here, see the use of nameof operator
var appSettingsSection = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = appSettingsSection.Get<AppSettings>()!;

// configure the TvShowHttpClient, with the BaseUri from appSettings.
services.AddHttpClient<ITvShowServiceClient, TvShowHttpClient>(client =>
{
    client.BaseAddress = new Uri(appSettings.BaseUri!);
});

services.AddControllersWithViews();

services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
    })
    .AddGoogleOpenIdConnect(GoogleDefaults.AuthenticationScheme, googleOptions =>
    {
        googleOptions.Authority = "https://accounts.google.com";
        googleOptions.ClientId = appSettings.AuthenticationSettings?.Google?.ClientId!;
        googleOptions.ClientSecret = appSettings.AuthenticationSettings?.Google?.ClientSecret!;
        googleOptions.ResponseType = OpenIdConnectResponseType.IdToken;
        googleOptions.SaveTokens = true;
        googleOptions.Scope.Add("openid");
        googleOptions.Scope.Add("profile");
        googleOptions.Scope.Add("email");
        googleOptions.CallbackPath = "/signin-google"; // Default callback path
        googleOptions.SignedOutCallbackPath = "/google/logout";
        googleOptions.GetClaimsFromUserInfoEndpoint = true;
        googleOptions.ClaimActions.MapUniqueJsonKey(ClaimTypes.Name, "given_name");
    })
    .AddFacebook(facebook =>
    {
        facebook.AppId = appSettings.AuthenticationSettings?.Facebook?.AppId!;
        facebook.AppSecret = appSettings.AuthenticationSettings?.Facebook?.AppSecret!;
    })
    .AddTwitter(twitter =>
    {
        twitter.ConsumerKey = appSettings.AuthenticationSettings?.Twitter?.ClientId!;
        twitter.ConsumerSecret = appSettings?.AuthenticationSettings?.Twitter?.ClientSecret!;
    });

services.AddScoped<ITvShowService, TvShowService>();
services.AddScoped<IJwtTokenService, JwtTokenService>();
services.AddHttpContextAccessor();

services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
services.AddOptions();

var app = builder.Build();

app.MapDefaultEndpoints();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{pageNumber?}");

await app.RunAsync();