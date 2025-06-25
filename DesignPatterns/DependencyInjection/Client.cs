namespace DesignPatterns.DependencyInjection
{
  public class Client
  {
    //public int Id { get; set; }
    //public string Name { get; set; }
    private string? _name;
    private string? _lastName;

    public Client(string name, string lastName)
    {
      _name = name;
      _lastName = lastName;
    }
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public string LatName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }
  }
}
