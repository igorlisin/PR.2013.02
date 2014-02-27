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
    /// Форма. Форма редактирования списка улиц
    /// </summary>
    public partial class StreetsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список улиц
        /// </summary>
        IStreets _streets;

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        ICities _cities;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public StreetsForm(IStreets streets, ICities cities)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _streets = streets;                     // Сохранить список улиц в поле

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
            DataGridViewColumn columnName;                                      // Колонка "Название"
            DataGridViewColumn columnCountry;                                   // Колонка "Страна"
            DataGridViewColumn columnRegion;                                    // Колонка "Регион"
            DataGridViewColumn columnCity;                                      // Колонка "Город"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название"
            columnCountry = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Регион"
            columnCity = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Город"

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

            columnCity.Width = 150;                                             // Задать ширину колонки
            columnCity.Name = "city";                                           // Задать название колонки
            columnCity.HeaderText = "Город";                                    // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
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
            string name;                                                    // Название
            string country;                                                 // Страна
            string region;                                                  // Регион
            string city;                                                    // Город

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IStreet street in _streets)                            // Выполнить для всех улиц из списка улиц
            {
                id = ((IEntity)street).Id.ToString();                       // Получить идентификатор
                description = ((IEntity)street).Description;                // Получить описание

                name = street.Name;                                         // Получить название

                region = null;                                              // Задать регион
                country = null;                                             // Задать страну
                city = null;                                                // Задать город

                if (street.City != null)                                    // Проверить город, связанный с улицой
                {
                    city = street.City.Name;                                // Получить улицу

                    if (street.City.Region != null)                         // Проверить регион, связанный с городом
                    {
                        region = street.City.Region.Name;                   // Получить регион

                        if (street.City.Region.Country != null)             // Проверить страну, связанную с регионом
                        {
                            country = street.City.Region.Country.Name;      // Получить страну
                        }
                    }
                }

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    name,
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
        /// Метод. Отображает контекстное меню создания новой улицы
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
        /// Метод. Удаляет улицу из списка улиц
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество улиц в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной улицы

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество улиц в списке

            if (rowCount > 0)                                               // Проверить общее количество улиц
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор улицы в выделенной строке

                _streets.RemoveById(id);                                    // Удалить улицу из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенной улицы
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IStreet street;                                                 // Улица
            StreetForm streetForm;                                          // Форма редактирования улицы
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной улицы
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор улицы в выделенной строке

                street = _streets.GetStreet(id);                            // Получить выделенную улицу

                streetForm = new StreetForm(street, _cities);               // Создать форму для редактирования улицы

                streetForm.ShowDialog();                                    // Отобразить форму для редактирования улицы

                entityNeedSave = streetForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _cities.SaveChanges();                                  // Сохранить изменения списка улиц
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новую улицу и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IStreet street;                                             // Улица
            ICity city;                                                 // Город, связанный с улицой
            StreetForm streetForm;                                      // Форма редактирования улицы
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество улиц в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество улиц в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество улиц
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            street = _streets.Create();                                 // Создать улицу
            city = _cities.Create();                                    // Создать город, связанный с улицей
            street.City = city;                                         // Связать город с улицей

            streetForm = new StreetForm(street, _cities);               // Создать форму для редактирования улицы

            streetForm.ShowDialog();                                    // Отобразить форму для редактирования улицы

            entityNeedSave = streetForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _streets.Add(street);                                   // Добавить созданную улицу в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество улиц
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает новую улицу на основе города и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IStreet street;                                             // Улица
            StreetForm streetForm;                                      // Форма редактирования улицы
            CitySelectForm citySelectForm;                              // Форма выбора города
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество улиц в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество улиц в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество улиц
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            street = _streets.Create();                                 // Создать улицу

            citySelectForm = new CitySelectForm(                        // Создать форму выбора города
                _cities);

            citySelectForm.ShowDialog();                                // Отобразить форму выбора города

            street.City = citySelectForm.SelectedCity;                  // Связать город с улицей

            if (street.City != null)                                    // Проверить связанный с улицей город
            {
                streetForm = new StreetForm(street, _cities);           // Создать форму для редактирования улицы

                streetForm.ShowDialog();                                // Отобразить форму для редактирования улицы

                entityNeedSave = streetForm.EntityNeedSave;             // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _streets.Add(street);                               // Добавить созданную улицу в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество улиц
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
