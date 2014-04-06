using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PRParser
{
    public class Zakamned
    {
        #region Static fields

        /// <summary>
        /// Поле. Шаблон регулярного выражения для поиска строки таблицы HTML разметки
        /// </summary>
        private static string _rowsRegExTemplate;

        /// <summary>
        /// Поле. Шаблон регулярного выражения для поиска ячеек таблицы HTML разметки
        /// </summary>
        private static string _cellsRegExTemplate;

        /// <summary>
        /// Поле. Адрес сайта
        /// </summary>
        private static string _siteAddress;

        /// <summary>
        /// Поле. Адрес страницы для однокомнатных квартир
        /// </summary>
        private static string _oneRoomApartmentAddress;

        #endregion

        #region Static properties

        /// <summary>
        /// Свойство. Задает и возвращает шаблон регулярного выражения для поиска строки таблицы HTML разметки
        /// </summary>
        public static string RowsRegExTemplate
        {
            get
            {
                return (_rowsRegExTemplate);
            }
            set
            {
                _rowsRegExTemplate = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает шаблон регулярного выражения для поиска ячеек таблицы HTML разметки
        /// </summary>
        public static string CellsRegExTemplate
        {
            get
            {
                return (_cellsRegExTemplate);
            }
            set
            {
                _cellsRegExTemplate = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает адрес сайта
        /// </summary>
        public static string SiteAddress
        {
            get
            {
                return (_siteAddress);
            }
            set
            {
                _siteAddress = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает адрес страницы для однокомнатных квартир
        /// </summary>
        public static string OneRoomApartmentAddress
        {
            get
            {
                return (_oneRoomApartmentAddress);
            }
            set
            {
                _oneRoomApartmentAddress = value;
            }
        }

        #endregion

        #region Static constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        static Zakamned()
        {
            _siteAddress = @"http://zakamned.ru";

            _oneRoomApartmentAddress = @"base/index.php?b=1";

            _rowsRegExTemplate = @"<tr class='row(1|0)' ><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td><div style='width: 100px; overflow:hidden'>.*?</div></td></tr>";
            _cellsRegExTemplate = @"<td>.*?</td>";
        }

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Адрес
        /// </summary>
        public  string address;

        /// <summary>
        /// Поле. Этаж
        /// </summary>
        public int floor;

        /// <summary>
        /// Поле. Максимальный этаж
        /// </summary>
        public int maxFloor;

        /// <summary>
        /// Поле. Общая площаль
        /// </summary>
        public int grossArea;

        /// <summary>
        /// Поле. Жилая площадь
        /// </summary>
        public int livingArea;

        /// <summary>
        /// Поле. Площадь кухни
        /// </summary>
        public int kitchenArea;

        /// <summary>
        /// Поле. Наличие балкона
        /// </summary>
        public bool hasBalcony;

        /// <summary>
        /// Поле. Наличие телефона
        /// </summary>
        public bool hasPhone;

        /// <summary>
        /// Поле. Наличие железной двери
        /// </summary>
        public bool hasIronDoor;

        /// <summary>
        /// Поле. Компания
        /// </summary>
        public string company;

        /// <summary>
        /// Поле. Контактный телефон
        /// </summary>
        public string phoneToCall;

        /// <summary>
        /// Поле. Цена
        /// </summary>
        public int price;

        /// <summary>
        /// Поле. Описание
        /// </summary>
        public string description;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public Zakamned()
        {
        }

        #endregion
        
        #region Methods

        #region Areas

        /// <summary>
        /// Метод. Возвращает общую площадь квартиры (разбирает выражение типа 36/20/10, где 36 - общая площадь, 20 - жилая площадь, 10 - площадь кухни)
        /// </summary>
        private int GetGrossArea(string areaString)
        {
            string[] areas;                                 // Площади
            int grosArea;                                   // Общая площадь

            areaString = areaString.Trim();                 // Удалить пробелы с начала и конца строки
            areas = areaString.Split('/');                  // Разбить строку на части
            
            grosArea = 0;                                   // Задать общую площадь

            if (areas.Length > 0)                           // Проверить количество указанных площадей
            {
                Int32.TryParse(areas[0], out grosArea);     // Получить общую площадь
            }

            return (grosArea);
        }

        /// <summary>
        /// Метод. Возвращает жилую площадь квартиры (разбирает выражение типа 36/20/10, где 36 - общая площадь, 20 - жилая площадь, 10 - площадь кухни)
        /// </summary>
        private int GetLivingArea(string areaString)
        {
            string[] areas;                                     // Площади
            int livingArea;                                     // Жилая площадь

            areaString = areaString.Trim();                     // Удалить пробелы с начала и конца строки
            areas = areaString.Split('/');                      // Разбить строку на части

            livingArea = 0;                                     // Задать жилую площадь

            if (areas.Length > 1)                               // Проверить количество указанных площадей
            {
                Int32.TryParse(areas[1], out livingArea);       // Получить жилую площадь
            }

            return (livingArea);
        }

        /// <summary>
        /// Метод. Возвращает площадь кухни квартиры (разбирает выражение типа 36/20/10, где 36 - общая площадь, 20 - жилая площадь, 10 - площадь кухни)
        /// </summary>
        private int GetKitchenArea(string areaString)
        {
            string[] areas;                                     // Площади
            int kitchenArea;                                    // Площадь кухни

            areaString = areaString.Trim();                     // Удалить пробелы с начала и конца строки
            areas = areaString.Split('/');                      // Разбить строку на части

            kitchenArea = 0;                                    // Задать площадь кухни

            if (areas.Length > 2)                               // Проверить количество указанных площадей
            {
                Int32.TryParse(areas[2], out kitchenArea);      // Получить площадь кухни
            }

            return (kitchenArea);
        }

        #endregion

        #region Floors

        /// <summary>
        /// Метод. Возвращает этаж квартиры (разбирает выражение типа 5/9, где 5 - этаж квартиры, 9 - общее количество этажей)
        /// </summary>
        private int GetFloorArea(string floorString)
        {
            string[] floors;                                // Этажи
            int floor;                                      // Этаж квартиры

            floorString = floorString.Trim();               // Удалить пробелы с начала и конца строки
            floors = floorString.Split('/');                // Разбить строку на части

            floor = 0;                                      // Задать этаж квартиры

            if (floors.Length > 0)                          // Проверить количество указанных этажей
            {
                Int32.TryParse(floors[0], out floor);       // Получить этаж квартиры
            }

            return (floor);
        }

        /// <summary>
        /// Метод. Возвращает общее количество этажей (разбирает выражение типа 5/9, где 5 - этаж квартиры, 9 - общее количество этажей)
        /// </summary>
        private int GetMaxFloorArea(string floorString)
        {
            string[] floors;                                    // Этажи
            int maxFloor;                                       // Общее количество этажей

            floorString = floorString.Trim();                   // Удалить пробелы с начала и конца строки
            floors = floorString.Split('/');                    // Разбить строку на части

            maxFloor = 0;                                       // Задать общее количество этажей

            if (floors.Length > 1)                              // Проверить количество указанных этажей
            {
                Int32.TryParse(floors[1], out maxFloor);        // Получить общее количество этажей
            }

            return (maxFloor);
        }

        #endregion

        /// <summary>
        /// Метод. Пытается разобрать строки с данными и заполнить данными поля 
        /// </summary>
        public bool TryParse(string[] apartmentRecordData)
        {
            int countOne;
            int countTwo;
            int counterOne;
            int counterTwo;

            Regex tagsRegEx = new Regex(@"<.*?>");
            MatchCollection tagsMatches;

            countOne = apartmentRecordData.Count();

            for (counterOne = 0; counterOne < countOne; counterOne++)
            {
                tagsMatches = tagsRegEx.Matches(apartmentRecordData[counterOne]);

                countTwo = tagsMatches.Count;

                for (counterTwo = 0; counterTwo < countTwo; counterTwo++)
                {
                    apartmentRecordData[counterOne] = apartmentRecordData[counterOne].Replace(tagsMatches[counterTwo].Value, "");
                }
            }

            address = apartmentRecordData[0];

            floor = GetFloorArea(apartmentRecordData[1]);
            maxFloor = GetMaxFloorArea(apartmentRecordData[1]);

            grossArea = GetGrossArea(apartmentRecordData[2]);
            livingArea = GetLivingArea(apartmentRecordData[2]);
            kitchenArea = GetKitchenArea(apartmentRecordData[2]);

            hasBalcony = false;
            if (apartmentRecordData[3].Trim() == "+")
            {
                hasBalcony = true;
            }

            hasPhone = false;
            if (apartmentRecordData[4].Trim() == "+")
            {
                hasPhone = true;
            }

            hasIronDoor = false;
            if (apartmentRecordData[5].Trim() == "+")
            {
                hasIronDoor = true;
            }

            company = apartmentRecordData[6];
            phoneToCall = apartmentRecordData[7];

            Int32.TryParse(apartmentRecordData[8], out price);

            description = apartmentRecordData[9];

            return (true);
        }

        #endregion
    }
}
