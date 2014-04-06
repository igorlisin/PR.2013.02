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

    }
}
