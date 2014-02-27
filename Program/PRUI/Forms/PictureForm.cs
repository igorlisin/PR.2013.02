using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class PictureForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Путь к папке с изображениями
        /// </summary>
        private string _imageFolderPath;

        /// <summary>
        /// Поле. Картинка
        /// </summary>
        IPicture _picture;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        private string PictureName
        {
            get
            {
                return (pictureNameTextBox.Text);
            }
            set
            {
                pictureNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает имя файла изображения
        /// </summary>
        private string ImageFileName
        {
            get
            {
                return (imageFileNameTextBox.Text);
            }
            set
            {
                imageFileNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип картинки
        /// </summary>
        private PictureTypes PictureType
        {
            get
            {
                return (((KeyValuePair<PictureTypes, string>)pictureTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<PictureTypes>(pictureTypeComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает картинку
        /// </summary>
        private Image Picture
        {
            get
            {
                return (picturePictureBox.Image);
            }
            set
            {
                picturePictureBox.Image = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату создания картинки
        /// </summary>
        private DateTime PictureCreationDate
        {
            get
            {
                return (pictureCreationDateDateTimePicker.Value);
            }
            set
            {
                pictureCreationDateDateTimePicker.Value = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public PictureForm(IPicture picture, string imageFolderPath)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _picture = picture;                     // Сохранить картинку в поле

            _imageFolderPath = imageFolderPath;     // Сохранить путь к файлу картинок в поле

            CleanAllData();                         // Очистить компоненты всех групп

            CopyDataFromEntity();                   // Скопировать данные сущности в компоненты формы

            SetPicture(ImageFileName);            // Задать картинку для предварительного просмотра
        }

        #endregion

        #region Methods

        #region Clean

        /// <summary>
        /// Метод. Очищает все данные формы
        /// </summary>
        protected override void CleanAllData()
        {
            base.CleanAllData();        // Очистить все данные

            CleanPicture();             // Очистить данные картинки
        }

        /// <summary>
        /// Метод. Очищает данные картинки
        /// </summary>
        private void CleanPicture()
        {
            pictureNameTextBox.Text = "";                                           // Очистить название
            imageFileNameTextBox.Text = "";                                         // Очистить имя файла картинки

            picturePictureBox.Image = null;                                         // Очистить изображение

            pictureCreationDateDateTimePicker.Value = new DateTime(1950, 1, 1);     // Очистить дату создания

            ClearPictureTypeList();                                                 // Очистить список "Тип картинки"
            FillPictureTypeList();                                                  // Заполнить список "Тип картинки"
        }

        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_picture);                // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_picture);       // Скопировать описание

            CopyPictureFromEntity(_picture);                    // Скопировать данные картинки
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в сущность
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_picture).Description = Description;      // Скопировать описание

            _picture.Name = PictureName;                        // Скопировать название
            _picture.Type = PictureType;                        // Скопировать тип
            _picture.ImageFileName = ImageFileName;             // Скопировать путь к файлу
            _picture.CreationDate = PictureCreationDate;        // Скопировать дату создания
        }

        /// <summary>
        /// Метод. Копирует данные картинки в компоненты документа
        /// </summary>
        private void CopyPictureFromEntity(IPicture picture)
        {
            PictureName = _picture.Name;                    // Скопировать название
            PictureType = picture.Type;                     // Скопировать тип картинки
            ImageFileName = picture.ImageFileName;          // Скопировать имя файла картинки
            PictureCreationDate = picture.CreationDate;     // Скопировать дату создания
        }

        #endregion

        #region Template methods

        /// <summary>
        /// Шаблонный метод. Выбирает элемент в списке
        /// </summary>
        private void SetComboBoxElementByType<T>(ComboBox comboBox, T value)
        {
            int count;                                                                          // Количество элементов в списке
            int counter;                                                                        // Счетчик циклов

            T currentElement;                                                                   // Ключ текущего элемента списка

            count = comboBox.Items.Count;                                                       // Получить количество элементов в списке

            for (counter = 0; counter < count; counter++)                                       // Выполнить для всех элементов списка
            {
                KeyValuePair<T, string> keyValuePair;                                           // Пара ключ-значение для текущего элемента списка

                keyValuePair = (KeyValuePair<T, string>)comboBox.Items[counter];                // Получить пару ключ значение для текущего элемента списка

                currentElement = keyValuePair.Key;                                              // Получить значение ключа из пары ключ-значение

                if (currentElement.ToString() == value.ToString())                              // Сравнить значение ключа элемента списка и заданного параметра (обе переменные имеют тип "T", приведение к строковому формату необходимо, так как сравнени "T == T" приводит к ошибке)
                {
                    comboBox.SelectedIndex = counter;                                           // Задать индекс выделенного элемента
                    break;
                }
            }
        }

        #endregion

        #region DataValidation

        #region NameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Открывает диалоговое окно выбора изображения, сохраняет выбранное изображение в поле и отображает его в полотне
        /// </summary>
        private void selectImageButton_Click(object sender, EventArgs e)
        {
            ImageSelectForm imageSelectForm;                            // Форма выбора изображения

            imageSelectForm = new ImageSelectForm(_imageFolderPath);    // Создать форму выбора изображения

            imageSelectForm.ShowDialog();                               // Отобразить форму выбора изображения

            if (imageSelectForm.SelectedFile != null)                   // Проверить выбранный файл изображения
            {
                ImageFileName = imageSelectForm.SelectedFile;           // Сохранить имя файла изображения

                SetPicture(ImageFileName);                              // Отобразить изображение в полотне
            }
        }

        #endregion

        #endregion

        #region Other

        /// <summary>
        /// Метод. Отображает изображение в полотне для предварительного просмотра
        /// </summary>
        private void SetPicture(string pictureFilePath)
        {
            int width;                                                  // Ширина изображения                                                     
            int height;                                                 // Высота изображения

            string pathToFile;                                          // Путь к файлу изображения

            width = picturePictureBox.Width;                            // Получить ширину изображения
            height = picturePictureBox.Height;                          // Получить высоту изображения

            pathToFile = _imageFolderPath + @"\" + pictureFilePath;     // Вычислить полный путь к файлу изображения

            try
            {
                Picture = Utils.ImageUtils.ResizeImage(                 // Отобразить изображение из файла
                    Image.FromFile(pathToFile),
                    width,
                    height);
            }
            catch
            {
                Picture = Utils.ImageUtils.ResizeImage(                 // Отобразить изображение по умолчанию
                    Properties.Resources.defaultPictureImage,
                    width,
                    height);
            }
        }

        #region Picture Type List

        //TODO: Изменить методы для заполнения списка типа изображения, метод GetSelectedImageType заменить на свойство ImageType (аналог см. в форме Apartment)

        /// <summary>
        /// Метод. Очищает список "Тип картинки"
        /// </summary>
        protected void ClearPictureTypeList()
        {
            pictureTypeComboBox.Items.Clear();     // Очистить список
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Тип картинки"
        /// </summary>
        private void AddPictureTypeToList(PictureTypes pictureType, string pictureTypeDescription)
        {
            pictureTypeComboBox.Items.Add(new KeyValuePair<PictureTypes, string>(pictureType, pictureTypeDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Тип картинки"
        /// </summary>
        private void SetPictureTypeListDisplayMember(string typeMember)
        {
            pictureTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Возвращает выделенный тип картинки из списка "Тип картинки"
        /// </summary>
        protected PictureTypes GetSelectedPictureType()
        {
            return (((KeyValuePair<PictureTypes, string>)pictureTypeComboBox.SelectedItem).Key);
        }

        /// <summary>
        /// Метод. Заполняет данными список "Тип картинки"
        /// </summary>
        protected void FillPictureTypeList()
        {
            foreach (PictureTypes pictureType in Enum.GetValues(typeof(PictureTypes)))                  // Выполнить для всех элементов перечисления
            {
                AddPictureTypeToList(pictureType, _picture.GetPictureTypeAsString(pictureType));        // Добавить элемент в список
            }

            SetPictureTypeListDisplayMember("Value");                                                   // Задать отображаемое поле 
        }

        #endregion

        #endregion

        #endregion
    }
}
