Feature: Account Creation Amazon

User naviates to the Account Creation page in Amazon.com and tries to create a new account

@PartiallyImplementedBecauseOf2FA
Scenario: Successfully create a new Amazon account
    Given I navigate to the amazon website
    When I click on New Customer? Start here
    Then I should be redirected to the account creation start page
    When I enter an email address "mehitih250@bizmud.com" that is not associated with an existing account
    And I click the Continue button
    Then I should be prompted to proceed to create a new account
    When I click on Proceed to Create an Account
    When I enter the email "mehitih250@bizmud.com", name "Gabriel", create a password "1234567", and re-enter the password "1234567"
    And I click the Verify email button
    Then I should be prompted to complete a puzzle verification

#   2 Factor Authentication and puzzles challenges stops the easy automation implementations.
#    When I solve the puzzle challenge
#    Then I should be asked to verify my email using a security code
#    When I enter the email security code sent to my inbox
#    Then I should be prompted to enter my mobile phone number
#    When I enter my mobile phone number
#    And I enter the one-time password (OTP) sent via SMS
#    Then my Amazon account should be successfully created


@NegativeTesting
Scenario: Attempt to create a new Amazon account with a short password
    Given I navigate to the amazon website
    When I click on New Customer? Start here
    Then I should be redirected to the account creation start page
    When I enter an email address "mehitih250@bizmud.com" that is not associated with an existing account
    And I click the Continue button
    Then I should be prompted to proceed to create a new account
    When I click on Proceed to Create an Account
    When I enter the email "mehitih250@bizmud.com", name "Gabriel", create a password "1234", and re-enter the password "1234"
    And I click the Verify email button
    Then I should see a validation error stating "Minimum 6 characters required".



Scenario: Display validation errors when required fields are left empty during account creation
    Given I navigate to the amazon website
    When I click on New Customer? Start here
    Then I should be redirected to the account creation start page
    When I enter an email address "mehitih250@bizmud.com" that is not associated with an existing account
    And I click the Continue button
    And I click on Proceed to Create an Account
    When I enter the email "", name "", create a password "", and re-enter the password ""
    And I click the Verify email button
	Then I should see validation errors for each required field:
		| Field                  | Error Message                           |
		| Email or Mobile Number | Enter your email or mobile phone number |
		| Your Name              | Enter your name                         |
		| Password               | Minimum 6 characters required           |