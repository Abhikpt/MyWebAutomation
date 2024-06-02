using FrameworkDesigns;
using FrameworkDesigns.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject
{

    public class HomePageObject : IDisposable , IHomePageObject
    {

   //     private readonly TestSetting _testSetting ;
     //   private  IDriverFixture _driverFixture ;
        private IWebDriver _driver;


         
        public HomePageObject( IDriverFixture  driverFixture)
        {             
            _driver = driverFixture.Driver ;

        }


        By UserLocator = By.CssSelector("#user-name");
        By PassLocator = By.CssSelector("#password");
        By LogicButtonLocator = By.CssSelector("#login-button");


        public string PageTitle => _driver.Title;
        public string PageUrl => _driver.Url;
        public IWebElement UserInput => _driver.FindElement(UserLocator);
        public IWebElement PassInput => _driver.FindElement(PassLocator);
        public IWebElement LoginButton => _driver.FindElement(LogicButtonLocator);

        public void Login() => LoginButton.Click();

        public void Dispose()
        {
            _driver.Dispose();
        }
    }

  
}