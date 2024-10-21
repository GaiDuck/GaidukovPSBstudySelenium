using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Tests
{
    public class ControlCheckBox
    {
        public string restaurants = "Кафе и рестораны";
        public string taxi = "Такси и каршеринг";
        public string entertainments = "Кино и развлечения";
        public string transport = "Общественный транспорт";
        public string petProducts = "Товары для животных";
        public string railwayTickets = "Ж/д билеты";
        public string medicine = "Аптеки, медицина";
        public string clothes = "Одежда и обувь";
        public string sportGoods = "Спорттовары";
        public string gifts = "Цветы и подарки";
        public string dutyFree = "Duty Free";
        public string tollRoads = "Платные дороги";
        public string appliances = "Бытовая техника";
        public string renovation = "Дом, ремонт";
        public string books = "Книги и канцтовары";
        public string productsForChildren = "Товары для детей";
        public string beautySalons = "Салоны красоты";
        public string cosmetics = "Косметика";
        public string carServices = "АЗС и автоуслуги"; // эти все варианты сделать Dicionary или наоборм статических строк, если ты хочешь их наружу вытаскивать.
                                                        // Выкинуть наружу, в одном чекбоксе только один чекбоксовый вариант, сейчас произойдёт дублирование строк
            
        Steps step; //наименование

        public ControlCheckBox(IWebDriver _driver, WebDriverWait _wait, Steps step /*оппачки, и получили конфликт имён*/) //вариант переменной текст тоже сюда прокинуть
        {
            /*это должно быть в классе, за пределами конструктора*/IWebDriver driver = _driver;//именования наоборот, локальное поле через _, а внешняя переменная просто с маленькой буквы
            /*та же история*/WebDriverWait wait = _wait;// именования должны быть наоборот
            step = new Steps(); // прокидываешь степ в конструктор, но создаёшь новый, зачем?
        }

        public void Switch(string text, IWebDriver driver, WebDriverWait wait) // зачем кидать сюда драйвер и вейт, если они уже хранятся в классе?
        {
            string xpath = $@"//li//span[contains(text(), '{text}')]//ancestor::li//rui-checkbox//label//input";
            step.ClickElement(driver, wait, xpath);
        }
        //и не вижу способа получить значение в чекбоксе
    }
}
