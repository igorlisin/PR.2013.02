using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список людей
    /// </summary>
    public interface IMans : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает нового человека
        /// </summary>
        IMan Create();

        /// <summary>
        /// Метод. Добавляет человека в список людей
        /// </summary>
        void Add(IMan man);

        /// <summary>
        /// Метод. Удаляет человека из списка людей
        /// </summary>
        void Remove(IMan man);

        /// <summary>
        /// Метод. Удаляет человека с указанным идентификатором из списка людей
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список людей
        /// </summary>
        List<IMan> ToList();

        /// <summary>
        /// Метод. Возвращает массив людей
        /// </summary>
        IMan[] ToArray();

        /// <summary>
        /// Метод. Возвращает человека с указанным идентификатором из списка людей
        /// </summary>
        IMan GetMan(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка людей
        /// </summary>
        void SaveChanges();
    }
}
