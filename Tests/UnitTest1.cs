using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriverManager.DriverConfigs.Impl;

namespace Tests;

[TestFixture]
public class ExampleTest
{



    IWebDriver driver = new ChromeDriver();

    [SetUp]
    public void BaseSetUp()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver.Navigate().GoToUrl("http://localhost:3000");
    }

    [Test]
    public void DifferentEmailsShouldReturnError()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        emailOne.SendKeys("admin@mail.com");
        Thread.Sleep(1000);

        emailTwo.SendKeys("adminTwo@mail.com");



        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string error = driver.FindElement(By.XPath("//*[@id='root']/div/div/span")).Text;

        Assert.AreEqual(error, "The emails don't match");
    }

    [Test]
    public void RightEmailsShoulgoNextStep()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        emailOne.SendKeys("admin@mail.com");
        Thread.Sleep(1000);

        emailTwo.SendKeys("admin@mail.com");

        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string error = driver.FindElement(By.XPath("//*[@id='root']/div/div/span")).Text;

        Assert.AreEqual(error, "The emails don't match");
    }

    [TearDown]
    public void DerivedTearDown()
    {
        driver.Close();
    }


}
