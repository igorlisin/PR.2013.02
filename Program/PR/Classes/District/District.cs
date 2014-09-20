using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
   public class District: Entity,IDistrict
   {
       #region Static 
       /// <summary>
       /// Метод. Возвращает престижность  как тестовую строку
       /// </summary>
       public static string GetPrestigeAsStringStatic(Prestiges prestige)
       {
           string prestigeAsString;                             // Тип (как тескстовая строка)

           switch (prestige)                                    // Проверить тип
           {
               case Prestiges.HiPrestige:                            // Сравнить тип 
                   prestigeAsString = "Престижный";                 // Задать тип (как текстовую строку)
                   break;
               case Prestiges.Middle:                        // Сравнить тип 
                   prestigeAsString = "Средний";                // Задать тип (как текстовую строку)
                   break;
               case Prestiges.NotPrestige:                     // Сравнить тип 
                   prestigeAsString = "Не престижный";      // Задать тип (как текстовую строку)
                   break;
               case Prestiges.Other:                     // Сравнить тип 
                   prestigeAsString = "ПРОЧЕЕ!!!!!!!!";      // Задать тип (как текстовую строку)
                   break;
               default:                                                // Тип по умолчанию 
                   prestigeAsString = "--";                     // Задать тип (как текстовую строку)
                   break;
           }

           return (prestigeAsString);
       }
       #endregion

       #region Fields
       /// <summary>
        /// Поле. Задает и возвращает название
        /// </summary>
        private string _name ;

 

        /// <summary>
        /// Поле. Задает и возвращает престижность района
        /// </summary>
       private Prestiges _prestige ;


        /// <summary>
        /// Поле. Задает и возвращает город
        /// </summary>
       //private ICity _city;
       #endregion

       #region Properties

       /// <summary>
       /// Свойство. Задает и возвращает название
       /// </summary>
       public string Name {
           get
           {
              return (_name );
           }
           set
           {
               _name = value;
           }
       }



       /// <summary>
       /// Свойство. Задает и возвращает престижность района
       /// </summary>
       public Prestiges Prestige
       {
           get
           {
               return (_prestige);
           }
           set
           {
               _prestige = value;
           }
       }

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
       /// Статический метод. Преобразует объект типа IDistrict в объект типа District
       /// </summary>
       public static District IDistrictToDistrictConverter(IDistrict district)
       {
           return ((District)district);
       }


       /// <summary>
       /// Статический метод. Преобразует объект типа District в объект типа IDistrict
       /// </summary>
       public static IDistrict DistrictToIDistrictConverter(District district)
       {
           return ((IDistrict)district);
       }
       #endregion

       /// <summary>
       /// Метод. Возвращает престижность как тестовую строку
       /// </summary>
       public string GetPrestigeAsString(Prestiges prestige)
       {
           return (District.GetPrestigeAsStringStatic(prestige));
       }
   }
}
