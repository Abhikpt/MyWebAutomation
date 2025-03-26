using System.Reactive.Disposables;
using System.Reflection;
using FrameworkDesign.Config;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using LearningWithAbhi.PageObject;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningWithAbhi.Practice;


//[Assembly:Parallelizable(ParallelScope.All)]
public class Seleniumtutorials : IDisposable
{

public IWebDriver _driver;
public DriverWithWait _driverwithWait;
public IHomePageObject  _homePage ;
public WebDriverWait wait;

    
    public Seleniumtutorials()
    {
        TestSetting testSetting = ConfigReader.ReadConfig();
        var driverFixture = new DriverFixture(testSetting);
        _driver = driverFixture.Driver;

         _driverwithWait = new DriverWithWait(driverFixture, testSetting);
         _homePage = new HomePageObject(driverFixture);

          wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3*1000));    
        
    }



    [Test]
    [TestCase("standard_user", "secret_sauce"),  Order(0)]    
    public void TC01_LoginWithValidData(string Users, string  paswrd)
    {
        
        _homePage.UserInput.Clear();
        _homePage.UserInput.SendKeys(Users);

        _homePage.PassInput.Clear();
        _homePage.PassInput.SendKeys(paswrd);
        Thread.Sleep(3000);
        _homePage.Login();

    }


     [Test, Category("check the iframes")]
       public void TC02_IFrameData()
       {
        _driver.Url= "https://demoqa.com/frames";

        // selecting the main page tag
         IWebElement elm1 = _driver.FindElement(By.CssSelector("#framesWrapper > h1"));
         Assert.That(elm1.Text, Is.EqualTo("Frames"));

        // selecting the content of iframe element by id
        _driver.SwitchTo().Frame("frame1");
         IWebElement frame0 = _driver.FindElement(By.CssSelector("#sampleHeading"));
         Console.WriteLine(frame0.Text);
         Assert.That(frame0.Text, Is.EqualTo("This is a sample page"));
         

         // switch back to the content of main page
         _driver.SwitchTo().DefaultContent();
        IWebElement elm2 = _driver.FindElement(By.CssSelector("#framesWrapper > h1"));
         Assert.That(elm2.Text, Is.EqualTo("Frames"));

       }

       [Test, Category("Capturing the screenshot")]
    public void  TC03_ScreenShotCapture()
    {
        _driver.Url = "https://www.saucedemo.com/";
        
        // Generate a unique filename using current timestamp
        string fileName =   $"Screenshots\\screenshot_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";

        _driver.FindElement(By.CssSelector("#login-button")).Click();
        ITakesScreenshot screenshot = (ITakesScreenshot)_driver;    
        Screenshot  ssFile =  screenshot.GetScreenshot(); 
        String filePAth = Path.Combine(ConfigReader.GetprojectDir(), fileName);
        ssFile.SaveAsFile(filePAth);   
    }

      [Test, Category("window Handling"), Order(1)]
      public void TC04_WindowHandel()
      {
       _driver.Url = "https://abhikpt.github.io/LearningwithAbhi";       

        //Store the ID of the original window
        string originalWindow = _driver.CurrentWindowHandle;
    
        //Check we don't have other windows open already
        Assert.That( _driver.WindowHandles.Count, Is.EqualTo(1));        
   
        _driver.Url = "https://abhikpt.github.io/LearningwithAbhi/Demo";

        wait.Until(wd => wd.FindElement(By.CssSelector("#app > div > main > div > a:nth-child(1)")).Displayed);
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#app > div > main > div > a:nth-child(1)")));
        //Click the link which opens in a new window
        _driver.FindElement(By.CssSelector("#app > div > main > div > a:nth-child(1)")).Click();

        //Wait for the new window or tab
        wait.Until(wd => wd.WindowHandles.Count == 2);

        //Loop through until we find a new window handle
        foreach(string window in _driver.WindowHandles)
        {
            if(originalWindow != window)
            {
                _driver.SwitchTo().Window(window);
                break;
            }
        }
        //Wait for the new tab to finish loading content
        wait.Until(wd => wd.Title == "Home - Entry point");
        
      }
  
     [Test, Category("GetLocator of a element")]
     public void TC05_GetElementcoordinates()
     {
         _driver.Url= "https://demoqa.com/frames";
        // selecting the main page tag
         IWebElement elm1 = _driver.FindElement(By.CssSelector("#framesWrapper > h1"));
         Assert.That(elm1.Text, Is.EqualTo("Frames"), "text is correct");

          // Get coordinates using JavaScript
          IJavaScriptExecutor js = (IJavaScriptExecutor) _driver ;
          
          int elementX = Convert.ToInt32( js.ExecuteScript("return arguments[0].getBoundingClientRect().left", elm1) );
          int elementY = Convert.ToInt32( js.ExecuteScript("return arguments[0].getBoundingClientRect().top", elm1));
           
          // coordinate using Location method
          Assert.That(elementX,Is.EqualTo(elm1.Location.X), " X coordinate is matched");
          Assert.That(elementY,Is.EqualTo(elm1.Location.Y)," Y coordinate is matched");
     }


    [OneTimeTearDown]
    public void Dispose()
    {
        
       _driver.Dispose();
       
    }
}