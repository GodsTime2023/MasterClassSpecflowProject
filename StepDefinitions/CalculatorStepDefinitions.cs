using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MasterClassSpecflowProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        IWebDriver driver = new ChromeDriver(); //Open browser

        [Given(@"I am on webform page")]
        public void GivenIAmOnWebformPage()
        {
            driver.Manage().Window.Maximize(); //Maximizing the browser
            driver.Navigate()
                .GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
        }

        [When(@"I complete the form")]
        public void WhenICompleteTheForm()
        {
            IReadOnlyCollection<IWebElement> listOfElements =
                driver.FindElements(By.XPath("//*[@class= 'form-control']"));

            listOfElements.First().SendKeys("Joseph");

            listOfElements.ElementAt(1).SendKeys("mysecreat Password");

            listOfElements.ElementAt(2).SendKeys("Welcome everyone");

            IWebElement dropdown = driver.FindElement(By.Name("my-select"));
            dropdown.SendKeys("Two");

            listOfElements.ElementAt(5).SendKeys("Chicago");

            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent + "\\TestData\\file.txt";

            listOfElements.ElementAt(6).SendKeys(path);

            IWebElement slider = driver.FindElement(By.Name("my-range"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("$(arguments[0]).val(arguments[1]).change();", slider, 0);
        }

        [When(@"I click the submit button")]
        public void WhenIClickTheSubmitButton()
        {
            driver.FindElement(By.CssSelector("[type='submit']")).Click();
        }

        [Then(@"my form is submitted")]
        public void ThenMyFormIsSubmitted()
        {
            var text = driver.FindElement(By.XPath("//h1")).Text;
            Assert.That(text, Is.EqualTo("Form submitted"));
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {
            driver.Quit();
        }
    }
}
