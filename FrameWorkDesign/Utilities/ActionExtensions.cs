using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationFramework.Extensions
{
    public static class ActionExtensions
    {
        /// <summary>
        /// Hovers over the specified element.
        /// </summary>
        public static void Hover(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).MoveToElement(element).Perform();
        }

        /// <summary>
        /// Right-clicks on the specified element.
        /// </summary>
        public static void RightClick(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).ContextClick(element).Perform();
        }

        /// <summary>
        /// Double-clicks on the specified element.
        /// </summary>
        public static void DoubleClick(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).DoubleClick(element).Perform();
        }

        /// <summary>
        /// Drags the source element and drops it onto the target element.
        /// </summary>
        public static void DragAndDrop(this IWebElement source, IWebElement target, IWebDriver driver)
        {
            new Actions(driver).DragAndDrop(source, target).Perform();
        }

        /// <summary>
        /// Sends keys to the specified element.
        /// </summary>
        public static void SendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Clicks and holds the specified element.
        /// </summary>
        public static void ClickAndHold(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).ClickAndHold(element).Perform();
        }

        /// <summary>
        /// Releases the mouse button on the specified element.
        /// </summary>
        public static void Release(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).Release(element).Perform();
        }

        /// <summary>
        /// Scrolls the page to the specified element.
        /// </summary>
        public static void ScrollTo(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).MoveToElement(element).Perform();
        }
    }
}
