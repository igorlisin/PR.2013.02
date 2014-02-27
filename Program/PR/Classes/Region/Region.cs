using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Регион
    /// </summary>
    public class Region : Entity, IRegion 
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
        /// Статический метод. Преобразует объект типа IRegion в объект типа Region
        /// </summary>
        public static Region IRegionToRegionConverter(IRegion region)
        {
            return ((Region)region);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Region в объект типа IRegion
        /// </summary>
        public static IRegion RegionToIRegionConverter(Region region)
        {
            return ((IRegion)region);
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
        /// Свойство. Задает и возвращает страну
        /// </summary>
        public ICountry Country
        {
            get
            {
                return ((ICountry)CountryForEntityFramework);
            }
            set
            {
                CountryForEntityFramework = (Country)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает страну (используется в Entity Framework) 
        /// </summary>
        public Country CountryForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список городов
        /// </summary>
        public List<ICity> Cities
        {
            get
            {
                return (CitiesForEntityFramwork.ConvertAll(City.CityToICityConverter));
            }
            set
            {
                CitiesForEntityFramwork = value.ConvertAll(City.ICityToCityConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список городов (используется в Entity Framework) 
        /// </summary>
        public List<City> CitiesForEntityFramwork { get; set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public Region()
        {
            Cities = new List<ICity>();     // Создать список городлв, связанных с регионом
        }

        /// <summary>
        /// Метод. Возвращает копию региона
        /// </summary>
        public override object Clone()
        {
            IRegion region;

            region = (IRegion)base.Clone();

            region.Name = Name;
            region.Country = Country;

            return ((object)region);
        }
    }
}
