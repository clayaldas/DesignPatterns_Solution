namespace DesignPatternsImplementation.DependencyInyection;

public class Client
{
    private string? _name;
    private string? _lastName;
    private string? _email;
    private string? _phone;
    public Client(string name, string lastName, string? email, string? phone)
    {
        _name = name;
        _lastName = lastName;
        _email = email;
        _phone = phone;
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }        
    }
    public string LastName
    {
        get { return _name; }
        set { _lastName = value; }
    }
}
