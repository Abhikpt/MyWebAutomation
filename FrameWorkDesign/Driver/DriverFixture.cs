using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using FrameWorkDesign.Config;

namespace FrameWorkDesign.Driver
{
     public class DriverFixture : IDriverFixture
    {
       public IWebDriver Driver {get;}
       public WebDriverWait Wait {get;}
        public DriverFixture(TestSetting testSetting)
        {
            Driver = GetBrowser(testSetting.browserType);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(testSetting.ApplicationURL);
            Thread.Sleep(5000);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(testSetting.TimeOutInterval ?? 30 )); 
            
        }  
        public IWebDriver GetBrowser(BrowserType browserType)
        {

            return browserType switch
            {
                BrowserType.ChromeDriver => new ChromeDriver(),
                BrowserType.EdgeDriver => new EdgeDriver(),
                BrowserType.FireFoxDriver => new FirefoxDriver(), 
                    _ => new ChromeDriver()

            } ;     

        }
    
    }
}