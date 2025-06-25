using DesignPatterns.Utilities.FactoryMethod_Profit.Products;

namespace DesignPatterns.Utilities.FactoryMethod_Profit.Factories
{
  public class LocalProfitFactory : ProfitFactory
  {
    // El objeto que se va a crear con esta fábrica tiene una dependencia, es decir tiene un atributo.
    // esto es el porcentaje de ganancia local y lo vamos administrar en el constructor.
    // este atributo es privado y solo se puede suministrar desde una clase externa como el método main.
    // para que la clase fábrica pueda crear el objeto y ya lo tengo por defecto.
    private readonly decimal _percentage;

    // Constructor de la clase LocalProfitFactory, que recibe un porcentaje de ganancia local.
    // Este constructor inicializa el atributo privado _percentage con el valor recibido.
    public LocalProfitFactory(decimal percentage)
    {
      _percentage = percentage;
    }

    // Factory Method: este método es el que se encarga de crear el objeto que se va a devolver.
    // este método es el que se va a sobreescribir en la clase hija.
    // Este método devuelve un objeto de tipo IProfit, que es la interfaz que implementa el producto.
    // En este caso, se crea un objeto de tipo LocalProfit, que es una implementación de IProfit.
    // El constructor de LocalProfit recibe el porcentaje de ganancia local que se pasó al constructor de la fábrica.
    // Este método es el que se va a llamar desde el cliente para crear el objeto.
    // El método GetProfit es el que se encarga de crear el objeto LocalProfit y devolverlo.
    public override IProfit GetProfit()
    {
      return new LocalProfit(_percentage);
    }
  }
}
