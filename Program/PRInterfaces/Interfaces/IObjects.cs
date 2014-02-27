using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список объектов оценки
    /// </summary>
    public interface IObjects : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый объект оценки
        /// </summary>
        IObject Create();

        /// <summary>
        /// Метод. Добавляет объект оценки в список объектов оценки
        /// </summary>
        void Add(IObject assessObject);

        /// <summary>
        /// Метод. Удаляет объект оценки из списка объектов оценки
        /// </summary>
        void Remove(IObject assessObject);

        /// <summary>
        /// Метод. Удаляет объект оценки с указанным идентификатором из списка объектов оценки
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список объектов оценки
        /// </summary>
        List<IObject> ToList();

        /// <summary>
        /// Метод. Возвращает массив объектов оценки
        /// </summary>
        IObject[] ToArray();

        /// <summary>
        /// Метод. Возвращает объект оценки с указанным идентификатором из списка объектов оценки
        /// </summary>
        IObject GetObject(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
