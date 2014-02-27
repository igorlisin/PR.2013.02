using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список документов
    /// </summary>
    public interface IDocuments : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый документ
        /// </summary>
        IDocument Create();

        /// <summary>
        /// Метод. Добавляет документ в список документов
        /// </summary>
        void Add(IDocument document);

        /// <summary>
        /// Метод. Удаляет документ из списка документов
        /// </summary>
        void Remove(IDocument document);

        /// <summary>
        /// Метод. Удаляет документ с указанным идентификатором из списка документов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список документов
        /// </summary>
        List<IDocument> ToList();

        /// <summary>
        /// Метод. Возвращает массив документов
        /// </summary>
        IDocument[] ToArray();

        /// <summary>
        /// Метод. Возвращает документ с указанным идентификатором из списка документов
        /// </summary>
        IDocument GetDocument(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
