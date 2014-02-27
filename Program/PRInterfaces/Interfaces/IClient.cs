namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Клиент
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Свойство. Задает и возвращает клиента
        /// </summary>
        IMan Man { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает отчет
        /// </summary>
        IReport Report { get; set; }
    }
}
