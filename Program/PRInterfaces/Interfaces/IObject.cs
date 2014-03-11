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
        int ObjectType { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает количество комнат
        /// </summary>
        int NumberOfRooms { get; set; }

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
        List<IMan> Holders { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает вид оцениваемой стоимости
        /// </summary>
        int TypeOfValue { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает оценочную рыночную стоимость
        /// </summary>
        int Price { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает скидку по ликвидационной стоимости
        /// </summary>
        int Discount { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает курс доллара
        /// </summary>
        int Dollar { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает цель оценки
        /// </summary>
        string PurposeOfTheEvaluation { get; set; }
    }
}