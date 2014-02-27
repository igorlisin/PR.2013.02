using System;

using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Документ
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Свойство. Задает и возвращает тип
        /// </summary>
        DocumentTypes Type { get; set; }

        /// <summary>
        /// Свойство. Возвращает тип документа как текстовую строку
        /// </summary>
        string TypeAsString { get; }

        /// <summary>
        /// Свойство. Задает и возвращает серию
        /// </summary>
        int Series { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дату выдачи
        /// </summary>
        DateTime DataOfIssue { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает место выдачи
        /// </summary>
        string PlaceOfIssue { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает человека
        /// </summary>
        IMan Man { get; set; }
    }
}
