
using System.Data.OleDb;
using FrameworkDesign.Config;
using FrameWorkDesign.DataSet;
using Dapper;

namespace FrameWorkDesign.Utilities;

public class ExcelOperation
{
    
    private readonly OleDbCommand connection ;

    // connection setting for accessing the source
    public static string TestDataFileConnection()
    {
       
        // accessing the file location from appsetting json
        var fileLocation = ConfigReader.ReadConfig().ProductDataFile;
        var conString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileLocation);
            return conString;
    }

    // created a method thwe will return the ProductData
    public static ProductData GetTestData(string testName)
       {

        // create the object for oledb using connection string
          var connection = new OleDbConnection(TestDataFileConnection()) ;
        
            connection.Open();
         

           // addProduct -> sheets Name, Keyname -> exact collumn name, testName - scenarion type
            var query = string.Format("select * from [AddProduct$] where keyName = '{0}'", testName);
          
            // map the query result with ProductDataModel 
            var value = connection.Query<ProductData>(query).FirstOrDefault(); 
            connection.Close();
         
            return value;
        }
    
}
    //  public static ProductData UpdateTest(string testName)
    //    {

    //     // create the object for oledb using connection string
    //     using(    var conn = new OleDbConnection(TestDataFileConnection()))
    //     {
    //         conn.Open();
    //         Console.WriteLine("Connection open");

    //        // addProduct -> sheets Name, Keyname -> exact collumn name, 
    //         var query = string.Format("select * from [AddProduct$] where keyName = '{0}'", testName);
    //         var value = conn.Query<ProductData>(query).FirstOrDefault(); 
    //         conn.Close();
         
    //         return value;
    //     }
    // }
