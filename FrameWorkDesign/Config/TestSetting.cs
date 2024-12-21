
namespace FrameWorkDesign.Config;
public class TestSetting
{
 public string? ApplicationURL ;
 public double? TimeOutInterval = 0;
 public BrowserType browserType ; 

 public string? ProductPageURL ;

 public string? ProductDataFile;


public TestRunType TestRunType ;
public Uri? GridUri { get; set; }    

}
public enum BrowserType
{
    ChromeDriver,
    EdgeDriver,
    FireFoxDriver
}


public enum TestRunType
    {
        Local ,
        Grid
    }