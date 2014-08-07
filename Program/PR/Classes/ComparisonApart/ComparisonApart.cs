using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
   public class ComparisonApart:Entity, IComparisonApart
    {
        #region Fields

        /// <summary>
        /// Поле. Адрес
        /// </summary>
        private string _address;

        /// <summary>
        /// Поле. Этаж
        /// </summary>
        private int _floor;

        /// <summary>
        /// Поле. Максимальный этаж
        /// </summary>
        private int _maxFloor;

        /// <summary>
        /// Поле. Общая площаль
        /// </summary>
        private int _grossArea;

        /// <summary>
        /// Поле. Жилая площадь
        /// </summary>
        private int _livingArea;

        /// <summary>
        /// Поле. Площадь кухни
        /// </summary>
        private int _kitchenArea;

        /// <summary>
        /// Поле. Наличие балкона
        /// </summary>
        private bool _hasBalcony;

        /// <summary>
        /// Поле. Наличие телефона
        /// </summary>
        private bool _hasPhone;

        /// <summary>
        /// Поле. Наличие железной двери
        /// </summary>
        private bool _hasIronDoor;

        /// <summary>
        /// Поле. Компания
        /// </summary>
        private string _company;

        /// <summary>
        /// Поле. Контактный телефон
        /// </summary>
        private string _phoneToCall;

        /// <summary>
        /// Поле. Цена
        /// </summary>
        private int _price;

        /// <summary>
        /// Поле. Описание
        /// </summary>
        private string _description;

        /// <summary>
        /// Поле. Поправка на торг
        /// </summary>
        private float _kTorg;

        /// <summary>
        /// Поле. Поправка на тип дома
        /// </summary>
        private float _kWallType;

        /// <summary>
        /// Поле. Поправка на этажность дома
        /// </summary>
        private float _kFloors;

        /// <summary>
        /// Поле. Поправка на этаж квартиры
        /// </summary>
        private float _kFloor;

        /// <summary>
        /// Поле. Поправка на площадь кухни
        /// </summary>
        private float _kSKitchen;

        /// <summary>
        /// Поле. Поправка на наличие балкона
        /// </summary>
        private float _kBalcon;

        /// <summary>
        /// Поле. Поправка на тип санузла
        /// </summary>
        private float _kSanuzel;

        /// <summary>
        /// Поле. Доплата за ремонт
        /// </summary>
        private float _finishingQualityPrice;

        /// <summary>
        /// . Состояние квартиры
        /// </summary>
        private float _statePrice;

        /// <summary>
        /// Поле. Скидка за состояние
        /// </summary>
        private float _kView;

        /// <summary>
        /// Поле. Вычисленная цена за квадратный метр
        /// </summary>
        private float _sqmCalcPrice;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Принимает и возвращает. Адрес
        /// </summary>
        public string address
        {
            get
            {
                return (_address);
            }
            set
            {
                _address = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Этаж
        /// </summary>
        public int floor
        {
            get
            {
                return (_floor);
            }
            set
            {
                _floor = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Максимальный этаж
        /// </summary>
        public int maxFloor
        {
            get
            {
                return (_maxFloor);
            }
            set
            {
                _maxFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Общая площаль
        /// </summary>
        public int grossArea
        {
            get
            {
                return (_grossArea);
            }
            set
            {
                _grossArea = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Жилая площадь
        /// </summary>
        public int livingArea
        {
            get
            {
                return (_livingArea);
            }
            set
            {
                _livingArea = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Площадь кухни
        /// </summary>
        public int kitchenArea
        {
            get
            {
                return (_kitchenArea);
            }
            set
            {
                _kitchenArea = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие балкона
        /// </summary>
        public bool hasBalcony
        {
            get
            {
                return (_hasBalcony);
            }
            set
            {
                _hasBalcony = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие телефона
        /// </summary>
        public bool hasPhone
        {
            get
            {
                return (_hasPhone);
            }
            set
            {
                _hasPhone = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие железной двери
        /// </summary>
        public bool hasIronDoor
        {
            get
            {
                return (_hasIronDoor);
            }
            set
            {
                _hasIronDoor = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Компания
        /// </summary>
        public string company
        {
            get
            {
                return (_company);
            }
            set
            {
                _company = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Контактный телефон
        /// </summary>
        public string phoneToCall
        {
            get
            {
                return (_phoneToCall);
            }
            set
            {
                _phoneToCall = value;
            }
        }

        /// <summary>
        /// Свойство. Принимает и возвращает. Цена
        /// </summary>
        public int price
        {
            get
            {
                return (_price);
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// Свойсво. Задает и возвращает квартиру (используется в Entity Framework) 
        /// </summary>
        public Apartment ApartmentForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает объект оценки квартира
        /// </summary>
        public IApartment Apartment
        {
            get
            {
                return ((IApartment)ApartmentForEntityFramework);
            }
            set
            {
                ApartmentForEntityFramework = (Apartment)value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на торг
        /// </summary>
        public float kTorg
        {
            get
            {
                return (_kTorg);
            }
            set
            {
                _kTorg = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на тип дома
        /// </summary>
        public float kWallType
        {
            get
            {
                return (_kWallType);
            }
            set
            {
                _kWallType = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на этажность дома
        /// </summary>
        public float kFloors
        {
            get
            {
                return (_kFloors);
            }
            set
            {
                _kFloors = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на этаж квартиры
        /// </summary>
        public float kFloor
        {
            get
            {
                return (_kFloor);
            }
            set
            {
                _kFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на площадь кухни
        /// </summary>
        public float kSKitchen
        {
            get
            {
                return (_kSKitchen);
            }
            set
            {
                _kSKitchen = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на наличие балкона
        /// </summary>
        public float kBalcon
        {
            get
            {
                return (_kBalcon);
            }
            set
            {
                _kBalcon = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на тип санузла
        /// </summary>
        public float kSanuzel
        {
            get
            {
                return (_kSanuzel);
            }
            set
            {
                _kSanuzel = value;
            }
        }

        /// <summary>
        /// Свойство. Доплата за ремонт
        /// </summary>
        public float finishingQualityPrice
        {
            get
            {
                return (_finishingQualityPrice);
            }
            set
            {
                _finishingQualityPrice = value;
            }
        }

        /// <summary>
        /// Свойство. Состояние квартиры
        /// </summary>
        public float statePrice
        {
            get
            {
                return (_statePrice);
            }
            set
            {
                _statePrice = value;
            }
        }

        /// <summary>
        /// Свойство. Поправка на вид из окна
        /// </summary>
        public float kView
        {
            get
            {
                return (_kView);
            }
            set
            {
                _kView = value;
            }
        }


        /// <summary>
        /// Свойство. Вычисленная цена за квадратный метр
        /// </summary>
        public float sqmCalcPrice
        {
            get
            {
                return (_sqmCalcPrice);
            }
            set
            {
                _sqmCalcPrice = value;
            }
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Статический метод. Преобразует объект типа IComparisonApart в объект типа ComparisonApart
        /// </summary>
        public static ComparisonApart IComparisonApartToComparisonApartConverter(IComparisonApart comparisonApart)
        {
            return ((ComparisonApart)comparisonApart);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа ComparisonApart в объект типа IComparisonApart
        /// </summary>
        public static IComparisonApart ComparisonApartToIComparisonApartConverter(ComparisonApart picture)
        {
            return ((IComparisonApart)picture);
        }
        #endregion
    }
}
