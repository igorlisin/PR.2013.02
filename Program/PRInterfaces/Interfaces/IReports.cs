using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список отчетов
    /// </summary>
    public interface IReports : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый отчет
        /// </summary>
        IReport Create();

        /// <summary>
        /// Метод. Добавляет отчет в список отчетов
        /// </summary>
        void Add(IReport report);

        /// <summary>
        /// Метод. Удаляет отчет из списка отчетов
        /// </summary>
        void Remove(IReport report);

        /// <summary>
        /// Метод. Удаляет отчет с указанным идентификатором из списка отчетов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список отчетов
        /// </summary>
        List<IReport> ToList();

        /// <summary>
        /// Метод. Возвращает массив отчетов
        /// </summary>
        IReport[] ToArray();

        /// <summary>
        /// Метод. Возвращает отчет с указанным идентификатором из списка отчетов
        /// </summary>
        IReport GetReport(int index);

        /// <summary>
        /// Метод. Сохраняет изменения списка отчетов
        /// </summary>
        void SaveChanges();
    }
}
