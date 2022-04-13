using Blazor_Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//load the component in html element with 'id' as 'App'
// wwwroot/index.html <div id="app">
builder.RootComponents.Add<App>("#app");
// headOutlet is a standard component that will
// added after html page header
builder.RootComponents.Add<HeadOutlet>("head::after");

//the http client class is registered into th DI container
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Run the applicaiton Asynchronously
await builder.Build().RunAsync();
