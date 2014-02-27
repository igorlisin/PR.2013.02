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
    /// Форма. Форма выбора клиента
    /// </summary>
    public partial class ClientSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        IClients _clients;

        /// <summary>
        /// Текущий клиент
        /// </summary>
        IClient _currentClient;

        /// <summary>
        /// Поле. Выбранный клиент
        /// </summary>
        IClient _selectedClient;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранного клиента
        /// </summary>
        public IClient SelectedClient
        {
            get
            {
                return (_selectedClient);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientSelectForm(IClients clients, IClient currentClient)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _clients = clients;                     // Скопировать список клиентов в поле

            _currentClient = currentClient;         // Скопировать текущего клиента в поле

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
            IMan man;                                                           // Человек, связанный с клиентом

            string id;                                                          // Идентификатор
            string name;                                                        // Имя
            string surname;                                                     // Фамилия
            string patronymic;                                                  // Отчество
 
            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            if (_currentClient != null)                                         // Проверить текущего клиента
            {
                name = null;                                                    // Задать имя
                surname = null;                                                 // Задать фамилию
                patronymic = null;                                              // Задать отчество

                id = ((IEntity)_currentClient).Id.ToString();                   // Получить идентификатор

                if (_currentClient.Man != null)                                 // Проверить человека, связанного с клиентом
                {
                    man = _currentClient.Man;                                   // Получить человека, связанного с клиентом
                    name = man.Name;                                            // Получить имя
                    surname = man.Surname;                                      // Получить фамилию
                    patronymic = man.Patronymic;                                // Получить отчество
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                    name,
                    surname,
                    patronymic,
                    id);
            }

            foreach (IClient client in _clients)                                // Выполнить для всех клиентов из списка клиентов
            {
                id = ((IEntity)client).Id.ToString();                           // Получить идентификатор

                name = null;                                                    // Задать имя
                surname = null;                                                 // Задать фамилию
                patronymic = null;                                              // Задать отчество

                if (client.Man != null)                                         // Проверить человека, связанного с клиентом
                {
                    man = client.Man;                                           // Получить человека, связанного с клиентом
                    name = man.Name;                                            // Получить имя
                    surname = man.Surname;                                      // Получить фамилию
                    patronymic = man.Patronymic;                                // Получить отчество
                }

                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                        name,
                        surname,
                        patronymic,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает клиента из списка клиентов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного клиента

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор клиента в выделенной строке

                _selectedClient = _clients.GetClient(id);                   // Получить выделенного клиента
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
