using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Комплекс
    /// </summary>
    public interface IComplex
    {
        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает город
        /// </summary>
        ICity City { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список домов 
        /// </summary>
        List<IHome> Homes { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности
        /// </summary>
        string Loacals_1 { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности
        /// </summary>
        string Loacals_2 { get; set; }

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
        /// Свойство. Задает и возвращает список аптек
        /// </summary>
        string PharmList { get; set; }

    }
}
