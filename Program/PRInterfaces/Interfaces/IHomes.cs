using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список домов
    /// </summary>
    public interface IHomes : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый дом
        /// </summary>
        IHome Create();

        /// <summary>
        /// Метод. Добавляет дом в список домов
        /// </summary>
        void Add(IHome home);

        /// <summary>
        /// Метод. Удаляет дом из списка домов
        /// </summary>
        void Remove(IHome home);

        /// <summary>
        /// Метод. Удаляет дом с указанным идентификатором из списка домов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список домов
        /// </summary>
        List<IHome> ToList();

        /// <summary>
        /// Метод. Возвращает массив домов
        /// </summary>
        IHome[] ToArray();

        /// <summary>
        /// Метод. Возвращает дом с указанным идентификатором из списка домов
        /// </summary>
        IHome GetHome(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
