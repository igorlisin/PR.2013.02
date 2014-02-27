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
    /// Форма. Форма выбора города
    /// </summary>
    public partial class CitySelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        ICities _cities;

        /// <summary>
        /// Поле. Выбранный город
        /// </summary>
        ICity _selectedCity;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный город
        /// </summary>
        public ICity SelectedCity
        {
            get
            {
                return (_selectedCity);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CitySelectForm(ICities cities)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _cities = cities;                       // Скопировать список городов в поле

            ConfigureEntitiesDataGridView();        // Настроить визуальное представление элемента отображения списка сущностей

            FillEntitiesDataGridView();             // Заполнить элемент отображения списка сущностей

            SetButtonActivity();                    // Задать активность элементов управления
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка сущностей
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                                      // Шаблон ячеек

            DataGridViewColumn columnId;                                                            // Колонка "Идентификатор"
            DataGridViewColumn columnName;                                                          // Колонка "Название"
            DataGridViewColumn columnCountry;                                                       // Колонка "Страна"
            DataGridViewColumn columnRegion;                                                        // Колонка "Регион"

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnName = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Название"
            columnCountry = new DataGridViewColumn(cellTemplateText);                               // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Регион"

            columnId.Width = 100;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            columnName.Width = 110;                                                                 // Задать ширину колонки
            columnName.Name = "name";                                                               // Задать название колонки
            columnName.HeaderText = "Название";                                                     // Задать заголовок
            columnName.SortMode = DataGridViewColumnSortMode.Automatic;                             // Задать тип сортировки

            columnCountry.Width = 110;                                                              // Задать ширину колонки
            columnCountry.Name = "country";                                                         // Задать название колонки
            columnCountry.HeaderText = "Страна";                                                    // Задать заголовок
            columnCountry.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            columnRegion.Width = 110;                                                               // Задать ширину колонки
            columnRegion.Name = "region";                                                           // Задать название колонки
            columnRegion.HeaderText = "Регион";                                                     // Задать заголовок
            columnRegion.SortMode = DataGridViewColumnSortMode.Automatic;                           // Задать тип сортировки

            entitiesDataGridView.Columns.Add(columnName);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                          // Идентификатор
            string name;                                                        // Название
            string country;                                                     // Название страны
            string region;                                                      // Название региона

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            foreach (ICity city in _cities)                                     // Выполнить для всех городов из списка городов
            {
                id = ((IEntity)city).Id.ToString();                             // Получить идентификатор

                name = city.Name;                                               // Задать название

                region = null;                                                  // Задать название региона
                country = null;                                                 // Задать название страны

                if (city.Region != null)                                        // Проверить регион, связанный с городом
                {
                    region = city.Region.Name;                                  // Получить название региона

                    if (city.Region.Country != null)                            // Проверить страну, связанную с регионом
                    {
                        country = city.Region.Country.Name;                     // Получить название страны
                    }
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                        name,
                        country,
                        region,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает город из списка городов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного города

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор города в выделенной строке

                _selectedCity = _cities.GetCity(id);                        // Получить выделенный город
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
