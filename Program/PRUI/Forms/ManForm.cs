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
    /// Форма. Форма редактирования человека
    /// </summary>
    public partial class ManForm : TemplateEntityPersonForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ManForm(IMan man, IDocuments documents)
            : base()
        {
            InitializeComponent();                      // Инициализировать компоненты формы

            _man = man;                                 // Сохранить человека в поле
            _documents = documents;                     // Сохранить список документов в поле

            _documentAfterRelinking = man.Document;     // Сохранить документ, связанный с человеком

            CleanAllData();                             // Очистить компоненты всех групп

            CopyDataFromEntity();                       // Скопировать данные человека в компоненты формы
        }

        #endregion

        #region Methods

        #region Copy

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_man);                // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_man);       // Скопировать описание

            CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyManFromEntity(_man);                        // Скопировать данные человека 
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            if (_documentAfterRelinking != null)                        // Проверить документ, связанный с человеком
            {
                CopyDocumentFromEntity(_documentAfterRelinking);        // Скопировать данные документа
            }
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_man).Description = Description;      // Скопировать описание

            _man.Name = ManName;                            // Скопировать имя
            _man.Surname = ManSurname;                      // Скопировать фамилию
            _man.Patronymic = ManPatronymic;                // Скопировать отчество

            _man.Document = _documentAfterRelinking;        // Скопировать документ после перепривязки 
        }

        #endregion

        #endregion
    }
}
