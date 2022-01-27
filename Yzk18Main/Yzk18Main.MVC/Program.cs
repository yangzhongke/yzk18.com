using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using MudBlazor.Services;
using MVCCommonInitializer;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRenderingContext(true);
builder.Services.AddMudServices();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

//this HttpClient is for pre-rendering of Blazor WebAsm
builder.Services.AddScoped<HttpClient>(sp => {
    var server = sp.GetRequiredService<IServer>();
    var addressFeatures = server.Features.Get<IServerAddressesFeature>();
    string url = addressFeatures.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(url) }; 
});
builder.ConfigureDbConfiguration();
builder.ConfigureExtraServices(new InitializerOptions { EventBusQueueName="yzk18",LogFilePath="d:/yzk18.log"});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseZackDefault();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
