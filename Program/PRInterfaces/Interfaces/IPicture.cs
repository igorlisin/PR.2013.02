using System;
using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Картинка
    /// </summary>
    public interface IPicture
    {
        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип
        /// </summary>
        PictureTypes Type { get; set; }

        /// <summary>
        /// Свойство. Возвращает тип картинки как текстовую строку
        /// </summary>
        string TypeAsString { get; }

        /// <summary>
        /// Свойство. Задает и возвращает имя файла изображения
        /// </summary>
        string ImageFileName { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дату и время создания
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает квартиру
        /// </summary>
        IApartment Apartment { get; set; }

        /// <summary>
        /// Метод. Возвращает тип картинки как текстовую строку
        /// </summary>
        string GetPictureTypeAsString(PictureTypes pictureType);
    }
}
