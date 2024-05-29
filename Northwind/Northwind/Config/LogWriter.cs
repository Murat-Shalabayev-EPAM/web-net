using System.Reflection;

namespace Northwind.Config
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;

        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }

        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
            {
                Log(logMessage, w);
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\nLog Entry : ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("  :");
            txtWriter.WriteLine("  :{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }
    }
}
