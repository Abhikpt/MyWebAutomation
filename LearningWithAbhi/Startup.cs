using Microsoft.Extensions.DependencyInjection;
using FrameworkDesign.Config;
using LearningWithAbhi.PageObject;
using FrameWorkDesign.Driver;

namespace LearningWithAbhi;
public class Startup {



// create dependency injection to fixes the object creation for each interface and create loosly 
    public void ConfigureServices(IServiceCollection services) 
    
    { services.AddSingleton(ConfigReader.ReadConfig());
       services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IHomePageObject, HomePageObject>();
        // .AddScoped<IDriverWithWait, DriverWithWait>(); 
    }   
}

