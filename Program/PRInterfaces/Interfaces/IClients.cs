using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список клиентов
    /// </summary>
    public interface IClients : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает нового клиента
        /// </summary>
        IClient Create();

        /// <summary>
        /// Метод. Добавляет клиента в список клиентов
        /// </summary>
        void Add(IClient client);

        /// <summary>
        /// Метод. Удаляет клиента из списка клиентов
        /// </summary>
        void Remove(IClient client);

        /// <summary>
        /// Метод. Удаляет клиента с указанными идентификатором из списка клиентов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список клиентов
        /// </summary>
        List<IClient> ToList();

        /// <summary>
        /// Метод. Возвращает массив клиентов
        /// </summary>
        IClient[] ToArray();

        /// <summary>
        /// Метод. Возвращает клиента с указанными идентификатором из списка клиентов
        /// </summary>
        IClient GetClient(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка клиентов
        /// </summary>
        void SaveChanges();
    }
}
