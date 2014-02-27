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
    /// Форма. Форма редактирования списка клиентов
    /// </summary>
    public partial class ClientsForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        IClients _clients;

        /// <summary>
        /// Поле. Список людей
        /// </summary>
        IMans _mans;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientsForm(IClients clients, IMans mans)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _clients = clients;                     // Скопировать список клиентов в поле

            _mans = mans;                           // Скопировать список людей в поле

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

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string name;                                                        // Имя
            string surname;                                                     // Фамилия
            string patronymic;                                                  // Отчество
            string documentType;                                                // Тип документа (как текстовая строка)
            string series;                                                      // Серия документа
            string number;                                                      // Номер документа
            string id;                                                          // Идентификатор
            string description;                                                 // Описание

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            foreach (IClient client in _clients)                                // Выполнить для всех клиентов из списка клиентов
            {
                id = ((IEntity)client).Id.ToString();                           // Получить идентификатор
                description = ((IEntity)client).Description;                    // Получить описание

                name = null;                                                    // Задать имя
                surname = null;                                                 // Задать фамилию
                patronymic = null;                                              // Задать отчество

                documentType = null;                                            // Задать тип документа
                series = null;                                                  // Задать серию документа
                number = null;                                                  // Задать номер документа

                if (client.Man != null)                                         // Проверить человека, связанного с клиентом
                {
                    name = client.Man.Name;                                     // Получить имя
                    surname = client.Man.Surname;                               // Получить фамилию
                    patronymic = client.Man.Patronymic;                         // Получить отчество

                    if (client.Man.Document != null)                            // Проверить документ, связанный с человеком
                    {
                        documentType = client.Man.Document.TypeAsString;        // Получить тип документа (как текстовую строку)
                        series = client.Man.Document.Series.ToString();         // Получить серию документа
                        number = client.Man.Document.Number.ToString();         // Получить номер документа
                    }
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                    name,
                    surname,
                    patronymic,
                    documentType,
                    series, 
                    number,
                    id,
                    description);
            }

        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового клиента
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
        /// Метод. Удаляет клиента из списка клиентов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество клиентов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного клиента

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество клиентов в списке

            if (rowCount > 0)                                               // Проверить общее количество клиентов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор клиента в выделенной строке

                _clients.RemoveById(id);                                    // Удалить клиента из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного клиента
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IClient client;                                                 // Клиент
            ClientForm clientForm;                                          // Форма редактирования клиента
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного клиента
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор клиента в выделенной строке

                client = _clients.GetClient(id);                            // Получить выделенного клиента

                clientForm = new ClientForm(client, _mans);                 // Создать форму для редактирования клиента

                clientForm.ShowDialog();                                    // Отобразить форму для редактирования клиента

                entityNeedSave = clientForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _clients.SaveChanges();                                 // Сохранить изменения списка клиентов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает нового клиента и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IClient client;                                             // Клиент
            IMan man;                                                   // Человек связанный с клиентом
            ClientForm clientForm;                                      // Форма редактирования клиента
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество клиентов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество клиентов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество клиентов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            client = _clients.Create();                                 // Создать клиента
            man = _mans.Create();                                       // Создать человека связанного с клиентом
            client.Man = man;                                           // Связать человека с клиентом

            clientForm = new ClientForm(client, _mans);                 // Создать форму для редактирования клиента

            clientForm.ShowDialog();                                    // Отобразить форму для редактирования клиента

            entityNeedSave = clientForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _clients.Add(client);                                   // Добавить созданного клиента в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество клиентов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает нового клиента на основе свободного человека и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByMenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IClient client;                                             // Клиент
            ClientForm clientForm;                                      // Форма редактирования клиента
            ManSelectForm manSelectForm;                                // Форма выбора человека
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество клиентов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество клиентов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество клиентов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            client = _clients.Create();                                 // Создать клиента

            manSelectForm = new ManSelectForm(                          // Создать форму выбора человека
                _mans, 
                null,
                ManSelectForm.ManSelectType.SelectForClient);             

            manSelectForm.ShowDialog();                                 // Отобразить форму выбора человека

            client.Man = manSelectForm.SelectedMan;                     // Связать человека с клиентом

            if (client.Man != null)                                     // Проверить связанного с клиентом человека
            {
                clientForm = new ClientForm(client, _mans);             // Создать форму для редактирования клиента

                clientForm.ShowDialog();                                // Отобразить форму для редактирования клиента

                entityNeedSave = clientForm.EntityNeedSave;             // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _clients.Add(client);                               // Добавить созданного клиента в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество клиентов
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
