using FrameworkDesign.Config;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

class ValidateDataCollection
{

      private IWebDriver driver;
     ValidateDataCollection()
    {
        TestSetting testSetting = ConfigReader.ReadConfig();
        driver = new DriverFixture(testSetting).Driver;
    }


    public void ValidateAllEmployeeDetails()
    {
        // Locate the table and rows
    IList<IWebElement> tableRows = driver.FindElements(By.CssSelector("table#employeeTable tbody tr"));

    // Create a list to store employee details from the table
    List<Dictionary<string, string>> tableEmployeeDetails = new List<Dictionary<string, string>>();

    // Extract employee details from the table
    foreach (var row in tableRows)
    {
        Dictionary<string, string> employee = new Dictionary<string, string>
        {
            { "empId", row.FindElement(By.CssSelector(".emp-id")).Text },
            { "empName", row.FindElement(By.CssSelector(".emp-name")).Text },
            { "empAge", row.FindElement(By.CssSelector(".emp-age")).Text },
            { "empSalary", row.FindElement(By.CssSelector(".emp-salary")).Text }
        };

        tableEmployeeDetails.Add(employee);
    }

    // Find and click the Edit button/link to open the next window
    IWebElement editButton = driver.FindElement(By.CssSelector(".edit-all-link"));
    editButton.Click();

    // Switch to the new window (assuming a new window is opened)
    string currentWindow = driver.CurrentWindowHandle;
    string newWindow = driver.WindowHandles.FirstOrDefault(w => w != currentWindow);
    driver.SwitchTo().Window(newWindow);

    // Wait for the next window to load (adjust the wait time as necessary)
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    wait.Until(driver => driver.FindElement(By.CssSelector(".employee-details-section")));

    // Extract employee details from the new window
    IList<IWebElement> editEmployeeRows = driver.FindElements(By.CssSelector(".employee-details-section tbody tr"));

    List<Dictionary<string, string>> editEmployeeDetails = new List<Dictionary<string, string>>();

    foreach (var row in editEmployeeRows)
    {
        Dictionary<string, string> employee = new Dictionary<string, string>
        {
            { "empId", row.FindElement(By.CssSelector(".edit-emp-id")).Text },
            { "empName", row.FindElement(By.CssSelector(".edit-emp-name")).Text },
            { "empAge", row.FindElement(By.CssSelector(".edit-emp-age")).Text },
            { "empSalary", row.FindElement(By.CssSelector(".edit-emp-salary")).Text },
            { "empDepartment", row.FindElement(By.CssSelector(".edit-emp-department")).Text },
            { "empProjects", row.FindElement(By.CssSelector(".edit-emp-projects")).Text }
        };

        editEmployeeDetails.Add(employee);
    }

    // Compare the details from the table with the details from the edit window
    bool allDetailsMatch = true;

    for (int i = 0; i < tableEmployeeDetails.Count; i++)
    {
        var tableEmployee = tableEmployeeDetails[i];
        var editEmployee = editEmployeeDetails[i];

        bool areDetailsCorrect = tableEmployee["empId"] == editEmployee["empId"] &&
                                 tableEmployee["empName"] == editEmployee["empName"] &&
                                 tableEmployee["empAge"] == editEmployee["empAge"] &&
                                 tableEmployee["empSalary"] == editEmployee["empSalary"];

        // Optionally, validate additional details like department and projects
        bool areAdditionalDetailsCorrect = editEmployee["empDepartment"] != null && editEmployee["empProjects"] != null;

        if (areDetailsCorrect && areAdditionalDetailsCorrect)
        {
            Console.WriteLine($"Employee {tableEmployee["empId"]} details validated successfully.");
        }
        else
        {
            Console.WriteLine($"Validation failed for Employee {tableEmployee["empId"]}.");
            allDetailsMatch = false;
        }
    }

    // Close the edit window and switch back to the original window
    driver.Close();
    driver.SwitchTo().Window(currentWindow);

    // Assert or return the final validation result
    if (allDetailsMatch)
    {
        Console.WriteLine("All employee details validated successfully.");
    }
    else
    {
        Console.WriteLine("Some employee details failed validation.");
    }
}

}
