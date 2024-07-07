
using FrameworkDesign.Config;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.Practice;

public class LogsAndScreenShot : IDisposable

{

   private IWebDriver  _driver;



public LogsAndScreenShot()
{

    TestSetting testSetting = ConfigReader.ReadConfig();
    _driver = new DriverFixture(testSetting).Driver;
}

   

    [Test, Category("Capturing the screenshot")]
    public void  ScreenShotCapture()
    {
        // Generate a unique filename using current timestamp
        string fileName =   $"Screenshots\\screenshot_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";

        _driver.FindElement(By.CssSelector("#login-button")).Click();
        ITakesScreenshot screenshot = (ITakesScreenshot)_driver;    
        Screenshot  ssFile =  screenshot.GetScreenshot(); 
        String filePAth = Path.Combine(ConfigReader.GetprojectDir(), fileName);
        ssFile.SaveAsFile(filePAth);   
    }


      [Test, Category("ExtentReports")]
    public void  LogReports()
    {
        // Generate a unique filename using current timestamp
       
    }





 public void Dispose()
    {
       _driver.Dispose();
    }

}