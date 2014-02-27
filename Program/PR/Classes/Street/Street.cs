using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Улица
    /// </summary>
    public class Street : Entity, IStreet
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
        /// Статический метод. Преобразует объект типа IStreet в объект типа Street
        /// </summary>
        public static Street IStreetToStreetConverter(IStreet street)
        {
            return ((Street)street);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Street в объект типа IStreet
        /// </summary>
        public static IStreet StreetToIStreetConverter(Street street)
        {
            return ((IStreet)street);
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
        public Street()
        {
            Homes = new List<IHome>();          // Создать список домов, связанных с улицей
        }

        /// <summary>
        /// Метод. Возвращает копию улицы
        /// </summary>
        public override object Clone()
        {
            IStreet street;

            street = (IStreet)base.Clone();

            street.Name = Name;
            street.City = City;

            return ((object)street);
        }
    }
}
