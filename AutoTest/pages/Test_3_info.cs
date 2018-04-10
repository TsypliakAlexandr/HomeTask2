/* Описывает главную страницу */
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class Test_3_info
    {
        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement UserPasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.fex-login__submitBtn")]
        public IWebElement LogingButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-create")]
        public IWebElement CreateMessageButton { get; set; }

        [FindsBy(How = How.Id, Using = "redactor")]
        public IWebElement MessageTextField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='cps_subject cps_inpt'] input[type='text']")]
        public IWebElement MessageSubjectField { get; set; }

        [FindsBy(How = How.Id, Using = "new_to")]
        public IWebElement MessageAdressField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "i.close")]
        public IWebElement MessageCloseButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#j_drafts > span")]
        public IWebElement DraftFolder { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.ib_subject")]
        public IWebElement LastDraftMessageSubject { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.ib_short_text")]
        public IWebElement LastDraftMessageText { get; set; }
    }
}
