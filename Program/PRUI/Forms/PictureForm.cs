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
        /// Поле. имя файла изображения
        /// </summary>
        private string _imageFileName;

        /// <summary>
        /// Поле. Картинка
        /// </summary>
        IPicture _picture;

        /// <summary>
        /// Поле. Список Квартир
        /// </summary>
        private IApartments _apartments;

        /// <summary>
        /// Поле. Квартира после перепривязки
        /// </summary>
        private IApartment _apartmentAfterRelink;

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

        /// <summary>
        /// Свойство. Задает и возвращает название улицы
        /// </summary>
        private string StreetName
        {
            get
            {
                return (streetTextBox.Text);
            }
            set
            {
                streetTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер дома
        /// </summary>
        private string HomeNumber
        {
            get
            {
                return (houseTextBox.Text);
            }
            set
            {
                houseTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер квартиры
        /// </summary>
        private string ApartmentNumber
        {
            get
            {
                return (apartmentNumberTextBox.Text);
            }
            set
            {
                apartmentNumberTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public PictureForm(IPicture picture, IApartments apartment, string imageFolderPath)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _picture = picture;                     // Сохранить картинку в поле

            _apartments = apartment;                // Сохранить список квартир 
            _apartmentAfterRelink = picture.Apartment;

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
            CleanApartment();           // Очистить данные квартиры
        }

               /// <summary>
        /// Метод. Очищает данные квартиры
        /// </summary>
        private void CleanApartment()
        {
            ApartmentNumber = "";
            HomeNumber = "";
            StreetName = "";
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

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyPictureFromEntity(_picture);                    // Скопировать данные картинки
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        private void CopyLinkedDataFromEntity()
        {
            if (_apartmentAfterRelink != null)                                                                // Проверить дом, связанный с квартирой
            {
                CopyApartmentNumberFromEntity(_apartmentAfterRelink);
                if (_apartmentAfterRelink.Home != null)
                {
                    CopyHomeFromEntity(_apartmentAfterRelink.Home);
                    if (_apartmentAfterRelink.Home.Street != null)
                    {
                        CopyStreetFromEntity(_apartmentAfterRelink.Home.Street);
                    }
                }
            }
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты улицы
        /// </summary>
        private void CopyStreetFromEntity(IStreet street)
        {
            StreetName = street.Name;       // Скопировать название улицы
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты квартиры
        /// </summary>
        private void CopyApartmentNumberFromEntity(IApartment apartment)
        {
            ApartmentNumber = Convert.ToString(apartment.Number);       // Скопировать номер квартиры
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты дома
        /// </summary>
        private void CopyHomeFromEntity(IHome home)
        {
            HomeNumber = home.Number;                   // Скопировать номер дома
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
            _picture.Apartment = _apartmentAfterRelink;         // Скопировать привязку к квартире
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

       public override void okButton_Click(object sender, EventArgs e)
        {
            ImageFileName = _imageFolderPath + "\\" + PictureName + "_" +
                              _picture.CreationDate.ToShortDateString() + "_" +
                              _picture.CreationDate.ToLongTimeString().Replace(":", ".") + "_" +
                              _picture.TypeAsString + ".png";
            Picture.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);

            base.okButton_Click(sender, e);
        }

       public override void saveButton_Click(object sender, EventArgs e)
       {
           ImageFileName = _imageFolderPath + "\\" + PictureName + "_" +
                             _picture.CreationDate.ToShortDateString() + "_" +
                             _picture.CreationDate.ToLongTimeString().Replace(":", ".") + "_" +
                             _picture.TypeAsString + ".png";
           Picture.Save( ImageFileName, System.Drawing.Imaging.ImageFormat.Png);


           base.saveButton_Click(sender, e);
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

        private void relinkApartmentButton_Click(object sender, EventArgs e)
        {
            ApartmentSelectForm apartmentSelectForm;                                  // Форма выбора квартиры

            apartmentSelectForm = new ApartmentSelectForm(_apartments);                // Создать форму выбора квартиры

            apartmentSelectForm.ShowDialog();                                // Отобразить форму выбора квартиры

            if (apartmentSelectForm.SelectedApartment != null)                    // Проверить выбранный квартиры
            {
                _apartmentAfterRelink = apartmentSelectForm.SelectedApartment;      // Сохранить выбранный квартиру в поле
            }

            CopyLinkedDataFromEntity();                                 // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        #endregion

        private void unlinkApartmentButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать квартиру?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _apartmentAfterRelink = null;                    // Отвязать квартиру от связанного дома

                CleanApartment();                                 // Очистить данные квартиры
               
                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        #endregion
    }
}
