using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список картинок
    /// </summary>
    public interface IPictures : IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую картинку
        /// </summary>
        IPicture Create();

        /// <summary>
        /// Метод. Добавляет картинку в список картинок
        /// </summary>
        void Add(IPicture picture);

        /// <summary>
        /// Метод. Удаляет картинку из списка картинок
        /// </summary>
        void Remove(IPicture picture);

        /// <summary>
        /// Метод. Удаляет картинку с указанным идентификатором из списка картинок
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список картинок
        /// </summary>
        List<IPicture> ToList();

        /// <summary>
        /// Метод. Возвращает массив картинок
        /// </summary>
        IPicture[] ToArray();

        /// <summary>
        /// Метод. Возвращает картинку с указанным идентификатором из списка картинок
        /// </summary>
        IPicture GetPicture(int id);

        /// <summary>
        /// Метод. Возвращает список картинок для выбранной квартиры
        /// </summary>
        IPictures PicturesForApartment(IApartment apartment);

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        void SaveChanges();
    }
}
