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
    /// Форма. Форма редактирования списка городов
    /// </summary>
    public partial class CitiesForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        ICities _cities;

        /// <summary>
        /// Поле. Список регионов
        /// </summary>
        IRegions _regions;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CitiesForm(ICities cities, IRegions regions)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _cities = cities;                       // Сохранить список городов в поле

            _regions = regions;                     // Сохранить список регионов с поле

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
            DataGridViewColumn columnRegion;                                    // Колонка "Регион"


            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название"
            columnCountry = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Регион"

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

            columnRegion.Width = 150;                                           // Задать ширину колонки
            columnRegion.Name = "region";                                       // Задать название колонки
            columnRegion.HeaderText = "Регион";                                 // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                     // Добавить колонку в элемент отображения списка сущностей
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
            string region;                                          // Регион

            entitiesDataGridView.Rows.Clear();                      // Очистить элемент отображения списка сущностей

            foreach (ICity city in _cities)                         // Выполнить для всех городов из списка городов
            {
                id = ((IEntity)city).Id.ToString();                 // Получить идентификатор
                description = ((IEntity)city).Description;          // Получить описание

                name = city.Name;                                   // Получить название

                region = null;                                      // Задать регион
                country = null;                                     // Задать страну

                if (city.Region != null)                            // Проверить регион, связанный с городом
                {
                    region = city.Region.Name;                      // Получить регион

                    if (city.Region.Country != null)                // Проверить страну, связанную с регионом
                    {
                        country = city.Region.Country.Name;         // Получить страну
                    }
                }

                entitiesDataGridView.Rows.Add(                      // Добавить строку в элемент отображения списка сущностей
                    name,
                    country,
                    region,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового города
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
        /// Метод. Удаляет город из списка городов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество городов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного города

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество городов в списке

            if (rowCount > 0)                                               // Проверить общее количество городов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор города в выделенной строке

                _cities.RemoveById(id);                                     // Удалить город из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного города
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            ICity city;                                                     // Город
            CityForm cityForm;                                              // Форма редактирования города
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного города
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор города в выделенной строке

                city = _cities.GetCity(id);                                 // Получить выделенный город

                cityForm = new CityForm(city, _regions);                    // Создать форму для редактирования города

                cityForm.ShowDialog();                                      // Отобразить форму для редактирования города

                entityNeedSave = cityForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _cities.SaveChanges();                                  // Сохранить изменения списка городов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новый город и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICity city;                                                 // Город
            IRegion region;                                             // Регион, связанный с городом
            CityForm cityForm;                                          // Форма редактирования города
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество городов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество городов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество городов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            city = _cities.Create();                                    // Создать город
            region = _regions.Create();                                 // Создать регион, связанный с городом
            city.Region = region;                                       // Связать регион с городом

            cityForm = new CityForm(city, _regions);                    // Создать форму для редактирования города

            cityForm.ShowDialog();                                      // Отобразить форму для редактирования города

            entityNeedSave = cityForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _cities.Add(city);                                      // Добавить созданный город в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество городов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает новый город на основе региона и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICity city;                                                 // Город
            CityForm cityForm;                                          // Форма редактирования города
            RegionSelectForm regionSelectForm;                          // Форма выбора региона
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество городов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество городов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество городов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            city = _cities.Create();                                    // Создать город

            regionSelectForm = new RegionSelectForm(                    // Создать форму выбора региона
                _regions);

            regionSelectForm.ShowDialog();                              // Отобразить форму выбора региона

            city.Region = regionSelectForm.SelectedRegion ;             // Связать регион с городом

            if (city.Region != null)                                    // Проверить связанный с городом регион
            {
                cityForm = new  CityForm(city, _regions);               // Создать форму для редактирования города

                cityForm.ShowDialog();                                  // Отобразить форму для редактирования региона

                entityNeedSave = cityForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _cities.Add(city);                                  // Добавить созданный город в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество городов
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
