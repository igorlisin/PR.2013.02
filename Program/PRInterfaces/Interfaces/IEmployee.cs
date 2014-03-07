

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Сотрудник
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Свойство. Задает и возвращает человека
        /// </summary>
        IMan Man { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает должность
        /// </summary>
        string Position { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
        /// </summary>
        string FurtherEducation { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает информацию о членстве в саморегулируемой организации оценщиков
        /// </summary>
        string Membership { get; set; }

        /// <summary>
        /// Свойство. Задает и возващает сведения об обязательном страховании гражданской ответственности
        /// </summary>
        string Insurance { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает стаж работы в оценочной деятельности
        /// </summary>
        int WorkTime { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает отчет
        /// </summary>
        IReport Report { get; set; }
    }
}
