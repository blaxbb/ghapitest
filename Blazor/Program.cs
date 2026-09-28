using Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

try
{
  
  var a = 123;
  var c = 0;
  var b = 123 / c;
  Console.WriteLine(b);
}
catch (Exception ex)
{
  Console.WriteLine(ex.ToString());
  throw new Exception("Throwing a different exception is bad");
}



await builder.Build().RunAsync();
