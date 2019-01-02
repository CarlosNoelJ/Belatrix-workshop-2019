using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Bogus;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class MailinatorPage
    {
        private IWebDriver driver;
        private string mailinator = "https://www.mailinator.com/";

        [FindsBy(How = How.Id, Using = "inboxfield")]
        public IWebElement InputEmail { get; set; } 

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        public IWebElement BtnGo { get; set; }

        [FindsBy(How  = How.ClassName, Using ="ng-binding", Priority = 4)]
        public IWebElement LastMail { get; set; }
        
        //[FindsBy(How = How.ClassName, Using = "mobileContentSize")]
        //public IWebElement SecurityCode { get; set; }

        public MailinatorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public void GoToMailinator()
        {
            driver.Navigate().GoToUrl(mailinator + "/");
        }
    }
}
