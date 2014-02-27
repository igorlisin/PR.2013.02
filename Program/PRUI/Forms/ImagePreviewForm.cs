using System;
using System.Drawing;
using System.Windows.Forms;

using PRUI.TemplateForms;

using Utils;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма предварительного просмостра изображения
    /// </summary>
    public partial class ImagePreviewForm : TemplateDialog
    {
        #region Fields

        /// <summary>
        /// Поле. Флаг ошибки при загрузки файлов
        /// </summary>
        private bool _errorWhileLoadingImage;

        #endregion
        
        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает изображение
        /// </summary>
        private Image ImageToPreview
        {
            get
            {
                return(imageToPriviewPictureBox.Image);
            }

            set
            {
                imageToPriviewPictureBox.Image = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает флаг ошибки при загрузки файлов
        /// </summary>
        public bool ErrorWhileLoadingImage
        {
            get
            {
                return (_errorWhileLoadingImage);
            }
            set
            {
                _errorWhileLoadingImage = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ImagePreviewForm(string imageToPreviewFilePath)
        {
            InitializeComponent();                          // Инициализировать компоненты формы

            SetImageToPreview(imageToPreviewFilePath);      // Отобразить изображение на полотне
        }

        #endregion

        #region Methods

        #region Other

        /// <summary>
        /// Метод. Отображает изображение на полотне
        /// </summary>
        private void SetImageToPreview(string imageToPreviewFilePath)
        {
            Image imageToPreview;                                           // Оригинальная картинка
            Image resizedImage;                                             // Картинка с измененными размерами 

            int resizedImageWidth;                                          // Ширина картинки с измененным размером
            int resizedImageHeight;                                         // Высота картинки с измененным размером

            resizedImageWidth = imageToPriviewPictureBox.Width;             // Получить ширину картинки с измененным размером
            resizedImageHeight = imageToPriviewPictureBox.Height;           // Получить высоту картинки с измененным размером

            _errorWhileLoadingImage = false;                                // Сбросить флаг ошибки при загрузке изображения

            try
            {
                imageToPreview = Image.FromFile(imageToPreviewFilePath);    // Загрузить оригинальную картинку 

                resizedImage = ImageUtils.ResizeImage(                      // Изменить размер картинки
                    imageToPreview,
                    resizedImageWidth,
                    resizedImageHeight);

                ImageToPreview = resizedImage;                              // Отобразить картинку
            }
            catch
            {
                MessageBox.Show(                                            // Вывести сообщение об ошибке
                    "Не удалось загрузить файл с изображением",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _errorWhileLoadingImage = true;                             // Установить флаг ошибки при загрузке изображения
            }
        }

        #endregion

        #endregion
    }
}
