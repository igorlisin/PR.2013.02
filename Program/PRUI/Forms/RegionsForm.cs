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
    /// Форма. Форма редактирования списка регионов
    /// </summary>
    public partial class RegionsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список регионов
        /// </summary>
        IRegions _regions;

        /// <summary>
        /// Поле. Список стран
        /// </summary>
        ICountries _countries;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public RegionsForm(IRegions regions, ICountries countries)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _regions = regions;                     // Сохранить список регионов в поле

            _countries = countries;                 // Сохранить список стран с поле

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
            DataGridViewColumn columnCountry;                                   // Колонка "Страна"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название"
            columnCountry = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Страна"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnName.Width = 160;                                             // Задать ширину колонки
            columnName.Name = "name";                                           // Задать название колонки
            columnName.HeaderText = "Название";                                 // Задать заголовок

            columnCountry.Width = 150;                                          // Задать ширину колонки
            columnCountry.Name = "country";                                     // Задать название колонки
            columnCountry.HeaderText = "Страна";                                // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                    // Добавить колонку в элемент отображения списка сущностей
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
            string country;                                         // Страна

            entitiesDataGridView.Rows.Clear();                      // Очистить элемент отображения списка сущностей

            foreach (IRegion region in _regions)                    // Выполнить для всех регионов из списка регионов
            {
                id = ((IEntity)region).Id.ToString();               // Получить идентификатор
                description = ((IEntity)region).Description;        // Получить описание

                name = region.Name;                                 // Получить название

                country = null;                                     // Задать страну

                if (region.Country != null)                         // Проверить страну, связанную с регионом
                {
                    country = region.Country.Name;                  // Получить страну
                }

                entitiesDataGridView.Rows.Add(                      // Добавить строку в элемент отображения списка сущностей
                    name,
                    country,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового региона
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
        /// Метод. Удаляет регион из списка регионов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество регионов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного региона

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество регионов в списке

            if (rowCount > 0)                                               // Проверить общее количество регионов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор региона в выделенной строке

                _regions.RemoveById(id);                                    // Удалить регион из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного региона
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IRegion region;                                                 // Регион
            RegionForm regionForm;                                          // Форма редактирования региона
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного региона
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор региона в выделенной строке

                region = _regions.GetRegion(id);                            // Получить выделенный регион

                regionForm = new RegionForm(region, _countries);            // Создать форму для редактирования региона

                regionForm.ShowDialog();                                    // Отобразить форму для редактирования региона

                entityNeedSave = regionForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _regions.SaveChanges();                                 // Сохранить изменения списка регионов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новый регион и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IRegion region;                                             // Регион
            ICountry country;                                           // Страна, связанная с регионом
            RegionForm regionForm;                                      // Форма редактирования региона
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество регионов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество регионов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество регионов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            region = _regions.Create();                                 // Создать регион
            country = _countries.Create();                              // Создать страну, связанную с регионом
            region.Country = country;                                   // Связать страну с регионом

            regionForm = new RegionForm(region, _countries);            // Создать форму для редактирования региона

            regionForm.ShowDialog();                                    // Отобразить форму для редактирования региона

            entityNeedSave = regionForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _regions.Add(region);                                   // Добавить созданный регион в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество регионов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает новый регион на основе страны и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IRegion region;                                             // Регион
            RegionForm regionForm;                                      // Форма редактирования региона
            CountrySelectForm countrySelectForm;                        // Форма выбора страны
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество регионов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество регионов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество регионов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            region = _regions.Create();                                 // Создать регион

            countrySelectForm = new CountrySelectForm(_countries);      // Создать форму выбора страны

            countrySelectForm.ShowDialog();                             // Отобразить форму выбора страны

            region.Country = countrySelectForm.SelectedCountry;         // Связать страну с регионом

            if (region.Country != null)                                 // Проверить связанную с регионом страну
            {
                regionForm = new RegionForm(region, _countries);        // Создать форму для редактирования региона

                regionForm.ShowDialog();                                // Отобразить форму для редактирования региона

                entityNeedSave = regionForm.EntityNeedSave;             // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _regions.Add(region);                               // Добавить созданный регион в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество регионов
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
