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
    /// Форма. Форма редактирования списка домов
    /// </summary>
    public partial class HomesForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        IHomes _homes;

        /// <summary>
        /// Поле. Список улиц
        /// </summary>
        IStreets _streets;

        /// <summary>
        /// Поле. Список комплексов
        /// </summary>
        IComplexes _complexes;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public HomesForm(IHomes homes, IStreets streets, IComplexes complexes)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _homes = homes;                         // Сохранить список домов в поле

            _streets = streets;                     // Сохранить список улиц с поле

            _complexes = complexes;                 // Сохранить список комплексов с поле

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
            DataGridViewCell cellTemplateText;                                  // Шаблон ячеек

            DataGridViewColumn columnId;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"
            DataGridViewColumn columnNote;                                      // Колонка "Примечание"
            DataGridViewColumn columnNumber;                                    // Колонка "Номер"
            DataGridViewColumn columnComplexNumber;                             // Колонка "Номер по комплексу"
            DataGridViewColumn columnCountry;                                   // Колонка "Страна"
            DataGridViewColumn columnRegion;                                    // Колонка "Регион"
            DataGridViewColumn columnCity;                                      // Колонка "Город"
            DataGridViewColumn columnStreet;                                    // Колонка "Улица"
            DataGridViewColumn columnComplex;                                   // Колонка "Комплекс"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnNote = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Примечание"
            columnNumber = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Номер"
            columnComplexNumber = new DataGridViewColumn(cellTemplateText);     // Создать колонку "Номер по комплексу"
            columnCountry = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Страна"
            columnRegion = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Регион"
            columnCity = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Город"
            columnStreet = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Улица"
            columnComplex = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Комплекс"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnNote.Width = 100;                                             // Задать ширину колонки
            columnNote.Name = "note";                                           // Задать название колонки
            columnNote.HeaderText = "Примечание";                               // Задать заголовок

            columnNumber.Width = 160;                                           // Задать ширину колонки
            columnNumber.Name = "number";                                       // Задать название колонки
            columnNumber.HeaderText = "Номер";                                  // Задать заголовок

            columnComplexNumber.Width = 160;                                    // Задать ширину колонки
            columnComplexNumber.Name = "number";                                // Задать название колонки
            columnComplexNumber.HeaderText = "Номер по комплексу";              // Задать заголовок

            columnCountry.Width = 150;                                          // Задать ширину колонки
            columnCountry.Name = "country";                                     // Задать название колонки
            columnCountry.HeaderText = "Страна";                                // Задать заголовок

            columnRegion.Width = 150;                                           // Задать ширину колонки
            columnRegion.Name = "region";                                       // Задать название колонки
            columnRegion.HeaderText = "Регион";                                 // Задать заголовок

            columnCity.Width = 150;                                             // Задать ширину колонки
            columnCity.Name = "city";                                           // Задать название колонки
            columnCity.HeaderText = "Город";                                    // Задать заголовок

            columnStreet.Width = 150;                                           // Задать ширину колонки
            columnStreet.Name = "street";                                       // Задать название колонки
            columnStreet.HeaderText = "Улица";                                  // Задать заголовок

            columnComplex.Width = 150;                                          // Задать ширину колонки
            columnComplex.Name = "complex";                                     // Задать название колонки
            columnComplex.HeaderText = "Комплекс";                              // Задать заголовок

            entitiesDataGridView.Columns.Add(columnNumber);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnComplexNumber);              // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCountry);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnRegion);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCity);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnStreet);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnComplex);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnNote);                       // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                              // Идентификатор
            string description;                                                     // Описание
            string note;                                                            // Примечание
            string number;                                                          // Номер
            string complexNumber;                                                   // Номер по комплексу
            string country;                                                         // Страна
            string region;                                                          // Регион
            string city;                                                            // Город
            string street;                                                          // Улица
            string complex;                                                         // Комплекс

            entitiesDataGridView.Rows.Clear();                                      // Очистить элемент отображения списка сущностей

            foreach (IHome home in _homes)                                          // Выполнить для всех домов из списка домов
            {
                id = ((IEntity)home).Id.ToString();                                 // Получить идентификатор
                description = ((IEntity)home).Description;                          // Получить описание
                note = null;                                                        // Задать примечание

                country = null;                                                     // Задать страну
                region = null;                                                      // Задать регион
                city = null;                                                        // Задать город
                street = null;                                                      // Задать улицу
                complex = null;                                                     // Задать комплекс

                if (home.Street != null)                                            // Проверить улицу, связанную с домом
                {
                    if (home.Street.City != null)                                   // Проверить город, связанный с улицей
                    {
                        if (home.Street.City.Region != null)                        // Проверить регион, связанный с городом
                        {
                            if (home.Street.City.Region.Country != null)            // Проверить страну, связанную с регионом
                            {
                                country = home.Street.City.Region.Country.Name;     // Получить страну
                            }
                            region = home.Street.City.Region.Name;                  // Получить регион
                        }
                        city = home.Street.City.Name;                               // Получить город
                    }
                    street = home.Street.Name;                                      // Получить улицу
                }

                if (home.Complex != null)                                           // Проверить комплекс, связанный с домом
                {
                    complex = home.Complex.Number.ToString();                       // Получить комплекс, связанный с домом
                }

                if (home.Street != null && home.Complex != null)
                {
                    if (home.Street.City != home.Complex.City)
                    {
                        note = "Ошибка: улица и комплекс расположены в разных городах"; 
                    }
                }

                number = home.Number;                                               // Получить номер
                complexNumber = home.ComplexNumber;                                 // Получить номер по комплексу

                entitiesDataGridView.Rows.Add(                                      // Добавить строку в элемент отображения списка сущностей
                    number,
                    complexNumber,
                    country,
                    region,
                    city,
                    street,
                    complex,
                    id,
                    description,
                    note);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового дома
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
        /// Метод. Удаляет дом из списка домов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество домов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного дома

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество домов в списке

            if (rowCount > 0)                                               // Проверить общее количество домов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор дома в выделенной строке

                _homes.RemoveById(id);                                      // Удалить дом из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного дома
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IHome home;                                                     // Дом
            HomeForm homeForm;                                              // Форма редактирования дома
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного дома
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор дома в выделенной строке

                home = _homes.GetHome(id);                                  // Получить выделенный дом

                homeForm = new HomeForm(home, _streets,_complexes);         // Создать форму для редактирования дома

                homeForm.ShowDialog();                                      // Отобразить форму для редактирования дома

                entityNeedSave = homeForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _homes.SaveChanges();                                   // Сохранить изменения списка домов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новый дом и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHome home;                                                 // Дом
            IStreet street;                                             // Улица, связанная с домом
            IComplex complex;                                           // Комплекс, связанный с домом
            HomeForm homeForm;                                          // Форма редактирования дома
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество домов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество домов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество домов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            home = _homes.Create();                                     // Создать дом
            street = _streets.Create();                                 // Создать улицу, связаннуй с домом
            complex = _complexes.Create();                              // Создать комплекс, связанный с домом
            home.Street = street;                                       // Связать улицу с домом
            home.Complex = complex;                                     // Связать комплекс с домом

            homeForm = new HomeForm(home, _streets,_complexes);         // Создать форму для редактирования дома

            homeForm.ShowDialog();                                      // Отобразить форму для редактирования дома

            entityNeedSave = homeForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _homes.Add(home);                                       // Добавить созданный дом в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество домов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления

        }

        /// <summary>
        /// Метод. Создает новый дом на основе улицы и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByStreetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHome home;                                                     // Дом
            HomeForm homeForm;                                              // Форма редактирования дома
            StreetSelectForm streetSelectForm;                              // Форма выбора улицы
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество домов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество домов в списке

            selectedRowIndex = 0;                                           // Задать индекс выделенной строки
            if (rowCount > 0)                                               // Проверить общее количество домов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
            }

            home = _homes.Create();                                         // Создать дом

            streetSelectForm = new StreetSelectForm(_streets);              // Создать форму выбора улицы

            streetSelectForm.ShowDialog();                                  // Отобразить форму выбора улицы

            home.Street = streetSelectForm.SelectedStreet;                  // Связать улицу с домом

            if (home.Street != null)                                        // Проверить связанную с домом улицу
            {
                homeForm = new HomeForm(home, _streets, _complexes);        // Создать форму для редактирования дома

                homeForm.ShowDialog();                                      // Отобразить форму для редактирования дома

                entityNeedSave = homeForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _homes.Add(home);                                       // Добавить созданный дом в список
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                           // Проверить общее количество домов
                {
                    SelectRow(selectedRowIndex);                            // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Создает новый дом на основе комплекса и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByComplexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHome home;                                                     // Дом
            HomeForm homeForm;                                              // Форма редактирования дома
            ComplexSelectForm complexSelectForm;                            // Форма выбора комплекса
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество домов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество домов в списке

            selectedRowIndex = 0;                                           // Задать индекс выделенной строки
            if (rowCount > 0)                                               // Проверить общее количество домов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
            }

            home = _homes.Create();                                         // Создать дом

            complexSelectForm = new ComplexSelectForm(_complexes);          // Создать форму выбора комплекса

            complexSelectForm.ShowDialog();                                 // Отобразить форму выбора комплекса

            home.Complex = complexSelectForm.SelectedComplex;               // Связать комплекс с домом

            if (home.Complex != null)                                       // Проверить связанный с домом комплекс
            {
                homeForm = new HomeForm(home, _streets, _complexes);        // Создать форму для редактирования дома

                homeForm.ShowDialog();                                      // Отобразить форму для редактирования дома

                entityNeedSave = homeForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _homes.Add(home);                                       // Добавить созданный дом в список
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                           // Проверить общее количество домов
                {
                    SelectRow(selectedRowIndex);                            // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
