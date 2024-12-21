using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

class MagnetoEcommerce
{
    public MagnetoEcommerce()
    {
    
        // Setup the ChromeDriver
        IWebDriver driver = new ChromeDriver();
        
        try
        {
            // Navigate to the page
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/men/tops-men/tees-men.html");
            driver.Manage().Window.Maximize();
            
            // Wait for the page to load fully (optional explicit wait can be added for better handling)
            System.Threading.Thread.Sleep(3000);

            // Find all products on the page
            IReadOnlyCollection<IWebElement> products = driver.FindElements(By.CssSelector(".product-item"));

            foreach (var product in products)
            {
                try
                {
                    // Find the rating element
                    IWebElement ratingElement = product.FindElement(By.CssSelector(".rating-summary .rating-result"));

                    // Extract the rating value (as an integer or float)
                    string ratingPercentage = ratingElement.GetAttribute("style").Replace("width:", "").Replace("%;", "").Trim();
                    double rating = (double.Parse(ratingPercentage) / 20); // Convert percentage to a 1-5 scale
                    
                    if (Math.Abs(rating - 4.0) < 0.01) // Check if rating is approximately 4
                    {
                        // Find the price for this product
                        IWebElement priceElement = product.FindElement(By.CssSelector(".price"));
                        string price = priceElement.Text;

                        Console.WriteLine($"Product with 4-star rating found! Price: {price}");
                        break; // Exit loop after finding the first match
                    }
                }
                catch (NoSuchElementException)
                {
                    // If a product does not have a rating or price, skip it
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }
}
