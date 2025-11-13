using ASPNETCore_DesignPatterns.Configuration;
using Utilities.DesignPatterns.FactoryMethod_Profit;
using Utilities.DesignPatterns.FactoryMethod_Profit.Factories;

namespace ASPNETCore_DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // builder: facilita la configuracion inicial del proyecto
            // WebApplication permite crear una proyecto Web.
            // Permite: Configuracion, registros (loggings), Inyección de dependencias
            var builder = WebApplication.CreateBuilder(args);

            // CONFIGURACION (INYECCIÓN DE DEPENDENCIAS)
            // Esto permite inyectar la clase CustomConfiguration para que se pueda utilizar
            // en cualquier para del proyecto en este caso se va a utilizar en un Controller            
            builder.Services.Configure<CustomConfiguration>(builder.Configuration.GetSection("CustomConfiguration"));

            // Crear la clase: LocalProfitFactory
            builder.Services.AddTransient((factory) =>
            {
                //return new LocalProfitFactory(0.74m);
                return new LocalProfitFactory(0.70m);
            });

            // Crear la clase: LocalProfitFactory
            builder.Services.AddTransient((factory) =>
            {
                return new ForeignProfitFactory(0.7m, 0.16m);
            });

            // Permite agragar el soporte para utilizar MVC
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Crea el objeto de tipo: WebApplication para el proyecto Web
            var app = builder.Build();

            // verifica si la aplicación esta en modo desarrollo
            // utilizar los componentes para ejecutar el proyecto
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // utilizar los midleware
            // Redirije automaticamente todas las solucitides HTTP o HTTPS
            app.UseHttpsRedirection();
            // Permite utilizar componentes estaticos
            app.UseStaticFiles();

            // Permite el uso de ruteo (navagacion entre paginas)
            app.UseRouting();
            
            // Permite la autorización en la tuberia de solicitudes de las paginas
            app.UseAuthorization();

            // Mapea loso diferentes controladores que responderan a las solicitudes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Ejecuta el proyecto
            app.Run();
        }
    }
}
