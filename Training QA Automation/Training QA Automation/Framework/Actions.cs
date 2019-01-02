using OpenQA.Selenium;
using System;
using System.Linq;

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
        
        public static void writeInput(IWebDriver driver, IWebElement element, string id, string text)
        {
            WaitForPageToFinishLoading(driver);
            try
            {
                element.Click();
                driver.FindElement(By.Id(id)).SendKeys(text);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static string getTextFromElement(IWebDriver driver,string classSelector)
        {
            return driver.FindElement(By.ClassName(classSelector)).Text;
        }

        public static void OpenNewTab(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
        }

        public static void returnToPage(IWebDriver driver)
        {
            WaitForPageToFinishLoading(driver);
            driver.FindElement(By.CssSelector("Body")).SendKeys(Keys.Control + Keys.Tab);
        }

        public string[] giveBackArray(string text)
        {
            return text.ToCharArray().Select(c => c.ToString()).ToArray();
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
