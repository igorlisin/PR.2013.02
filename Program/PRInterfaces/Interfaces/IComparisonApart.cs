using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRInterfaces.Interfaces
{
   public interface IComparisonApart
    {
        /// <summary>
        /// Свойство. Принимает и возвращает. Адрес
        /// </summary>
        string address { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Этаж
        /// </summary>
        int floor { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Максимальный этаж
        /// </summary>
        int maxFloor { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Общая площаль
        /// </summary>
        int grossArea { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Жилая площадь
        /// </summary>
        int livingArea { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Площадь кухни
        /// </summary>
        int kitchenArea { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие балкона
        /// </summary>
        bool hasBalcony { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие телефона
        /// </summary>
        bool hasPhone { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Наличие железной двери
        /// </summary>
        bool hasIronDoor { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Компания
        /// </summary>
        string company { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Контактный телефон
        /// </summary>
        string phoneToCall { get; set; }

        /// <summary>
        /// Свойство. Принимает и возвращает. Цена
        /// </summary>
        int price { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает квартиру
        /// </summary>
        IApartment Apartment { get; set; }

        /// <summary>
        /// Свойство. Поправка на торг
        /// </summary>
        float kTorg { get; set; }

        /// <summary>
        /// Свойство. Поправка на тип дома
        /// </summary>
        float kWallType { get; set; }

        /// <summary>
        /// Свойство. Поправка на этажность дома
        /// </summary>
        float kFloors { get; set; }

        /// <summary>
        /// Свойство. Поправка на этаж квартиры
        /// </summary>
        float kFloor { get; set; }

        /// <summary>
        /// Свойство. Поправка на площадь кухни
        /// </summary>
        float kSKitchen { get; set; }

        /// <summary>
        /// Свойство. Поправка на наличие балкона
        /// </summary>
        float kBalcon { get; set; }

        /// <summary>
        /// Свойство. Поправка на тип санузла
        /// </summary>
        float kSanuzel { get; set; }

        /// <summary>
        /// Свойство. Доплата за ремонт
        /// </summary>
        float finishingQualityPrice { get; set; }

        /// <summary>
        /// Свойство. Поправка на вид из окна
        /// </summary>
        float kView { get; set; }

        /// <summary>
        /// Свойство. Вычисленная цена за квадратный метр
        /// </summary>
        float sqmCalcPrice { get; set; }
   }
}
