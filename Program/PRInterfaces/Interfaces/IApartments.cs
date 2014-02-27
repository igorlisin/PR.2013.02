using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список квартир
    /// </summary>
    public interface IApartments : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую квартиру
        /// </summary>
        IApartment Create();

        /// <summary>
        /// Метод. Добавляет квартиру в список квартир
        /// </summary>
        void Add(IApartment appartment);

        /// <summary>
        /// Метод. Удаляет квартиру из списка квартир
        /// </summary>
        void Remove(IApartment appartment);

        /// <summary>
        /// Метод. Удаляет квартиру с указанным идентификатором из списка квартир
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список квартир
        /// </summary>
        List<IApartment> ToList();

        /// <summary>
        /// Метод. Возвращает массив квартир
        /// </summary>
        IApartment[] ToArray();

        /// <summary>
        /// Метод. Возвращает квартиру с указанным идентификатором из списка квартир
        /// </summary>
        IApartment GetAppartment(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка квартир
        /// </summary>
        void SaveChanges();
    }
}
