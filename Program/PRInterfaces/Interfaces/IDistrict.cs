using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интрефейс. Район
    /// </summary>
    public interface IDistrict
    {
        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает регион
        /// </summary>
        IRegion Region { get; set; }
    }
}
