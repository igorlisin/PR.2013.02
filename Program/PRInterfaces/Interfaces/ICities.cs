using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список городов
    /// </summary>
    public interface ICities : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый город
        /// </summary>
        ICity Create();

        /// <summary>
        /// Метод. Добавляет город в список городов
        /// </summary>
        void Add(ICity city);

        /// <summary>
        /// Метод. Удаляет город из списка городов
        /// </summary>
        void Remove(ICity city);

        /// <summary>
        /// Метод. Удаляет город с указанным идентификатором из списка городов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список городов
        /// </summary>
        List<ICity> ToList();

        /// <summary>
        /// Метод. Возвращает массив городов
        /// </summary>
        ICity[] ToArray();

        /// <summary>
        /// Метод. Возвращает город с указанным идентификатором из списка городов
        /// </summary>
        ICity GetCity(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка городов
        /// </summary>
        void SaveChanges();
    }
}
