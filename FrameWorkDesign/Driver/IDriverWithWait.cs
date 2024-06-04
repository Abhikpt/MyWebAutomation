using OpenQA.Selenium;

namespace FrameWorkDesign.Driver;

public interface IDriverWithWait
{
    IWebElement FindWebElement(By elementLocator);
    IEnumerable<IWebElement> FindWebElements(By elementLocator);
}