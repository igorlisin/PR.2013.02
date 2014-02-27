using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Класс. Форма редактирования документа
    /// </summary>
    public partial class DocumentForm : TemplateEntityPersonForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentForm(IDocument document)
            : base()
        {
            InitializeComponent();          // Инициализировать компоненты формы

            _document = document;           // Сохранить документ в поле

            CleanAllData();                 // Очистить компоненты всех групп

            CopyDataFromEntity();           // Скопировать данные сущности в компоненты формы

            SetMonthCalendarDate();         // Задать дату календаря
        }
        
        #endregion
     
        #region Methods

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_document);               // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_document);      // Скопировать описание
            CopyDocumentFromEntity(_document);                  // Скопировать данные документа
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в сущность
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_document).Description = Description;                         // Скопировать описание

            _document.Type = GetSelectedDocumentType();                             // Скопировать тип

            _document.Series = Convert.ToInt32(DocumentSeries);                     // Скопировать серию
            _document.Number = Convert.ToInt32(DocumentNumber);                     // Скопировать номер 

            _document.DataOfIssue = Convert.ToDateTime(DocumentDateOfIssue);        // Скопировать дату выдачи
            _document.PlaceOfIssue = DocumentPlaceOfIssue;                          // Скопировать место выдачи
        }

        #endregion

        #region Controls Event Handlers

        #region DataValidation
  
        #region DocumentDateOfIssueTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void documentDateOfIssueTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void documentDateOfIssueTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsDateTime(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости

            SetMonthCalendarDate();                                                                     // Задать дату календаря
        }

        #endregion

        #endregion

        #region Other

        /// <summary>
        /// Метод. Сохраняет выбранную в календаре дату в текстовое поле
        /// </summary>
        private void calendarMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DocumentDateOfIssue = ((MonthCalendar)sender).SelectionRange.Start.ToShortDateString();     // Сохранить дату в тектовое поле
        }

        /// <summary>
        /// Метод. Задает дату календаря
        /// </summary>
        private void SetMonthCalendarDate()
        {
            documentDateOfIssueMonthCalendar.SetDate(Convert.ToDateTime(DocumentDateOfIssue));       // Задать дату календаря
        }

        #endregion

        #endregion

        #endregion
    }
}
