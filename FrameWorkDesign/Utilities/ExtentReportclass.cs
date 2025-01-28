using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualBasic;

namespace FrameWorkDesign.Utilities;

public class ExtenReportClass
 {
     public  ExtentReports? extent ;




    public void ExtentReportclass()
    {
         string str_directory = Environment.CurrentDirectory.ToString();
        

        //create the ExtentSparkReporter object to create Html report and pass directory
        ExtentSparkReporter extentSparkReporter = new ExtentSparkReporter("extReport.html");
        extentSparkReporter.Config.DocumentTitle = "Test report";

        //create extent report object
         extent = new ExtentReports();
        extent.AttachReporter(extentSparkReporter);

        //To set the title of the extent report 
              

        
    }
}