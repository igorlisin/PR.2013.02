using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Комплекс
    /// </summary>
    public class Complex : Entity, IComplex 
    {
        /// <summary>
        /// Статическое поле. Номер по умолчанию
        /// </summary>
        private static int _defaultNumber;

        /// <summary>
        /// Поле. Задает и возвращает локальные особенности
        /// </summary>
        private string _loacals_1;

        /// <summary>
        /// Поле. Задает и возвращает локальные особенности
        /// </summary>
        private string _loacals_2;

        /// <summary>
        /// Поле. Задает и возвращает список банков
        /// </summary>
        private string _banks;


        /// <summary>
        /// Поле. Задает и возвращает список больниц
        /// </summary>
        private string _hospitals;


        /// <summary>
        /// Поле. Задает и возвращает список дет садов
        /// </summary>
        private string _kinders;


        /// <summary>
        /// Поле. Задает и возвращает список мест отдыха
        /// </summary>
        private string _restPlaces;


        /// <summary>
        /// Поле. Задает и возвращает список школ
        /// </summary>
        private string _schools;


        /// <summary>
        /// Поле. Задает и возвращает список предприятий быта
        /// </summary>
        private string _services;


        /// <summary>
        /// Поле. Задает и возвращает список объектов торговли
        /// </summary>
        private string _tradings;

        /// <summary>
        /// Свойство. Задает и возвращает список аптек
        /// </summary>
        private string _pharmList;

        /// <summary>
        /// Статическое свойство. Номер по умолчанию
        /// </summary>
        public static int DefaultNumber
        {
            get
            {
                return (_defaultNumber);
            }
            set
            {
                _defaultNumber = value;
            }
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа IComplex в объект типа Complex
        /// </summary>
        public static Complex IComplexToComplexConverter(IComplex complex)
        {
            return ((Complex)complex);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Complex в объект типа IComplex
        /// </summary>
        public static IComplex ComplexToIComplexConverter(Complex complex)
        {
            return ((IComplex)complex);
        }

        /// <summary>
        /// Поле. Номер
        /// </summary>
        private int _number;

        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        public int Number
        {
            get
            {
                return (_number);
            }
            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности
        /// </summary>
        public string Loacals_1
        {
            get
            {
                return _loacals_1;
            }
            set
            {
                _loacals_1 = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности
        /// </summary>
        public string Loacals_2
        {
            get
            {
                return _loacals_2;
            }
            set
            {
                _loacals_2 = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список банков
        /// </summary>
        public string Banks
        {
            get
            {
                return (_banks);
            }
            set
            {
                _banks = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список больниц
        /// </summary>
        public string Hospitals
        {
            get
            {
                return (_hospitals);
            }
            set
            {
                _hospitals = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список дет садов
        /// </summary>
        public string Kinders
        {
            get
            {
                return (_kinders);
            }
            set
            {
                _kinders = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список мест отдыха
        /// </summary>
        public string RestPlaces
        {
            get
            {
                return (_restPlaces);
            }
            set
            {
                _restPlaces = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список школ
        /// </summary>
        public string Schools
        {
            get
            {
                return (_schools);
            }
            set
            {
                _schools = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список предприятий быта
        /// </summary>
        public string Services
        {
            get
            {
                return (_services);
            }
            set
            {
                _services = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список объектов торговли
        /// </summary>
        public string Tradings
        {
            get
            {
                return (_tradings);
            }
            set
            {
                _tradings = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список аптек
        /// </summary>
        public string PharmList
        {
            get
            {
                return (_pharmList);
            }
            set
            {
                _pharmList = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает город
        /// </summary>
        public ICity City
        {
            get
            {
                return ((ICity)CityForEntityFramework);
            }
            set
            {
                CityForEntityFramework = (City)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает город (используется в Entity Framework) 
        /// </summary>
        public City CityForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список домов 
        /// </summary>
        public List<IHome> Homes
        {
            get
            {
                return (HomesForEntityFramework.ConvertAll(Home.HomeToIHomeConverter));
            }
            set
            {
                HomesForEntityFramework = value.ConvertAll(Home.IHomeToHomeConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список домов (используется в Entity Framework) 
        /// </summary>
        public List<Home> HomesForEntityFramework { get; set; }

 

        /// <summary>
        /// Конструктор
        /// </summary>
        public Complex()
        {
            Homes = new List<IHome>();          // Создать список домов, связанных с комплексом
        }

        /// <summary>
        /// Метод. Возвращает копию комплекса
        /// </summary>
        public override object Clone()
        {
            IComplex complex;

            complex = (IComplex)(base.Clone());

            complex.Number = Number;
            complex.City = City;

            return ((object)complex);
        }

 

    }
}
