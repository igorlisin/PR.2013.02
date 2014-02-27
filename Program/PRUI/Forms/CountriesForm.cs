using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования списка стран
    /// </summary>
    public partial class CountriesForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список стран
        /// </summary>
        ICountries _countries;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CountriesForm(ICountries countries)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _countries = countries;                 // Сохранить список стран в поле

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
            DataGridViewCell cellTemplateText;                                  // Шаблон ячеек

            DataGridViewColumn columnId;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"
            DataGridViewColumn columnName;                                      // Колонка "Название"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название"
            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnName.Width = 160;                                             // Задать ширину колонки
            columnName.Name = "name";                                           // Задать название колонки
            columnName.HeaderText = "Название";                                 // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                              // Идентификатор
            string description;                                     // Описание
            string name;                                            // Название

            entitiesDataGridView.Rows.Clear();                      // Очистить элемент отображения списка сущностей

            foreach (ICountry country in _countries)                // Выполнить для всех стран из списка стран
            {
                id = ((IEntity)country).Id.ToString();              // Получить идентификатор
                description = ((IEntity)country).Description;       // Получить описание
                name = country.Name;                                // Получить название

                entitiesDataGridView.Rows.Add(                      // Добавить строку в элемент отображения списка сущностей
                    name,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Создает новую страну и открывает диалоговое окно для ее редактирования
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            ICountry country;                                           // Страна
            CountryForm countryForm;                                    // Форма редактирования страны
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество стран в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество стран в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество стран
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            country = _countries.Create();                              // Создать страну

            countryForm = new CountryForm(country);                     // Создать форму для редактирования страны

            countryForm.ShowDialog();                                   // Отобразить форму для редактирования страны

            entityNeedSave = countryForm.EntityNeedSave;                // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _countries.Add(country);                                // Добавить созданную страну в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество стран
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Удаляет страну из списка стран
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество стран в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной страны

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество стран в списке

            if (rowCount > 0)                                               // Проверить общее количество стран
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор страны в выделенной строке

                _countries.RemoveById(id);                                  // Удалить страну из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенной страны
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            ICountry country;                                               // Страна
            CountryForm countryForm;                                        // Форма редактирования страны
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной страны
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество стран в списке

            if (rowCount > 0)                                               // Проверить общее количество стран
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор страны в выделенной строке

                country = _countries.GetCountry(id);                        // Получить выделенную страну

                countryForm = new CountryForm(country);                     // Создать форму для редактирования страны

                countryForm.ShowDialog();                                   // Отобразить форму для редактирования страны

                entityNeedSave = countryForm.EntityNeedSave;                // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _countries.SaveChanges();                               // Сохранить изменения списка стран
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        #endregion

        #endregion
    }
}
