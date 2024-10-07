using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumInitialize_Builder;
using System.Diagnostics;

namespace SeleniumInitialize_Tests
{
    public class Tests
    {
        private SeleniumBuilder _builder;
        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
            _builder.HeadLessMod = false;
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }

        [Test(Description = "Проверка корректной инициализации экземпляра IWebDriver")]
        public void BuildTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsNotNull(driver);
        }

        [Test(Description = "Проверка очистки ресурсов IWebDriver")]
        public void DisposeTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsFalse(_builder.IsDisposed);
            _builder.Dispose();
            Assert.IsTrue(_builder.IsDisposed);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }

        [Test(Description = "Проверка изменения порта")]
        public void ChangePortTest()
        {
            IWebDriver driver = _builder.ChangePort(123).Build();
            Assert.That(_builder.Port, Is.EqualTo(123));
        }

/*
        [Test(Description = "Добавление аргумента")]
        public void ArgumentTest1()
        {
            string argument = "--start-maximized";
            IWebDriver driver = _builder.SetArgument(argument).Build();
            Assert.Contains(argument, _builder.ChangedArguments);
            var startingSize = driver.Manage().Window.Size;
            driver.Manage().Window.Maximize();
            Assert.That(driver.Manage().Window.Size, Is.EqualTo(startingSize));
        }
*/

        [Test(Description = "HeadLess режим")]
        public void SetHeadLessModTest()
        {
            IWebDriver driver = _builder.SetHeadLessMod().Build();
            Assert.That(_builder.HeadLessMod, Is.EqualTo(true));
        }



        [Test(Description = "Проверка изменения таймаута")]
        public void TimeoutTest()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(20);
            IWebDriver driver = _builder.WithTimeout(timeout).Build();
            Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(timeout));
            Assert.That(_builder.Timeout, Is.EqualTo(timeout));
        }
    }
}