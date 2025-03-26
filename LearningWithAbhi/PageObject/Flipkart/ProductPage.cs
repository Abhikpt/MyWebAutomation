using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject.Flipkart;

public class ProductPage
{

    public IWebDriver driver ;
    
        public ProductPage( DriverFixture driverFixture)
        {
            driver = driverFixture.Driver;
        }

        



}