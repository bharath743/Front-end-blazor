using FrondEnd.Shared.Utils;
using FrontEnd.BlazorWasm;
using FrontEnd.BlazorWasm.Services;
using FrontEnd.BlazorWasm.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseUrls.BASE_URL) });

//Adding telerik to the IoC container
builder.Services.AddTelerikBlazor();

//adding our services to the IoC container.
builder.Services.AddTransient<IServerService, ServerService>();
builder.Services.AddTransient<IPdfExportationService, PdfExportationService>();

await builder.Build().RunAsync();
