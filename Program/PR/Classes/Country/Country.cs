using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Страна
    /// </summary>
    public class Country : Entity, ICountry
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
        /// Статический метод. Преобразует объект типа ICountry в объект типа Country
        /// </summary>
        public static Country ICountryToCountryConverter(ICountry country)
        {
            return ((Country)country);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Country в объект типа ICountry
        /// </summary>
        public static ICountry CountryToICountryConverter(Country country)
        {
            return ((ICountry)country);
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
        /// Свойство. Задает и возвращает список регионов
        /// </summary>
        public List<IRegion> Regions
        {
            get
            {
                return (RegionsForEntityFramework.ConvertAll(Region.RegionToIRegionConverter));
            }
            set
            {
                RegionsForEntityFramework = value.ConvertAll(Region.IRegionToRegionConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список регионов (используется в Entity Framework) 
        /// </summary>
        public List<Region> RegionsForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает отчет
        /// </summary>
        public IReport Report
        {
            get
            {
                return ((IReport)ReportForEntityFramwork);
            }
            set
            {
                ReportForEntityFramwork = (Report)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчет (используется в Entity Framework) 
        /// </summary>
        public Report ReportForEntityFramwork { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Country()
        {
            Regions = new List<IRegion>();      // Создать список регионов, связанных со страной
        }

        /// <summary>
        /// Метод. Возвращает копию страны
        /// </summary>
        public override object Clone()
        {
            ICountry country;

            country = (ICountry)base.Clone();

            country.Name = Name;

            return ((object)country);
        }
    }
}
