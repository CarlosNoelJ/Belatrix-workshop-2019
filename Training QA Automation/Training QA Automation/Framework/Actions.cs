using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class Actions
    {
        public static void clickOn(IWebDriver driver, IWebElement element)
        {
            WaitForPageToFinishLoading(driver);
            try
            {
                element.Click();
                WaitForPageToFinishLoading(driver);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Type()
        {

        }
        
        public static void WaitForPageToFinishLoading(IWebDriver driver, int timeout=20)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }
    }
}
