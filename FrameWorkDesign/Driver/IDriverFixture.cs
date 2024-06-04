
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameWorkDesign.Driver
{
 public interface IDriverFixture
    {
        IWebDriver Driver {get;}    //this fields should be implement with public
        WebDriverWait Wait {get;}

    }
}