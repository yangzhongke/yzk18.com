using MVCCommonInitializer;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
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
app.UseStaticFiles();
//app.UseEventBus();
app.UseCors();//∆Ù”√Cors
app.UseForwardedHeaders();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
