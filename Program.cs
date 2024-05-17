using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ParcialUnoP_IV.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<ParcialUnoP_IVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParcialUnoP_IVContext")));

// Configurar servicios de autenticación basados en cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

// Agregar servicios de controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Redireccionar a /Auth/Login al iniciar la aplicación
app.Use(async (context, next) =>
{
    if (!context.User.Identity.IsAuthenticated && context.Request.Path != "/Auth/Login")
    {
        context.Response.Redirect("/Auth/Login");
        return;
    }

    await next();
});

// Configurar el enrutamiento de las rutas
app.MapControllerRoute(
    name: "auth",
    pattern: "Auth/{action}/{id?}",  // Rutas relacionadas con la autenticación
    defaults: new { controller = "Auth" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Ruta predeterminada

app.Run();
