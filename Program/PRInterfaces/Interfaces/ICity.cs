using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Город
    /// </summary>
    public interface ICity
    {
        /// <summary>
        /// Свойство. Задает и возвращае название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает регион
        /// </summary>
        IRegion Region { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список районов
        /// </summary>
        List<IDistrict> Districts { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список улиц
        /// </summary>
        List<IStreet> Streets { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список комплексов
        /// </summary>
        List<IComplex> Complexes { get; set; }
    }
}
