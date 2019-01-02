using OpenQA.Selenium;

namespace Training_QA_Automation.Framework.PageObjects
{
    static class WebElementExtension
    {
        public static void SetText(this IWebElement e,string text)
        {
            e.Click();
            e.Clear();
            e.SendKeys(text);
        }

        public static string GetText(this IWebElement e)
        {
            string webElementText = e.Text;
            if (string.IsNullOrEmpty(webElementText))
            {
                string webElementTextAttribute = e.GetAttribute("value");
                if (!string.IsNullOrEmpty(webElementTextAttribute)) return webElementTextAttribute;
            }
            return webElementText;
        }
    }
}
