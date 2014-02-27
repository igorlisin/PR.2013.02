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
