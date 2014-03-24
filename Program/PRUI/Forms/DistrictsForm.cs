using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class DistrictsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список районов
        /// </summary>
        IDistricts _districts;

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        ICities _cities;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DistrictsForm(IDistricts districts, ICities cities)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _districts = districts;                 // Сохранить список районов в поле
            _cities = cities;                           // Сохранить список районов в поле
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

            DataGridViewColumn columnName;                                      // Колонка "Название района"
            DataGridViewColumn columnId;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название района"
            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"

            columnName.Width = 160;                                             // Задать ширину колонки
            columnName.Name = "name";                                           // Задать название колонки
            columnName.HeaderText = "Название";                                 // Задать заголовок

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

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
            string name;                                                    // Название района
            string id;                                                      // Идентификатор
            string description;                                             // Описание

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IDistrict district in _districts)                      // Выполнить для всех документов из списка документов
            {
                id = ((IEntity)district).Id.ToString();                     // Получить идентификатор
                description = ((IEntity)district).Description;              // Получить описание
                name = district.Name;                                       // Получить район (как текстовую строку)
                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    name,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Создает новый район и открывает диалоговое окно для его редактирования
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
        /// Метод. Удаляет документ из списка документов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество документов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного документа

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество документов в списке

            if (rowCount > 0)                                               // Проверить общее количество документов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор документа в выделенной строке

                _districts.RemoveById(id);                                  // Удалить документ из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного документа
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IDistrict district;                                             // Документ
            DistrictForm districtForm;                                      // Форма редактирования документа
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного документа
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор документа в выделенной строке

                district = _districts.GetDistrict(id);                      // Получить выделенный документ

                districtForm = new DistrictForm(district, _cities);                  // Создать форму для редактирования документа

                districtForm.ShowDialog();                                  // Отобразить форму для редактирования документа

                entityNeedSave = districtForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _districts.SaveChanges();                               // Сохранить изменения списка документов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        #endregion

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDistrict district;                                         // Район
            DistrictForm districtForm;                                  // Форма редактирования документа
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество документов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество документов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество документов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            district = _districts.Create();                             // Создать документ

            districtForm = new DistrictForm(district,_cities);                  // Создать форму для редактирования документа

            districtForm.ShowDialog();                                  // Отобразить форму для редактирования документа

            entityNeedSave = districtForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _districts.Add(district);                               // Добавить созданный документ в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество документов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }
        


        #endregion

        private void addByCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDistrict district;                                         // Район
            DistrictForm districtForm;                                  // Форма редактирования документа
            DataGridViewRow selectedRow;                                // Выделенная строка
            CitySelectForm citySelectForm;                              // Форма выбора города

            int rowCount;                                               // Общее количество документов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество документов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество документов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            district = _districts.Create();                             // Создать Район

            citySelectForm = new CitySelectForm(                        // Создать форму выбора города
     _cities);

            citySelectForm.ShowDialog();                                // Отобразить форму выбора города

            district.City = citySelectForm.SelectedCity;                  // Связать город с улицей

            if (district.City != null)                                    // Проверить связанный с улицей город
            {

            districtForm = new DistrictForm(district,_cities);                  // Создать форму для редактирования Район

            districtForm.ShowDialog();                                  // Отобразить форму для редактирования Район

            entityNeedSave = districtForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _districts.Add(district);                               // Добавить созданный Район в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество Район
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }
        }
    }
}
