

using System;
using LWASpecflow.Drivers;
using LWASpecflow.Utilities;
using OpenQA.Selenium;

public class MagnetoLandingPage : IDisposable
{

    private IWebDriver _driver;
    TestSetting _testseting;

    public MagnetoLandingPage()
    {

        _driver = new DriverFactory().Driver;
    }


    public void  OpenLandingPage() 
    {
     _driver.Url= "https://magento.softwaretestingboard.com/";
    }


    public String Title()
    {
string title =_driver.Title;
return title;
    } 

    
    public void Dispose()
    {
        _driver.Dispose();
        _driver.Quit();
    }
  
}