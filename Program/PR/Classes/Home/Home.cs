using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Дом
    /// </summary>
    public class Home : Entity, IHome 
    {
        /// <summary>
        /// Статическое поле. Номер по умолчанию
        /// </summary>
        private static string _defaultNumber;

        /// <summary>
        /// Статическое поле. Номер по комплексу по умолчанию
        /// </summary>
        private static string _defaultComplexNumber;

        /// <summary>
        /// Статическое свойство. Номер по умолчанию
        /// </summary>
        public static string DefaultNumber
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
        /// Статическое свойство. Номер по комплексу по умолчанию
        /// </summary>
        public static string DefaultComplexNumber
        {
            get
            {
                return (_defaultComplexNumber);
            }
            set
            {
                _defaultComplexNumber = value;
            }
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа IHome в объект типа Home
        /// </summary>
        public static Home IHomeToHomeConverter(IHome home)
        {
            return ((Home)home);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Home в объект типа IHome
        /// </summary>
        public static IHome HomeToIHomeConverter(Home home)
        {
            return ((IHome)home);
        }

        /// <summary>
        /// Поле. Номер
        /// </summary>
        private string _number;

        /// <summary>
        /// Поле. Номер по комплексу
        /// </summary>
        private string _complexNumber;

        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        public string Number
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
        /// Свойство. Задает и возвращает номер по комплексу
        /// </summary>
        public string ComplexNumber
        {
            get
            {
                return (_complexNumber);
            }
            set
            {
                _complexNumber = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает улицу
        /// </summary>
        public IStreet Street
        {
            get
            {
                return ((IStreet)StreetForEntityFramework);
            }
            set
            {
                StreetForEntityFramework = (Street)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает улицу (используется в Entity Framework) 
        /// </summary>
        public Street StreetForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс
        /// </summary>
        public IComplex Complex
        {
            get
            {
                return ((IComplex)ComplexForEntityFramework);
            }
            set
            {
                ComplexForEntityFramework = (Complex)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс (используется в Entity Framework) 
        /// </summary>
        public Complex ComplexForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир
        /// </summary>
        public List<IApartment> Appartments
        {
            get
            {
                return (AppartmentsForEntityFramework.ConvertAll(Apartment.ApartmentToIApartmentConverter));
            }
            set
            {
                AppartmentsForEntityFramework = value.ConvertAll(Apartment.IApartmentToApartmentConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир (используется в Entity Framework) 
        /// </summary>
        public List<Apartment> AppartmentsForEntityFramework { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Home()
        {
            Appartments = new List<IApartment>();       // Создать список квартир, связанных домом
        }

        /// <summary>
        /// Метод. Возвращает копию дома
        /// </summary>
        public override object Clone()
        {
            IHome home;

            home = (IHome)base.Clone();

            home.Number = Number;
            home.ComplexNumber = ComplexNumber;
            home.Street = Street;
            home.Complex = Complex;

            return ((object)home);
        }
    }
}
