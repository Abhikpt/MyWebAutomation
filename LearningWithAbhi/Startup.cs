using Microsoft.Extensions.DependencyInjection;
using FrameworkDesign.Config;
using LearningWithAbhi.PageObject;
using FrameWorkDesign.Driver;
public class Startup {


    public void ConfigureServices(IServiceCollection services) 
    
    { services
        .AddSingleton(ConfigReader.ReadConfig())
        .AddScoped<IDriverFixture, DriverFixture>()
        .AddScoped<IHomePageObject, HomePageObject>()
        .AddScoped<IDriverWithWait, DriverWithWait>();
       

    }   
}