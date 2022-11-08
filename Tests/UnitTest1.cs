using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriverManager.DriverConfigs.Impl;

namespace Tests;

[TestFixture]
public class ExampleTest
{



    IWebDriver driver = new ChromeDriver();


    [OneTimeSetUp]
    public void BaseSetUp()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver.Navigate().GoToUrl("http://localhost:3000");
    }

    [Test, Order(1)]
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

    [Test, Order(2)]
    public void RightEmailsShoulgoNextStep()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        emailOne.Clear();
        emailTwo.Clear();

        emailOne.SendKeys("admin@mail.com");
        Thread.Sleep(1000);

        emailTwo.SendKeys("admin@mail.com");

        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string title = driver.FindElement(By.XPath("//*[@id='root']/div/div/h2")).Text;

        Assert.That(title.Contains("Question"));
    }

    [Test, Order(3)]
    public void AnswerQuestionShouldReturnNextQuestion()
    {

        Thread.Sleep(1000);
        IWebElement answer = driver.FindElement(By.Id("1"));
        Thread.Sleep(3000);

        answer.Click();

        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string title = driver.FindElement(By.XPath("//*[@id='root']/div/div/h2")).Text;

        Assert.That(title.Contains("2"));
    }

    [Test, Order(4)]
    public void AnswerAllQuestionsShouldReturnNextResults()
    {
        IWebElement save = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input"));

        for (int i = 0; i < 14; i++)
        {
            IWebElement answer = driver.FindElement(By.Id("1"));
            Thread.Sleep(1000);

            answer.Click();

            save.Click();

        }


        Thread.Sleep(2000);
        string results = driver.FindElement(By.XPath("//*[@id='root']/div/div/h2")).Text;

        Assert.That(results.Contains("Results"));
    }



    [OneTimeTearDown]
    public void DerivedTearDown()
    {
        driver.Close();
        driver.Quit();
    }


}
