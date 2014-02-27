using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class ReportsForm : TemplateEntityListForm
    {
        #region Delegates

        /// <summary>
        /// Делегат. Представляет метод создания отчета
        /// </summary>
        public delegate void CreateReportDocument(IReport report, string reportTemplatesFolderPath, string reportsFolderPath);

        /// <summary>
        /// Делегат. Представляет метод создания отчета
        /// </summary>
        private CreateReportDocument _createReportDocument;

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Список отчетов
        /// </summary>
        private IReports _reports;

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        private IClients _clients;

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        private IEmployees _employees;

        /// <summary>
        /// Поле. Путь к папке с шаблонами отчетов
        /// </summary>
        private string _reportTemplatesFolderPath;

        /// <summary>
        /// Поле. Путь к папке с отчетами
        /// </summary>
        private string _reportsFolderPath;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ReportsForm(IReports reports, IClients clients, IEmployees employees, string reportTemplatesFolderPath, string reportsFolderPath, CreateReportDocument createReportDocumentFunction)
            : base()
        {
            InitializeComponent();                                      // Инициализировать компоненты формы

            _reports = reports;                                         // Сохранить список отчетов в поле
            _clients = clients;                                         // Сохранить список клиентов в поле
            _employees = employees;                                     // Сохранить список сотрудников в поле
            _reportTemplatesFolderPath = reportTemplatesFolderPath;     // Сохранить путь к папке с шаблонами отчетов
            _reportsFolderPath = reportsFolderPath;                     // Сохранить путь к папке с отчетами
            _createReportDocument = createReportDocumentFunction;       // Сохранить делегат метода создания отчета

            ConfigureEntitiesDataGridView();                            // Настроить визуальное представление элемента отображения списка сущностей

            FillEntitiesDataGridView();                                 // Заполнить элемент отображения списка сущностей

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        #endregion

        #region Methods

        #region Other

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка сущностей
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                      // Шаблон ячеек

            DataGridViewColumn columnReportNumber;                                  // Колонка "Номер отчета"
            DataGridViewColumn columnClientFullName;                                // Колонка "Полное имя клиента"
            DataGridViewColumn columnEmployeeFullName;                              // Колонка "Полное имя сотрудника"
            DataGridViewColumn columnEvaluationDate;                                // Колонка "Дата оценки"
            DataGridViewColumn columnReportDate;                                    // Колонка "Дата формирования отчета"
            DataGridViewColumn columnId;                                            // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                                   // Колонка "Описание"

            cellTemplateText = new DataGridViewTextBoxCell();                       // Создать шаблон ячеек

            columnReportNumber = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Номер"
            columnClientFullName = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Полное имя клиента"
            columnEmployeeFullName = new DataGridViewColumn(cellTemplateText);      // Создать колонку "Полное имя сотрудника"
            columnEvaluationDate = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Дата оценки"
            columnReportDate = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Дата формирования отчета"
            columnId = new DataGridViewColumn(cellTemplateText);                    // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Описание"

            columnReportNumber.Width = 90;                                          // Задать ширину колонки
            columnReportNumber.Name = "reportNumber";                               // Задать название колонки
            columnReportNumber.HeaderText = "Номер отчета";                         // Задать заголовок

            columnClientFullName.Width = 250;                                       // Задать ширину колонки
            columnClientFullName.Name = "clientFullName";                           // Задать название колонки
            columnClientFullName.HeaderText = "Полное имя клиента";                 // Задать заголовок

            columnEmployeeFullName.Width = 250;                                     // Задать ширину колонки
            columnEmployeeFullName.Name = "employeeFullName";                       // Задать название колонки
            columnEmployeeFullName.HeaderText = "Полное имя сотрудника";            // Задать заголовок

            columnEvaluationDate.Width = 90;                                        // Задать ширину колонки
            columnEvaluationDate.Name = "evaluationDate";                           // Задать название колонки
            columnEvaluationDate.HeaderText = "Дата оценки";                        // Задать заголовок

            columnReportDate.Width = 90;                                            // Задать ширину колонки
            columnReportDate.Name = "reportDate";                                   // Задать название колонки
            columnReportDate.HeaderText = "Дата отчета";                            // Задать заголовок

            columnId.Width = 100;                                                   // Задать ширину колонки
            columnId.Name = "id";                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                  // Задать заголовок

            columnDescription.Width = 350;                                          // Задать ширину колонки
            columnDescription.Name = "description";                                 // Задать название колонки
            columnDescription.HeaderText = "Описание";                              // Задать заголовок

            entitiesDataGridView.Columns.Add(columnReportNumber);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnClientFullName);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnEmployeeFullName);               // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnEvaluationDate);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnReportDate);                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                             // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                    // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                   // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string reportNumber;                                                                // Номер отчета
            string clientFullName;                                                              // Полное имя клиента 
            string employeeFullName;                                                            // Полное имя сотрудника
            string evaluationDate;                                                              // Дата оценки 
            string reportDate;                                                                  // Дата формирования отчета
            string id;                                                                          // Идентификатор
            string description;                                                                 // Описание

            entitiesDataGridView.Rows.Clear();                                                  // Очистить элемент отображения списка сущностей

            foreach (IReport report in _reports)                                                // Выполнить для всех отчетов из списка отчетов
            {
                id = ((IEntity)report).Id.ToString();                                           // Получить идентификатор
                description = ((IEntity)report).Description;                                    // Получить описание
                reportNumber = report.ReportNumber;                                             // Получить номер отчета

                clientFullName = null;                                                          // Задать полное имя клиента

                if (report.Client != null)                                                      // Проверить клиента, связанного с отчетом
                {
                    if (report.Client.Man != null)                                              // Проверить человека, связанного с клиентом
                    {
                        clientFullName = GetManFullName((IMan)report.Client.Man);               // Получить полное имя клиента
                    }
                }

                employeeFullName = null;                                                        // Задать полное имя сотрудника

                if (report.Employee != null)                                                    // Проверить сотрудника, связанного с отчетом
                {
                    if (report.Employee.Man != null)                                            // Проверить человека, связанного с сотрудником
                    {
                        employeeFullName = GetManFullName((IMan)report.Employee.Man);           // Получить полное имя сотрудника
                    }
                }

                evaluationDate = report.EvaluationDate.ToShortDateString();                     // Получить дату оценки
                reportDate = report.ReportDate.ToShortDateString();                             // Получить дату формирования отчета

                entitiesDataGridView.Rows.Add(                                                  // Добавить строку в элемент отображения списка сущностей
                    reportNumber,
                    clientFullName,
                    employeeFullName,
                    evaluationDate,
                    reportDate,
                    id,
                    description);
            }
        }

        /// <summary>
        /// Метод. Возвращает полное имя человека
        /// </summary>
        private string GetManFullName(IMan man)
        {
            string manFullName;                                                     // Полное имя человека

            manFullName = man.Surname + " " + man.Name + " " + man.Patronymic;      // Получить полное имя человека

            return (manFullName);
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Создает новый отчет и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            IReport report;                                             // Отчет
            ReportForm reportForm;                                      // Форма редактирования отчета
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество отчетов в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество отчетов в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество отчетов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            report = _reports.Create();                                 // Создать отчет

            reportForm = new ReportForm(                                // Создать форму для редактирования отчета
                report,
                _clients,
                _employees);                        

            reportForm.ShowDialog();                                    // Отобразить форму для редактирования отчета

            entityNeedSave = reportForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _reports.Add(report);                                   // Добавить созданный отчет в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество отчетов
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Удаляет отчет из списка отчетов
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество отчетов в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного отчета

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество отчетов в списке

            if (rowCount > 0)                                               // Проверить общее количество отчетов
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор отчета в выделенной строке

                _reports.RemoveById(id);                                    // Удалить отчет из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного отчета
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IReport report;                                                 // Отчет
            ReportForm reportForm;                                          // Форма редактирования отчета
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного отчета
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор отчета в выделенной строке

                report = _reports.GetReport(id);                            // Получить выделенный отчет

                reportForm = new ReportForm(                                // Создать форму для редактирования отчета
                    report,
                    _clients,
                    _employees);                        

                reportForm.ShowDialog();                                     // Отобразить форму для редактирования отчета

                entityNeedSave = reportForm.EntityNeedSave;                 // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _reports.SaveChanges();                                 // Сохранить изменения списка отчетов
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает документ отчета для выделенного отчета
        /// </summary>
        private void createReportButton_Click(object sender, EventArgs e)
        {
            IReport report;                                                                 // Отчет
            DataGridViewRow selectedRow;                                                    // Выделенная строка

            int id;                                                                         // Идентификатор выделенного отчета

            selectedRow = entitiesDataGridView.SelectedRows[0];                             // Получить выделенную строку
            id = Convert.ToInt32(selectedRow.Cells["id"].Value);                            // Получить идентификатор отчета в выделенной строке

            report = _reports.GetReport(id);                                                // Получить выделенный отчет

            _createReportDocument(report, _reportTemplatesFolderPath, _reportsFolderPath);        // Создать документ отчета для выделенного отчета
        }

        #endregion



        #endregion

        #endregion
    }
}
