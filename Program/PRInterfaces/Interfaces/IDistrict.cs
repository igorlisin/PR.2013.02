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
        /// Свойство. Задает и возвращает список банков
        /// </summary>
        string Banks { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает список больниц
        /// </summary>
        string Hospitals { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает дет садов
        /// </summary>
        string Kinders { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает мест отдыха
        /// </summary>
        string RestPlaces { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает список школ
        /// </summary>
        string Schools { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает список предприятий быта
        /// </summary>
        string Services { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает список объектов торговли
        /// </summary>
        string Tradings { get; set; }


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
