using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список компаний
    /// </summary>
    public interface ICompanies : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую компанию
        /// </summary>
        ICompany Create();

        /// <summary>
        /// Метод. Добавляет компанию в список компаний
        /// </summary>
        void Add(ICompany company);

        /// <summary>
        /// Метод. Удаляет компанию из списка компаний
        /// </summary>
        void Remove(ICompany company);

        /// <summary>
        /// Метод. Удаляет компанию с указанным идентификатором из списка компаний
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список компаний
        /// </summary>
        List<ICompany> ToList();

        /// <summary>
        /// Метод. Возвращает массив компаний
        /// </summary>
        ICompany[] ToArray();

        /// <summary>
        /// Метод. Возвращает компанию с указанным идентификатором из списка компаний
        /// </summary>
        ICompany GetCompany(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка компаний
        /// </summary>
        void SaveChanges();
    }
}
