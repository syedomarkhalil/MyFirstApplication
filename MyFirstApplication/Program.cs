using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using MyFirstApplication.Infrastructure;
using MyFirstApplication.Models;
using MyFirstApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

// read the appsettings here, see the use of nameof operator
var appSettingsSection = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = appSettingsSection.Get<AppSettings>()!;

// configure the TvShowHttpClient, with the BaseUri from appSettings.
services.AddHttpClient<TvShowHttpClient>(client =>
{
    client.BaseAddress = new Uri(appSettings.BaseUri!);
});

services.AddHttpClient();
services.AddControllersWithViews();

services.AddAuthentication(google =>
    {
        google.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        google.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
    })
    .AddGoogle(google =>
    {
        google.ClientId = appSettings.GoogleAuthSettings?.ClientId!;
        google.ClientSecret = appSettings.GoogleAuthSettings?.ClientSecret!;
    });

services.AddScoped<ITvShowService, TvShowService>();

services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
services.AddOptions();

var app = builder.Build();

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

app.Run();