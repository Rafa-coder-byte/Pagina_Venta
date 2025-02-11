using CapaDatos.Repositorios;
using CapaNegocio;
using ContractsDatos;

namespace CapaPresentacionAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Configuración de autenticación
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cookies";
                options.DefaultChallengeScheme = "Cookies";
            })
            .AddCookie("Cookies", options =>
            {
                options.LoginPath = "/Home/Login";
                options.LogoutPath = "/Home/Logout";
            });
            // En Program.cs
            builder.Services.AddScoped<IConnectionFactory, Conexion>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); // O AddScoped, AddSingleton según tu necesidad
            builder.Services.AddTransient<CN_Usuarios>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            // Uso de CORS
            app.UseCors("AllowAll");

            // Uso de autenticación
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
