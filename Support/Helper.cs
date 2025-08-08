using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolisTestAutomationUI.Support
{
    public static class Helper
    {
        public static bool WaitForPageLoad(IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(static d => ((IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState")
                    .ToString()
                    .Equals("complete", StringComparison.OrdinalIgnoreCase));
                return true;    
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"[Warning] Page did not load completely within {timeoutSeconds} seconds.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Failed while waiting for page load: {ex.Message}");
                return false;
            }
        }

        public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
    }
}
