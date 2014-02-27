using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список комплексов
    /// </summary>
    public interface IComplexes : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новый комплекс
        /// </summary>
        IComplex Create();

        /// <summary>
        /// Метод. Добавляет комплекс в список комплексов
        /// </summary>
        void Add(IComplex complex);

        /// <summary>
        /// Метод. Удаляет комплекс из списка комплексов
        /// </summary>
        void Remove(IComplex complex);

        /// <summary>
        /// Метод. Удаляет комплекс с указанным идентификатором из списка комплексов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список комплексов
        /// </summary>
        List<IComplex> ToList();

        /// <summary>
        /// Метод. Возвращает массив комплексов
        /// </summary>
        IComplex[] ToArray();

        /// <summary>
        /// Метод. Возвращает комплекс с указанным идентификатором из списка комплексов
        /// </summary>
        IComplex GetComplex(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка городов
        /// </summary>
        void SaveChanges();
    }
}
