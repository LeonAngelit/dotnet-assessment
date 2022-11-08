using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    public void EmptyEmailsShouldReturnError()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        Thread.Sleep(1000);


        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string error = driver.FindElement(By.XPath("//*[@id='empty']")).Text;

        Assert.AreEqual(error, "The emails field cannot be empty");
    }


    [Test, Order(2)]
    public void InvalidEmailsShouldReturnError()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        emailOne.SendKeys("a");
        Thread.Sleep(1000);
        emailTwo.SendKeys("a");

        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        IWebElement error = driver.FindElement(By.XPath("//*[@id='notAnEmail']"));
        string errormsg = driver.FindElement(By.XPath("//*[@id='notAnEmail']")).Text;
        Console.WriteLine("element" + error);
        Console.WriteLine("error" + errormsg);
        Assert.AreEqual(errormsg, "Write a valid email \"example@example.com\"");
    }

    [Test, Order(3)]
    public void DifferentEmailsShouldReturnError()
    {

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));


        emailOne.SendKeys("admin@mail.com");
        Thread.Sleep(1000);

        emailTwo.SendKeys("adminTwo@mail.com");



        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
        string error = driver.FindElement(By.XPath("//*[@id='unmatch']")).Text;

        Assert.AreEqual(error, "The emails don't match");
    }

    [Test, Order(4)]
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

    [Test, Order(5)]
    public void UserOnlySeesOneQuestion()
    {
        Thread.Sleep(1000);
        IWebElement questions = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]"));
        Thread.Sleep(3000);

        List<IWebElement> questionsAmmount = questions.FindElements(By.XPath("./child::*")).ToList();

        Assert.That(questionsAmmount.Count == 1);
    }

    [Test, Order(6)]
    public void ButtonChangesHover()
    {
        Thread.Sleep(1000);
        IWebElement inputButton = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/form/div[3]/input"));
        Actions action = new Actions(driver);

        var background = inputButton.GetCssValue("background-color");

        action.MoveToElement(inputButton).Perform();
        var backgroundHover = inputButton.GetCssValue("background-color");

        Assert.That(!background.Equals(backgroundHover));
    }


    [Test, Order(7)]
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

    [Test, Order(8)]
    public void AnswerAllQuestionsShouldReturnQuestionNumber()
    {
        IWebElement save = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input"));

        for (int i = 0; i < 13; i++)
        {
            IWebElement answer = driver.FindElement(By.Id("1"));
            Thread.Sleep(1000);

            answer.Click();

            save.Click();

        }

        Thread.Sleep(2000);
        string title = driver.FindElement(By.XPath("//*[@id='root']/div/div/h2")).Text;

        Assert.That(title.Contains("15 of 15"));
    }

    [Test, Order(9)]
    public void WhenLastQuestionButtonReadsOtherText()
    {
        Thread.Sleep(3000);
        string save = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).GetProperty("value");
        Console.WriteLine(save);
        Assert.That(save.Contains("Send Questions"));
    }

    [Test, Order(10)]
    public void AnswerLastQuestionShouldReturnResults()
    {
        IWebElement save = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input"));

        IWebElement answer = driver.FindElement(By.Id("1"));
        Thread.Sleep(1000);

        answer.Click();
        save.Click();

        Thread.Sleep(2000);
        string results = driver.FindElement(By.XPath("//*[@id='root']/div/div/h2")).Text;

        Assert.That(results.Contains("Results"));
    }

    [Test, Order(11)]
    public void UsedEmailsShoulgoToResults()
    {
        driver.Navigate().Refresh();

        IWebElement emailOne = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[1]/input"));
        IWebElement emailTwo = driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[2]/input"));

        emailOne.Clear();
        emailTwo.Clear();

        emailOne.SendKeys("admin@mail.com");
        Thread.Sleep(1000);

        emailTwo.SendKeys("admin@mail.com");

        driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/input")).Click();

        Thread.Sleep(3000);
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
