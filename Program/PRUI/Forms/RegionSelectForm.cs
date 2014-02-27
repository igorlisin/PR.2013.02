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
    /// Форма. Форма выбора региона
    /// </summary>
    public partial class RegionSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список регионов
        /// </summary>
        IRegions _regions;

        /// <summary>
        /// Поле. Выбранный регион
        /// </summary>
        IRegion _selectedRegion;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный регион
        /// </summary>
        public IRegion SelectedRegion
        {
            get
            {
                return (_selectedRegion);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public RegionSelectForm(IRegions regions)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _regions = regions;                     // Скопировать список регионов в поле

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

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnName = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Название"
            columnCountry = new DataGridViewColumn(cellTemplateText);                               // Создать колонку "Страна"

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

            entitiesDataGridView.Columns.Add(columnName);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                                        // Добавить колонку в элемент отображения списка сущностей
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

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            foreach (IRegion region in _regions)                                // Выполнить для всех регионов из списка регионов
            {
                id = ((IEntity)region).Id.ToString();                           // Получить идентификатор

                name = region.Name;                                             // Задать название

                country = null;                                                 // Задать название страны

                if (region.Country != null)                                     // Проверить страну, связанную с регионом
                {
                    country = region.Country.Name;                              // Получить название страны
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                        name,
                        country,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает регион из списка регионов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного региона

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор региона в выделенной строке

                _selectedRegion = _regions.GetRegion(id);                   // Получить выделенный регион
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
