using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace apiNET2.Tests;
public class Test
{

    [TestFixture]
    public class ExampleTest
    {
        IWebDriver? Driver;

        [Test]
        public void SampleTest()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Close();
        }


    }
}