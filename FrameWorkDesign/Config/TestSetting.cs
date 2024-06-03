
namespace FrameWorkDesign.Config;
public class TestSetting
{
 public string? ApplicationURL ;
 public int TimeOutInterval = 0;
 public BrowserType browserType ; 

 public string? ProductPageURL ;
}

public enum BrowserType
{
    ChromeDriver,
    EdgeDriver,
    FireFoxDriver
}
