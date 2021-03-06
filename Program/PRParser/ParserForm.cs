﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRInterfaces.Interfaces;

namespace PRParser
{
    public partial class ParserForm : Form
    {
        private Parser _parser;
        private Zakamned[] zakamneds;
        private IApartment _apartment;
        private IObjects _objects;
        private IComparisonAparts _comparisonApartments;
        private IComparisonApart[] aparts;
            

        public ParserForm(IApartment apartment, IObjects objects, IComparisonAparts comparisonApartments)
        {
            _apartment = apartment;
            _objects = objects;
            _comparisonApartments = comparisonApartments;

            InitializeComponent();

            ConfigureEntitiesDataGridView();
        }

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка квартир
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                  // Шаблон ячеек
            
            DataGridViewCheckBoxColumn columnChecked;
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
           
            columnChecked = new DataGridViewCheckBoxColumn();
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

            columnAddress.Width = 150;                                             // Задать ширину колонки
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

            columnCompany.Width = 100;                                      // Задать ширину колонки
            columnCompany.Name = "company";                             // Задать название колонки
            columnCompany.HeaderText = "Компания";                          // Задать заголовок

            columnPhoneToCall.Width = 100;                                      // Задать ширину колонки
            columnPhoneToCall.Name = "phoneToCall";                             // Задать название колонки
            columnPhoneToCall.HeaderText = "Телефон";                          // Задать заголовок

            columnPrice.Width = 70;                                      // Задать ширину колонки
            columnPrice.Name = "price";                             // Задать название колонки
            columnPrice.HeaderText = "Цена";                          // Задать заголовок

            columnDescription.Width = 200;                                      // Задать ширину колонки
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


        }

        private void button2_Click(object sender, EventArgs e)
        {
            object tagObject = apartmentDataGridView.SelectedRows[0].Tag;

            WebBrowserForm a = new WebBrowserForm((Zakamned)tagObject);
            a.Show();
        }

        private void AddToReportButton_Click(object sender, EventArgs e)
        {
            aparts = new IComparisonApart[5];
            int j = 0;
            for (int i = 0; i < apartmentDataGridView.RowCount - 1; i++)        // Вычисляем выбранные квартиры
            {
                if ((bool)apartmentDataGridView[0, i].Value == true)
                {
                    if (j < 5)                                                 // Добавляем первые 5
                    {
                        aparts[j] = _comparisonApartments.Create();           // Создаем объект

                        aparts[j].address = zakamneds[i].address;            // Заполняем поля
                        aparts[j].company = zakamneds[i].company;
                        aparts[j].floor = zakamneds[i].floor;
                        aparts[j].grossArea = zakamneds[i].grossArea != 0 ? zakamneds[i].grossArea : Convert.ToInt32(_apartment.GrossArea) ; //Чтобы не было нулевой площади
                        aparts[j].hasBalcony = zakamneds[i].hasBalcony;
                        aparts[j].hasIronDoor = zakamneds[i].hasIronDoor;
                        aparts[j].hasPhone = zakamneds[i].hasPhone;
                        aparts[j].kitchenArea = zakamneds[i].kitchenArea;
                        aparts[j].livingArea = zakamneds[i].livingArea;
                        aparts[j].maxFloor = zakamneds[i].maxFloor;
                        aparts[j].phoneToCall = zakamneds[i].phoneToCall;
                        aparts[j].price = zakamneds[i].price;
                        aparts[j].Apartment = _apartment;

                        _comparisonApartments.Add(aparts[j]);                                                      // Добавляем
                                             
                        j++;
                    }
                }
            }
            FactorRateForm frf = new FactorRateForm(aparts);
            frf.Show();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _parser = new Parser(
            Zakamned.SiteAddress + @"/" + Zakamned.OneRoomApartmentAddress + _apartment.RoomNumber,
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

        //Вычисление цены кв. м, ликвидационной уценки.Сохранение результата
        private void SaveButton_Click(object sender, EventArgs e)
        {
            float sum = 0;
            float sqmCalcPrice;

            //вычисление ликвидационной уценки
            float k_sdv; //коэффициент стоимости денег во времени
            float r12;//требуемая доходность инвестирования в объект оценки в год
            double r;//требуемая доходность инвестирования в объект оценки 
            float risks;//коэффициент по рискам
            double tm; //разница во времени при продаже с рыночной ценой и ликвидационной

            risks = (_apartment.Object.AcceleratedWear + _apartment.Object.BadManagment +
                _apartment.Object.ConcurentsUp + _apartment.Object.Criminal +
                _apartment.Object.EconSituationDown + _apartment.Object.ExtremalSituation +
                _apartment.Object.FinanceChecking + _apartment.Object.LowChange +
                _apartment.Object.NoRentalMoney + _apartment.Object.NotCorrect) / 10;
            r12 = _apartment.Object.NoRisk + risks + (_apartment.Object.NoRisk / 12)*_apartment.Object.T_r + _apartment.Object.InvestManage;
            r = r12 / 12;
            tm = _apartment.Object.T_r - _apartment.Object.T_l;
            k_sdv = Convert.ToSingle(1 / (System.Math.Pow((1 + r/100) , tm)));
            

            for (int i = 0; i < 5; i++)
            {
                sum = aparts[i].sqmCalcPrice + sum;
            }
            sqmCalcPrice = sum / 5;
            //Вычисление рыночной стоимости
            _apartment.Object.Price = sqmCalcPrice * _apartment.GrossArea;

            //Вычисление ликвидационной стоимости
            _apartment.Object.Discount = _apartment.Object.Price * _apartment.Object.K_el * k_sdv;

            _objects.SaveChanges();
            _comparisonApartments.SaveChanges();
            this.Close();
        }

        private void DeleteAnalogs_Click(object sender, EventArgs e)
        {
            IComparisonApart[] apartArray;
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите удалить все аналоги квартиры?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                if (_apartment.ComparApart != null)
                {
                apartArray = _apartment.ComparApart.ToArray();
                    foreach (IComparisonApart a in apartArray)
                     {
                    _comparisonApartments.Remove(a);
                     }
                _comparisonApartments.SaveChanges();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            float sum = 0;
            float sqmCalcPrice;

            //вычисление ликвидационной уценки
            float k_sdv; //коэффициент стоимости денег во времени
            float r12;//требуемая доходность инвестирования в объект оценки в год
            double r;//требуемая доходность инвестирования в объект оценки 
            float risks;//коэффициент по рискам
            double tm; //разница во времени при продаже с рыночной ценой и ликвидационной
            IComparisonApart[] aparts1;
            aparts1 = _apartment.ComparApart.ToArray();

            risks = (_apartment.Object.AcceleratedWear + _apartment.Object.BadManagment +
                _apartment.Object.ConcurentsUp + _apartment.Object.Criminal +
                _apartment.Object.EconSituationDown + _apartment.Object.ExtremalSituation +
                _apartment.Object.FinanceChecking + _apartment.Object.LowChange +
                _apartment.Object.NoRentalMoney + _apartment.Object.NotCorrect) / 10;
            r12 = _apartment.Object.NoRisk + risks + (_apartment.Object.NoRisk / 12) * _apartment.Object.T_r + _apartment.Object.InvestManage;
            r = r12 / 12;
            tm = _apartment.Object.T_r - _apartment.Object.T_l;
            k_sdv = Convert.ToSingle(1 / (System.Math.Pow((1 + r / 100), tm)));


            for (int i = 0; i < 5; i++)
            {
                sum = aparts1[i].sqmCalcPrice + sum;
            }
            sqmCalcPrice = sum / 5;
            //Вычисление рыночной стоимости
            _apartment.Object.Price = sqmCalcPrice * _apartment.GrossArea;

            //Вычисление ликвидационной стоимости
            _apartment.Object.Discount = _apartment.Object.Price * _apartment.Object.K_el * k_sdv;

            _objects.SaveChanges();
            _comparisonApartments.SaveChanges();

            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Рыночная стоимость равна " + Convert.ToString(_apartment.Object.Price) + "руб.",
                "Подтверждение",
                MessageBoxButtons.OK);

        }
    }
}
