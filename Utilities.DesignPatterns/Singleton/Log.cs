namespace Utilities.DesignPatterns.Singleton;

// Patrón: Singleton
// Aplicación utilizando un Log
public sealed class Log
{
    private static Log? _instance;
    //private string _nameFile = "log.txt";
    private string _nameFile;
    private Log(string nameFile)
    {
        _nameFile = nameFile;
    }
    public static Log GetIntance(string nameFile)
    {
        if (_instance == null)
        {
            _instance = new Log(nameFile);
        }
        return _instance;
    }
    public void SaveFile(string message)
    {
        File.AppendAllText(_nameFile, message + Environment.NewLine);
    }
}
