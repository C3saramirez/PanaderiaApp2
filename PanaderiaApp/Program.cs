using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;
using PanaderiaApp.Client.Pages;
using PanaderiaApp.Components;
using PanaderiaApp.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PanaderiaDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepositorioProveedores, RepositorioProveedores>();
builder.Services.AddScoped<IRepositorioInsumos, RepositorioInsumos>();
builder.Services.AddScoped<IRepositorioProductos, RepositorioProductos>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PanaderiaApp.Client._Imports).Assembly);

app.Run();
