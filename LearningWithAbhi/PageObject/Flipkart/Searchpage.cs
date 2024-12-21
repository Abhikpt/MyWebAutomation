

using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject.Flipkart;

public class SearchPage
{

    public IWebDriver driver ;
    
        public SearchPage( DriverFixture driverFixture)
        {
            driver = driverFixture.Driver;
        }



         
        



}