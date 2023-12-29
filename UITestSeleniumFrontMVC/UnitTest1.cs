using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UITestSeleniumFrontMVC
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests() => _driver = new ChromeDriver();
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        /*
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:7237/TemplateProject/Create");

            _driver.FindElement(By.Id("TemplateProjectName"))
                .SendKeys("TemplateProjectName Test");

            _driver.FindElement(By.Id("TemplateProjectTitle"))
                .SendKeys("TemplateProjectTitle Test");

            _driver.FindElement(By.Id("TemplateProjectDescription"))
                .SendKeys("TemplateProjectDescription Test");

            _driver.FindElement(By.Id("TemplateProjectVersion"))
                .SendKeys("TemplateProjectVersion Test");

            _driver.FindElement(By.Id("TemplateProjectVersionNet"))
                .SendKeys("TemplateProjectVersionNet Test");

            _driver.FindElement(By.Id("Create"))
                .Click();
        }
        */
    }
}