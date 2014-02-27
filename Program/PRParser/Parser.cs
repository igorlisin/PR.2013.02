using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PRParser
{
    class Parser
    {
        #region Fields

        /// <summary>
        /// Поле. URI веб-страницы для разбора данных
        /// </summary>
        private string _uri;

        /// <summary>
        /// Поле. HTML код веб-страницы
        /// </summary>
        private string _pageHtmlCode;

        /// <summary>
        /// Поле. Дата и время получения HTML кода веб-страницы
        /// </summary>
        private DateTime _pageHtmlCodeTimeStamp;

        /// <summary>
        /// Поле. Шаблон регулярного выражения для выбора строк таблицы 
        /// </summary>
        private string _patternForRowParsing;

        /// <summary>
        /// Поле. Шаблон регулярного выражения для выбора ячеек таблицы из строк таблицы 
        /// </summary>
        private string _patternForColumnParsing;

        /// <summary>
        /// Поле. Список строк таблицы HTML разметки
        /// </summary>
        private List<string> _tableRows;

        /// <summary>
        /// Поле. Список массивов ячеек таблицы строк таблицы HTML разметки
        /// </summary>
        private List<string[]> _tableCells;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает URI веб-страницы для разбора данных
        /// </summary>
        public string Uri
        {
            get
            {
                return (_uri);
            }
            set
            {
                _uri = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает HTML код веб-страницы
        /// </summary>
        public string PageHtmlCode
        {
            get
            {
                return (_pageHtmlCode);
            }
            set
            {
                _pageHtmlCode = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату и время получения HTML кода веб-страницы
        /// </summary>
        public DateTime PageHtmlCodeTimeStamp
        {
            get
            {
                return (_pageHtmlCodeTimeStamp);
            }
            set
            {
                _pageHtmlCodeTimeStamp = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает шаблон регулярного выражения для выбора строк таблицы
        /// </summary>
        public string PatternForRowParsing
        {
            get
            {
                return (_patternForRowParsing);
            }
            set
            {
                _patternForRowParsing = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает шаблон регулярного выражения для выбора ячеек таблицы из строк таблицы 
        /// </summary>
        public string PatternForColumnParsing
        {
            get
            {
                return (_patternForColumnParsing);
            }
            set
            {
                _patternForColumnParsing = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список строк таблицы HTML разметки
        /// </summary>
        public List<string> TableRows
        {
            get
            {
                return (_tableRows);
            }
            set
            {
                _tableRows = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает списко массивов ячеек таблицы строк таблицы HTML разметки
        /// </summary>
        public List<string[]> TableCells
        {
            get
            {
                return (_tableCells);
            }
            set
            {
                _tableCells = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public Parser(string uri, string patternForRowParsing, string patternForColumnParsing)
        {
            _uri = uri;                                                                         // Сохранить адрес веб-страницы в поле

            _patternForRowParsing = patternForRowParsing;                                       // Сохранить шаблон регулярного выражения для выбора строк таблицы

            _patternForColumnParsing = patternForColumnParsing;                                 // Сохранить шаблон регулярного выражения для выбора ячеек таблицы

            _pageHtmlCode = GetHtmlCode(_uri);                                                  // Получить HTML код веб-страницы

            _tableRows = GetTableRowFromHtmlCode(_pageHtmlCode, _patternForRowParsing);         // Получить список строк таблицы

            _tableCells = GetTableCellFromTableRow(_tableRows, _patternForColumnParsing);       // Получить список массивов ячеек таблицы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Получает HTML код указанной веб страницы
        /// </summary>
        public string GetHtmlCode(string uri)
        {
            HttpWebRequest requestToServer;                                                                                         // Запрос к серверу
            HttpWebResponse responseFromServer;                                                                                     // Ответ от сервера

            StreamReader streamReader;                                                                                              // Объект для чтения потока данных с сервера

            string htmlCode = "";                                                                                                   // HTML разметка веб-страницы

            requestToServer = (HttpWebRequest)WebRequest.Create(uri);                                                               // Создать запрос к серверу
            responseFromServer = (HttpWebResponse)requestToServer.GetResponse();                                                    // Получить ответ от сервера

            if (((int)responseFromServer.StatusCode < 299 && (int)responseFromServer.StatusCode >= 200))                            // Проверить код статуса ответа сервера                                 
            {
                streamReader = new StreamReader(responseFromServer.GetResponseStream(), Encoding.GetEncoding("windows-1251"));      // Создать поток для чтения HTML разметки

                htmlCode = streamReader.ReadToEnd();                                                                                // Сохранить данные их потока в переменную

                streamReader.Close();                                                                                               // Закрыть поток для чтения HTML разметки
            }

            responseFromServer.Close();                                                                                             // Закрыть ответ от сервера

            return (htmlCode);
        }

        /// <summary>
        /// Метод. Возвращает список строк таблицы удовлетворяющих шаблону регулярного выражения
        /// </summary>
        private List<string> GetTableRowFromHtmlCode(string htmlCode, string regExTemplate)
        {
            Regex regEx;                                    // Регулярное выражение для выбора строк
            MatchCollection matches;                        // Коллекция совпадений с регулярным выражением

            List<string> rows;                              // Список строк таблицы HTML разметки

            regEx = new Regex(regExTemplate);               // Создать регулярное выражение для выбора строк с помощью шаблона

            rows = new List<string>();                      // Создать список строк таблицы HTML разметки

            matches = regEx.Matches(htmlCode);              // Получить совпадения с регулярным выражением

            foreach (Match rowParseMatch in matches)        // Выполнить для всех совпадений
            {
                rows.Add(rowParseMatch.Value);              // Добавить строку в список строк таблицы HTML разметки
            }

            return (rows);
        }

        /// <summary>
        /// Метод. Возвращает список ячеек таблицы удовлетворяющих шаблону регулярного выражения
        /// </summary>
        private List<string[]> GetTableCellFromTableRow(List<string> rows, string regExTemplate)
        {
            Regex regEx;                                                    // Регулярное выражение для выбора ячеек
            MatchCollection matches;                                        // Коллекция совпадений с регулярным выражением

            string[] cells;                                                 // Массив ячеек строки
            List<string[]> cellsList;                                       // Список массивов ячеек строк

            int counter;                                                    // Счетчик циклов

            regEx = new Regex(regExTemplate);                               // Создать регулярное выражения для выбора ячеек с помощью шаблона

            cellsList = new List<string[]>();                               // Создать список массивом ячеек строк             

            foreach (string row in rows)                                    // Выполнить для всех элементов списка строк
            {
                matches = regEx.Matches(row);                               // Получить совпадения с регулярным выражением
                cells = new string[matches.Count];                          // Создать массив ячеек строк

                for (counter = 0; counter < matches.Count; counter++)       // Выполнить для всех совпадений
                {
                    cells[counter] = matches[counter].Value;                // Сохранить ячеейку строки
                }

                cellsList.Add(cells);                                       // Добавить массив ячеек строк в список
            }

            return(cellsList);
        }

        #endregion
    }
}
