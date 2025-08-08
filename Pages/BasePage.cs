using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CapitolisTestAutomationUI.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitUntilVisible(By locator)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            WaitUntilVisible(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitUntilVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

    }
}
