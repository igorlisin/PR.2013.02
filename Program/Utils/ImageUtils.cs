using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utils
{
    /// <summary>
    /// Класс. Набор методов для работы с изображениями
    /// </summary>
    public class ImageUtils
    {
        /// <summary>
        /// Статический метод. Изменяет размер изображения
        /// </summary>
        public static Image ResizeImage(Image image, int width, int height)
        {
            int resizedImageWidth;                                                                  // Ширина изображения после изменения размера
            int resizedImageHeight;                                                                 // Высота изображения после изменения размера

            Image resizedImage;                                                                     // Изображание с измененными размерами

            resizedImageWidth = width;                                                              // Скопировать требуемую ширину
            resizedImageHeight = height;                                                            // Скопировать требуемую высоту

            GetSize(image.Width, image.Height, ref resizedImageWidth, ref resizedImageHeight);      // Вычислить ширину и высоту с сохранением соотношения сторон

            resizedImage = new Bitmap(resizedImageWidth, resizedImageHeight);                       // Создать изображение с измененным размером

            using (Graphics graphic = Graphics.FromImage((Image)resizedImage))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;                   // Задать алгоритм интерполяции
                graphic.SmoothingMode = SmoothingMode.HighQuality;                                  // Задать режим сглаживания
                graphic.DrawImage(image, 0, 0, resizedImageWidth, resizedImageHeight);              // Нарисовать изображаение
                graphic.Dispose();                                                                  // Освободить ресурсы объекта
            }

            return resizedImage;
        }

        /// <summary>
        /// Метод. Возвращает соотношение сторон изображения
        /// </summary>
        private static double GetAspectRation(int width, int height)
        {
            double aspectRetion;                                // Соотношение сторон

            aspectRetion = (double)width / (double)height;      // Вычислить соотношение сторон

            return (aspectRetion);
        }

        /// <summary>
        /// Метод. Вычисляет ширину и высоту с сохранением соотношения сторон
        /// </summary>
        private static void GetSize(int originalWidth, int originalHeight, ref int sizedWidth, ref int sizedHeight)
        {
            double aspectRation;                                                // Соотношение сторон оригинального изображения
            double scaleRation;                                                 // Коэффициент масштабирования изображения

            aspectRation = GetAspectRation(originalWidth, originalHeight);      // Вычислить соотношение сторон

            if (aspectRation > 1.0)                                             // Проверить соотношение сторон
            {
                scaleRation = (double)originalWidth / (double)sizedWidth;       // Вычислить коэффициент масштабирования
            }
            else
            {
                scaleRation = (double)originalHeight / (double)sizedHeight;     // Вычислить коэффициент масштабирования
            }

            sizedWidth = (int)((double)originalWidth / scaleRation);            // Вычислить ширину
            sizedHeight = (int)((double)originalHeight / scaleRation);          // Вычислить высоту
        }
    }
}
