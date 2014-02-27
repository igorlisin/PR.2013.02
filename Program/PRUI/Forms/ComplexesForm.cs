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
    /// Форма. Форма редактирования списка комплексов
    /// </summary>
    public partial class ComplexesForm : TemplateEntityListForm
    {
       #region Fields

        /// <summary>
        /// Поле. Список комплексов
        /// </summary>
        IComplexes _complexes;

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        ICities _cities;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ComplexesForm(IComplexes complexes, ICities cities)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _complexes = complexes;                 // Сохранить список комплексов в поле

            _cities = cities;                       // Сохранить список городов с поле

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
            DataGridViewColumn columnNumber;                                    // Колонка "Номер"
            DataGridViewColumn columnCountry;                                   // Колонка "Страна"
            DataGridViewColumn columnRegion;                                    // Колонка "Регион"
            DataGridViewColumn columnCity;                                      // Колонка "Город"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnNumber = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Номер"
            columnCountry = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Регион"
            columnCity = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Город"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnNumber.Width = 160;                                           // Задать ширину колонки
            columnNumber.Name = "number";                                       // Задать название колонки
            columnNumber.HeaderText = "Номер";                                  // Задать заголовок

            columnCountry.Width = 150;                                          // Задать ширину колонки
            columnCountry.Name = "country";                                     // Задать название колонки
            columnCountry.HeaderText = "Страна";                                // Задать заголовок

            columnRegion.Width = 150;                                           // Задать ширину колонки
            columnRegion.Name = "region";                                       // Задать название колонки
            columnRegion.HeaderText = "Регион";                                 // Задать заголовок

            columnCity.Width = 150;                                             // Задать ширину колонки
            columnCity.Name = "city";                                           // Задать название колонки
            columnCity.HeaderText = "Город";                                    // Задать заголовок

            entitiesDataGridView.Columns.Add(columnNumber);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCity);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                      // Идентификатор
            string description;                                             // Описание
            string number;                                                  // Номер
            string country;                                                 // Страна
            string region;                                                  // Регион
            string city;                                                    // Город

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IComplex complex in _complexes)                        // Выполнить для всех комплексов из списка комплексов
            {
                id = ((IEntity)complex).Id.ToString();                      // Получить идентификатор
                description = ((IEntity)complex).Description;               // Получить описание

                number = complex.Number.ToString();                         // Получить номер

                region = null;                                              // Задать регион
                country = null;                                             // Задать страну
                city = null;                                                // Задать город

                if (complex.City != null)                                   // Проверить город, связанный с улицой
                {
                    city = complex.City.Name;                               // Получить улицу

                    if (complex.City.Region != null)                        // Проверить регион, связанный с городом
                    {
                        region = complex.City.Region.Name;                  // Получить регион

                        if (complex.City.Region.Country != null)            // Проверить страну, связанную с регионом
                        {
                            country = complex.City.Region.Country.Name;     // Получить страну
                        }
                    }
                }

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    number,
                    country,
                    region,
                    city,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового комплекса
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            int buttonWidth;                                        // Ширина кнопки
            int buttonHeight;                                       // Высота кнопки

            buttonWidth = ((Button)sender).Width;                   // Получить ширину кнопки
            buttonHeight = ((Button)sender).Height;                 // Получить высоту кнопки

            addContextMenuStrip.Show(
                (Control)sender,
                new Point(buttonWidth / 2, buttonHeight / 2));      // Показать контекстное меню
        }

        /// <summary>
        /// Метод. Удаляет комплекс из списка комплексов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество комплексов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного комплекса

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество комплексов в списке

            if (rowCount > 0)                                               // Проверить общее количество комплексов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор комплекса в выделенной строке

                _complexes.RemoveById(id);                                  // Удалить комплекс из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного комплекса
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IComplex complex;                                               // Комплекс
            ComplexForm complexForm;                                        // Форма редактирования комплекса
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного комплекса
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор комплекса в выделенной строке

                complex = _complexes.GetComplex(id);                        // Получить выделенный комплекс

                complexForm = new ComplexForm(complex, _cities);            // Создать форму для редактирования комплекса

                complexForm.ShowDialog();                                   // Отобразить форму для редактирования комплекса

                entityNeedSave = complexForm.EntityNeedSave;                // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _cities.SaveChanges();                                  // Сохранить изменения списка комплексов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новый комплекс и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IComplex complex;                                           // Комплекс
            ICity city;                                                 // Город, связанный с комплексом
            ComplexForm complexForm;                                    // Форма редактирования комплекса
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество улиц в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество комплексов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество комплексов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            complex = _complexes.Create();                              // Создать комплекс
            city = _cities.Create();                                    // Создать город, связанный с комплексом
            complex.City = city;                                        // Связать город с комплексом

            complexForm = new ComplexForm(complex, _cities);            // Создать форму для редактирования комплекса

            complexForm.ShowDialog();                                   // Отобразить форму для редактирования комплекса

            entityNeedSave = complexForm.EntityNeedSave;                // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _complexes.Add(complex);                                // Добавить созданный комплекс в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество комплексов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает новый комплекс на основе города и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IComplex complex;                                           // Комплекс
            ComplexForm complexForm;                                    // Форма редактирования комплекса
            CitySelectForm citySelectForm;                              // Форма выбора города
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество комплексов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество комплексов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество комплексов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            complex = _complexes.Create();                              // Создать комплекс

            citySelectForm = new CitySelectForm(                        // Создать форму выбора города
                _cities);

            citySelectForm.ShowDialog();                                // Отобразить форму выбора города

            complex.City = citySelectForm.SelectedCity;                 // Связать город с комплексом

            if (complex.City != null)                                   // Проверить связанный с комплексов город
            {
                complexForm = new ComplexForm(complex, _cities);        // Создать форму для редактирования комплекса

                complexForm.ShowDialog();                               // Отобразить форму для редактирования комплекса

                entityNeedSave = complexForm.EntityNeedSave;            // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _complexes.Add(complex);                            // Добавить созданный комплекс в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество комплексов
                {
                    SelectRow(selectedRowIndex);                        // Выделить строку
                }

                SetButtonActivity();                                    // Задать активность элементов управления
            }
        }

        #endregion

        #endregion
    }
}
