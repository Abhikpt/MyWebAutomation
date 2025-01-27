using System.Reflection;
using FrameWorkDesign.Config;
using Newtonsoft.Json;



namespace FrameworkDesign.Config;

    public class ConfigReader
    {

         public static TestSetting ReadConfig()
            {
              //  string? buildPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ;

                string accessFile = File.ReadAllText(GetprojectDir() + "/appsettings.json") ;
            
                return JsonConvert.DeserializeObject<TestSetting>(accessFile) ;
            }

        public static string GetprojectDir()
        {
              string workingDir = Environment.CurrentDirectory;
         //    String projectDir = Directory.GetParent(workingDir).Parent.Parent.ToString();

            String projectDir =  workingDir.Replace("LearningWithAbhi\\bin\\Debug\\net8.0", "FrameWorkDesign\\Config");

             return projectDir;

        }

       
    

    }