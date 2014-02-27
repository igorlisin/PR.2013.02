using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список сотрудников
    /// </summary>
    public interface IEmployees : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает нового сотрудника
        /// </summary>
        IEmployee Create();

        /// <summary>
        /// Метод. Добавляет сотрудника в список сотрудников
        /// </summary>
        void Add(IEmployee employee);

        /// <summary>
        /// Метод. Удаляет сотрудника из списка сотрудников
        /// </summary>
        void Remove(IEmployee employee);

        /// <summary>
        /// Метод. Удаляет сотрудника с указанным идентификатором из списка сотрудников
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список сотрудников
        /// </summary>
        List<IEmployee> ToList();

        /// <summary>
        /// Метод. Возвращает массив сотрудников
        /// </summary>
        IEmployee[] ToArray();

        /// <summary>
        /// Метод. Возвращает сотрудника с указанным идентификатором из списка сотрудников
        /// </summary>
        IEmployee GetEmployee(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
