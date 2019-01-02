using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Bogus;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        private string url = "https://www.taxact.com";

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

        /// Next = CssSelector -> button.btn
        [FindsBy(How = How.CssSelector, Using = "button.btn")]
        public IWebElement BtnNext { get; set; }

        /// input -> id = Email
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailInput = null;

        /// id Username ->  Username
        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserName { get; set; }

        /// id Password -> Password
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        public IWebElement PhoneNumber { get; set; }
        
        //[FindsBy(How = How.CssSelector, Using = "button.btn")]
        //public IWebElement BtnNext { get; set; }

        /// Security question 1 ->  secquestion1lg
        [FindsBy(How = How.Id, Using = "secquestion1lg")]
        public IWebElement SecurityQuestion1 { get; set; }

        [FindsBy(How = How.Id, Using = "secquestion2lg")]
        public IWebElement SecurityQuestion2 { get; set; }

        [FindsBy(How = How.Id, Using = "secquestion3lg")]
        public IWebElement SecurityQuestion3 { get; set; }

        [FindsBy(How = How.Id, Using = "SecretQuestion1_Answer")]
        public IWebElement SecretQuestion1_Answer { get; set; }

        [FindsBy(How = How.Id, Using = "SecretQuestion2_Answer")]
        public IWebElement SecretQuestion2_Answer { get; set; }

        [FindsBy(How = How.Id, Using = "SecretQuestion3_Answer")]
        public IWebElement SecretQuestion3_Answer { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "btnAccept")]
        public IWebElement BtnAccept { get; set; }


        public string OrderPayType
        {
            get { return new SelectElement(SecurityQuestion1).SelectedOption.GetText(); ; }
            private set { new SelectElement(SecurityQuestion1).SelectByText(value); }
        }

        private IList<string> PickRandom_SecurityQuestion1 {
            get { return new SelectElement(SecurityQuestion1).Options.Where(x => !x.GetText().Contains("Select a security question"))
                .Select(x => x.GetText()).ToList(); }
        }

        private IList<string> PickRandom_SecurityQuestion2
        {
            get
            {
                return new SelectElement(SecurityQuestion2).Options.Where(x => !x.GetText().Contains("Select a security question"))
              .Select(x => x.GetText()).ToList();
            }
        }

        private IList<string> PickRandom_SecurityQuestion3
        {
            get
            {
                return new SelectElement(SecurityQuestion3).Options.Where(x => !x.GetText().Contains("Select a security question"))
              .Select(x => x.GetText()).ToList();
            }
        }

        /// Email Register
        public string registerEmail { get { return EmailInput.GetText(); } private set { EmailInput.SetText(value); } }

        public Faker<RegistrationPage> Generator()
        {
            var registerEmail = new Faker<RegistrationPage>()
                .CustomInstantiator(f => new RegistrationPage(driver))
                .RuleSet("HappyPath", (set) => {
                    set.StrictMode(false);
                    set.RuleFor(a => a.registerEmail, f => f.Person.Email);
                });
            return registerEmail;
        }

        /// Method to navigate into the website
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url + "/");
        }

        
        public string GetEmailCreated()
        {
            return driver.FindElement(By.Id("Email")).Text;
        }
    }
}
