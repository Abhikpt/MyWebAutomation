using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject.Flipkart;

public class CartPage
{

    public IWebDriver driver ;
    
        public CartPage( DriverFixture driverFixture)
        {
            driver = driverFixture.Driver;
        }

        



}