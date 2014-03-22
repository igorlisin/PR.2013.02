using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
   public class District: Entity,IDistrict
   {
       #region Fields
       /// <summary>
        /// Поле. Задает и возвращает название
        /// </summary>
        private string _name ;

        /// <summary>
        /// Поле. Задает и возвращает список банков
        /// </summary>
       private string _banks ;


        /// <summary>
        /// Поле. Задает и возвращает список больниц
        /// </summary>
       private string _hospitals ;


        /// <summary>
        /// Поле. Задает и возвращает список дет садов
        /// </summary>
       private string _kinders ;


        /// <summary>
        /// Поле. Задает и возвращает список мест отдыха
        /// </summary>
       private string _restPlaces ;


        /// <summary>
        /// Поле. Задает и возвращает список школ
        /// </summary>
       private string _schools ;


        /// <summary>
        /// Поле. Задает и возвращает список предприятий быта
        /// </summary>
       private string _services ;


        /// <summary>
        /// Поле. Задает и возвращает список объектов торговли
        /// </summary>
       private string _tradings ;


        /// <summary>
        /// Поле. Задает и возвращает престижность района
        /// </summary>
       private string _prestige ;


        /// <summary>
        /// Поле. Задает и возвращает город
        /// </summary>
       private ICity _city ;
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
               Kinders = value;
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
       /// Свойство. Задает и возвращает престижность района
       /// </summary>
       public string Prestige
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
   }
}
