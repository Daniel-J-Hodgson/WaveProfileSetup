using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Text.Json;
using WaveProfileProject.Model;
using WaveProfileProject.PageObjects;

namespace WaveProfileProject
{
    public class KorberLoginTest
    {
        IWebDriver driver;
        public static Properties prop;

        [SetUp]
        public void Setup()
        {
            //Load values from JSON
            string currentDir = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDir.Split("\\bin")[0], "Properties.json");
            string jsonfilePath = File.ReadAllText(path);
            prop = JsonSerializer.Deserialize<Properties>(jsonfilePath);
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--user-data-dir=C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(prop.KoberUrl);

        }

        [Test]
        public void LoginTest1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            LoginPage loginPgObj = new LoginPage(driver);
            loginPgObj.LoginToKorberUI(prop.KoberUserName, prop.KoberPassword);

            //wait for home page to load - uses the menu button at the top to confirm load
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menuButtonToggle")));

        }

        [TearDown]
        public void teardown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}