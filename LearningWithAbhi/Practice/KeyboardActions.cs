
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class KeyboardAction
{

     public IWebDriver driver;
    public WebDriverWait wait;
    public KeyboardAction()
    {

            driver = new ChromeDriver();
            driver.Url = "https://magento.softwaretestingboard.com/men/tops-men/tees-men.html";
                    
    }


    public void PassUpperCase()
    {
           ;

    }
}