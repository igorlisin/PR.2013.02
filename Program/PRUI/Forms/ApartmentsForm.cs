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
    /// Форма. Форма редактирования списка квартир
    /// </summary>
    public partial class ApartmentsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список квартир
        /// </summary>
        IApartments _apartments;

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        IHomes _homes;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApartmentsForm(IApartments apartments, IHomes homes)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _apartments = apartments;               // Сохранить список квартир в поле

            _homes = homes;                         // Сохранить список домов с поле

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
            DataGridViewColumn columnNumber;                                    // Колонка "Номер квартиры"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnNumber = new DataGridViewColumn(cellTemplateText);            // Создать колонку "квартиры"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnNumber.Width = 160;                                           // Задать ширину колонки
            columnNumber.Name = "number";                                       // Задать название колонки
            columnNumber.HeaderText = "Номер квартиры";                             // Задать заголовок

            entitiesDataGridView.Columns.Add(columnNumber);                     // Добавить колонку в элемент отображения списка сущностей
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
            string number;                                          // Номер квартиры

            entitiesDataGridView.Rows.Clear();                      // Очистить элемент отображения списка сущностей

            foreach (IApartment apartment in _apartments)           // Выполнить для всех квартир из списка квартир
            {
                id = ((IEntity)apartment).Id.ToString();            // Получить идентификатор
                description = ((IEntity)apartment).Description;     // Получить описание

                number = apartment.Number.ToString();               // Получить номер квартиры

                entitiesDataGridView.Rows.Add(                      // Добавить строку в элемент отображения списка сущностей
                    number,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания новой квартиры
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
        /// Метод. Удаляет квартиру из списка квартир
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество квартир в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной квартиры

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество квартир в списке

            if (rowCount > 0)                                               // Проверить общее количество квартир
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор квартиры в выделенной строке

                _apartments.RemoveById(id);                                 // Удалить квартиру из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенной квартиры
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IApartment apartment;                                           // Квартира
            ApartmentForm apartmentForm;                                    // Форма редактирования квартиры
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной квартиры
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор квартиры в выделенной строке

                apartment = _apartments.GetAppartment(id);                  // Получить выделенную квартиру

                apartmentForm = new ApartmentForm(apartment, _homes);       // Создать форму для редактирования квартиры

                apartmentForm.ShowDialog();                                 // Отобразить форму для редактирования квартиры

                entityNeedSave = apartmentForm.EntityNeedSave;              // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _apartments.SaveChanges();                              // Сохранить изменения списка квартир
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает новую квартиру и открывает диалоговое окно для ее редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IApartment apartment;                                       // Квартира
            IHome home;                                                 // Дом, связанный с квартирой
            ApartmentForm apartmentForm;                                // Форма редактирования квартиры
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество квартир в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество квартир в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество квартир
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            apartment = _apartments.Create();                           // Создать квартиру
            home = _homes.Create();                                     // Создать дом, связанный с квартирой
            apartment.Home = home;                                      // Связать дом с квартирой

            apartmentForm = new ApartmentForm(apartment, _homes);       // Создать форму для редактирования квартиры

            apartmentForm.ShowDialog();                                 // Отобразить форму для редактирования квартиры

            entityNeedSave = apartmentForm.EntityNeedSave;              // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _apartments.Add(apartment);                             // Добавить созданную квартиру в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество квартир
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает новую квартиру на основе дома и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByStreetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IApartment apartment;                                           // Квартира
            ApartmentForm homeForm;                                         // Форма редактирования квартиры
            HomeSelectForm homeSelectForm;                                  // Форма выбора дома
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество квартир в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество квартир в списке

            selectedRowIndex = 0;                                           // Задать индекс выделенной строки
            if (rowCount > 0)                                               // Проверить общее количество квартир
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
            }

            apartment = _apartments.Create();                               // Создать квартиру

            homeSelectForm = new HomeSelectForm(_homes);                    // Создать форму выбора дома

            homeSelectForm.ShowDialog();                                    // Отобразить форму выбора дома

            apartment.Home = homeSelectForm.SelectedHome;                   // Связать дом с квартирой

            if (apartment.Home != null)                                     // Проверить связанный с квартирой дом
            {
                homeForm = new ApartmentForm(apartment, _homes);            // Создать форму для редактирования квартиры

                homeForm.ShowDialog();                                      // Отобразить форму для редактирования квартиры

                entityNeedSave = homeForm.EntityNeedSave;                   // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _apartments.Add(apartment);                             // Добавить созданную квартиру в список
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                           // Проверить общее количество квартир
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
