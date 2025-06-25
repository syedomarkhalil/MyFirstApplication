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

var googleAuthSection = builder.Configuration.GetSection("Authentication:Google");
var googleClientId = googleAuthSection["ClientId"];
var googleClientSecret = googleAuthSection["ClientSecret"];

services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = googleClientId!;
        options.ClientSecret = googleClientSecret!;
    });

//services.AddAuthentication()
//        .AddGoogle(google =>
//        {
//            google.ClientId = "877899375263-m4io06muost8fv7l6k68lugkcr58eicc.apps.googleusercontent.com";
//            google.ClientSecret = "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";
//        });

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