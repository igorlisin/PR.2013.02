using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма выбора изображения
    /// </summary>
    public partial class ImageSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Путь к папке с изображениями
        /// </summary>
        private string _imageFolderPath;

        /// <summary>
        /// Поле. Форма отображения процесса загрузки данных
        /// </summary>
        private ProgressBarForm _loadingDataProgressBarForm;

        /// <summary>
        /// Поле. Выбранный файл
        /// </summary>
        private string _selectedFile;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выбранный файл
        /// </summary>
        public string SelectedFile
        {
            get
            {
                return (_selectedFile);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ImageSelectForm(string imageFolderPath)
            : base()
        {
            InitializeComponent();                                  // Инициализировать компоненты формы

            _imageFolderPath = imageFolderPath;                     // Скопировать путь к папке с изображениями

            _loadingDataProgressBarForm = new ProgressBarForm();    // Создать форму отображения процесса загрузки данных

            ConfigureEntitiesDataGridView();                        // Настроить визуальное представление элемента отображения списка сущностей

            FillEntitiesDataGridView();                             // Заполнить элемент отображения списка сущностей

            SetButtonActivity();                                    // Задать активность элементов управления
        }

        #endregion

        #region Methods

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Отображает форму предварительного просмотра изображений для выделенной строки
        /// </summary>
        private void previewImageButton_Click(object sender, EventArgs e)
        {
            ImagePreviewForm imagePreviewForm;                                              // Форма предварительного просмотра изображений
            DataGridViewRow selectedRow;                                                    // Выделенная строка

            string fileName;                                                                // Имя файла изображения
            string fileExtension;                                                           // Расширение файла изображения
            string fileFullPath;                                                            // Полный путь к файлу изображения

            selectedRow = entitiesDataGridView.SelectedRows[0];                             // Получить выделенную строку

            fileName = Convert.ToString(selectedRow.Cells["name"].Value);                   // Получить название файла изображения
            fileExtension = Convert.ToString(selectedRow.Cells["format"].Value);            // Получить расширение файла изображения
            
            fileFullPath = _imageFolderPath + @"\" + fileName + "." + fileExtension;        // Вычислить полный путь к файлу изображения

            imagePreviewForm = new ImagePreviewForm(fileFullPath);                          // Создать форму предварительного просмотра изображений

            if (imagePreviewForm.ErrorWhileLoadingImage == false)                           // Проверить флаг ошибки при загрузке изображения
            {
                imagePreviewForm.ShowDialog();                                              // Отобразить форму предварительного просмотра изображений
            }
        }


        /// <summary>
        /// Метод. Сохраняет выбранный файл в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                                // Выделенная строка

            string fileName;                                                            // Имя файла изображения
            string fileExtension;                                                       // Расширение файла изображения

            selectedRow = entitiesDataGridView.SelectedRows[0];                         // Получить выделенную строку

            fileName = Convert.ToString(selectedRow.Cells["name"].Value);               // Получить название файла изображения
            fileExtension = Convert.ToString(selectedRow.Cells["format"].Value);        // Получить расширение файла изображения

            _selectedFile = fileName + @"." + fileExtension.ToLower();                  // Получить полное имя файла изображения и сохранить в поле

            Close();                                                                    // Закрыть форму                               
        }

        #endregion

        #endregion

        #region Other

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка сущностей
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                                      // Шаблон ячеек

            DataGridViewColumn columnName;                                                          // Колонка "Название"
            DataGridViewColumn columnSize;                                                          // Колонка "Размер"
            DataGridViewColumn columnFormat;                                                        // Колонка "Расширение"
            DataGridViewColumn columnCreationDateAndTime;                                           // Колонка "Дата и время создания"

            cellTemplateText = new DataGridViewTextBoxCell();                                       // Создать шаблон ячеек

            columnName = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Название"
            columnSize = new DataGridViewColumn(cellTemplateText);                                  // Создать колонку "Размер"
            columnFormat = new DataGridViewColumn(cellTemplateText);                                // Создать колонку "Расширение"
            columnCreationDateAndTime = new DataGridViewColumn(cellTemplateText);                   // Создать колонку "Дата и время создания"

            columnName.Width = 400;                                                                 // Задать ширину колонки
            columnName.Name = "name";                                                               // Задать название колонки
            columnName.HeaderText = "Название";                                                     // Задать заголовок

            columnSize.Width = 90;                                                                  // Задать ширину колонки
            columnSize.Name = "size";                                                               // Задать название колонки
            columnSize.HeaderText = "Размер";                                                       // Задать заголовок

            columnFormat.Width = 60;                                                                // Задать ширину колонки
            columnFormat.Name = "format";                                                           // Задать название колонки
            columnFormat.HeaderText = "Формат";                                                     // Задать заголовок

            columnCreationDateAndTime.Width = 70;                                                   // Задать ширину колонки
            columnCreationDateAndTime.Name = "creationDate";                                        // Задать название колонки
            columnCreationDateAndTime.HeaderText = "Дата и время создания";                         // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSize);                                           // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnFormat);                                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnCreationDateAndTime);                            // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                                                   // Настроить визуальное представление элемента отображения списка сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            List<string> imageFiles;                                            // Список файлов с изображениями
            FileInfo fileInfo;                                                  // Объект с информацией о файле с изображением

            string name;                                                        // Название файла
            string size;                                                        // Размер файла
            string format;                                                      // Формат файла
            string creationDate;                                                // Дата создания файла

            int imageFileCount;                                                 // Количество файлов с изображениями
            int counter;                                                        // Счетчик циклов

            entitiesDataGridView.Rows.Clear();                                  // Очистить элемент отображения списка сущностей

            #region Progress Bar Form

            _loadingDataProgressBarForm.RefreshFormData(                        // Обновить данные формы отображения процесса загрузки данных
                0,
                "Загрузка списка файлов");
            _loadingDataProgressBarForm.Show();                                 // Отобразить форму отображения процесса загрузки данных

            #endregion

            imageFiles = GetImageFiles();                                       // Получить список файлов с изображениями
            imageFileCount = imageFiles.Count;                                  // Вычислить количество файлов с изображениями

            #region Progress Bar Form

            _loadingDataProgressBarForm.RefreshFormData(                        // Обновить данные формы отображения процесса загрузки данных
                0,
                "Загрузка информации о файлах");

            #endregion

            for (counter = 0; counter < imageFileCount - 1; counter++)          // Выполнить для всех файлов из списка
            {
                fileInfo = new FileInfo(imageFiles[counter]);                   // Создать объект с информацией о файле с изображением

                name = fileInfo.Name.Replace(fileInfo.Extension, "");           // Получить название файла
                size = Convert.ToString(fileInfo.Length);                       // Получить размер файла
                format = fileInfo.Extension.Replace(".", "").ToUpper();         // Получить формат файла
                creationDate = fileInfo.CreationTime.ToString();                // Получить дату создания файла

                if ((format == "PNG") || (format == "JPG") || (format == "JPEG") || (format == "BMP") || (format == "TIFF"))        // Проверить формат файла
                {
                    entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                              name,
                              size,
                              format,
                              creationDate);
                }

                #region Progress Bar Form

                _loadingDataProgressBarForm.RefreshFormData(                    // Обновить данные формы отображения процесса загрузки данных
                    (int)((double)counter / (double)imageFileCount * 100.0));

                #endregion
            }

            #region Progress Bar Form

            _loadingDataProgressBarForm.Close();                                // Закрыть формы отображения процесса загрузки данных

            #endregion
        }

        /// <summary>
        /// Метод. Возвращает список файлов с изображениями
        /// </summary>
        private List<string> GetImageFiles()
        {
            List<string> imageFiles;                                                        // Список файлов с изображениями

            imageFiles = null;                                                              // Задать список файлов с изображениями

            try
            {
                imageFiles = new List<string>(Directory.GetFiles(_imageFolderPath));        // Создать список файлов с изображениями
            }
            catch
            {
                MessageBox.Show(                                                            // Вывести сообщение об ошибке
                    "Не удалось получить список файлов с изображениями",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return (imageFiles);
        }

        #endregion

        #endregion
    }
}
