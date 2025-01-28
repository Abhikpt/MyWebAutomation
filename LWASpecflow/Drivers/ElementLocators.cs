

using System;
using System.Collections.Generic;
using LWASpecflow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LWASpecflow.Drivers;


public class ElementLocators 
{

    private IDriverFactory _driverFactory;
    private  TestSetting _testSetting;
    private readonly Lazy<WebDriverWait> _webdriverWait;


    public ElementLocators()
    {     _testSetting =  ConfigReader.ReadConfig();    // created as it will be used data in GetWaitdriver 
         _webdriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
         _driverFactory = new DriverFactory();
        
    }  


     public IWebElement FindWebElement(By elmLocator)
    {
        return _webdriverWait.Value.Until(_ => _driverFactory.Driver.FindElement(elmLocator));
    }

    public IEnumerable<IWebElement> FindWebElements(By elmLocator)  //enumerable can use to get query 
    {
        return _webdriverWait.Value.Until(_ => _driverFactory.Driver.FindElements(elmLocator));
    }

      public WebDriverWait GetWaitDriver()
    {
        return new WebDriverWait(_driverFactory.Driver, timeout: TimeSpan.FromSeconds(_testSetting.TimeOutInterval ?? 30 ))
        {
            PollingInterval = TimeSpan.FromSeconds(_testSetting.TimeOutInterval ?? 1)
        };
    }
}