using System.Reflection;
using FrameWorkDesign.Config;
using Newtonsoft.Json;



namespace FrameworkDesign.Config;

    public class ConfigReader
    {
         public static TestSetting ReadConfig()
    {
        string? buildPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ;

        string accessFile = File.ReadAllText(buildPath + "/appsettings.json") ;
       

        return JsonConvert.DeserializeObject<TestSetting>(accessFile) ;
    }

    }