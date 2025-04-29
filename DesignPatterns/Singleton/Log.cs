using System.IO;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class Log
    {
        private static Log _instance;

        private string _pathFile = "log.txt";

        private Log()
        {
            
        }

        public static Log GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Log();
            }

            return _instance;
        }

        public void SaveFile(string message)
        {
            File.AppendAllText(_pathFile, message + Environment.NewLine);
        }
    }
}
