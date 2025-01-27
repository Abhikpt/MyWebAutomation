using System;
using System.IO;
using System.Reflection;
using System.Text;
using LWASpecflow.Utilities;
using Newtonsoft.Json;

namespace LWASpecflow.Utilities;

  public class ConfigReader
  {

        public static TestSetting ReadConfig()
          {
              string accessFile = File.ReadAllText(GetprojectDir() + "/appsettings.json") ;   
              return JsonConvert.DeserializeObject<TestSetting>(accessFile) ;
          }

      public static string GetprojectDir()
      {
          String biDirctorty = Environment.CurrentDirectory; 
           String workingDir = Directory.GetParent(biDirctorty).Parent.Parent.ToString();
          string projectDir  =  workingDir + "\\Utilities";
          return projectDir;
      }
  

  }