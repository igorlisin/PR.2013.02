using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Дом
    /// </summary>
    public interface IHome
    {
        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает номер по комплексу
        /// </summary>
        string ComplexNumber { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает улицу
        /// </summary>
        IStreet Street { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс
        /// </summary>
        IComplex Complex { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир
        /// </summary>
        List<IApartment> Appartments { get; set; }
    }
}
