using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutoTest.pages;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace AutoTest
{
    [TestFixture]
    public class Test
    {
        DateTime CurentMoment = DateTime.Now;
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_1()
        {//autorization test
            Test_1_info pageHome = new Test_1_info();
            PageFactory.InitElements(driver, pageHome);
            driver.Navigate().GoToUrl("https://fex.net/");
            Thread.Sleep(2000);
            pageHome.StartLoginButton.Click();
            Thread.Sleep(2000);
            pageHome.NameField.Clear();
            pageHome.NameField.SendKeys("+380963872434");
            pageHome.PasswordField.Clear();
            pageHome.PasswordField.SendKeys("1234567890a");
            Thread.Sleep(2000);
            pageHome.AuthorizationButton.Click();
            Thread.Sleep(5000);
            Assert.AreEqual(pageHome.LogedUserName.Text, "TestLogin");
            Thread.Sleep(2000);
        }

        [Test]
        public void Test_2()
        {//correct file object creation in cloud check
            Test_2_info pageHome = new Test_2_info();
            PageFactory.InitElements(driver, pageHome);
            Test_1();
            pageHome.MenuUploadButton.Click();
            Thread.Sleep(2000);
            pageHome.ObjectNameField.Clear();
            pageHome.ObjectNameField.SendKeys("Test " + CurentMoment.ToShortDateString());
            Thread.Sleep(2000);
            string CodeOfCreatedFile = pageHome.ObjectNumber.Text;
            pageHome.LogoIcon.Click();
            Thread.Sleep(2000);
            pageHome.MenuGetObjectButton.Click();
            Thread.Sleep(2000);
            pageHome.GetingObjectNumberField.Clear();
            pageHome.GetingObjectNumberField.SendKeys(CodeOfCreatedFile);
            Thread.Sleep(2000);
            Assert.AreEqual(pageHome.OpenedObjectName.Text, "Test " + CurentMoment.ToShortDateString());
        }

        [Test]
        public void Test_3()
        {//mail draft saving check 
            Test_3_info pageHome = new Test_3_info();
            PageFactory.InitElements(driver, pageHome);
            driver.Navigate().GoToUrl("https://mail.fex.net");
            Thread.Sleep(5000);
            pageHome.UserNameField.Clear();
            pageHome.UserNameField.SendKeys("+380963872434");
            pageHome.UserPasswordField.Clear();
            pageHome.UserPasswordField.SendKeys("1234567890a");
            pageHome.LogingButton.Click();
            Thread.Sleep(2000);
            pageHome.CreateMessageButton.Click();
            Thread.Sleep(2000);
            string letterCreationMoment = CurentMoment.ToString();
            pageHome.MessageTextField.Clear();
            pageHome.MessageTextField.SendKeys("test message" + letterCreationMoment);
            pageHome.MessageSubjectField.Clear();
            pageHome.MessageSubjectField.SendKeys("test subject" + letterCreationMoment);
            pageHome.MessageAdressField.Clear();
            pageHome.MessageAdressField.SendKeys("test adress");
            Thread.Sleep(2000);
            pageHome.MessageCloseButton.Click();
            Thread.Sleep(2000);
            pageHome.DraftFolder.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(pageHome.LastDraftMessageSubject.Text, "test subject" + letterCreationMoment);
            Assert.AreEqual(pageHome.LastDraftMessageText.Text, "test message" + letterCreationMoment);
            Thread.Sleep(2000);
        }
    }
}
