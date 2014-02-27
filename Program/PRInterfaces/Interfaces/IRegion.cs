using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интрефейс. Регион
    /// </summary>
    public interface IRegion
    {
        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает страну
        /// </summary>
        ICountry Country { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список городов
        /// </summary>
        List<ICity> Cities { get; set; }
    }
}
