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
    /// Форма. Форма редактирования списка сотрудников
    /// </summary>
    public partial class EmployeesForm : TemplateEntityListForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список сотрудников
        /// </summary>
        IEmployees _employees;

        /// <summary>
        /// Поле. Список людей
        /// </summary>
        IMans _mans;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public EmployeesForm(IEmployees employees, IMans mans)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _employees = employees;                 // Скопировать список сотрудников в поле

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
            DataGridViewColumn columnPosition;                                  // Колонка "Должность"
            DataGridViewColumn columnWorktime;                                  // Колонка "Стаж работы"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Имя"
            columnSurname = new DataGridViewColumn(cellTemplateText);           // Создать колонку "Фамилия"
            columnPatronymic = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Отчество"
            columnPosition = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Должность"
            columnWorktime = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Должность"

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

            columnPosition.Width = 250;                                         // Задать ширину колонки
            columnPosition.Name = "position";                                   // Задать название колонки
            columnPosition.HeaderText = "Должность";                            // Задать заголовок

            columnWorktime.Width = 80;                                          // Задать ширину колонки
            columnWorktime.Name = "worktime";                                   // Задать название колонки
            columnWorktime.HeaderText = "Стаж работы";                          // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSurname);                    // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPatronymic);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPosition);                   // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnWorktime);                   // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения списка сущностей
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
            string position;                                                    // Должность
            string worktime;                                                    // Стаж работы в оценочной деятельности

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            foreach (IEmployee employee in _employees)                          // Выполнить для всех сотрудников из списка сотрудников
            {
                id = ((IEntity)employee).Id.ToString();                         // Получить идентификатор
                description = ((IEntity)employee).Description;                  // Получить описание

                name = null;                                                    // Задать имя
                surname = null;                                                 // Задать фамилию
                patronymic = null;                                              // Задать отчество
                                                                                // Задать должность
                if (employee.Man != null)                                       // Проверить человека, связанного с сотрудником
                {
                    name = employee.Man.Name;                                   // Получить имя
                    surname = employee.Man.Surname;                             // Получить фамилию
                    patronymic = employee.Man.Patronymic;                       // Получить отчество
                }

                position = employee.Position;                                   // Получить дожность
                worktime = employee.WorkTime.ToString();                        // Получить работы в оценочной деятельности

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                    name,
                    surname,
                    patronymic,
                    position,
                    worktime,
                    id,
                    description);
            }

        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает контекстное меню создания нового сотрудника
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
        /// Метод. Удаляет сотрудника из списка сотрудников
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество сотрудников в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного сотрудника

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество сотрудников в списке

            if (rowCount > 0)                                               // Проверить общее количество сотрудников
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор сотрудника в выделенной строке

                _employees.RemoveById(id);                                  // Удалить сотрудника из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенного сотрудника
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IEmployee employee;                                             // Сотрудник
            EmployeeForm employeeForm;                                      // Форма редактирования сотрудника
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенного сотрудника
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор сотрудника в выделенной строке

                employee = _employees.GetEmployee(id);                      // Получить выделенного сотрудника

                employeeForm = new EmployeeForm(employee, _mans);           // Создать форму для редактирования сотрудника

                employeeForm.ShowDialog();                                  // Отобразить форму для редактирования сотрудника

                entityNeedSave = employeeForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
                {
                    _employees.SaveChanges();                               // Сохранить изменения списка сотрудников
                }

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Создает нового сотрудника и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEmployee employee;                                         // Сотрудник
            IMan man;                                                   // Человек связанный с сотрудником
            EmployeeForm employeeForm;                                  // Форма редактирования сотрудника
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество сотрудников в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество сотрудников в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество сотрудников
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            employee = _employees.Create();                             // Создать сотрудника
            man = _mans.Create();                                       // Создать человека связанного с сотрудником
            employee.Man = man;                                         // Связать человека с сотрудником

            employeeForm = new EmployeeForm(employee, _mans);           // Создать форму для редактирования сотрудника

            employeeForm.ShowDialog();                                  // Отобразить форму для редактирования сотрудника

            entityNeedSave = employeeForm.EntityNeedSave;               // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _employees.Add(employee);                               // Добавить созданного сотрудника в список
            }

            FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                           // Проверить общее количество сотрудников
            {
                SelectRow(selectedRowIndex);                            // Выделить строку
            }

            SetButtonActivity();                                        // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Создает нового сотрудника на основе свободного человека и открывает диалоговое окно для его редактирования
        /// </summary>
        private void addByMenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEmployee employee;                                         // Сотрудник
            EmployeeForm employeeForm;                                  // Форма редактирования сотрудника
            ManSelectForm manSelectForm;                                // Форма выбора человека
            DataGridViewRow selectedRow;                                // Выделенная строка

            int rowCount;                                               // Общее количество сотрудников в списке
            int selectedRowIndex;                                       // Индекс выделенной строки
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                 // Получить общее количество сотрудников в списке

            selectedRowIndex = 0;                                       // Задать индекс выделенной строки
            if (rowCount > 0)                                           // Проверить общее количество сотрудников
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];     // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                   // Получить индекс выделенной строки
            }

            employee = _employees.Create();                             // Создать сотрудника

            manSelectForm = new ManSelectForm(                          // Создать форму выбора человека
                _mans, 
                null,
                ManSelectForm.ManSelectType.SelectForEmployee);             

            manSelectForm.ShowDialog();                                 // Отобразить форму выбора человека

            employee.Man = manSelectForm.SelectedMan;                   // Связать человека с сотрудником

            if (employee.Man != null)                                   // Проверить связанного с сотрудником человека
            {
                employeeForm = new EmployeeForm(employee, _mans);       // Создать форму для редактирования сотрудника

                employeeForm.ShowDialog();                              // Отобразить форму для редактирования сотрудника

                entityNeedSave = employeeForm.EntityNeedSave;           // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                             // Проверить флаг необходимости сохранения сущности
                {
                    _employees.Add(employee);                           // Добавить созданного сотрудника в список
                }

                FillEntitiesDataGridView();                             // Заполнить данными элемент отображения списка сущностей

                if (rowCount > 0)                                       // Проверить общее количество сотрудников
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
