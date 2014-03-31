using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования списка картинок
    /// </summary>
    public partial class PicturesForm : TemplateEntityListForm
    {
        #region Fieds

        /// <summary>
        /// Поле. Путь к папке с изображениями
        /// </summary>
        private string _imageFolderPath;

        /// <summary>
        /// Поле. Список картинок
        /// </summary>
        IPictures _pictures;

        /// <summary>
        /// Поле. Список Квартир
        /// </summary>
        IApartments _apartments;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public PicturesForm(IPictures pictures, IApartments apartments, string imageFolderPath)
            :base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _pictures = pictures;                   // Сохранить список картинок с поле

            _apartments = apartments;               // Сохранить список квартир

            _imageFolderPath = imageFolderPath;     // Сохранить путь к папке с изображениями в поле

            ConfigureEntitiesDataGridView();        // Настроить визуальное представление элемента отображения списка сущностей

            FillEntitiesDataGridView();             // Заполнить элемент отображения списка сущностей

            SetButtonActivity();                    // Задать активность элементов управления
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Настраивает визуальное представление элемента отображения списка сущностей
        /// </summary>
        public new void ConfigureEntitiesDataGridView()
        {
            DataGridViewCell cellTemplateText;                                  // Шаблон ячеек

            DataGridViewColumn columnId;                                        // Колонка "Идентификатор"
            DataGridViewColumn columnDescription;                               // Колонка "Описание"
            DataGridViewColumn columnName;                                      // Колонка "Название"
            DataGridViewColumn columnType;                                      // Колонка "Тип"
            DataGridViewColumn columnFileName;                                  // Колонка "Имя файла изображения"
            DataGridViewColumn columnCreationDate;                              // Колонка "Дата создания"

            cellTemplateText = new DataGridViewTextBoxCell();                   // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);                // Создать колонку "Идентификатор"
            columnDescription = new DataGridViewColumn(cellTemplateText);       // Создать колонку "Описание"
            columnName = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Название"
            columnType = new DataGridViewColumn(cellTemplateText);              // Создать колонку "Тип"
            columnFileName = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Имя файла изображения"
            columnCreationDate = new DataGridViewColumn(cellTemplateText);      // Создать колонку "Дата создания"

            columnId.Width = 100;                                               // Задать ширину колонки
            columnId.Name = "id";                                               // Задать название колонки
            columnId.HeaderText = "Идентификатор";                              // Задать заголовок

            columnDescription.Width = 350;                                      // Задать ширину колонки
            columnDescription.Name = "description";                             // Задать название колонки
            columnDescription.HeaderText = "Описание";                          // Задать заголовок

            columnName.Width = 200;                                             // Задать ширину колонки
            columnName.Name = "name";                                           // Задать название колонки
            columnName.HeaderText = "Название";                                 // Задать заголовок

            columnType.Width = 100;                                             // Задать ширину колонки
            columnType.Name = "type";                                           // Задать название колонки
            columnType.HeaderText = "Тип";                                      // Задать заголовок

            columnFileName.Width = 300;                                         // Задать ширину колонки
            columnFileName.Name = "fileName";                                   // Задать название колонки
            columnFileName.HeaderText = "Имя файла изображения";                // Задать заголовок

            columnCreationDate.Width = 200;                                     // Задать ширину колонки
            columnCreationDate.Name = "creationDate";                           // Задать название колонки
            columnCreationDate.HeaderText = "Дата создания";                    // Задать заголовок

            entitiesDataGridView.Columns.Add(columnName);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnType);                       // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnFileName);                   // Добавить колонку в элемент отображения списка сущностей 
            entitiesDataGridView.Columns.Add(columnCreationDate);               // Добавить колонку в элемент отображения списка сущностей 
            entitiesDataGridView.Columns.Add(columnId);                         // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnDescription);                // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                               // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                      // Идентификатор
            string description;                                             // Описание
            string name;                                                    // Название
            string type;                                                    // Тип
            string fileName;                                                // Имя файла изображения
            string creationDate;                                            // Дата создания

            entitiesDataGridView.Rows.Clear();                              // Очистить элемент отображения списка сущностей

            foreach (IPicture picture in _pictures)                         // Выполнить для всех картинок из списка картинок
            {
                id = ((IEntity)picture).Id.ToString();                      // Получить идентификатор
                description = ((IEntity)picture).Description;               // Получить описание
                name = picture.Name; ;                                      // Получить название
                type = picture.TypeAsString;                                // Получить тип
                fileName = picture.ImageFileName;                           // Получить имя файла изображения
                creationDate = picture.CreationDate.ToShortDateString();    // Получить дату создания

                entitiesDataGridView.Rows.Add(                              // Добавить строку в элемент отображения списка сущностей
                    name,
                    type,
                    fileName,
                    creationDate,
                    id,
                    description);
            }
        }

        /// <summary>
        /// Метод. Задает активность компонентов
        /// </summary>
        protected override void SetButtonActivity()
        {
            base.SetButtonActivity();                       // Задать активность компонентов

            if (entitiesDataGridView.Rows.Count > 0)        // Проверить количество строк
            {
                previewImageButton.Enabled = true;          // Активировать кнопку "Просмотр"
            }
            else
            {
                previewImageButton.Enabled = false;         // Деактивировать кнопку "Просмотр"
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Создает новую картинку и открывает диалоговое окно для ее редактирования
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            IPicture picture;                                               // Картинка
            PictureForm pictureForm;                                        // Форма редактирования картинки
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество картинок в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            bool entityNeedSave;                                            // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество картинок в списке

            selectedRowIndex = 0;                                           // Задать индекс выделенной строки

            if (rowCount > 0)                                               // Проверить общее количество картинок
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
            }

            picture = _pictures.Create();                                   // Создать картинку

            pictureForm = new PictureForm(picture, _apartments, _imageFolderPath);       // Создать форму для редактирования картинки

            pictureForm.ShowDialog();                                       // Отобразить форму для редактирования картинки

            entityNeedSave = pictureForm.EntityNeedSave;                    // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                     // Проверить флаг необходимости сохранения сущности
            {
                _pictures.Add(picture);                                     // Добавить созданную картинку в список
            }

            FillEntitiesDataGridView();                                     // Заполнить данными элемент отображения списка сущностей

            if (rowCount > 0)                                               // Проверить общее количество картинок
            {
                SelectRow(selectedRowIndex);                                // Выделить строку
            }

            SetButtonActivity();                                            // Задать активность элементов управления
        }

        /// <summary>
        /// Метод. Удаляет картинку из списка картинок
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка

            int rowCount;                                                   // Общее количество картинок в списке
            int selectedRowIndex;                                           // Индекс выделенной строки
            int id;                                                         // Идентификатор выделенной картинки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество картинок в списке

            if (rowCount > 0)                                               // Проверить общее количество картинок
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор картинки в выделенной строке

                _pictures.RemoveById(id);                                   // Удалить картинку из списка

                FillEntitiesDataGridView();                                 // Заполнить данными элемент отображения списка сущностей

                if (selectedRowIndex > 1)                                   // Проверить индекс выделенной строки
                {
                    SelectRow(selectedRowIndex - 1);                        // Выделить строку
                }

                SetButtonActivity();                                        // Задать активность элементов управления
            }
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно для редактирования выделенной картинки
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            IPicture picture;                                                   // Картинка
            PictureForm pictureForm;                                            // Форма редактирования картинки
            DataGridViewRow selectedRow;                                        // Выделенная строка

            int rowCount;                                                       // Общее количество строк в списке
            int selectedRowIndex;                                               // Индекс выделенной строки
            int id;                                                             // Идентификатор выделенной картинки
            bool entityNeedSave;                                                // Флаг необходимости сохранения сущности

            rowCount = entitiesDataGridView.Rows.Count;                         // Получить общее количество строк в списке

            if (rowCount > 0)                                                   // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];             // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                           // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);            // Получить идентификатор картинки в выделенной строке

                picture = _pictures.GetPicture(id);                             // Получить выделенную картинку

                pictureForm = new PictureForm(picture,_apartments,_imageFolderPath);       // Создать форму для редактирования картинки

                pictureForm.ShowDialog();                                       // Отобразить форму для редактирования картиннки

                entityNeedSave = pictureForm.EntityNeedSave;                    // Получить значение флага необходимости сохранения сущности

                if (entityNeedSave == true)                                     // Проверить флаг необходимости сохранения сущности
                {
                    _pictures.SaveChanges();                                    // Сохранить изменения списка картинок
                }

                FillEntitiesDataGridView();                                     // Заполнить данными элемент отображения списка сущностей

                SelectRow(selectedRowIndex);                                    // Выделить строку
            }
        }

        /// <summary>
        /// Метод. Отображает форму предварительного просмотра изображений для выделенной строки
        /// </summary>
        private void previewImageButton_Click(object sender, EventArgs e)
        {
            ImagePreviewForm imagePreviewForm;                          // Форма предварительного просмотра изображений
            DataGridViewRow selectedRow;                                // Выделенная строка
            IPicture picture;                                           // Картинка

            int id;                                                     // Идентификатор выделенной картинки

            string fileName;                                            // Имя файла изображения
            string fileFullPath;                                        // Полный путь к файлу изображения

            selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
            id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор картинки в выделенной строке

            picture = _pictures.GetPicture(id);                         // Получить выделенную картинку

            fileName = picture.ImageFileName;                           // Получить название файла изображения

            fileFullPath = _imageFolderPath + @"\" + fileName;          // Вычислить полный путь к файлу изображения

            imagePreviewForm = new ImagePreviewForm(fileFullPath);      // Создать форму предварительного просмотра изображений

            if (imagePreviewForm.ErrorWhileLoadingImage == false)       // Проверить флаг ошибки при загрузке изображения
            {
                imagePreviewForm.ShowDialog();                          // Отобразить форму предварительного просмотра изображений
            }
        }

        #endregion

        #endregion
    }
}
