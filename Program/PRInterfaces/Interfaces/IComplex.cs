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
    }
}
