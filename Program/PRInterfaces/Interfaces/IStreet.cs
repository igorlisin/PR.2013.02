using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Улица
    /// </summary>
    public interface IStreet
    {
        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает город
        /// </summary>
        ICity City { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список домов 
        /// </summary>
        List<IHome> Homes { get; set; }
    }
}
