using System.Collections.Generic;

using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Объект оценки
    /// </summary>
    public interface IObject
    {
        /// <summary>
        /// Свойство. Задает и возвращает тип объекта оценки
        /// </summary>
        string ObjectType { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает количество комнат
        /// </summary>
        //int NumberOfRooms { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает имущественные права на объект оценки
        /// </summary>
        string Property { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает существующие ограничения права
        /// </summary>
        string Restriction { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает правообладателей оцениваемого имущества
        /// </summary>
        string Holders { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает вид оцениваемой стоимости
        /// </summary>
        string TypeOfValue { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает оценочную рыночную стоимость
        /// </summary>
        float Price { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает скидку по ликвидационной стоимости
        /// </summary>
        float Discount { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает курс доллара
        /// </summary>
        float Dollar { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает цель оценки
        /// </summary>
        string PurposeOfTheEvaluation { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает цель оценки
        /// </summary>
        string DestOfTheEvaluation { get; set; }
        
        ///// <summary>
        ///// Свойство. Задает и возвращает Квартиру
        ///// </summary>
        //IApartment Apartments { get; set; }
    }
}