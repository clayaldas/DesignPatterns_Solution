using DesignPatterns.Utilities.FactoryMethod_Profit.Factories;
using DesignPatterns_ASPNETCore.Configuration;

namespace DesignPatterns_ASPNETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // *************************************************************
            // Inyección de Dependencias
            // *************************************************************

            // Esto permite inyectar la clase "CustomConfiguration" en Container para esta pueda 
            // ser utilizada por cualquier "Controller".
            builder.Services.Configure<CustomConfiguration>(builder.Configuration.GetSection("CustomConfiguration"));

            // Injectar la clase: LocalProfitFactory
            builder.Services.AddTransient(
                (factory) =>
                {
                    return  new LocalProfitFactory(0.3m);
                }
                );

            // Injectar la clase: ForeignProfitFactory
            builder.Services.AddTransient(
                (factory) =>
                {
                    return new ForeignProfitFactory(0.3m, 0.16m);
                }
                );


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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
