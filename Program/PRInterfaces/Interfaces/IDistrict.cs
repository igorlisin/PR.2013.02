using System.Collections.Generic;
using PRInterfaces.Enumerations;

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
        /// Свойство. Задает и возвращает престижность района
        /// </summary>
        Prestiges Prestige { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает город
        /// </summary>
        ICity City { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дома
        /// </summary>
        List<IHome> Homes { get; set; }

        /// <summary>
        /// Метод. Возвращает  как тестовую строку
        /// </summary>
        string GetPrestigeAsString(Prestiges prestigeType);
    }
}
