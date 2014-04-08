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
