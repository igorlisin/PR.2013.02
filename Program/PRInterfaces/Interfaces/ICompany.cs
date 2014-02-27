namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Компания
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// Свойство. Задает и возвращает наименование
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает юридический адрес
        /// </summary>
        string LegalAddress { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает почтовый адрес
        /// </summary>
        string PostalAddress { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает ОГРН
        /// </summary>
        string PSRN { get; set; }
    }
}
