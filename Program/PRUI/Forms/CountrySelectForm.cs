using System;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма выбора страны
    /// </summary>
    public partial class CountrySelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список стран
        /// </summary>
        ICountries _countries;

        /// <summary>
        /// Поле. Выделенная страна
        /// </summary>
        ICountry _selectedCountry;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выделенную страну
        /// </summary>
        public ICountry SelectedCountry
        {
            get
            {
                return (_selectedCountry);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CountrySelectForm(ICountries countries)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _countries = countries;                 // Скопировать список стран в поле

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
            DataGridViewCell cellTemplateText;                              // Шаблон ячеек

            DataGridViewColumn columnId;                                    // Колонка "Идентификатор"
            DataGridViewColumn columnName;                                  // Колонка "Название"

            cellTemplateText = new DataGridViewTextBoxCell();               // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Идентификатор"
            columnName = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Название"

            columnId.Width = 100;                                           // Задать ширину колонки
            columnId.Name = "id";                                           // Задать название колонки
            columnId.HeaderText = "Идентификатор";                          // Задать заголовок

            columnName.Width = 160;                                         // Задать ширину колонки
            columnName.Name = "type";                                       // Задать название колонки
            columnName.HeaderText = "Тип";                                  // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                   // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                     // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                           // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                      // Идентификатор
            string name;                                    // Название

            entitiesDataGridView.Rows.Clear();              // Очистить элемент отображения списка сущностей

            foreach (ICountry country in _countries)        // Выполнить для всех стран из списка стран
            {
                id = ((IEntity)country).Id.ToString();      // Получить идентификатор
                name = country.Name;                        // Получить название

                entitiesDataGridView.Rows.Add(              // Добавить строку в элемент отображения списка сущностей
                    name,
                    id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает страну из списка стран, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенной страны

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор страны в выделенной строке

                _selectedCountry = _countries.GetCountry(id);               // Получить выделенную страну
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
