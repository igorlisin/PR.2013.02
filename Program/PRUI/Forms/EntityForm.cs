using System;
using System.Windows.Forms;

using PRInterfaces.Interfaces;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования сущности
    /// </summary>
    public partial class EntityForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Сущность
        /// </summary>
        IEntity _entity;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityForm(IEntity entity)
            : base()
        {
            InitializeComponent();          // Инициализировать компоненты формы

            _entity = entity;               // Сохранить сущность в поле

            CleanBaseInfoGroup();           // Очистить компоненты группы "Основная информация"

            CopyDataFromLink();             // Скопировать данные сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Очищает компоненты группы "Основная информация"
        /// </summary>
        private void CleanBaseInfoGroup()
        {
            idTextBox.Text = "";                // Очистить идентификатор
            descriptionTextBox.Text = "";       // Очистить описание
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты формы
        /// </summary>
        private void CopyDataFromLink()
        {
            CopyBaseInfoFromLink(_entity);      // Скопировать данные в группу "Основная информация"
        }

        /// <summary>
        /// Метод. Копирует данные клиента в компоненты группы "Основная информация"
        /// </summary>
        private void CopyBaseInfoFromLink(IEntity entity)
        {
            idTextBox.Text = Convert.ToString(entity.Id);        // Скопировать идентификатор 
            descriptionTextBox.Text = entity.Description;        // Скопировать описание
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        private void CopyDataToLink()
        {
            _entity.Description = descriptionTextBox.Text;      // Скопировать описание
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        #endregion

        #endregion
    }
}
