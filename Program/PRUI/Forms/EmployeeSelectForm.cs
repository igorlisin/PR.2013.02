using System;
using System.Windows.Forms;
using System.Drawing;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма выбора работника
    /// </summary>
    public partial class EmployeeSelectForm : TemplateEntitySelectForm
    {
        #region Fields
        /// <summary>
        /// Поле. Список работников
        /// </summary>
        IEmployees _employees;

        /// <summary>
        /// Поле. Выбранный работник
        /// </summary>
        IEmployee _selectedEmployee;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранного работника
        /// </summary>
        public IEmployee selectedEmployee
        {
            get
            {
                return (_selectedEmployee);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public EmployeeSelectForm(IEmployees employees)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _employees = employees;                 // Скопировать список сотрудников в поле

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
            DataGridViewCell cellTemplateText;                                                      // Шаблон ячеек

            DataGridViewColumn columnId;                                                            // Колонка идентификатор
            DataGridViewColumn columnManName;                                                       // Колонка имя
            DataGridViewColumn columnManSurname;                                                    // Колонка фамилия
            DataGridViewColumn columnPosition;                                                      // Колонка должность
            DataGridViewColumn columnEdu;                                                           // Колонка Доп образование
            DataGridViewColumn columnWorkTime;                                                      // Колонка Стаж


            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку идентификатора
            columnManName = new DataGridViewColumn(cellTemplateText);                               // Создать колонку имя
            columnManSurname = new DataGridViewColumn(cellTemplateText);                            // Создать колонку фамилия
            columnPosition = new DataGridViewColumn(cellTemplateText);                              // Создать колонку должность
            columnEdu = new DataGridViewColumn(cellTemplateText);                                   // Создать колонку образование
            columnWorkTime = new DataGridViewColumn(cellTemplateText);                              // Создать колонку стаж

            columnId.Width = 100;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            columnManName.Width = 110;                                                                 // Задать ширину колонки
            columnManName.Name = "name";                                                               // Задать название колонки
            columnManName.HeaderText = "Имя";                                                          // Задать заголовок
            columnManName.SortMode = DataGridViewColumnSortMode.Automatic;                             // Задать тип сортировки

            columnManSurname.Width = 110;                                                              // Задать ширину колонки
            columnManSurname.Name = "surname";                                                         // Задать название колонки
            columnManSurname.HeaderText = "Фамилия";                                                   // Задать заголовок
            columnManSurname.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            columnPosition.Width = 110;                                                               // Задать ширину колонки
            columnPosition.Name = "position";                                                         // Задать название колонки
            columnPosition.HeaderText = "Должность";                                                  // Задать заголовок
            columnPosition.SortMode = DataGridViewColumnSortMode.Automatic;                           // Задать тип сортировки

            columnEdu.Width = 110;                                                                   // Задать ширину колонки
            columnEdu.Name = "education";                                                            // Задать название колонки
            columnEdu.HeaderText = "Образование";                                                    // Задать заголовок
            columnEdu.SortMode = DataGridViewColumnSortMode.Automatic;                               // Задать тип сортировки

            columnWorkTime.Width = 110;                                                               // Задать ширину колонки
            columnWorkTime.Name = "worktime";                                                         // Задать название колонки
            columnWorkTime.HeaderText = "Стаж";                                                       // Задать заголовок
            columnWorkTime.SortMode = DataGridViewColumnSortMode.Automatic;                           // Задать тип сортировки

            entitiesDataGridView.Columns.Add(columnManName);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnManSurname);                                      // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPosition);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnEdu);                                             // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnWorkTime);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                              // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                          // Идентификатор
            string name;                                                        // Название имя 
            string surname;                                                     // Название фамилия
            string position;                                                    // Название должность
            string edu;                                                         // Название образование
            string worktime;                                                    // Название стаж

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            foreach (IEmployee employee in _employees)                         // Выполнить для всех сотрудников из списка сотрудников
            {
                id = ((IEntity)employee).Id.ToString();                        // Получить идентификатор

                name = null;                                                  // Задать имя
                surname = null;                                                 // Задать фамилию

                if (employee.Man != null)                                        // Проверить человека, связанный с сотрудником
                {
                    name = employee.Man.Name;                                  // Получить название сотрудника
                    surname = employee.Man.Surname;
 
                }

                position = employee.Position;
                edu = employee.FurtherEducation;
                worktime = employee.WorkTime.ToString();

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                        name,
                        surname,
                        position,
                        edu,
                        worktime,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает сотрудника из списка сотрудников, сохраняет в поле и закрывает диалоговое окно
        /// </summary>

        public EmployeeSelectForm()
        {
            InitializeComponent();
        }


        private void clsEmloyeeSelectBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного работника

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор работника в выделенной строке

                _selectedEmployee = _employees.GetEmployee(id);             // Получить выделенного работника
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }
        #endregion    
        #endregion
    }
}
