using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject.Flipkart;

public class HomePageModel : IDisposable
{

    public IWebDriver driver ;
    
        public HomePageModel(IDriverFixture driverFixture)
        {
            driver = driverFixture.Driver; 
        }       

        By GlobalSearch  = By.CssSelector("#container > div > div.q8WwEU > div > div > div > div > div:nth-child(1) > div > div > div > div._2nl6Ch > div._2NhoPJ > header > div._3ZqtNW > div._3NorZ0._3jeYYh > form > div > div > input");
        By SrchSugestion = By.CssSelector("#container > div > div.q8WwEU > div > div > div > div > div:nth-child(1) > div > div > div > div._2nl6Ch > div._2NhoPJ > header > div._3ZqtNW > div._3NorZ0._3jeYYh > form > ul > li");
        By MyAccount = By.XPath("//a[@title='My Account']/preceding-sibling::div");
        public string Title  => driver.Title;
        public string pageSource =>   driver.PageSource;
        



        public void SelectMyAccount() => driver.FindElement(MyAccount).Click();


        // passing value in search field
        public void SendSearchvalue(string s) => driver.FindElement(GlobalSearch).SendKeys(s);
       
       // get list of all suggested value
       public List<string> GetAutosugestionValue() 
       {
         IList<IWebElement> SugestionElms = driver.FindElements(SrchSugestion);
         List<string> sugestedValue = new List<string>();

         foreach(var elm in SugestionElms)
         {
            sugestedValue.Add(elm.Text);

         }
         return sugestedValue;
       }



  
    public void Dispose()
    {
        driver.Dispose();
    }
}