using Jashter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Jashter.Services.Interfaces;
using Jashter.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
#if DEBUG
string uri = "http://localhost:8080/api/";
#else
string uri = "https://www.sato-home.mydns.jp:8443/api/";
#endif
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(uri) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IJsonConvertService, JsonConvertService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticateionService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
