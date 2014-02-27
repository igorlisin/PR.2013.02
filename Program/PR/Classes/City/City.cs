using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Город
    /// </summary>
    public class City : Entity, ICity
    {
        /// <summary>
        /// Статическое поле. Название по умолчанию
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// Статическое свойство. Название по умолчанию
        /// </summary>
        public static string DefaultName
        {
            get
            {
                return (_defaultName);
            }
            set
            {
                _defaultName = value;
            }
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа ICity в объект типа City
        /// </summary>
        public static City ICityToCityConverter(ICity city)
        {
            return ((City)city);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа City в объект типа ICity
        /// </summary>
        public static ICity CityToICityConverter(City city)
        {
            return ((ICity)city);
        }

        /// <summary>
        /// Поле. Название
        /// </summary>
        private string _name;

        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает регион
        /// </summary>
        public IRegion Region
        {
            get
            {
                return ((IRegion)RegionForEntityFramework);
            }
            set
            {
                RegionForEntityFramework = (Region)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает регион (используется в Entity Framework) 
        /// </summary>
        public Region RegionForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список улиц
        /// </summary>
        public List<IStreet> Streets
        {
            get
            {
                return (StreetsForEntityFramework.ConvertAll(Street.StreetToIStreetConverter));
            }
            set
            {
                StreetsForEntityFramework = value.ConvertAll(Street.IStreetToStreetConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список улиц (используется в Entity Framework) 
        /// </summary>
        public List<Street> StreetsForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список комплексов
        /// </summary>
        public List<IComplex> Complexes
        {
            get
            {
                return (ComplexesForEntityFramework.ConvertAll(Complex.ComplexToIComplexConverter));
            }
            set
            {
                ComplexesForEntityFramework = value.ConvertAll(Complex.IComplexToComplexConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список комплексов (используется в Entity Framework) 
        /// </summary>
        public List<Complex> ComplexesForEntityFramework { get; set; }
     
        /// <summary>
        /// Конструктор
        /// </summary>
        public City()
        {
            Streets = new List<IStreet>();          // Создать список улиц, связанных с городом
            Complexes = new List<IComplex>();       // Создать список комплексов, связанных с городом
        }

        /// <summary>
        /// Метод. Возвращает копию города
        /// </summary>
        public override object Clone()
        {
            ICity city;

            city = (ICity)base.Clone();

            city.Name = Name;
            city.Region = Region;

            return ((object)city);
        }
    }
}
