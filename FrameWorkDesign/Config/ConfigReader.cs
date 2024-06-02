
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FrameworkDesigns.Config;


namespace FrameworkDesigns.Config
{
    public class ConfigRrader
    {

        //create the class to fetch the property of TestSetting model type
        public static TestSetting ReadConfig()
        {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var accessConfig = File.ReadAllText(path);

            var jsonSerializeOption = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,    //when comparing property not check case

            };

            jsonSerializeOption.Converters.Add(new JsonStringEnumConverter());


            return JsonSerializer.Deserialize<TestSetting>(accessConfig, jsonSerializeOption);
        }
    }
}