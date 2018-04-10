using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class Test_1_info
    {
        [FindsBy(How = How.CssSelector, Using = "a.fex-user-actions__login > span")]
        public IWebElement StartLoginButton { get; set; }
        //
        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement NameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.auth_block.lg_block > div.ct > input[name=\"pass\"]")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.authorization_button.btn")]
        public IWebElement AuthorizationButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "fex-user-name")]
        public IWebElement LogedUserName { get; set; }
    }
}
