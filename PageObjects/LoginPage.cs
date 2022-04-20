using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveProfileProject.PageObjects
{
    public class LoginPage
    {
        private IWebDriver Driver;


        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/hj-logon/div/div/div[2]/hj-field-table/div/hj-field-table-row[2]/div/hj-field-cell/div/hj-field-control/div/div/span[1]/hj-textbox/input")]
        [CacheLookup]
        public IWebElement UserNameInput { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/hj-logon/div/div/div[2]/hj-field-table/div/hj-field-table-row[3]/div/hj-field-cell/div/hj-field-control/div/div/span[1]/hj-password-textbox/input")]
        [CacheLookup]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/hj-logon/div/div/div[3]/hj-button/button")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        public void LoginToKorberUI(string username, string password)
        {
            Thread.Sleep(500);
            UserNameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            Thread.Sleep(1000);
            LoginButton.Click();
        }
    }
}
