
class LogHelper
{
    // configuration Details
    public static string browser = "chrome";
    public static string serviceName = "MyWebApp";

    // public static string Environment = "Int";
    public static string Environment = "QA";
    public static string startupPath = Directory.GetCurrentDirectory();
    public static string logFilePath = startupPath.Replace("bin\\Debug\\net8.0", "Logs\\");


    // Global declaration
    public static string _logFileName = string.Format("{0:yyyyMMDD_hhmmss}", DateTime.Now) + ".log";
    public static StreamWriter _streamW = null;

    //creating file
    public static void CreateLogFile()
    {
        string dir = logFilePath;
        string curFile = dir+ _logFileName;
        if(File.Exists(curFile))
        {

        }
        else
        {
            _streamW = File.AppendText(curFile);
        }
    }

    public static void Write()
    {
        _streamW.Write("\n");
        _streamW.Flush();


    }

    public static void Write(string msg)
    {
        _streamW.Write("{0} {1}" , DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString());
        _streamW.WriteLine(" {0}",msg);
        _streamW.Flush();
    }

    public static void Write(string msg, string val)
    {
        _streamW.Write("{0} {1}" , DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString());
        _streamW.WriteLine(" {0}{1}",msg, val);
        _streamW.Flush();
    }

    
}