﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using Training_QA_Automation.Framework.PageObjects;

namespace Training_QA_Automation.Tests
{
    [TestClass]
    public class RegistrationTest : Actions
    {
        public TestContext TestContext { get; set; }
        
        IWebDriver driver;
        ChromeOptions options = new ChromeOptions();
        //string emailCreated;
        //string securityCode;
        //string[] arraySecurityCode;
        
        [TestInitialize]
        public void Initialize()
        {
            var sauceUserName = Environment.GetEnvironmentVariable("CarlosNoelJ", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("5a765391-c29c-4b1f-9000-0b5c644da8e0", EnvironmentVariableTarget.User);

            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", "CarlosNoelJ", true);
            options.AddAdditionalCapability("accessKey", "5a765391-c29c-4b1f-9000-0b5c644da8e0", true);
            options.AddAdditionalCapability("name", TestContext.TestName, true);
            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
        }

        [TestMethod]
        public void CreateNewAccount()
        {
            var registerPage = new RegistrationPage(driver);
            registerPage.GoToPage();
            clickOn(driver, registerPage.SignInButton);
            clickOn(driver, registerPage.CreateNewAccount);

            //clickOn(driver, registerPage.EmailInput);
            //registerPage.Generator().StrictMode(false).Generate("HappyPath, Dafault");
            //emailCreated = registerPage.GetEmailCreated();
            //clickOn(driver, registerPage.BtnNext);
            //OpenNewTab(driver);
            //var mailinatorPage = new MailinatorPage(driver);
            //mailinatorPage.GoToMailinator();
            //writeInput(driver, mailinatorPage.InputEmail, "inboxfield", emailCreated);
            //clickOn(driver, mailinatorPage.BtnGo);
            //clickOn(driver, mailinatorPage.LastMail);
            //securityCode = getTextFromElement(driver, "mobileContentSize");
            //returnToPage(driver);
            //arraySecurityCode = giveBackArray(securityCode);

            //foreach (var item in arraySecurityCode)
            //{

            //}


            Assert.AreEqual("Create a TaxAct account to file your taxes online", driver.Title);
            /// Sign Out -> id = sign-out-desk (findelement)

        }

        [TestCleanup]
        public void CleanUp()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;

            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            if (driver != null)
                driver.Quit();
        }
    }
}
