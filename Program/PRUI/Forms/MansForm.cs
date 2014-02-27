using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class MansForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Cписок людей
        /// </summary>
        IMans _mans;

        /// <summary>
        /// Поле. Cписок документов
        /// </summary>
        IDocuments _documents;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public MansForm(IMans mans, IDocuments documents)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _mans = mans;                           // Скопировать список людей в поле

            _documents = documents;                 // Скопировать список документов в поле

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
            DataGridViewColumn columnName;                                      // Колонка "Имя"
            DataGridViewColumn columnSurname;                                   // Колонка "Фамилия"
            DataGridViewColumn columnPatronymic;                                // Колонка "Отчество"
            DataGridViewColumn columnDocumentType;                              // Колонка "Тип документа"
            DataGridViewColumn columnSeries;                                    // Колонка "Серия"
            DataGridViewColumn columnNumber;                                    // Колонка "Номер"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Имя"
            columnSurname = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Фамилия"
            columnPatronymic = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Отчество"
            columnDocumentType = new DataGridViewColumn(cellTemplateText);      // Создать колонку "Тип документа"
            columnSeries = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Серия"
            columnNumber = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Номер"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnName.Width = 80;                                              // Задать ширину колонки
            columnName.Name = "name";                                           // Задать название колонки
            columnName.HeaderText = "Имя";                                      // Задать заголовок

            columnSurname.Width = 110;                                          // Задать ширину колонки
            columnSurname.Name = "surname";                                     // Задать название колонки
            columnSurname.HeaderText = "Фамилия";                               // Задать заголовок

            columnPatronymic.Width = 110;                                       // Задать ширину колонки
            columnPatronymic.Name = "patronymic";                               // Задать название колонки
            columnPatronymic.HeaderText = "Отчество";                           // Задать заголовок

            columnDocumentType.Width = 160;                                     // Задать ширину колонки
            columnDocumentType.Name = "documentType";                           // Задать название колонки
            columnDocumentType.HeaderText = "Тип документа";                    // Задать заголовок

            columnSeries.Width = 60;                                            // Задать ширину колонки
            columnSeries.Name = "series";                                       // Задать название колонки
            columnSeries.HeaderText = "Серия";                                  // Задать заголовок

            columnNumber.Width = 80;                                            // Задать ширину колонки
            columnNumber.Name = "number";                                       // Задать название колонки
            columnNumber.HeaderText = "Номер";                                  // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSurname);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPatronymic);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDocumentType);               // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSeries);                     // Добавить колонку в элемент отображения списка сущностей
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
            string id;                                                          // Идентификатор
            string description;                                                 // Описание
            string name;                                                        // Имя
            string surname;                                                     // Фамилия
            string patronymic;                                                  // Отчество
            string documentType;                                                // Тип документа
            string series;                                                      // Серия документа
            string number;                                                      // Номер документа

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка людей

            foreach (IMan man in _mans)                                         // Выполнить для всех людей из списка людей
            {
                id = ((IEntity)man).Id.ToString();                              // Получить идентификатор
                description = ((IEntity)man).Description;                       // Получить описание

                name = man.Name;                                                // Получить имя
                surname = man.Surname;                                          // Получить фамилию
                patronymic = man.Patronymic;                                    // Получить отчество

                documentType = null;                                            // Задать тип документа
                series = null;                                                  // Задать серию документа
                number = null;                                                  // Задать номер документа

                if (man.Document != null)                                       // Проверить документ связанный с человеком
                {
                    documentType = man.Document.TypeAsString;                   // Задать тип документа (как текстовую строку)
                    series = man.Document.Series.ToString();                    // Получить серию документа
                    number = man.Document.Number.ToString();                    // Получить номер документа
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                    name,
                    surname,
                    patronymic,
                    documentType,
                    series, number,
                    id,
                    description);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового человека
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
        /// Метод. Удаляет человека из списка людей
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество людей в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного человека

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество людей в списке

            if (rowCount > 0)                                               // Проверить общее количество людей
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор человека в выделенной строке

                _mans.RemoveById(id);                                       // Удалить человека из списка
                _mans.SaveChanges();                                        // Сохранить изменения списка людей

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка людей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного человека
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IMan man;                                                   // Человек для редактирования 
            ManForm manForm;                                            // Форма редактирования человека
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество строк в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения человека после редактирования

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество строк в списке

            if (rowCount > 0)                                           // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки

                man = _mans.ToList()[selectedRowIndex];                 // Получить выделенного человека

                manForm = new ManForm(man, _documents);                             // Создать форму для редактирования человека

                manForm.ShowDialog();                                   // Отобразить форму для редактирования человека

                entityNeedSave = manForm.EntityNeedSave;                // Получить значение флага необходимости сохранения человека

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения человека
                {
                    _mans.SaveChanges();                                // Сохранить изменения списка людей
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка людей

                SelectRow(selectedRowIndex);                            // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает нового человека и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMan man;                                                   // Человек
            IDocument document;                                         // Документ связанный с человеком
            ManForm manForm;                                            // Форма редактирования человека
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество людей в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество людей в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество людей
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            man = _mans.Create();                                       // Создать человека
            document = _documents.Create();                             // Создать документ связанный с человеком
            man.Document = document;                                    // Связать документ с человеком

            manForm = new ManForm(man, _documents);                      // Создать форму для редактирования человека

            manForm.ShowDialog();                                       // Отобразить форму для редактирования человека

            entityNeedSave = manForm.EntityNeedSave;                    // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _mans.Add(man);                                         // Добавить созданного человека в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество людей
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает нового человека на основе свободного документа и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMan man;                                                           // Клиент
            ManForm manForm;                                                    // Форма редактирования человека
            DocumentSelectForm documentSelectForm;                              // Форма выбора документа
            DataGridViewRow selectedRow;                                        // Выделенная строка

            int rowCount;                                                       // Общее количество людей в списке
            int selectedRowIndex;                                               // Индекс выделенной строки
            bool entityNeedSave;                                                // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                         // Получить общее количество людей в списке

            selectedRowIndex = 0;                                               // Задать индекс выделенной строки
            if (rowCount > 0)                                                   // Проверить общее количество людей
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];             // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                           // Получить индекс выделенной строки
            }

            man = _mans.Create();                                               // Создать человека

            documentSelectForm = new DocumentSelectForm(_documents, null);      // Создать форму выбора документа

            documentSelectForm.ShowDialog();                                    // Отобразить форму выбора документа

            man.Document = documentSelectForm.SelectedDocument;                 // Связать документ с человеком

            if (man.Document != null)                                           // Проверить связанный с человеком документ
            {
                manForm = new ManForm(man, _documents);                         // Создать форму для редактирования человека

                manForm.ShowDialog();                                           // Отобразить форму для редактирования человека

                entityNeedSave = manForm.EntityNeedSave;                        // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                     // Проверить флаг необходимости сохранения сущности
                {
                    _mans.Add(man);                                             // Добавить созданного человека в список
                }

                FillEntitiesDataGridView();                                     // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                               // Проверить общее количество людей
                {
                    SelectRow(selectedRowIndex);                                // Выделить строку
                }

                SetButtonActivity();                                            // Задать активность элементов управления
            }
        }

        #endregion

        #endregion
    }
}
