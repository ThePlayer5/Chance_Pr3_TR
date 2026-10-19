using ChancePr3TRBlazor;
using ChancePr3TRBlazor.ApiRequest;
using ChancePr3TRBlazor.ApiRequest.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7041/api") });

builder.Services.AddScoped<RequestApi>();

builder.Services.AddSingleton<UserService>();

builder.Services.AddScoped<ChatService>();

await builder.Build().RunAsync();
