using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список улиц
    /// </summary>
    public interface IStreets : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую улицу
        /// </summary>
        IStreet Create();

        /// <summary>
        /// Метод. Добавляет улицу в список улиц
        /// </summary>
        void Add(IStreet street);

        /// <summary>
        /// Метод. Удаляет улицу из списка улиц
        /// </summary>
        void Remove(IStreet street);

        /// <summary>
        /// Метод. Удаляет улицу с указанным идентификатором из списка улиц
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список улиц
        /// </summary>
        List<IStreet> ToList();

        /// <summary>
        /// Метод. Возвращает массив улиц
        /// </summary>
        IStreet[] ToArray();

        /// <summary>
        /// Метод. Возвращает улицу с указанным идентификатором из списка улиц
        /// </summary>
        IStreet GetStreet(int id);


        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
