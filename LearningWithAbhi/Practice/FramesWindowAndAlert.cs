
using System.Collections;
using NUnit.Framework;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningWithAbhi.Practice;

public class FramesWindowAndAlert : IDisposable
{

    public IWebDriver driver;
    public WebDriverWait wait;

    public  FramesWindowAndAlert()
   
       {
          var _testSetting = new TestSetting() 
            {
                ApplicationURL = "https://demoqa.com/frames",
                browserType = BrowserType.ChromeDriver,
                TimeOutInterval = 10
            };

             var drv = new DriverFixture(_testSetting);
           driver = drv.Driver;
           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3*1000));
       }


    [Test, Category("check the iframes")]
       public void IFrameData()
       {

        // selecting the main page tag
         IWebElement elm1 = driver.FindElement(By.CssSelector("#framesWrapper > h1"));
         Assert.That(elm1.Text, Is.EqualTo("Frames"));

        // selecting the content of iframe element by id
        driver.SwitchTo().Frame("frame1");
         IWebElement frame0 = driver.FindElement(By.CssSelector("#sampleHeading"));
         Console.WriteLine(frame0.Text);
         Assert.That(frame0.Text, Is.EqualTo("This is a sample page"));
         

         // selecting the content of outer element
         driver.SwitchTo().DefaultContent();
        IWebElement elm2 = driver.FindElement(By.CssSelector("#framesWrapper > h1"));
         Assert.That(elm2.Text, Is.EqualTo("Frames"));

       }


      [Test, Category("window Handling")]
      public void WindowHandel()
      {
        driver.Url = "https://abhikpt.github.io/LearningwithAbhi";
        

                //Store the ID of the original window
        string originalWindow = driver.CurrentWindowHandle;

        //store the all open window 
        var Window = driver.WindowHandles;

        //Check we don't have other windows open already
        Assert.AreEqual(driver.WindowHandles.Count, 1);        
   
        driver.Url = "https://abhikpt.github.io/LearningwithAbhi/Demo";

        wait.Until(wd => wd.FindElement(By.CssSelector("#app > div > main > div > a:nth-child(1)")).Displayed);
        
        //Click the link which opens in a new window
        driver.FindElement(By.CssSelector("#app > div > main > div > a:nth-child(1)")).Click();

        //Wait for the new window or tab
        wait.Until(wd => wd.WindowHandles.Count == 2);

        //Loop through until we find a new window handle
        foreach(string window in driver.WindowHandles)
        {
            if(originalWindow != window)
            {
                driver.SwitchTo().Window(window);
                break;
            }
        }
        //Wait for the new tab to finish loading content
        wait.Until(wd => wd.Title == "Home - Entry point");
        
      }
  

    public void Dispose()
    {
       driver.Dispose();
       
    }

    
}