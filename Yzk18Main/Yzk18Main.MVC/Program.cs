using MVCCommonInitializer;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Zack.JWT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
builder.ConfigureDbConfiguration();
builder.ConfigureExtraServices();
JWTOptions jwtOpt = builder.Configuration.GetSection("JWT").Get<JWTOptions>();

builder.Services.AddJWTAuthentication(jwtOpt);
//启用Swagger中的【Authorize】按钮。这样就不用每个项目的AddSwaggerGen中单独配置了
builder.Services.Configure<SwaggerGenOptions>(c =>
{
    c.AddAuthenticationHeader();
});
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
app.UseCors();//启用Cors
app.UseForwardedHeaders();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
