using MyFirstApplication.Infrastructure;
using MyFirstApplication.Models;
using MyFirstApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

// read the appsettings here, see the use of nameof operator
var appSettingsSection = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = appSettingsSection.Get<AppSettings>()!;

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITvShowService, TvShowService>();

// configure the TvShowHttpClient, with the BaseUri from appSettings.
builder.Services.AddHttpClient<TvShowHttpClient>(client =>
{
    client.BaseAddress = new Uri(appSettings.BaseUri);
});

builder.Services.AddHttpClient();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
builder.Services.AddOptions();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();