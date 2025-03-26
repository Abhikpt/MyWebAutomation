
using System.Collections;
using System.Configuration;
using System.Dynamic;
using FrameWorkDesign;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class TestUtil  : BaseConfig
{
    public static IWebDriver webDriver;

    public TestUtil(IWebDriver driver) 
    {
        webDriver = driver;
        
    }

    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
    IJavaScriptExecutor js = null;


    public void ClickUsingJavaScriptExecutor(IWebElement element)   
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("argument[0].click();", element);

    }
    
    public bool CheckWebElementPresence(IWebElement webElement)
    {
        bool flag = false;

        try
        {
            if (webElement.Displayed)
            {
                LogHelper.Write($"WebElement:{webElement} is Displayed");
                if(webElement.Enabled)
                {
                    LogHelper.Write($"WebElement:{webElement} is Enable");
                    flag = true;
                }
                else
                {
                    LogHelper.Write($"WebElement:{webElement} is Display but it is not Enable");
                    flag = false;
                }
                
            }
            else
            {
                LogHelper.Write($"WebElement:{webElement} is not available/Disable");
                flag = false;

            }
        }
        catch(NoSuchElementException noSuchElement)
        {
            LogHelper.Write(noSuchElement.Message);
        }
         catch(ElementNotVisibleException noVisible)
        {
            LogHelper.Write(noVisible.Message);
        }
        catch (Exception e)
        {            
           LogHelper.Write(e.Message);
        }

        return flag;

    }

    public bool CheckWebElementClickable(IWebElement element)
    {
        bool flag = false;

        return flag;
    }
    
    public bool SelectRadioButtonOrCheckBox(IWebElement element)
    {
        bool flag = false;

        return flag;

    }

     public string IsAlertDisplay()
    {
        string message = null;
        Thread.Sleep(3000);

        try
        {
            
        }
        catch (Exception e)
        {
            
            LogHelper.Write(e.Message);
        }

        return message;

    }

    public ArrayList stringArrayToListConversion(String conversionString)
    {
        char[] seperator = {'\n'};
        string[] strList = conversionString.Split(seperator);
        ArrayList aList = new ArrayList();
        for(int i = 0 ; i< strList.Length ; i++)
        {
            aList.Add(strList.GetValue(i).ToString());
        }
        return aList;
    }

    public Dictionary<string,string> StringArrayToDictionaryConversion(String conversionString)
    {
         char[] seperator = {'=','\n'};
        string[] strList = conversionString.Split(seperator);
        Dictionary<string,string> dict = new Dictionary<string, string>();
        for(int i = 0 ; i< strList.Length ; i++)
        {
           dict.Add(strList.GetValue(i).ToString(), strList.GetValue(i+1).ToString());
           i=i+2;
        }
        return dict;

    }


    public bool CompareTwoArrayList(string expected, string actual)
    {
        bool flag = false;
        ArrayList list1 = stringArrayToListConversion(expected);
        ArrayList list2 = stringArrayToListConversion(actual);

        if(list1.Count == list2.Count)
        {
            for(int i = 0 ; i< list1.Count ; i++)
            {
                if(list1[i].Equals(list2[i]))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
        }
        else
        {
            flag = false;
        }

        return flag;
    }

    public SelectElement SelectWebElement(IWebElement element)
    {
        SelectElement selectElement = new SelectElement(element);
        return selectElement;
    }   


    public int GenerateRandomNumber(int Length)
    {

        Random random = new Random();

        if(Length == 1)
        {
            return random.Next(1,10);
        }
       else if(Length == 2)
        {
            return random.Next(10,100);
        }
        else if(Length == 3)
        {
            return random.Next(100,1000);
        }
        else if(Length == 4)
        {
            return random.Next(1000,10000);
        }
        else if(Length == 5)
        {
            return random.Next(10000,100000);
        }
        else if(Length == 6)
        {
            return random.Next(100000,1000000);
        }
        else if(Length == 7)
        {
            return random.Next(1000000,10000000);
        }
        else if(Length == 8)
        {
            return random.Next(10000000,100000000);
        }
        else if(Length == 9)
        {
            return random.Next(100000000,1000000000);
        }
        else if(Length == 10)
        {
            return random.Next(1000000000,1000000000);
        }
        else
        {
            return random.Next(1,10);
        }   
    }

    public String GenerateRandomString(int Length)
    {
        string randomString = "";
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        for(int i = 0 ; i< Length ; i++)
        {
            randomString += characters[random.Next(characters.Length)];
        }
        return randomString;
    }

    public void ScrollToElement(IWebElement element)
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public void ScrollToElementByCoordinates(int x, int y)
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("window.scrollBy("+x+","+y+")");
    }
    public void scrolltoBottom()
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }

    public void scrolltoTop()
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("window.scrollTo(0, 0)");
    }

    public void scrolltoRight()
    {
        js = (IJavaScriptExecutor) webDriver;
        js.ExecuteScript("window.scrollTo(document.body.scrollWidth, 0)");
    }

    public void MouseHoverOnElement(IWebElement element)
    {
        Actions action = new Actions(webDriver);
        action.MoveToElement(element).Perform();
    }

    public string GetCurrentWindowHandle()
    {
        return webDriver.CurrentWindowHandle;
    }

    public string WindowHandelForTwoTab()
    {
        string currentWindowHandle = GetCurrentWindowHandle();
        string newWindowHandle = null;

        try
        {
            foreach(string windowHandle in webDriver.WindowHandles)
            {
                if(!windowHandle.Equals(currentWindowHandle))
                {
                    newWindowHandle = windowHandle;
                }
            }
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }

        return newWindowHandle;
    }

    public dynamic ReadConfigFile()
    {
        try{
            appSettingPath = Path.Combine(System.IO.Directory.GetCurrentDirectory().Replace("bin\\debug\\net8.0", "AppSettings.json"));
            string json = File.ReadAllText(appSettingPath);
            jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());
            config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);  
                        
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return config;
    }
   

    public void WriteConfigFile()
    {
        try
        {
            dynamic newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingPath, newJson);
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }
    }




    
}