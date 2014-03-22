using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список районов
    /// </summary>
    public interface IDistricts
    {
        /// <summary>
        /// Метод. Создает и возвращает новый район
        /// </summary>
        IDistrict Create();

        /// <summary>
        /// Метод. Добавляет район в список районов
        /// </summary>
        void Add(IDistrict district);

        /// <summary>
        /// Метод. Удаляет район из списка районов
        /// </summary>
        void Remove(IDistrict district);

        /// <summary>
        /// Метод. Удаляет район с указанным идентификатором из списка районов
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список районов
        /// </summary>
        List<IDistrict> ToList();

        /// <summary>
        /// Метод. Возвращает массив районов
        /// </summary>
        IDistrict[] ToArray();

        /// <summary>
        /// Метод. Возвращает район с указанным идентификатором из списка районов
        /// </summary>
        IDistrict GetDistrict(int index);

        /// <summary>
        /// Метод. Сохраняет изменения списка районов
        /// </summary>
        void SaveChanges();
    }
}
