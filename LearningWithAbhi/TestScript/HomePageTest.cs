
using FrameWorkDesign.Driver;
using FrameWorkDesign.Config;
using LearningWithAbhi.PageObject;
using OpenQA.Selenium.Support.UI;
using FrameworkDesign.Config;

namespace LearningWithAbhi.TestScript;
public class HomePageTests : IDisposable
{
    private  HomePageObject _homePage ;
    private IDriverFixture _driverFixture;

    


    public  HomePageTests()
    {
        // TestSetting testSetting = new TestSetting()
        // {
        //     browserType = BrowserType.ChromeDriver,
        //     ApplicationURL = "https://www.saucedemo.com/",
        //     TimeOutInterval = 3
        // };


        var testSetting = ConfigReader.ReadConfig();

        
        _driverFixture = new DriverFixture(testSetting);
        _homePage = new HomePageObject(_driverFixture);        
    }    

    [Test, Category("Open Application")]
    public void TC01_HomeScreenIsOpen ()
    {        
        Assert.That(_homePage.PageUrl,Is.EqualTo("https://www.saucedemo.com/"));
    }

    [Test, Category("validate Login")]
    [TestCase("abhishek", "admin12345")]    
    [TestCase("admin", "1234")]
    [TestCase("standard_user", "secret_sauce")]    
    public void TC02_LoginWithValidData(string Users, string  paswrd)
    {
        _homePage.UserInput.Clear();
        _homePage.UserInput.SendKeys(Users);

        _homePage.PassInput.Clear();
        _homePage.PassInput.SendKeys(paswrd);
        Thread.Sleep(3000);
        _homePage.Login();

    }

     [Test, Category("user loging successfully")]
    public void TC03_LoginSuccess()
    {
        Assert.That(_homePage.PageUrl, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
    }

    [OneTimeTearDown]
       public void Dispose()
        {
           _homePage.Dispose();
           _driverFixture.Driver.Dispose();
        }




}



