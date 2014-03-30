using System;
using System.Windows.Forms;

using PRInterfaces.Interfaces;

namespace PRUI.TemplateForms
{
    /// <summary>
    /// Форма. Шаблон формы редактирования сущности
    /// </summary>
    public partial class TemplateEntityForm : TemplateDialog
    {
        #region Fields

        /// <summary>
        /// Поле. Флаг необходимости сохранения сущности
        /// </summary>
        protected bool _entityNeedSave;

        /// <summary>
        /// Поле. Текстовая строка для восстановления значения текстовых полей, в случае если введенные данные не проходят проверку
        /// </summary>
        protected string _textBoxStringToRestore;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает флаг необходимости сохранения сущности
        /// </summary>
        public bool EntityNeedSave
        {
            get
            {
                return (_entityNeedSave);
            }
        }

        /// <summary>
        /// Свойство. Задает идентификатор
        /// </summary>
        protected int Id
        {
            set
            {
                idTextBox.Text = Convert.ToString(value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает описание
        /// </summary>
        protected string Description
        {
            get
            {
                return (descriptionTextBox.Text);
            }
            set
            {
                descriptionTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает примечание
        /// </summary>
        protected string Note
        {
            set
            {
                noteTextBox.Text = value;
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Делегат. Представляет функцию для проверки значения текстового поля
        /// </summary>
        public delegate bool TextBoxValidateDelegate(string value);

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public TemplateEntityForm()
        {
            InitializeComponent();          // Инициализировать компоненты формы

            _entityNeedSave = false;        // Сбросить флаг необходимости сохранения сущности
        }

        #endregion

        #region Methods

        #region Clean

        /// <summary>
        /// Метод. Очищает все данные
        /// </summary>
        protected virtual void CleanAllData()
        {
            CleanId();                  // Очистить идентификатор
            CleanDescription();         // Очистить описание
            CleanNote();                // Очистить примечание
        }

        /// <summary>
        /// Метод. Очищает идентификатор
        /// </summary>
        protected void CleanId()
        {
            idTextBox.Text = "";
        }

        /// <summary>
        /// Метод. Очищает описание
        /// </summary>
        protected void CleanDescription()
        {
            descriptionTextBox.Text = "";
        }

        /// <summary>
        /// Метод. Очищает примечание
        /// </summary>
        protected void CleanNote()
        {
            noteTextBox.Text = "";
        }

        #endregion

        #region CopyData

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected virtual void CopyDataFromEntity()
        {
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в сущность
        /// </summary>
        protected virtual void CopyDataToEntity()
        {
        }

        /// <summary>
        /// Метод. Копирует идентификтор
        /// </summary>
        protected void CopyIdFromEntity(IEntity entity)
        {
            Id = entity.Id;
        }
        
        /// <summary>
        /// Метод. Копирует описание
        /// </summary>
        protected void CopyDescriptionFromEntity(IEntity entity)
        {
            Description = entity.Description;
        }

        #endregion

        #region DataValidation

        /// <summary>
        /// Метод. Сохраняет значение текстового поля перед началом ввода данных пользователем
        /// </summary>
        protected void TextBoxEnter(TextBox textBox)
        {
            _textBoxStringToRestore = textBox.Text;     // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Восстанавливает значение текстового поля после ввода данных пользователем, если данные не прошли проверку
        /// </summary>
        protected void TextBoxLeave(TextBox textBox, TextBoxValidateDelegate Validate)
        {
            if (!Validate(textBox.Text))                    // Проверить данные, введенные пользователем
            {
                textBox.Text = _textBoxStringToRestore;     // Восстановить значение текстового поля
            }
        }
        
        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Сохраняет изменения данных и закрывает диалоговое окно
        /// </summary>
        public virtual void okButton_Click(object sender, EventArgs e)
        {
            CopyDataToEntity();         // Скопировать данные из компонентов формы в данные сущности

            _entityNeedSave = true;     // Установить флаг необходимости сохранения сущности

            CloseForm();                // Закрыть диалоговое окно   
        }

        /// <summary>
        /// Метод. Сохраняет изменения данных
        /// </summary>
        public virtual void saveButton_Click(object sender, EventArgs e)
        {
            CopyDataToEntity();           // Скопировать данные из компонентов формы в данные дома

            _entityNeedSave = true;     // Установить флаг необходимости сохранения сущности
        }

        #endregion

        #endregion

        #endregion
    }
}

