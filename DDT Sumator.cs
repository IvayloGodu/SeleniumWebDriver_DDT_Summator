using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace ContactBook.WebDriverTests
{
    public class UITests
    {
       
        private WebDriver driver;
        IWebElement firstField;
        IWebElement secondField;
        IWebElement operations;
        IWebElement calcButton;
        IWebElement resetButton;
        IWebElement resultField;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            firstField = driver.FindElement(By.Id("number1"));
            secondField = driver.FindElement(By.Id("number2"));
            operations = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            resultField = driver.FindElement(By.Id("result"));
            

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        [TestCase("3","+","4", "Result: 7")]
        [TestCase("5","-","4", "Result: 1")]
        [TestCase("5","*","4", "Result: 20")]
        [TestCase("20","/","4", "Result: 5")]
        [TestCase("20","/","4", "Result: 5")]
        [TestCase("2adaf","/","sdgdf", "Result: invalid input")]
        public void Test_Summator_Funtions(string num1, string operetion, string num2, string result)
        {
            firstField.SendKeys(num1);
            secondField.SendKeys(num2);
            operations.SendKeys(operetion);
            calcButton.Click();

            Assert.That(result, Is.EqualTo(resultField.Text));

            resetButton.Click();    
        }
    }
}