using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        private string url = "https://www.taxact.com/";

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// id =  sign-in-desk
        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        public IWebElement SignInButton { get; set; }
        
        /// create an account = a.btn (CssSelector)
        [FindsBy(How = How.CssSelector, Using = "a.btn")]
        public IWebElement CreateNewAccount { get; set; }

        /// Method to navigate into the website
        public void GoToPage(string queryParam ="")
        {
            driver.Navigate().GoToUrl(url + "/");
        }
        

    }
}
