using CapitolisTestAutomationUI.Support;
using FluentAssertions;
using FluentAssertions.Primitives;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapitolisTestAutomationUI.Pages
{
    public class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver driver): base(driver) {}

        private string LooksLikeYouAreNewToAmazonExpectedText = "Looks like you're new to Amazon";

        private string url = AppSettingsReader.GetConfigValue("url");

        private IWebElement ClickOnContinueShoppingButtonInTheBeginning => Driver.FindElement(By.XPath("*//form/div/div/span/span/button"));
        private IWebElement HelloSignInAccountAndListsElement => Driver.FindElement(By.Id("nav-link-accountList"));
        private IWebElement SignInOrCreateAccount => Driver.FindElement(By.XPath("//*[@id='claim-collection-container']/h1"));
        private IWebElement EmailLoginInput => Driver.FindElement(By.Id("ap_email_login"));
        private IWebElement ContinueButton => Driver.FindElement(By.Id("continue"));
        private IWebElement ProceedToCreateAnAccountButton => Driver.FindElement(By.Id("intention-submit-button"));
        private By LooksLikeYouAreNewToAmazonScreenText => By.XPath("//*[@id='intent-confirmation-container']/h1");
        private By EmailOrMobileFromCreateAccountScreen => By.Id("ap_email");
        private IWebElement YourNameWebElement => Driver.FindElement(By.Id("ap_customer_name"));
        private IWebElement PasswordIWebElement => Driver.FindElement(By.Id("ap_password"));
        private IWebElement ReEnterPasswordIWebElement => Driver.FindElement(By.Id("ap_password_check"));
        private IWebElement ClickVerifyEmailButtonFromFormPage => Driver.FindElement(By.Id("continue"));
        private By PuzzleCatchaText => By.Id("aacb-captcha-header");
        private By ShortPasswordErrorMessageElement => By.CssSelector("#auth-password-invalid-password-alert > div > div");
        private By ErrorMessageEmptyEnterYourEmail => By.XPath("//*[@id='auth-email-missing-alert']/div/div");
        private By ErrorMessageEmptyNameInput => By.XPath("//*[@id='auth-customerName-missing-alert']/div/div");
        private By ErrorMessageEmptyPassword => By.XPath("//*[@id='auth-password-missing-alert']/div/div");

        private Dictionary<string, By> ErrorLocators => new()
        {
            { "Email or Mobile Number", ErrorMessageEmptyEnterYourEmail },
            { "Your Name", ErrorMessageEmptyNameInput },
            { "Password", ErrorMessageEmptyPassword }
        };

        public string GetErrorMessage(string field) =>
            Driver.FindElement(ErrorLocators[field])
                   .Text.Trim();

        public void NavigateToAmazonWebsite()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ClickOnContinueShoppingButton()
        {
            ClickOnContinueShoppingButtonInTheBeginning.Click();
        }

        public void ClickOnHelloSignInAccountAndLists()
        {
            if (Helper.WaitForPageLoad(Driver))
            {
                HelloSignInAccountAndListsElement.Click();
            }
        }

        public void AssertThatYouAreOnSignInOrCreateAccountElement() 
        {
            string expectedText = "Sign in or create account";
            SignInOrCreateAccount.Text.Trim().Should().BeEquivalentTo(expectedText);
        }

        public void EnterEmailInInput(string email)
        {
            EmailLoginInput.SendKeys(email);
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public void AssertLooksLikeYouAreNewToAmazon()
        {
            var LooksLimeYouAreNewToAmazon = Helper.WaitUntilVisible(Driver, LooksLikeYouAreNewToAmazonScreenText, 10);
            LooksLimeYouAreNewToAmazon.Text.Trim().Should().BeEquivalentTo(LooksLikeYouAreNewToAmazonExpectedText); 
        }

        public void ClickProceedToCreateAnAccount()
        {
            if (Helper.WaitForPageLoad(Driver))
            {
                ProceedToCreateAnAccountButton.Click();
            }
        }

        public void EnterInEmailTextboxForAccount(string email)
        {
            var EmailOrMobileFromCreateAccountWebElement = Helper.WaitUntilVisible(Driver, EmailOrMobileFromCreateAccountScreen, 10);
            EmailOrMobileFromCreateAccountWebElement.Clear();
            EmailOrMobileFromCreateAccountWebElement.SendKeys(email);
        }

        public void EnterNameTextbox(string name)
        {
            YourNameWebElement.Clear();
            YourNameWebElement.SendKeys(name);
        }

        public void EnterPasswordTextbox(string pass) 
        {
            PasswordIWebElement.SendKeys(pass);
        }

        public void ReEnterPasswordTextbox(string reEnterpass)
        {
            ReEnterPasswordIWebElement.SendKeys(reEnterpass);
        }

        public void ClickVerifyEmailFromFormPage()
        {
            Thread.Sleep(1000); //not a recommended practice, for the sake of time will use now.
            ClickVerifyEmailButtonFromFormPage.Click();
        }

        public bool VerifyYouAreOnCatchaPuzzleScreen()
        {
            var catchaPuzzleText = Helper.WaitUntilVisible(Driver, PuzzleCatchaText, 10);
            return catchaPuzzleText != null && catchaPuzzleText.Displayed;
        }
        
        public string ValidateTextCapturedFromPuzzleScreen()
        {
            var catchaPuzzleText = Helper.WaitUntilVisible(Driver, PuzzleCatchaText, 10);
            return catchaPuzzleText.Text;
        }

        public string CaptureAndReturnShortPassValidationMessage()
        {
            var shortPassMessageElement = Helper.WaitUntilVisible
                (Driver, ShortPasswordErrorMessageElement, 10);
            return shortPassMessageElement.Text.Trim();
        }

        public void AssertAndValidateErrorMessagesDisplayed(DataTable table)
        {
            foreach (var row in table.Rows)
            {
                var field = row["Field"];
                var expectedMsg = row["Error Message"];
                var actualMsg = GetErrorMessage(field);
                actualMsg.Should().Be(expectedMsg, $"Mismatch for field '{field}'");
            }
        }
    }
}
