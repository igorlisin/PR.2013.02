using System;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class DistrictSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список районов
        /// </summary>
        IDistricts _districts;

        /// <summary>
        /// Поле. Выбранный район
        /// </summary>
        IDistrict _selectedDistrict;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный 
        /// </summary>
        public IDistrict SelectedDistrict
        {
            get
            {
                return (_selectedDistrict);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DistrictSelectForm(IDistricts districts)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _districts = districts;                 // Скопировать список комплексов в поле

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
            DataGridViewCell cellTemplateText;                                                      // Шаблон ячеек

            DataGridViewColumn columnId;                                                            // Колонка "Идентификатор"
            DataGridViewColumn columnName;                                                        // Колонка "Номер"
     
            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку "Идентификатор"
            columnName = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Номер"

            columnId.Width = 100;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            columnName.Width = 110;                                                               // Задать ширину колонки
            columnName.Name = "number";                                                           // Задать название колонки
            columnName.HeaderText = "Номер";                                                      // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                      // Идентификатор
            string number;                                                  // Номер

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IDistrict district in _districts)                        // Выполнить для всех комплексов из списка комплексов
            {
                id = ((IEntity)district).Id.ToString();                      // Получить идентификатор

                number = district.Name;                                      // Получить номер

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                        number,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает комплекс из списка комплексов, сохраняет в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного комплекса

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор комплекса в выделенной строке

                _selectedDistrict = _districts.GetDistrict(id);               // Получить выделенный комплекс
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion

        #endregion
    }
}
