using CapitolisTestAutomationUI.Pages;
using FluentAssertions;

namespace CapitolisTestAutomationUI.StepDefinitions
{
    [Binding]
    public class CreateAccountStepDefinitions
    {
        private readonly CreateAccountPage _createAccountPage;

        public CreateAccountStepDefinitions(CreateAccountPage createAccountPage)
        {
            _createAccountPage = createAccountPage;
        }

        [Given("I navigate to the amazon website")]
        public void GivenINavigateToTheAmazonWebsite()
        {
            _createAccountPage.NavigateToAmazonWebsite();
            _createAccountPage.ClickOnContinueShoppingButton();
        }

        [When("I click on New Customer? Start here")]
        public void WhenIClickOnNewCustomerStartHere()
        {
            _createAccountPage.ClickOnHelloSignInAccountAndLists();
        }

        [Then("I should be redirected to the account creation start page")]
        public void ThenIShouldBeRedirectedToTheAccountCreationStartPage()
        {
            _createAccountPage.AssertThatYouAreOnSignInOrCreateAccountElement();
        }

        [When("I enter an email address {string} that is not associated with an existing account")]
        public void WhenIEnterAnEmailAddressThatIsNotAssociatedWithAnExistingAccount(string email)
        {
            _createAccountPage.EnterEmailInInput(email);
        }

        [When("I click the Continue button")]
        public void WhenIClickTheContinueButton()
        {
            _createAccountPage.ClickContinueButton();
        }

        [Then("I should be prompted to proceed to create a new account")]
        public void ThenIShouldBePromptedToProceedToCreateANewAccount()
        {
            _createAccountPage.AssertLooksLikeYouAreNewToAmazon();
        }

        [When("I click on Proceed to Create an Account")]
        public void WhenIClickOnProceedToCreateAnAccount()
        {
            _createAccountPage.ClickProceedToCreateAnAccount();
        }

        [When("I enter the email {string}, name {string}, create a password {string}, and re-enter the password {string}")]
        public void WhenIEnterTheEmailNameCreateAPasswordAndRe_EnterThePassword(string email, string name, string pass, string passReEntered)
        {
            _createAccountPage.EnterInEmailTextboxForAccount(email);
            _createAccountPage.EnterNameTextbox(name);
            _createAccountPage.EnterPasswordTextbox(pass);
            _createAccountPage.ReEnterPasswordTextbox(passReEntered);
        }

        [When("I click the Verify email button")]
        public void WhenIClickTheVerifyEmailButton()
        {
            _createAccountPage.ClickVerifyEmailFromFormPage();
        }

        [Then("I should be prompted to complete a puzzle verification")]
        public void ThenIShouldBePromptedToCompleteAPuzzleVerification()
        {
            _createAccountPage.VerifyYouAreOnCatchaPuzzleScreen().Should().BeTrue();
            _createAccountPage.ValidateTextCapturedFromPuzzleScreen().Should().BeEquivalentTo("Solve this puzzle to protect your account");
        }

        [Then("I should see a validation error stating {string}.")]
        public void ThenIShouldSeeAValidationErrorStating_(string validationErrorMessageOfPasswordTextbox)
        {
            _createAccountPage.CaptureAndReturnShortPassValidationMessage()
                .Should().BeEquivalentTo(validationErrorMessageOfPasswordTextbox);
        }

        [Then("I should see validation errors for each required field:")]
        public void ThenIShouldSeeValidationErrorsForEachRequiredField(DataTable dataTable)
        {
            _createAccountPage.AssertAndValidateErrorMessagesDisplayed(dataTable);
        }


    }
}
