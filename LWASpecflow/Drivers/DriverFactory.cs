using System;
using System.Threading.Tasks;
using LWASpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace LWASpecflow.Drivers;

public class DriverFactory : IDriverFactory
{
    public IWebDriver Driver { get; }
    private TestSetting _testsetting;
   // private readonly Lazy<WebDriverWait> webDriverWait;

    // to initialize the driver
    public DriverFactory()
    {
        _testsetting = ConfigReader.ReadConfig();
        Driver = _testsetting.TestRunType == TestRunType.Grid ? GetBrowserDriver(_testsetting.browserType) : GetRemoteWebDriver(_testsetting.browserType);
        Driver.Manage().Window.Maximize();

    }

    // wait for element to locate
    public IWebElement WaitForElement(By by, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(drv => drv.FindElement(by));
    }



    private IWebDriver GetBrowserDriver(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.ChromeDriver => new ChromeDriver(),
            BrowserType.EdgeDriver => new EdgeDriver(),
            BrowserType.FireFoxDriver => new FirefoxDriver(),
            _ => new ChromeDriver(),
        };
    }

    private IWebDriver GetRemoteWebDriver(BrowserType browserType)
    {
        IWebDriver driver = browserType switch
        {
            BrowserType.ChromeDriver => new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions()),
            BrowserType.EdgeDriver => new RemoteWebDriver(_testsetting.GridUri, new EdgeOptions()),
            BrowserType.FireFoxDriver => new RemoteWebDriver(_testsetting.GridUri, new FirefoxOptions()),
            _ => new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions()),
        }; return driver;

    }



    [OneTimeTearDown]
    public void DriverClosed()
    {
        Driver.Quit();

    }




}



