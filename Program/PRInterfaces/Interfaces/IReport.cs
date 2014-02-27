using System;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Отчет
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Свойство. Задает и возвращает номер отчета
        /// </summary>
        string ReportNumber { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дату проведения оценки
        /// </summary>
        DateTime EvaluationDate { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дату составления отчета
        /// </summary>
        DateTime ReportDate { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает договор
        /// </summary>
        string Contract { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дату заключения договора
        /// </summary>
        DateTime DateOfContract { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает клиента
        /// </summary>
        IClient Client { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает компанию оценщика
        /// </summary>
        ICompany Company { get; set; }

        /// <summary>
        /// Свойсвто. Задает и возвращает сотрудника
        /// </summary>
        IEmployee Employee { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает объект оценки
        /// </summary>
        IObject Object { get; set; }
    }
}
