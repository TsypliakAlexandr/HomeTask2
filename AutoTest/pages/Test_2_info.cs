using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class Test_2_info
    {
        [FindsBy(How = How.CssSelector, Using = "div.upload.main_menu_create")]
        public IWebElement MenuUploadButton{ get; set; }

        [FindsBy(How = How.Id, Using = "post")]
        public IWebElement ObjectNameField { get; set; }

        [FindsBy(How = How.Id, Using = "obj_num")]
        public IWebElement ObjectNumber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.fex-header__logo > svg")]
        public IWebElement LogoIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.get_open_main")]
        public IWebElement MenuGetObjectButton { get; set; }

        [FindsBy(How = How.Id, Using = "get_inp_main")]
        public IWebElement GetingObjectNumberField { get; set; }

        [FindsBy(How = How.ClassName, Using = "js-redactor-name")]
        public IWebElement OpenedObjectName { get; set; }

    }
}
