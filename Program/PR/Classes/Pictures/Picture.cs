using System;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Картинка
    /// </summary>
    public class Picture : Entity, IPicture
    {
        #region Static fields

        /// <summary>
        /// Статическое поле. Название по умолчанию
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// Статическое свойство. Название по умолчанию
        /// </summary>
        public static string DefaultName
        {
            get
            {
                return (_defaultName);
            }
            set
            {
                _defaultName = value;
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Статический метод. Преобразует объект типа IPicture в объект типа Picture
        /// </summary>
        public static Picture IPictureToPictureConverter(IPicture picture)
        {
            return ((Picture)picture);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Picture в объект типа IPicture
        /// </summary>
        public static IPicture PictureToIPictureConverter(Picture picture)
        {
            return ((IPicture)picture);
        }

        /// <summary>
        /// Статический метод. Возвращает тип картинки как текстовую строку
        /// </summary>
        public static string GetPictureTypeAsStringStatic(PictureTypes pictureType)
        {
            string pictureTypeAsString;                         // Тип картинки (как тескстовая строка)

            switch (pictureType)                                // Проверить тип картинки
            {
                case PictureTypes.document:                      // Тип картинки: документ
                    pictureTypeAsString = "Документ";           // Задать тип картинки
                    break;
                case PictureTypes.map:                           // Тип картинки: карта
                    pictureTypeAsString = "Карта";              // Задать тип картинки
                    break;
                case PictureTypes.photo:                         // Тип картинки: фотография
                    pictureTypeAsString = "Фотография";         // Задать тип картинки
                    break;
                case PictureTypes.screenshot:                    // Тип картинки: снимок экрана
                    pictureTypeAsString = "Снимок экрана";      // Задать тип картинки
                    break;
                case PictureTypes.appartmentMap:                 // Тип картинки: снимок экрана
                    pictureTypeAsString = "План квартиры";      // Задать тип картинки
                    break;
                default:                                        // Тип картинки: картинка по умолчанию
                    pictureTypeAsString = "";                   // Задать тип картинки
                    break;
            }

            return (pictureTypeAsString);
        }

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Название
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Тип
        /// </summary>
        private PictureTypes _type;

        /// <summary>
        /// Поле. Имя файла изображения
        /// </summary>
        private string _imageFileName;

        /// <summary>
        /// Поле. Дата создания
        /// </summary>
        private DateTime _creationDate;

        #endregion

        #region Properties

        /// <summary>
        /// Свойсво. Задает и возвращает квартиру (используется в Entity Framework) 
        /// </summary>
        public Apartment ApartmentForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает объект оценки квартира
        /// </summary>
        public IApartment Apartment
        {
            get
            {
                return ((IApartment)ApartmentForEntityFramework);
            }
            set
            {
                ApartmentForEntityFramework = (Apartment)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип
        /// </summary>
        public PictureTypes Type
        {
            get
            {
                return (_type);
            }
            set
            {
                _type = value;
            }

        }
        
        /// <summary>
        /// Свойство. Возвращает тип картинки как текстовую строку
        /// </summary>
        public string TypeAsString
        {
            get
            {
                return (Picture.GetPictureTypeAsStringStatic(_type));
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает имя файла изображения
        /// </summary>
        public string ImageFileName
        {
            get
            {
                return (_imageFileName);
            }
            set
            {
                _imageFileName = value;
            }

        }

        /// <summary>
        /// Свойство. Задает и возвращает дату создания
        /// </summary>
        public DateTime CreationDate
        {
            get
            {
                return (_creationDate);
            }
            set
            {
                _creationDate = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Возвращает копию картинки
        /// </summary>
        public override object Clone()
        {
            IPicture picture;

            picture = (IPicture)base.Clone();

            picture.Type = Type;
            picture.ImageFileName = ImageFileName;

            return ((object)picture);
        }

        /// <summary>
        /// Метод. Возвращает тип картинки как текстовую строку
        /// </summary>
        public string GetPictureTypeAsString(PictureTypes pictureType)
        {
            return (Picture.GetPictureTypeAsStringStatic(pictureType));
        }

        #endregion
    }
}
