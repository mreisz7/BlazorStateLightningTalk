var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// AppState - DI
builder.Services.AddScoped<AppStateDependencyInjection>();

// AppState - Cascading Value
builder.Services.AddCascadingValue<AppStateCascadingValue>(_ => new AppStateCascadingValue());

await builder.Build().RunAsync();