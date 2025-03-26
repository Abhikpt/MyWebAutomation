
using FrameWorkDesign.Driver;
using FrameWorkDesign.Config;
using LearningWithAbhi.PageObject;
using LearningWithAbhi.PageObject.Flipkart;

namespace LearningWithAbhi.TestScript.flipkart;

[Category("Flipkart page automation")]
public class HomePageTests : IDisposable
{
    private  HomePageModel _homePage ;
    private IDriverFixture _driverFixture;

    


    public  HomePageTests()
    {
        TestSetting testSetting = new TestSetting()
        {
            browserType = BrowserType.ChromeDriver,
            ApplicationURL = "https://www.flipkart.com/",
            TimeOutInterval = 3
        };

        _driverFixture = new DriverFixture(testSetting);
        _homePage = new HomePageModel(_driverFixture);        
    }    

    
    [Test, Category("Open My account")]
    public void TC01_HomeScreenIsOpen ()
    {       
        _homePage.SelectMyAccount();
        
    }

      
    public void TC02_LoginWithValidData(string Users, string  paswrd)
    {
        
        Thread.Sleep(3000);
        

    }

     [Test, Category("user loging successfully")]
    public void TC03_LoginSuccess()
    {Thread.Sleep(3000);
       
    }

    [OneTimeTearDown]
       public void Dispose()
        {
           _homePage.Dispose();
           _driverFixture.Driver.Dispose();
        }




}



