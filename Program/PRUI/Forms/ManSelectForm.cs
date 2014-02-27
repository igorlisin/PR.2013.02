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
    /// Форма. Форма выбора человека
    /// </summary>
    public partial class ManSelectForm : TemplateEntitySelectForm
    {
        /// <summary>
        /// Перечисление. Цель выбора человека
        /// </summary>
        public enum ManSelectType
        {
            /// <summary>
            /// Перечисление. Человек выбирается для связи с клиентом
            /// </summary>
            SelectForClient = 1,
            /// <summary>
            /// Перечисление. Человек выбирается для связи с сотрудником
            /// </summary>
            SelectForEmployee = 2
        }

        #region Fields

        /// <summary>
        /// Поле. Список людей
        /// </summary>
        IMans _mans;

        /// <summary>
        /// Текущий человек
        /// </summary>
        IMan _currentMan;

        /// <summary>
        /// Поле. Выбранный человека
        /// </summary>
        IMan _selectedMan;

        /// <summary>
        /// Поле. Цель выбора человека
        /// </summary>
        ManSelectType _manSelectType;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранного человека
        /// </summary>
        public IMan SelectedMan
        {
            get
            {
                return (_selectedMan);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ManSelectForm(IMans mans, IMan currentMan, ManSelectType manSelectType)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _mans = mans;                           // Скопировать список людей в поле

            _currentMan = currentMan;               // Скопировать текущего человека в поле

            _manSelectType = manSelectType;         // Скопировать цель выбора человека

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

            DataGridViewColumn columnId;                                                            // Колонка "Идентификатор"
            DataGridViewColumn columnName;                                                          // Колонка "Имя"
            DataGridViewColumn columnSurname;                                                       // Колонка "Фамилия"
            DataGridViewColumn columnPatronymic;                                                    // Колонка "Отчество"

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnName = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Имя"
            columnSurname = new DataGridViewColumn(cellTemplateText);                               // Создать колонку "Фамилия"
            columnPatronymic = new DataGridViewColumn(cellTemplateText);                            // Создать колонку "Отчество"

            columnName.Width = 80;                                                                  // Задать ширину колонки
            columnName.Name = "name";                                                               // Задать название колонки
            columnName.HeaderText = "Имя";                                                          // Задать заголовок
            columnName.SortMode = DataGridViewColumnSortMode.Automatic;                             // Задать тип сортировки

            columnSurname.Width = 110;                                                              // Задать ширину колонки
            columnSurname.Name = "surname";                                                         // Задать название колонки
            columnSurname.HeaderText = "Фамилия";                                                   // Задать заголовок
            columnSurname.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            columnPatronymic.Width = 110;                                                           // Задать ширину колонки
            columnPatronymic.Name = "patronymic";                                                   // Задать название колонки
            columnPatronymic.HeaderText = "Отчество";                                               // Задать заголовок
            columnPatronymic.SortMode = DataGridViewColumnSortMode.Automatic;                       // Задать тип сортировки

            columnId.Width = 100;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSurname);                                        // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnPatronymic);                                     // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                              // Идентификатор
            string name;                                            // Имя
            string surname;                                         // Фамилия
            string patronymic;                                      // Отчество
 
            entitiesDataGridView.Rows.Clear();                      // Очистить элемент отображения списка сущностей

            if (_currentMan != null)                                // Проверить текущего человека
            {
                id = ((IEntity)_currentMan).Id.ToString();          // Получить идентификатор
                name = _currentMan.Name;                            // Получить имя
                surname = _currentMan.Surname;                      // Получить фамилию
                patronymic = _currentMan.Patronymic;                // Получить отчество

                entitiesDataGridView.Rows.Add(                      // Добавить строку в элемент отображения списка сущностей
                    name,
                    surname,
                    patronymic,
                    id);
            }

            foreach (IMan man in _mans)                             // Выполнить для всех людей из списка людей
            {
                if (man != _currentMan)                             // Проверить текущего человека (проверка необходима для того, чтобы текущий человек не попал в список дважды)
                {
                    id = ((IEntity)man).Id.ToString();              // Получить идентификатор

                    switch (_manSelectType)                         // Проверить цель выбора человека
                    {
                        case (ManSelectType.SelectForClient):       // Цель выбора человека: человек выбирается для связи с клиентом

                            #region SelectForClient

                            if (man.Client == null)                 // Проверить клиента, связанного с человеком
                            {
                                name = man.Name;                    // Получить имя
                                surname = man.Surname;              // Получить фамилию
                                patronymic = man.Patronymic;        // Получить отчество

                                entitiesDataGridView.Rows.Add(      // Добавить строку в элемент отображения списка сущностей
                                    name,
                                    surname,
                                    patronymic,
                                    id);
                            }

                            break;

                            #endregion

                        case (ManSelectType.SelectForEmployee):     // Цель выбора человека: человек выбирается для связи с сотрудником

                            #region SelectForEmployee

                            if (man.Employee == null)               // Проверить сотрудника, связанного с человеком
                            {
                                name = man.Name;                    // Получить имя
                                surname = man.Surname;              // Получить фамилию
                                patronymic = man.Patronymic;        // Получить отчество

                                entitiesDataGridView.Rows.Add(      // Добавить строку в элемент отображения списка сущностей
                                    name,
                                    surname,
                                    patronymic,
                                    id);
                            }

                            break;

                            #endregion
                    }
                }
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает человека из списка людей, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного человека

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор человека в выделенной строке

                _selectedMan = _mans.GetMan(id);                            // Получить выделенного человека
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
