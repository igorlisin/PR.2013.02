using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{ 
    /// <summary>
    /// Форма. Форма выбора города
    /// </summary>
    public partial class ApartmentSelectForm : TemplateEntitySelectForm
    {
        
        #region Fields

        /// <summary>
        /// Поле. Список 
        /// </summary>
        IApartments _apartments;

        /// <summary>
        /// Поле. Выбранный 
        /// </summary>
        IApartment _selectedApartment;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный 
        /// </summary>
        public IApartment SelectedApartment
        {
            get
            {
                return (_selectedApartment);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApartmentSelectForm(IApartments apartments)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _apartments = apartments;                       // Скопировать список городов в поле

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

            DataGridViewColumn columnId;                                                            // Колонка идентификатора
            DataGridViewColumn columnType;                                                          // Колонка тип квартиры
            DataGridViewColumn columnComplexAddress;                                                // Колонка адрес
            DataGridViewColumn columnStreetAddress;                                                // Колонка адрес
 
            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                                    // Создать колонку идентификатор
            columnType = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку тип квартиры
            columnComplexAddress = new DataGridViewColumn(cellTemplateText);                        // Создать колонку адрес по комплексу
            columnStreetAddress = new DataGridViewColumn(cellTemplateText);                         // Создать колонку адрес по улице

            columnId.Width = 50;                                                                   // Задать ширину колонки
            columnId.Name = "id";                                                                   // Задать название колонки
            columnId.HeaderText = "Идентификатор";                                                  // Задать заголовок

            columnType.Width = 110;                                                                 // Задать ширину колонки
            columnType.Name = "type";                                                               // Задать название колонки
            columnType.HeaderText = "Тип";                                                          // Задать заголовок
            columnType.SortMode = DataGridViewColumnSortMode.Automatic;                             // Задать тип сортировки

            columnComplexAddress.Width = 170;                                                              // Задать ширину колонки
            columnComplexAddress.Name = "complexaddress";                                                         // Задать название колонки
            columnComplexAddress.HeaderText = "Адрес по компл";                                                     // Задать заголовок
            columnComplexAddress.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            columnStreetAddress.Width = 170;                                                              // Задать ширину колонки
            columnStreetAddress.Name = "streetaddress";                                                         // Задать название колонки
            columnStreetAddress.HeaderText = "Адрес по ул";                                                     // Задать заголовок
            columnStreetAddress.SortMode = DataGridViewColumnSortMode.Automatic;                          // Задать тип сортировки

            entitiesDataGridView.Columns.Add(columnType);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnComplexAddress);                                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnStreetAddress);                                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                                             // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                          // Идентификатор
            string type;                                                        // Тип
            string complexaddress;                                              // Адрес
            string streetaddress;                                               // Адрес по улице
            type = null;
            complexaddress = null;
            streetaddress = null;

            entitiesDataGridView.Rows.Clear();                                                // Очистить элемент отображения списка сущностей

            foreach (IApartment apartment in _apartments)                                     // Выполнить для всех квартир из списка квартир
            {
                id = ((IEntity)apartment).Id.ToString();                                      // Получить идентификатор

                type = apartment.RoomNumber.ToString();                                         // Задать тип
                
                if(apartment.Home!=null)
                {
                    if (apartment.Home.Complex != null)
                    {
                        complexaddress = apartment.Home.ComplexNumber + "-" + apartment.Number;                                               // Получить адрес по комплексу
                    }
                    if (apartment.Home.Street.Name != null)
                    {
                        streetaddress = apartment.Home.Street.Name + " " + apartment.Home.Number + ", " + apartment.Number;                 // Получить адрес по улице
                    }
                }


                entitiesDataGridView.Rows.Add(                                  // Добавить строку в элемент отображения списка сущностей
                        type,
                        complexaddress,
                        streetaddress,
                        id);
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает квартиру из списка квартир, сохраняет в поле и закрывает диалоговое окно
        /// </summary>

        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного квартиры

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор квартиры в выделенной строке

                _selectedApartment = _apartments.GetAppartment(id);                        // Получить выделенный квартиру
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }


        #endregion
    }
}
        #endregion