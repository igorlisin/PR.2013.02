using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список регионов
    /// </summary>
    public interface IRegions : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый регион
        /// </summary>
        IRegion Create();

        /// <summary>
        /// Метод. Добавляет регион в список регионов
        /// </summary>
        void Add(IRegion region);

        /// <summary>
        /// Метод. Удаляет регион из списка регионов
        /// </summary>
        void Remove(IRegion region);

        /// <summary>
        /// Метод. Удаляет регион с указанным идентификатором из списка регионов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список регионов
        /// </summary>
        List<IRegion> ToList();

        /// <summary>
        /// Метод. Возвращает массив регионов
        /// </summary>
        IRegion[] ToArray();

        /// <summary>
        /// Метод. Возвращает регион с указанным идентификатором из списка регионов
        /// </summary>
        IRegion GetRegion(int index);

        /// <summary>
        /// Метод. Сохраняет изменения списка регионов
        /// </summary>
        void SaveChanges();
    }
}
