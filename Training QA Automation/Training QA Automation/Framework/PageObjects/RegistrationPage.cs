using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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

        /// input -> id = Email
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailInput { get; set; }

        /// Writing a Random email
        public Faker<RegistrationPage> GenerateEmail()
        {
            var registerEmail = new Faker<RegistrationPage>()
                .CustomInstantiator(f => new RegistrationPage(driver))
                .RuleSet("HappyPath",
                (set) =>
                {
                    set.StrictMode(false);
                    set.RuleFor(a => a.EmailInput, f => f.Person.EmailInput);
                }
                );

            return registerEmail;
        }

        /// Method to navigate into the website
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url + "/");
        }
    }
}
