using FrameWorkDesign.Utilities;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Model;
using NUnit.Framework;

namespace FrameWorkDesign;

public abstract class BaseConfig
{

    public TestUtil util = null;
    public static SelectElement select = null;
    public static dynamic config = null;
    public static string appSettingPath = null;
    public static JsonSerializerSettings jsonSettings = null;

  //  public static DataSet dataSet = null;
    public static Actions actions =null;

    public static string testCaseName = null;
    public static string testCaseNumber = null;

    public static ExcelOperation excelOperation = null;
    public static int start_TestData_RowIndex;
    public static int end_TestData_RowIndex;
    public static string executionControlFlag = null;
    public static IWebDriver driver = null;

    public void Open()
    {
        // initialize run setting
   //     testCaseName =  TestContext.CurrentContext.Test.Name;
     //   testCaseNumber = TestContext.CurrentContext.Test.Properties.Get("TestCaseNumber").ToString();
    }


}
