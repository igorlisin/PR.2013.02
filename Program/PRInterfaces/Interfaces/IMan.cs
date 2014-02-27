namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Класс. Человек
    /// </summary>
    public interface IMan
    {
        /// <summary>
        /// Свойство. Задает и возвращает имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает фамилию
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает отчество
        /// </summary>
        string Patronymic { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает документ
        /// </summary>
        IDocument Document { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает клиента
        /// </summary>
        IClient Client { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает сотрудника
        /// </summary>
        IEmployee Employee { get; set; }
    }
}
