// Program.cs
using ECommerceServer.Components; // Ajusta el namespace
using ECommerceServer.Services;   // Ajusta el namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Asegúrate de tener esto para habilitar @rendermode InteractiveServer

// Registra el servicio de estado de autenticación simulado
builder.Services.AddScoped<SimulatedAuthStateService>(); // Scoped es una buena opción para Blazor Server

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Esto aplica el modo a <App> y sus hijos si no tienen uno específico

app.Run();