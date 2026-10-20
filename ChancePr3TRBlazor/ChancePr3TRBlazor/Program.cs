using ChancePr3TRBlazor;
using ChancePr3TRBlazor.ApiRequest;
using ChancePr3TRBlazor.ApiRequest.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7041/") });

builder.Services.AddScoped<RequestApi>();

builder.Services.AddSingleton<UserService>();

builder.Services.AddScoped<ChatService>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
