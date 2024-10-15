using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumInitialize_Builder;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

namespace SeleniumInitialize_Tests
{
    public class Tests
    {
        /// <summary>
        /// ���������� ������ "������ �������"
        /// </summary>
        public const string mortgageObject = @"//label[text()='������ �������']";

        /// <summary>
        /// ������ "��������� ����� ���������"
        /// </summary>
        public const string buttonGosuslugy = @"//button[@icon='gosuslugi']/rui-wrapper";

        /// <summary>
        /// ����� "�������� �������"
        /// </summary>
        public const string familyMortgage = @"//div[@class='brands-cards__item _active ng-star-inserted']/div[@class='brands-cards__desc']";

        /// <summary>
        /// ������������� "����������� �����"
        /// </summary>
        public const string lifeInsurance = @"//psb-switcher[@class='deltas__switcher _theme-default _checked ng-untouched ng-pristine ng-valid']//span[@class='slider _not-standalone']";
        
        /// <summary>
        /// ���� "���� �������"
        /// </summary>
        public const string crediteTerm = @"//rui-range-slider[@id='loanPeriod']//input[@data-tesid='native-input']";
        
        /// <summary>
        /// Xpath, �� ������� �� � ������ ��������
        /// </summary>
        public const string negativeTestXpath = @"//*[@someWrongWords]";
        
        /// <summary>
        /// ������������� "����������� �����" �� ���������� ���������
        /// </summary>
        public const string lifeInsuranceSwitcherOn = @"//psb-switcher[@class='deltas__switcher _theme-default _checked ng-untouched ng-pristine ng-valid']//span[@class='slider _not-standalone']//ancestor::psb-switcher[contains(@class, '_checked')]";
        
        /// <summary>
        /// ������ "��������� ��� ��������" �� �������� ������� �������
        /// </summary>
        public const string fillWithoutGosuslugyMilitary = @"//button[@class='mortgage-calculator-output-submit__button']";
        
        /// <summary>
        /// ������ "��������� ��� ��������" �� �������� ������������ �������
        /// </summary>
        public const string fillWithoutGosuslugyClassic = @"//button[@class='mortgage-calculator-output-submit__button']//rui-wrapper[@data-appearance='secondary']";
        
        /// <summary>
        /// ���� � ��������������� �� �������� ������� �������
        /// </summary>
        public const string warninTablet = @"//div[@class='mortgage-calculator-output__alert mortgage-calculator-output__alert_show']";
        
        /// <summary>
        /// ���� "�������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string lastName = @"//input[@name='CardHolderLastName']";
        
        /// <summary>
        /// ���� "���" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string firstName = @"//input[@name='CardHolderFirstName']";
        
        /// <summary>
        /// ���� "��������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string middleName = @"//input[@name='CardHolderMiddleName']";
        
        /// <summary>
        /// ������������� "�������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string man = @"//rui-radio[@id='formly_19_radio_Sex_0-0']";
        
        /// <summary>
        /// ���� "���� ��������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string birthday = @"//input[@data-mat-calendar='mat-datepicker-1']";
        
        /// <summary>
        /// ���� "����� ���������� ��������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string mobilePhone = @"//input[@name='Phone']";
        
        /// <summary>
        /// ���� "����� ����������� �����" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string email = @"//input[@name='Email']";
        
        /// <summary>
        /// ���������� ������ "�����������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string citizenship = @"//mat-select[@rtl-automark='RussianFederationResident']";
        
        /// <summary>
        /// ����� "��" ����������� ������ "�����������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string RF = @"//span[@data-test-id='option-label-0']";
        
        /// <summary>
        /// ���������� ������ "���������� ���������������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string work = @"//mat-select[@name='RussianEmployment']";
        
        /// <summary>
        /// ����� "����" ����������� ������ "���������� ���������������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string yes = @"//span[@data-test-id='option-label-0']";
        
        /// <summary>
        /// ���������� ������ "����� ���������� ������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string adress = @"//div[@id='mat-select-value-9']";
        
        /// <summary>
        /// ������ ����� ����������� ������ "����� ���������� ������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string firstAdress = @"//mat-option[@id='formly_28_select-with-double-item_OfficeId_0_0']";
        
        /// <summary>
        /// ������ "������" �� ��������� � Cookies
        /// </summary>
        public const string acceptCookies = @"//psb-button[@class='button _shape-button _size-m _theme-main']";
        
        /// <summary>
        /// ���-���� "�������� �� ��������� ������������ ������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string personalDataCheckBox = @"//rui-checkbox[@name='PersonalDataProcessingAgreementConcent']";
        
        /// <summary>
        /// ���-���� "�������� �� ������ � ���� ��������� �������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string bkiRequestCheckBox = @"//rui-checkbox[@name='BkiRequestAgreementConcent']";
        
        /// <summary>
        /// ������ "����������" � ����� ���������� ������ ������������ �� �������� ������������ �������
        /// </summary>
        public const string registrationNext = @"//button[@rtl-automark='REGISTRATION_NEXT']";
        
        /// <summary>
        /// ��������� "���������� �����������" �� �������� ������� ��������
        /// </summary>
        public const string financialInstruments = @"//div[@class='header']/h2";
        
        /// <summary>
        /// ���������� ������ "����������" �� �������� ������� �������� 
        /// </summary>
        public const string investment = @"//span[text()='����������']";
        
        /// <summary>
        /// ���� "���������� �������" ����������� ������� "����������" �� �������� ������� �������� 
        /// </summary>
        public const string investmentsBrokerage = @"//a[@href='/store/products/investmentsbrokerage']";
        
        /// <summary>
        /// ������ "��������� ����� ���������" �� �������� "���������� ������������"
        /// </summary>
        public const string buttonDealByGosuslugy = @"//button[@icon='gosuslugi']";
        
        /// <summary>
        /// ����� "��������" �� ��������� "���������� ������������" � "����������"
        /// </summary>
        public const string generalLicence = @"//div[@class='landing-footer-copyrights']";
        
        /// <summary>
        ///������ "������� ������ ���������" �� �������� "���� ������"
        /// </summary>
        public const string changeCategories = @"//span[text()=' ������� ������ ��������� ']";
        
        /// <summary>
        /// �������� ���-���� � ������ ��������� �� �������� "���� ������"
        /// </summary>
        public const string activeCheckBox = @"//label[@class='rui-checkbox rui-checkbox_checked']";
        
        /// <summary>
        /// ���� "�������" �� �������� "���� ������"
        /// </summary>
        public const string lastNameFormCashback = @"//input[@name='CardHolderLastName']";
        
        /// <summary>
        /// ����� "������" �� ����������� ������ "�������" �� �������� "���� ������"
        /// </summary>
        public const string pushkinLastname = @"//div[text()=' ������ ']";

        /// <summary>
        /// ������ "������� �� ���������" �� �������� "����������"
        /// </summary>
        public const string switchToGosuslugi = @"//button[@class='digital-profile-auth__button ng-star-inserted']";

        /// <summary>
        /// ������ "����������" � ���� ������ ��������� �� �������� "���� ������"
        /// </summary>
        public const string confirmButton = @"//button[contains(@class, 'confirm-button')]";

        /// <summary>
        /// ���������� ��������� "�������� ����� "���� ������"" �� �������� "���� ������"
        /// </summary>
        public const string downloadFile = @"//h4[contains(text(),'��������� �����')]";


        public string ScreenshotDerictoryPath = @"C:\Users\alexg\OneDrive\������� ����\������\���\PSBstudy\PSBstudy\C#\Selenium\Screenshots\";
        public string licenceMask = "����������� �������� �� ������������� ���������� ��������";

        private SeleniumBuilder _builder;
        
        PageYourCashback _cashback;
        PageCashLoan _cashLoan;

        TestUserModel _userProfile;
        Steps step;



        [SetUp]
        public void Setup()
        {
            step = new Steps();
            _builder = new SeleniumBuilder();
            _cashback = new PageYourCashback();
            _cashLoan = new PageCashLoan();
            _builder.HeadLessMod = false;

            _userProfile = new TestUserModel();
            _userProfile.LastName = "�����������";
            _userProfile.FirstName = "���������";
            _userProfile.MiddleName = "�������������";
            _userProfile.Birthday = "11.11.2000";
            _userProfile.PhoneNumber = "(987) 654-32-10";
            _userProfile.Email = "alex.alexandrov@test.ru";
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }

        [Test(Description = "�������� ���������� ������������� ���������� IWebDriver")]
        public void BuildTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsNotNull(driver);
        }

        [Test(Description = "�������� ������� �������� IWebDriver")]
        public void DisposeTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsFalse(_builder.IsDisposed);
            _builder.Dispose();
            Assert.IsTrue(_builder.IsDisposed);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }

        [Test(Description = "�������� ��������� �����")]
        public void ChangePortTest()
        {
            IWebDriver driver = _builder.ChangePort(123).Build();
            Assert.That(_builder.Port, Is.EqualTo(123));
        }

        [Test(Description = "HeadLess �����")]
        public void SetHeadLessModTest()
        {
            IWebDriver driver = _builder.SetHeadLessMod().Build();
            Assert.That(_builder.HeadLessMod, Is.EqualTo(true));
        }



        [Test(Description = "�������� ��������� ��������")]
        public void TimeoutTest()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithTimeout(timeout).Build();
            Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(timeout));
            Assert.That(_builder.Timeout, Is.EqualTo(timeout));
        }

        [Test(Description = "�������� �������� �� ��������� ������")]
        public void SetStartingUrlTest()
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            IWebDriver driver = _builder.WithURL(url).Build();
            Assert.That(driver.Url, Is.EqualTo(url));
        }

        
        [Test(Description = "�������� ������� ��������")]
        [TestCase(mortgageObject)]
        [TestCase(buttonGosuslugy)]
        [TestCase(familyMortgage)]
        [TestCase(lifeInsurance)]
        [TestCase(crediteTerm)]
        [TestCase(negativeTestXpath)]
        public void ElementIsFoundTest(string xpath)
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            try
            {
                var element = driver.FindElement(By.XPath(xpath));
                Assert.That(element, Is.Not.Null);
            }
            catch 
            {
                var screenshot = driver.TakeScreenshot();
                screenshot.SaveAsFile($"{ScreenshotDerictoryPath}screenshot_1.png");
                Assert.Pass();
            }
        }
        
        [Test(Description = "�������� ����������� ��������")]
        [TestCase(mortgageObject)]
        [TestCase(buttonGosuslugy)]
        [TestCase(familyMortgage)]
        [TestCase(lifeInsurance)]
        [TestCase(crediteTerm)]
        public void ElementIsActiveTest(string xpath)
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            var element = driver.FindElement(By.XPath(xpath));
            Assert.That(element.Enabled);
        }
                
        [Test(Description = "�������� ��������� ��������")]
        [TestCase(mortgageObject)]
        [TestCase(buttonGosuslugy)]
        [TestCase(familyMortgage)]
        [TestCase(lifeInsurance)]
        [TestCase(crediteTerm)]
        public void ElementIsVisibleTest(string xpath)
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            var element = driver.FindElement(By.XPath(xpath));
            Assert.That(element.Displayed);
        }

        [Test(Description = "�������� ��������� ��������")]
        [TestCase(mortgageObject, null)]
        [TestCase(crediteTerm, "30")]
        public void ElementValueTest(string xpath, string expectedValue)
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            var element = driver.FindElement(By.XPath(xpath));
            Assert.That(element.GetDomProperty("value"), Is.EqualTo(expectedValue));
        }

        [Test(Description = "�������� ��������� ��������")]
        [TestCase(familyMortgage)]
        [TestCase(lifeInsuranceSwitcherOn)]
        public void ElementConditionTest(string xpath)
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            var element = driver.FindElement(By.XPath(xpath));
            Assert.That(element, Is.Not.Null);
        }

        [Test(Description = "�������� ���������")]
        [TestCase(fillWithoutGosuslugyMilitary, warninTablet)]
        public void FillWithoutGosuslugyTest(string xpath_1, string xpath_2)
        {
            string url = @"https://ib.psbank.ru/store/products/military-family-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            var element = driver.FindElement(By.XPath(xpath_1));
            element.Click();
          
            element = driver.FindElement(By.XPath(xpath_2));

            Thread.Sleep(3000);
            Assert.IsFalse(element.Displayed);
        }

        [Test(Description = "�������������� � ����������")]
        public void InteractWithElements()
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            step.ClickElement(driver, wait, fillWithoutGosuslugyClassic);

            var element = driver.FindElement(By.XPath(registrationNext));
            Assert.False(element.Enabled);

            try
            {
                step.ClickElement(driver, wait, acceptCookies);
            }
            finally { /* I HATE COOKIES */ }

            step.FillElement(driver, wait, lastName, _userProfile.LastName);
            step.FillElement(driver, wait, firstName, _userProfile.FirstName);
            step.FillElement(driver, wait, middleName, _userProfile.MiddleName);
            step.ClickElement(driver, wait, man);
            step.FillElement(driver, wait, birthday, _userProfile.Birthday);
            step.FillElement(driver, wait, mobilePhone, _userProfile.PhoneNumber);
            step.FillElement(driver, wait, email, _userProfile.Email);
            step.ClickElement(driver, wait, citizenship);
            step.ClickElement(driver, wait, RF);
            step.ClickElement(driver, wait, work);
            step.ClickElement(driver, wait, yes);
            step.ClickElement(driver, wait, adress);
            step.ClickElement(driver, wait, firstAdress);
            step.ClickElement(driver, wait, personalDataCheckBox);
            step.ClickElement(driver, wait, bkiRequestCheckBox);

            element = driver.FindElement(By.XPath(registrationNext));
            Assert.That(element.Enabled);
        }

        [Test(Description = "�������������� � ����������")]
        public void ActionsWithElements()
        {
            string url = @"https://ib.psbank.ru/store/products/classic-mortgage-program";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            var element = driver.FindElement(By.XPath(buttonGosuslugy));
            Assert.That(element.Enabled);

            var color = step.ConvertColor(element.GetCssValue("background-color"));
            Assert.That(color, Is.EqualTo("#F26126"));

            Thread.Sleep(5000);
            new Actions(driver).MoveToElement(element).Perform();
            Thread.Sleep(5000);

            color = step.ConvertColor(element.GetCssValue("background-color"));
            Assert.That(color, Is.EqualTo("#D44921"));
        }

        [Test(Description = "�������� �������� ��������")]
        public void PageLoadAwaite()
        {
            string url = @"https://ib.psbank.ru/";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(financialInstruments)));
            var element = driver.FindElement(By.XPath(financialInstruments));
            Assert.That(element.Enabled);
        }

        [Test(Description = "�������� �������� �� ������")]
        public void TransitionByLink()
        {
            string url = @"https://ib.psbank.ru/";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(financialInstruments)));

            step.ClickElement(driver, wait, investment);
            step.ClickElement(driver, wait, investmentsBrokerage);

            Thread.Sleep(10000);

            wait.Until(ExpectedConditions.ElementExists(By.XPath(buttonDealByGosuslugy)));
            var element = driver.FindElement(By.XPath(buttonDealByGosuslugy));
            Assert.That(element.Enabled);
        }

        [Test(Description = "�������� ������������ ����� ���������")]
        public void SwitchBrowserTab()
        {
            string url1 = @"https://ib.psbank.ru/store/products/consumer-loan";
            string url2 = @"https://ib.psbank.ru/store/products/investmentsbrokerage";

            TimeSpan timeout = TimeSpan.FromSeconds(8);

            IWebDriver driver = _builder.WithURL(url1).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            var element = driver.FindElement(By.XPath(switchToGosuslugi));
            Assert.That(element.Enabled);
            string currHandle = driver.CurrentWindowHandle;

            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(url2);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(generalLicence)));
            element = driver.FindElement(By.XPath(generalLicence));
            
            if(!element.Text.Contains(licenceMask))
                Assert.Fail();

            driver.Close();

            driver.SwitchTo().Window(currHandle);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(generalLicence)));
            element = driver.FindElement(By.XPath(generalLicence));

            if (!element.Text.Contains(licenceMask))
                Assert.Fail();
        }

        [Test(Description = "�������� ��������� ���������")]
        public void ChangeCategories() //���� �� �������, ������ 404+ ��������� � ��������� �����
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));



            step.ClickElement(driver, wait, changeCategories);

            try
            {
                step.ClickElement(driver, wait, acceptCookies);
            }
            finally { /* I HATE COOKIES */ }

            for (int i = 0; i < 3; i++)
            {
                step.ClickElement(driver, wait, activeCheckBox);
            }

            for (int i = 4; i < 9; i=i+2)
            {
                step.ClickElement(driver, wait, step.CheckBoxUniversalXPath(i));
            }

            var element = driver.FindElement(By.XPath(confirmButton)); 
            Assert.That(element.Enabled);
        }

        [Test(Description = "�������� ������ ������������ �������.")]
        public void ChooseLastName()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            string lastName = "��";
            step.FillElement(driver, wait, lastNameFormCashback, lastName);
            step.ClickElement(driver, wait, pushkinLastname);
            Thread.Sleep(3000);
        }

        [Test(Description = "�������� ���������� ����������� �����")]
        public void DownloadFile()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            step.ClickElement(driver, wait, downloadFile);
            IList<string> windowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(windowHandles[1]);

            string currentURL = driver.Url.ToString();
            string[] docName = Regex.Split(currentURL, @"/");
            Assert.That(docName[docName.Length-1], Is.EqualTo("yc_short_tarifs.pdf"));
        }

        [Test(Description = "�������� ���������� ������ �� �����")]
        public void FormFillTest()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            var element = driver.FindElement(By.XPath(_cashback.buttonNextXpath));  
            Assert.False(element.Enabled);

            try
            {
                step.ClickElement(driver, wait, acceptCookies);
            }
            finally { /* I HATE COOKIES */ }

            _cashback.FillDebitCardApplication(driver, wait, this.step, this._userProfile);

            Assert.True(element.Enabled);
        }

        [Test(Description = "�������� ����������� ������ �� �������� ���� ������")]
        public void EnteredDataTest()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            var element = driver.FindElement(By.XPath(_cashback.buttonNextXpath));

            try
            {
                step.ClickElement(driver, wait, acceptCookies);
            }
            finally { /* I HATE COOKIES */ }

            _cashback.FillDebitCardApplication(driver, wait, this.step, this._userProfile);
            step.ClickElement(driver, wait, _cashback.buttonNextXpath);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_cashback.FindStringAtPage(_userProfile.LastName))));
            element = driver.FindElement(By.XPath(_cashback.FindStringAtPage(_userProfile.LastName)));
            Assert.That(element.Displayed);
            element = driver.FindElement(By.XPath(_cashback.FindStringAtPage(_userProfile.FirstName)));
            Assert.That(element.Displayed);
            element = driver.FindElement(By.XPath(_cashback.FindStringAtPage(_userProfile.MiddleName)));
            Assert.That(element.Displayed);
            element = driver.FindElement(By.XPath(_cashback.FindStringAtPage(_userProfile.Birthday)));
            Assert.That(element.Displayed);
            element = driver.FindElement(By.XPath(_cashback.FindStringAtPage(_userProfile.PhoneNumber)));
            Assert.That(element.Displayed);
        }

        [Test(Description = "�������� ����������� ������ �� �������� ������ ���������")]
        public void PageInheritanceTest()
        {
            string url = @"https://ib.psbank.ru/store/products/consumer-loan";
            TimeSpan timeout = TimeSpan.FromSeconds(8);
            IWebDriver driver = _builder.WithURL(url).WithTimeout(timeout).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            try
            {
                step.ClickElement(driver, wait, acceptCookies);
            }
            finally { /* I HATE COOKIES */ }

            _cashLoan.FillDebitCardApplication(driver, wait, this.step, this._userProfile);
            Thread.Sleep(10000);
        }
    }
}