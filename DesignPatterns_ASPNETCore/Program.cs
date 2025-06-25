using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatterns.Utilities.FactoryMethod_Profit.Factories;
using DesignPatterns_ASPNETCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns_ASPNETCore
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Esto permite inyectar la clase "CustomConfiguration" en Container para esta pueda
      // ser utilizada por cualquier "Controller".
      builder.Services.Configure<CustomConfiguration>(
          builder.Configuration.GetSection("CustomConfiguration")
      );

      // Inyectamos la clase: LocalProfitFactory
      builder.Services.AddTransient(
          (factory) =>
          {
            return new LocalProfitFactory(0.7m);
          }
      );

      // Inyectamos la clase: ForeignProfitFactory
      builder.Services.AddTransient(
          (factory) =>
          {
            return new ForeignProfitFactory(0.7m, 0.18m);
          }
      );

      // Obtener el contexto de la base de datos.
      // Inyectamos el contexto de la base de datos: SalesContext
      builder.Services.AddDbContext<SalesContext>(
          options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
      );


      // Inyectamos la clase: Factory 
      // AddScoped: lo que se inyecte con "Scoped" en el mismo controlador este va utilizar la misma instancia
      //            no importa que se instancie varias veces.
      // AddTransient: lo que se inyecte con "Transient" si se hace referencia al objeto varias veces en el
      //            mismo controlador se va utilizar una nueva instancia para cada referencia.
      // AddSingleton: lo que se inyecte con "Singleton" va utilizar la misma instancia para todos los controladores.     
      // Utilizammos AddScoped para que se utilice el mismo objeto para toda la solicitud HTTP.
      builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

      // Nuevo código.
      builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
          pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}
