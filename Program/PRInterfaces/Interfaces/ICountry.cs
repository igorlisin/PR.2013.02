using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Страна
    /// </summary>
    public interface ICountry
    {
        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список регионов
        /// </summary>
        List<IRegion> Regions { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает отчет
        /// </summary>
        IReport Report { get; set; }
    }
}
