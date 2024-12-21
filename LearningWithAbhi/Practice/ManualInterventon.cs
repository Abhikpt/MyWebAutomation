
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;



namespace LearningWithAbhi.Practice;
public class ManualInterventon
{

     IWebDriver webDriver;


    public ManualInterventon()
    {
        TestSetting ts = new TestSetting()
        {
            ApplicationURL = "https://www.irctc.co.in/nget/train-search",
            browserType = BrowserType.ChromeDriver,
            TimeOutInterval = 10,
            

        };
        webDriver = new DriverFixture(ts).Driver;
    
    }


      [Test, Category ("Test manual work")]  
    public  void TestManual()
    {
        
        

        // Wait for manual intervention
        Console.WriteLine("Please complete any manual actions and press Enter to continue...");
        Console.ReadLine();
        
        // Continue with your automation...
        webDriver.Quit();
 
        
    }
}