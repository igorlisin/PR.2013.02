using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список стран
    /// </summary>
    public interface ICountries : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую страну
        /// </summary>
        ICountry Create();

        /// <summary>
        /// Метод. Добавляет страну в список стран
        /// </summary>
        void Add(ICountry country);

        /// <summary>
        /// Метод. Удаляет страну из списка стран
        /// </summary>
        void Remove(ICountry country);

        /// <summary>
        /// Метод. Удаляет страну с указанным идентификатором из списка стран
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список стран
        /// </summary>
        List<ICountry> ToList();

        /// <summary>
        /// Метод. Возвращает массив стран
        /// </summary>
        ICountry[] ToArray();

        /// <summary>
        /// Метод. Возвращает страну с указанным идентификатором из списка стран
        /// </summary>
        ICountry GetCountry(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка городов
        /// </summary>
        void SaveChanges();
    }
}