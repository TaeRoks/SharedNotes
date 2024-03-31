using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SharedNotes.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<INoteService, ClientNoteService > ();

await builder.Build().RunAsync();
