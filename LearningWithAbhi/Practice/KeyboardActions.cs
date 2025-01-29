
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V123.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LearningWithAbhi.Practice;
public class KeyboardAction : IDisposable
{

     public IWebDriver driver;
    public WebDriverWait wait;
    public KeyboardAction()
    {

            driver = new ChromeDriver();
            driver.Url = "https://magento.softwaretestingboard.com/men/tops-men/tees-men.html";
                    
    }

   

    [Test, Category("keyboard actions")]   
    public void PassUpperCase()
    {
       var elm1 =  driver.FindElement(By.Id("search"));
       elm1.SendKeys(Keys.Shift + "debian");

       elm1.SendKeys(Keys.Control + "A");
        Thread.Sleep(2000);
       elm1.SendKeys(Keys.Backspace);
       Thread.Sleep(2000);
     //  Console.ReadKey(); 

        elm1.SendKeys(Keys.Shift + "Inserted with Shift") ;       

    }

    [Test, Category("Keyboard with Action class")]
    public void KeyWordActionUsingActionCls()
    {
        Actions actions = new Actions(driver);

        // Press and release a key
        var elm1 =  driver.FindElement(By.Id("search"));
        elm1.SendKeys("Working with Action class");

        var search = driver.FindElement(By.CssSelector("button[ title='Search']"));
        actions.SendKeys(search,Keys.Enter).Perform();
        Thread.Sleep(2000);

        elm1 =  driver.FindElement(By.Id("search"));  // will get stale element error not locating again
        //press the Control key don and send A to perform Select All
        actions.SendKeys(elm1," ").KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).Perform();
        Thread.Sleep(5000);
       
    }



     public void Dispose()
    {
        driver.Dispose();
    }
}