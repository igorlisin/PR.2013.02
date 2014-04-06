using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRParser
{
    public partial class ParserForm : Form
    {
        private Parser _parser;
        private Zakamned[] zakamneds;

        public ParserForm()
        {
            InitializeComponent();

            ConfigureEntitiesDataGridView();
        }

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка квартир
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                  // Шаблон ячеек
            DataGridViewCell cellTemplateCheckBox;                            // ячеек с чекбоксами

            DataGridViewColumn columnChecked;
            DataGridViewColumn columnNumber;                                      // Колонка "Адресс"
            DataGridViewColumn columnAddress;                                      // Колонка "Адресс"
            DataGridViewColumn columnFloor;                                    // Колонка "Серия"
            DataGridViewColumn columnArea;                                    // Колонка "Номер"
            DataGridViewColumn columnBalcony;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnPhone;                               // Колонка "Описание"
            DataGridViewColumn columnIronDoor;                               // Колонка "Описание"
            DataGridViewColumn columnCompany;                               // Колонка "Описание"
            DataGridViewColumn columnPhoneToCall;                               // Колонка "Описание"
            DataGridViewColumn columnPrice;                               // Колонка "Описание"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек
            cellTemplateCheckBox = new DataGridViewCheckBoxCell();

            columnChecked = new DataGridViewColumn(cellTemplateCheckBox);
            columnNumber = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Тип документа"
            columnAddress = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Тип документа"
            columnFloor = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Серия"
            columnArea = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Номер"
            columnBalcony = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnPhone = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnIronDoor = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnCompany = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnPhoneToCall = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnPrice = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"

            columnChecked.Width = 50;
            columnChecked.Name = "checked";
            columnChecked.Selected = false;
            columnChecked.HeaderText = "Выбрать";
           

            columnNumber.Width = 50;                                             // Задать ширину колонки
            columnNumber.Name = "Number";                                           // Задать название колонки
            columnNumber.HeaderText = "#";                                      // Задать заголовок

            columnAddress.Width = 200;                                             // Задать ширину колонки
            columnAddress.Name = "address";                                           // Задать название колонки
            columnAddress.HeaderText = "Адрес";                                      // Задать заголовок

            columnFloor.Width = 100;                                            // Задать ширину колонки
            columnFloor.Name = "floor";                                       // Задать название колонки
            columnFloor.HeaderText = "Этаж";                                  // Задать заголовок

            columnArea.Width = 120;                                            // Задать ширину колонки
            columnArea.Name = "area";                                       // Задать название колонки
            columnArea.HeaderText = "Площадь";                                  // Задать заголовок

            columnBalcony.Width = 50;                                       // Задать ширину колонки
            columnBalcony.Name = "balcony";                             // Задать название колонки
            columnBalcony.HeaderText = "Б";                       // Задать заголовок

            columnPhone.Width = 50;                                     // Задать ширину колонки
            columnPhone.Name = "phone";                           // Задать название колонки
            columnPhone.HeaderText = "Т";                     // Задать заголовок

            columnIronDoor.Width = 50;                                               // Задать ширину колонки
            columnIronDoor.Name = "ironDoor";                                               // Задать название колонки
            columnIronDoor.HeaderText = "Ж/д";                              // Задать заголовок

            columnCompany.Width = 200;                                      // Задать ширину колонки
            columnCompany.Name = "company";                             // Задать название колонки
            columnCompany.HeaderText = "Компания";                          // Задать заголовок

            columnPhoneToCall.Width = 200;                                      // Задать ширину колонки
            columnPhoneToCall.Name = "phoneToCall";                             // Задать название колонки
            columnPhoneToCall.HeaderText = "Телефон";                          // Задать заголовок

            columnPrice.Width = 100;                                      // Задать ширину колонки
            columnPrice.Name = "price";                             // Задать название колонки
            columnPrice.HeaderText = "Цена";                          // Задать заголовок

            columnDescription.Width = 300;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            apartmentDataGridView.Columns.Add(columnChecked);
            apartmentDataGridView.Columns.Add(columnNumber);                       // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnAddress);                       // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnFloor);                     // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnArea);                     // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnBalcony);                // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnPhone);               // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnIronDoor);                         // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnCompany);                // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnPhoneToCall);                // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnPrice);                // Добавить колонку в элемент отображения списка сущностей
            apartmentDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей
            
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
           
            string address;                                                    // Тип
            string floor;                                                  // Серия 
            string area;                                                  // Номер
            string balcony;                                             // Дата выдачи 
            string phone;                                            // Место выдачи
            string ironDoor;                                                      // Идентификатор
            string company;                                             // Описание
            string phoneToCall;                                             // Описание
            string description;
            int price;

            int counter = 0;

            apartmentDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            int rowId;

            foreach (Zakamned zakamned in zakamneds)                      // Выполнить для всех документов из списка документов
            {
                counter++;
                address = zakamned.address;
                floor = zakamned.floor + @"/" + zakamned.maxFloor;
                area = zakamned.grossArea + @"/" + zakamned.livingArea + @"/" + zakamned.kitchenArea;
                balcony = zakamned.hasBalcony.ToString();
                phone = zakamned.hasPhone.ToString();
                ironDoor = zakamned.hasIronDoor.ToString();
                company = zakamned.company;
                phoneToCall = zakamned.phoneToCall;
                price = zakamned.price;
                description = zakamned.description;

                rowId = apartmentDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    false,
                    counter.ToString(),
                    address,
                    floor,
                    area,
                    balcony,
                    phone,
                    ironDoor,
                    company,
                    phoneToCall,
                    price.ToString(),
                    description);

                apartmentDataGridView.Rows[rowId].Tag = zakamned;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            _parser = new Parser(
                Zakamned.SiteAddress + @"/" + Zakamned.OneRoomApartmentAddress,
                Zakamned.RowsRegExTemplate,
                Zakamned.CellsRegExTemplate);

            zakamneds = new Zakamned[_parser.TableCells.Count];

            for (int counter = 0; counter < _parser.TableCells.Count; counter++)
            {
                zakamneds[counter] = new Zakamned();
                zakamneds[counter].TryParse(_parser.TableCells[counter]);
            }

            FillEntitiesDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object tagObject = apartmentDataGridView.SelectedRows[0].Tag;

            WebBrowserForm a = new WebBrowserForm((Zakamned)tagObject);
            a.Show();
        }
    }
}
