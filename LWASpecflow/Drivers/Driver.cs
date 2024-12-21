using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LWASpecflow.Drivers;
public class Driver 
{
    IWebDriver driver;



    public Driver()
    {
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for an element to be visible and interactable
     IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("elementId")));
    IWebElement element1 = wait.Until(driver => driver.FindElement(By.Id("elementId")));

        
    }
       
        

        

    
}
