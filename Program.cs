using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.WingsMarketContext;

using WingsMarket.Services.DragonService;
using WingsMarket.Services.CustomerService;
using WingsMarket.Services.PurchaseService;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration
    .GetConnectionString("ConnectionString") ?? throw new ArgumentException("Hasnt connection string");


builder.Services.AddDbContext<WingsMarketContext>((options) => {
    options.UseNpgsql( connectionString);
});

builder.Services.AddTransient<DragonService>();//Servicio de dragones
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<PurchaseService>();

builder.Logging.ClearProviders();//Elimina todos los proveedores de logging existentes.
builder.Logging.AddConsole(); // Agrega el proveedor de logging para que los mensajes de log se muestren en la consola.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}

// app.UseHttpsRedirection(); //redireccion a HTTPS en ve de HTTP
app.UseSwagger();
app.UseSwaggerUI( c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Wings Market Swagger"));

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dragon}/{action=Index}/{id?}");

app.MapGet("/", 
            () => Results.Ok());

app.Run();

