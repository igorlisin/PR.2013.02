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
    /// Форма. Форма выбора комплекса
    /// </summary>
    public partial class ComplexSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список комплексов
        /// </summary>
        IComplexes _complexes;

        /// <summary>
        /// Поле. Выбранный комплекс
        /// </summary>
        IComplex _selectedComplex;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный комплекс
        /// </summary>
        public IComplex SelectedComplex
        {
            get
            {
                return (_selectedComplex);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ComplexSelectForm(IComplexes complexes)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _complexes = complexes;                 // Скопировать список комплексов в поле

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

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnNumber = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Номер"
            columnCountry = new DataGridViewColumn(cellTemplateText);                               // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Регион"
            columnCity = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Город"

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

            entitiesDataGridView.Columns.Add(columnNumber);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCity);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                      // Идентификатор
            string number;                                                  // Номер
            string country;                                                 // Название страны
            string region;                                                  // Название региона
            string city;                                                    // Название города

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IComplex complex in _complexes)                        // Выполнить для всех комплексов из списка комплексов
            {
                id = ((IEntity)complex).Id.ToString();                      // Получить идентификатор

                number = complex.Number.ToString();                         // Получить номер

                region = null;                                              // Задать название региона
                country = null;                                             // Задать название страны
                city = null;                                                // Задать название города

                if (complex.City != null)                                   // Проверить город, связанный с улицей
                {
                    city = complex.City.Name;                               // Получить название города

                    if (complex.City.Region != null)                        // Проверить регион, связанный с городом
                    {
                        region = complex.City.Region.Name;                  // Получить название региона

                        if (complex.City.Region.Country != null)            // Проверить страну, связанную с регионом
                        {
                            country = complex.City.Region.Country.Name;     // Получить название страны
                        }
                    }
                }

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                        number,
                        country,
                        region,
                        city,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает комплекс из списка комплексов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного комплекса

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор комплекса в выделенной строке

                _selectedComplex = _complexes.GetComplex(id);               // Получить выделенный комплекс
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion

        #endregion
    }
}
