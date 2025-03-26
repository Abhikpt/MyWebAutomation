

using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject.Flipkart;

public class LoginPage
{

    public IWebDriver driver ;
    
        public LoginPage( DriverFixture driverFixture)
        {
            driver = driverFixture.Driver;
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }

        

        



}