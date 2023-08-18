using Jashter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

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

await builder.Build().RunAsync();
