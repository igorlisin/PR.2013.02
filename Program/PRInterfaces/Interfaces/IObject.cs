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
        /// Свойство. Задает и возвращает документы правообладателей оцениваемого имущества
        /// </summary>
        string Documents { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает вид оцениваемой стоимости
        /// </summary>
        string TypeOfValue { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает оценочную рыночную стоимость
        /// </summary>
        float Price { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает ликвидационную стоимость
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

        /// <summary>
        /// Свойство. Доходность
        /// </summary>
        float R { get; set; }

        /// <summary>
        /// Свойство. Срок реализации объекта по рыночной стоимости
        /// </summary>
        float T_r { get; set; }

        /// <summary>
        /// Свойство. Срок реализации объекта по ликвидационной стоимости
        /// </summary>
        float T_l { get; set; }

        /// <summary>
        /// Свойство. Ухудшение общей экономической ситуации
        /// </summary>
        float EconSituationDown { get; set; }

        /// <summary>
        /// Свойство. Увеличение числа конкурирующих объектов
        /// </summary>
        float ConcurentsUp { get; set; }

        /// <summary>
        /// Свойство. Изменение федерального или местного законодательства
        /// </summary>
        float LowChange { get; set; }

        /// <summary>
        /// Свойство. Природные и антропогенные чрезвычайные ситуации
        /// </summary>
        float ExtremalSituation { get; set; }

        /// <summary>
        /// Свойство. Ускоренный износ объекта оценки
        /// </summary>
        float AcceleratedWear { get; set; }

        /// <summary>
        /// Свойство. Неполучение арендных платежей
        /// </summary>
        float NoRentalMoney { get; set; }

        /// <summary>
        /// Свойство. Неэффективный менеджмент
        /// </summary>
        float BadManagment { get; set; }

        /// <summary>
        /// Свойство. Криминогенные факторы
        /// </summary>
        float Criminal { get; set; }

        /// <summary>
        /// Свойство. Финансовые проверки
        /// </summary>
        float FinanceChecking { get; set; }

        /// <summary>
        /// Свойство. Неправильное оформление договоров аренды
        /// </summary>
        float NotCorrect { get; set; }

        /// <summary>
        /// Свойство. Безрисковая ставка
        /// </summary>
        float NoRisk { get; set; }

        /// <summary>
        /// Свойство. Инвестиционный менеджмент
        /// </summary>
        float InvestManage { get; set; }

        /// <summary>
        /// Свойство. Коэффициент, учитывающий эластичность
        /// </summary>
        float K_el { get; set; }

    }
}