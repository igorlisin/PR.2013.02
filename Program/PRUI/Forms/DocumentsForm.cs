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
    /// Форма. Форма редактирования списка документов
    /// </summary>
    public partial class DocumentsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список документов
        /// </summary>
        IDocuments _documents;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsForm(IDocuments documents)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _documents = documents;                 // Сохранить список документов в поле

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

            DataGridViewColumn columnType;                                      // Колонка "Тип документа"
            DataGridViewColumn columnSeries;                                    // Колонка "Серия"
            DataGridViewColumn columnNumber;                                    // Колонка "Номер"
            DataGridViewColumn columnDateOfIssue;                               // Колонка "Дата выдачи"
            DataGridViewColumn columnPlaceOfIssue;                              // Колонка "Место выдачи"
            DataGridViewColumn columnId;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnType = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Тип документа"
            columnSeries = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Серия"
            columnNumber = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Номер"
            columnDateOfIssue = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Дата выдачи"
            columnPlaceOfIssue = new DataGridViewColumn(cellTemplateText);      // Создать колонку "Место выдачи"
            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"

            columnType.Width = 160;                                             // Задать ширину колонки
            columnType.Name = "type";                                           // Задать название колонки
            columnType.HeaderText = "Тип";                                      // Задать заголовок

            columnSeries.Width = 60;                                            // Задать ширину колонки
            columnSeries.Name = "series";                                       // Задать название колонки
            columnSeries.HeaderText = "Серия";                                  // Задать заголовок

            columnNumber.Width = 80;                                            // Задать ширину колонки
            columnNumber.Name = "number";                                       // Задать название колонки
            columnNumber.HeaderText = "Номер";                                  // Задать заголовок

            columnDateOfIssue.Width = 70;                                       // Задать ширину колонки
            columnDateOfIssue.Name = "dateOfIssue";                             // Задать название колонки
            columnDateOfIssue.HeaderText = "Дата выдачи";                       // Задать заголовок

            columnPlaceOfIssue.Width = 250;                                     // Задать ширину колонки
            columnPlaceOfIssue.Name = "placeOfIssue";                           // Задать название колонки
            columnPlaceOfIssue.HeaderText = "Место выдачи";                     // Задать заголовок

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            entitiesDataGridView.Columns.Add(columnType);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSeries);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnNumber);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDateOfIssue);                // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPlaceOfIssue);               // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string type;                                                    // Тип
            string series;                                                  // Серия 
            string number;                                                  // Номер
            string dateOfIssue;                                             // Дата выдачи 
            string placeOfIssue;                                            // Место выдачи
            string id;                                                      // Идентификатор
            string description;                                             // Описание

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IDocument document in _documents)                      // Выполнить для всех документов из списка документов
            {
                id = ((IEntity)document).Id.ToString();                     // Получить идентификатор
                description = ((IEntity)document).Description;              // Получить описание
                type = document.TypeAsString;                               // Получить тип документа (как текстовую строку)
                series = document.Series.ToString();                        // Получить серию
                number = document.Number.ToString();                        // Получить номер
                dateOfIssue = document.DataOfIssue.ToShortDateString();     // Получить дату выдачи
                placeOfIssue = document.PlaceOfIssue;                       // Получить дату выдачи

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    type,
                    series,
                    number,
                    dateOfIssue,
                    placeOfIssue,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Создает новый документ и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            IDocument document;                                         // Документ
            DocumentForm documentForm;                                  // Форма редактирования документа
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

            document = _documents.Create();                             // Создать документ

            documentForm = new DocumentForm(document);                  // Создать форму для редактирования документа

            documentForm.ShowDialog();                                  // Отобразить форму для редактирования документа

            entityNeedSave = documentForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _documents.Add(document);                               // Добавить созданный документ в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество документов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
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

                _documents.RemoveById(id);                                  // Удалить документ из списка

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
            IDocument document;                                             // Документ
            DocumentForm documentForm;                                      // Форма редактирования документа
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

                document = _documents.GetDocument(id);                      // Получить выделенный документ

                documentForm = new DocumentForm(document);                  // Создать форму для редактирования документа

                documentForm.ShowDialog();                                  // Отобразить форму для редактирования документа

                entityNeedSave = documentForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _documents.SaveChanges();                               // Сохранить изменения списка документов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        #endregion

        #endregion
    }
}
