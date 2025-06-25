namespace DesignPatterns.DependencyInjection
{
  public class Store
  {
    // Dependencia
    private Client _client;

    public Store(Client client)
    {
      _client = client;
    }
    public void WelcomeClient()
    {
      //_client = new Client("John", "Doe");
      Console.WriteLine($"Bienvenido a la tienda, {_client.Name}!");
    }
  }
}
