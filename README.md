# Capitolis Test Automation UI

## Capitolis UI Test Framework Home Assignment Task.

This project was created using C#, Reqnroll for the BDD scenarios in Gherkin language using Selenium with a Page Object Model approach.

Clone the project in your local and build it. It should load and run straight away when you have the Prerequisites.

## Prerequisites
- .NET latest version
- Chrome Browser
- Visual Studio 2022
- Reqnroll Extension installed in VS 2022.

## Project Structure
- Features --> Feature files with the scenarios in Gherkin language.
- Hooks --> Initialiser class with tags like [BeforeScenario], etc.
- Pages --> Pages with objects and methods that access the pages.
- StepDefinitions --> Implementation of the BDD steps.
- Support --> Support methods and config readers.
- AppSettings.json --> configuration json file to add information to use along the project.

## Packages needed to run
    <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
    <PackageReference Include="ExtentReports" Version="5.0.4" />
    <PackageReference Include="FluentAssertions" Version="8.5.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="9.0.8" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="9.0.8" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="9.0.8" />
    <PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="9.0.8" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.10.0" />
    <PackageReference Include="Reqnroll.NUnit" Version="2.2.1" />
    <PackageReference Include="nunit" Version="3.14.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
    <PackageReference Include="Selenium.WebDriver" Version="4.34.0" />

## Assumptions made
There will not be 2 Factor Authentication methods to actually create the new account.

This is only running in Chrome Browser.

The Tests are currently passing at the time of pushing.

<img width="756" height="166" alt="image" src="https://github.com/user-attachments/assets/af2f730e-c95f-47df-aabe-55f2b2d7b4b2" />


## Reporting Tool

Extents Report has been implemented in this framework.

This is how the report is currently looking. Attached to the project, or after running the project the file will be automatically generated under \bin\Debug\net9.0 folder
<img width="1902" height="912" alt="image" src="https://github.com/user-attachments/assets/c457821e-7d7b-4030-ab12-23a4cd11c0b9" />



