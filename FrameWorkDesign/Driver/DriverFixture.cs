using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using FrameWorkDesign.Config;
using OpenQA.Selenium.Remote;
using System;

namespace FrameWorkDesign.Driver
{
     public class DriverFixture : IDriverFixture
    {
       public IWebDriver Driver {get;}
       public TestSetting _testsetting;
       public WebDriverWait Wait {get;}
        public DriverFixture(TestSetting testSetting)
        {
            _testsetting = testSetting; 
       //     Driver = _testsetting.TestRunType == TestRunType.Local ? GetWebDriver(testSetting.browserType) : GetRemoteWebDriver(testSetting.browserType);
            Driver =  GetWebDriver(testSetting.browserType) ;

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(testSetting.ApplicationURL);
            Thread.Sleep(5000);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(testSetting.TimeOutInterval ?? 30 )); 
            
        }  
        public IWebDriver GetWebDriver(BrowserType browserType)
        {

            return browserType switch
            {
                BrowserType.ChromeDriver => new ChromeDriver(),
                BrowserType.EdgeDriver => new EdgeDriver(),
                BrowserType.FireFoxDriver => new FirefoxDriver(), 
                    _ => new ChromeDriver()

            } ;     

        }

         public IWebDriver GetRemoteWebDriver(BrowserType browserType)
        {
            IWebDriver driver;

         switch (browserType)
            {
                case BrowserType.ChromeDriver:
                    driver = new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions());
                    break;                
                case BrowserType.EdgeDriver:
                    driver = new RemoteWebDriver(_testsetting.GridUri, new EdgeOptions());
                    break;                
                case BrowserType.FireFoxDriver:
                    driver = new RemoteWebDriver(_testsetting.GridUri, new FirefoxOptions());
                    break;
                default:
                    driver = new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions());
                    break;
            }

        return driver;

        }


       
    }
}