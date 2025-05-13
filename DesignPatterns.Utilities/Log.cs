using System.IO;
using System.Text;

namespace DesignPatterns.Utilities
{
    public sealed class Log
    {
        private static Log? _instance;

        private string _fileName;

        private Log(string nameFile)
        {
            _fileName = nameFile;
        }

        public static Log GetInstance(string nameFile)
        {
            if (_instance == null)
            {
                _instance = new Log(nameFile);
            }

            return _instance;
        }

        public void SaveFile(string message)
        {
            File.AppendAllText(_fileName, message + Environment.NewLine);
        }
    }
}
