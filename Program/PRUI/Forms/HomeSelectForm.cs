using System;
using System.Windows.Forms;
using System.Drawing;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма выбора дома
    /// </summary>
    public partial class HomeSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        IHomes _homes;

        /// <summary>
        /// Поле. Выбранный дом
        /// </summary>
        IHome _selectedHome;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный дом
        /// </summary>
        public IHome SelectedHome
        {
            get
            {
                return (_selectedHome);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public HomeSelectForm(IHomes homes)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _homes = homes;                         // Скопировать список домов в поле

            ConfigureEntitiesDataGridView();        // Настроить визуальное представление элемента отображения списка сущностей

            FillEntitiesDataGridView();             // Заполнить элемент отображения списка сущностей

            SetButtonActivity();                    // Задать активность элементов управления
        }

        #endregion

        #region Methods

        #region Other

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка сущностей
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                                      // Шаблон ячеек

            DataGridViewColumn columnId;                                                            // Колонка "Идентификатор"
            DataGridViewColumn columnNumber;                                                        // Колонка "Номер"
            DataGridViewColumn columnCountry;                                                       // Колонка "Страна"
            DataGridViewColumn columnRegion;                                                        // Колонка "Регион"
            DataGridViewColumn columnCity;                                                          // Колонка "Город"
            DataGridViewColumn columnStreet;                                                        // Колонка "Улица"

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnNumber = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Номер"
            columnCountry = new DataGridViewColumn(cellTemplateText);                               // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Регион"
            columnCity = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Город"
            columnStreet = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Улица"

            columnId.Width = 100;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            columnNumber.Width = 110;                                                               // Задать ширину колонки
            columnNumber.Name = "number";                                                           // Задать название колонки
            columnNumber.HeaderText = "Номер";                                                      // Задать заголовок

            columnCountry.Width = 110;                                                              // Задать ширину колонки
            columnCountry.Name = "country";                                                         // Задать название колонки
            columnCountry.HeaderText = "Страна";                                                    // Задать заголовок
            columnCountry.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            columnRegion.Width = 110;                                                               // Задать ширину колонки
            columnRegion.Name = "region";                                                           // Задать название колонки
            columnRegion.HeaderText = "Регион";                                                     // Задать заголовок
            columnRegion.SortMode = DataGridViewColumnSortMode.Automatic;                           // Задать тип сортировки

            columnCity.Width = 110;                                                                 // Задать ширину колонки
            columnCity.Name = "city";                                                               // Задать название колонки
            columnCity.HeaderText = "Город";                                                        // Задать заголовок
            columnCity.SortMode = DataGridViewColumnSortMode.Automatic;                             // Задать тип сортировки

            columnStreet.Width = 110;                                                               // Задать ширину колонки
            columnStreet.Name = "street";                                                           // Задать название колонки
            columnStreet.HeaderText = "Улица";                                                      // Задать заголовок
            columnStreet.SortMode = DataGridViewColumnSortMode.Automatic;                           // Задать тип сортировки

            entitiesDataGridView.Columns.Add(columnNumber);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCity);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnStreet);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                              // Идентификатор
            string number;                                                          // Номер
            string country;                                                         // Название страны
            string region;                                                          // Название региона
            string city;                                                            // Название города
            string street;                                                          // Название улицы

            entitiesDataGridView.Rows.Clear();                                      // Очистить элемент отображения списка сущностей

            foreach (IHome home in _homes)                                          // Выполнить для всех домов из списка домов
            {
                id = ((IEntity)home).Id.ToString();                                 // Получить идентификатор

                number = home.Number;                                               // Получить номер

                region = null;                                                      // Задать название региона
                country = null;                                                     // Задать название страны
                city = null;                                                        // Задать название города
                street = null;                                                      // Задать название улицы

                if (home.Street != null)                                            // Проверить улицу, связанную с домом
                {
                    if (home.Street.City != null)                                   // Проверить город, связанный с улицей
                    {
                        if (home.Street.City.Region != null)                        // Проверить регион, связанный с городом
                        {
                            if (home.Street.City.Region.Country != null)            // Проверить страну, связанную с регионом
                            {
                                country = home.Street.City.Region.Country.Name;     // Получить название страны
                            }

                            region = home.Street.City.Region.Name;                  // Получить название региона
                        }

                        city = home.Street.City.Name;                               // Получить название города
                    }

                    street = home.Street.Name;                                      // Получить название улицы
                }

                entitiesDataGridView.Rows.Add(                                      // Добавить строку в элемент отображения списка сущностей
                        number,
                        country,
                        region,
                        city,
                        street,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает дом из списка домов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного дома

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор дома в выделенной строке

                _selectedHome = _homes.GetHome(id);                         // Получить выделенный дома
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion

        #endregion
    }
}
