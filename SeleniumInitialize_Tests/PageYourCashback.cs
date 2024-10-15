using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumInitialize_Tests
{
    internal class PageYourCashback
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastNameXpath = @"//input[@name='CardHolderLastName']";

        /// <summary>
        /// Имя
        /// </summary>
        public string firstNameXpath = @"//input[@name='CardHolderFirstName']";

        /// <summary>
        /// Отчество
        /// </summary>
        public string middleNameXpath = @"//input[@name='CardHolderMiddleName']";

        /// <summary>
        /// Пол: мужской
        /// </summary>
        public string manGenderXparh = @"//div[contains(text(),'Мужской')]";

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string birthdayXpath = @"//input[@data-mat-calendar='mat-datepicker-1']";

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string phoneNumberXpath = @"//input[@name='Phone']";

        /// <summary>
        /// Гражданство
        /// </summary>
        public string citizenshipXpath = @"//mat-select[@name='RussianFederationResident']";

        /// <summary>
        /// РФ
        /// </summary>
        public string RFXpath = @"//mat-option[@data-test-id='select-option-0']";

        /// <summary>
        /// Согласие на обработку персональных данных 
        /// </summary>
        public string personalDataXpath = @"//rui-checkbox[@name='PersonalDataProcessingAgreementConcent']";

        /// <summary>
        /// Кнопка Продолжить
        /// </summary>
        public string buttonNextXpath = @"//button[@rtl-automark='REGISTRATION_NEXT']";

        /// <summary>
        /// Принять Cookies
        /// </summary>
        public string acceptCookies = @"//psb-button[@class='button _shape-button _size-m _theme-main']";

        /// <summary>
        /// Метод возвращает XPath, указывающий на поданный в метод текст 
        /// </summary>
        public string FindStringAtPage(string text)
        {
            return $@"//b[contains(text(),'{text}')]";
        }

        public void FillDebitCardApplication(IWebDriver driver, WebDriverWait wait, Steps step, TestUserModel _userProfile)
        {
            step.FillElement(driver, wait, lastNameXpath, _userProfile.LastName);
            step.FillElement(driver, wait, firstNameXpath, _userProfile.FirstName);
            step.FillElement(driver, wait, middleNameXpath, _userProfile.MiddleName);
            step.ClickElement(driver, wait, manGenderXparh);
            step.FillElement(driver, wait, birthdayXpath, _userProfile.Birthday);
            step.FillElement(driver, wait, phoneNumberXpath, _userProfile.PhoneNumber);
            step.ClickElement(driver, wait, citizenshipXpath);
            step.ClickElement(driver, wait, RFXpath);
            step.ClickElement(driver, wait, personalDataXpath);
        }
    }
}
