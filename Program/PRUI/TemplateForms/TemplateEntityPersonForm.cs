using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;
using PRUI.Forms;

namespace PRUI.TemplateForms
{
    /// <summary>
    /// Форма. Шаблон формы для редактирования сущности определяющей персону
    /// </summary>
    public partial class TemplateEntityPersonForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Документ
        /// </summary>
        protected IDocument _document;

        /// <summary>
        /// Поле. Человек
        /// </summary>
        protected IMan _man;

        /// <summary>
        /// Поле. Клиент
        /// </summary>
        protected IClient _client;

        /// <summary>
        /// Поле. Сотрудник
        /// </summary>
        protected IEmployee _employee;

        /// <summary>
        /// Поле. Список документов
        /// </summary>
        protected IDocuments _documents;

        /// <summary>
        /// Поле. Список людей
        /// </summary>
        protected IMans _mans;

        /// <summary>
        /// Поле. Документ после перепривязки
        /// </summary>
        protected IDocument _documentAfterRelinking;

        /// <summary>
        /// Поле. Человек после перепривязки
        /// </summary>
        protected IMan _manAfterRelinking;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает серию документа
        /// </summary>
        protected string DocumentSeries
        {
            get
            {
                return (documentSeriesTextBox.Text);
            }
            set
            {
                documentSeriesTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        protected string DocumentNumber
        {
            get
            {
                return (documentNumberTextBox.Text);
            }
            set
            {
                documentNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возращает дату выдачи
        /// </summary>
        protected string DocumentDateOfIssue
        {
            get
            {
                return (documentDateOfIssueTextBox.Text);
            }
            set
            {
                documentDateOfIssueTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает место выдачи 
        /// </summary>
        protected string DocumentPlaceOfIssue
        {
            get
            {
                return (documentPlaceOfIssueTextBox.Text);
            }
            set
            {
                documentPlaceOfIssueTextBox.Text = value;
            }

        }

        /// <summary>
        /// Свойство. Задает и возвращает имя человека
        /// </summary>
        protected string ManName
        {
            get
            {
                return (manNameTextBox.Text);
            }
            set
            {
                manNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает фамилию человека
        /// </summary>
        protected string ManSurname
        {
            get
            {
                return (manSurnameTextBox.Text);
            }
            set
            {
                manSurnameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчество человека
        /// </summary>
        protected string ManPatronymic
        {
            get
            {
                return (manPatronymicTextBox.Text);
            }
            set
            {
                manPatronymicTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public TemplateEntityPersonForm()
        {
            InitializeComponent();          // Инициализировать компоненты формы

            ClearDocumentTypeList();        // Очистить список "Тип документа

            FillDocumentTypeList();         // Заполнить данными список "Тип документа"
        }

        #endregion

        #region Method 

        //TODO: Изменить методы для заполнения списка типа документа, метод GetSelectedDocumentType заменить на свойство DocumentType (аналог см. в форме Apartment)

        #region Document Type List

        /// <summary>
        /// Метод. Очищает список "Тип документа"
        /// </summary>
        protected void ClearDocumentTypeList()
        {
            documentTypeComboBox.Items.Clear();     // Очистить список
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Тип документа"
        /// </summary>
        private void AddDocumentTypeToList(DocumentTypes documentType, string documentTypeDescription)
        {
            documentTypeComboBox.Items.Add(new KeyValuePair<DocumentTypes, string>(documentType, documentTypeDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Тип документа"
        /// </summary>
        private void SetDocumentTypeListDisplayMember(string typeMember)
        {
            documentTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Возвращает выделенный тип документа из списка "Тип документа"
        /// </summary>
        protected DocumentTypes GetSelectedDocumentType()
        {
            return (((KeyValuePair<DocumentTypes, string>)documentTypeComboBox.SelectedItem).Key);
        }

        /// <summary>
        /// Метод. Заполняет данными список "Тип документа"
        /// </summary>
        protected void FillDocumentTypeList()
        {
            AddDocumentTypeToList(DocumentTypes.passport, "Паспорт");                        // Добавить элемента "Паспорт"
            AddDocumentTypeToList(DocumentTypes.driverId, "Водительское удостоверение");     // Добавить элемента "Водительское удостоверение"
            AddDocumentTypeToList(DocumentTypes.warId, "Военный билет");                     // Добавить элемента "Военный билет"

            SetDocumentTypeListDisplayMember("Value");                                      // Задать отображаемое поле 
        }

        #endregion 

        #region Clean

        /// <summary>
        /// Метод. Очищает все данные формы
        /// </summary>
        protected override void CleanAllData()
        {
            base.CleanAllData();        // Очистить все данные

            CleanMan();                 // Очистить данные человека
            CleanDocument();            // Очистить данные документа
        }

        /// <summary>
        /// Метод. Очищает данные документа
        /// </summary>
        private void CleanDocument()
        {
            DocumentSeries = "";            // Очистить серию
            DocumentNumber = "";            // Очистить номер
            DocumentDateOfIssue = "";       // Очистить дату выдачи
            DocumentPlaceOfIssue = "";      // Очистить место выдачи
        }

        /// <summary>
        /// Метод. Очищает данные человека
        /// </summary>
        private void CleanMan()
        {
            ManName = "";              // Очистить имя
            ManSurname = "";           // Очистить фамилию
            ManPatronymic = "";        // Очистить отчество
        }
      
        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью 
        /// </summary>
        protected virtual void CopyLinkedDataFromEntity()
        {
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты документа
        /// </summary>
        protected void CopyDocumentFromEntity(IDocument document)
        {
            documentTypeComboBox.SelectedIndex = Convert.ToInt32(document.Type);        // Скопировать тип

            DocumentSeries = Convert.ToString(document.Series);                         // Скопировать серию
            DocumentNumber = Convert.ToString(document.Number);                         // Скопировать номер 

            DocumentDateOfIssue = document.DataOfIssue.ToShortDateString();             // Скопировать дату выдачи
            DocumentPlaceOfIssue = document.PlaceOfIssue;                               // Скопировать место выдачи 
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты человека
        /// </summary>
        protected void CopyManFromEntity(IMan man)
        {
            ManName = man.Name;                    // Скопировать имя
            ManSurname = man.Surname;              // Скопировать фамилию
            ManPatronymic = man.Patronymic;        // Скопировать отчество
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Связывает выбранный документ с человеком 
        /// </summary>
        private void relinkDocumentButton_Click(object sender, EventArgs e)
        {
            DocumentSelectForm documentSelectForm;                                      // Форма выбора документа

            documentSelectForm = new DocumentSelectForm(_documents, _man.Document);     // Создать форму выбора документа

            documentSelectForm.ShowDialog();                                            // Отобразить форму выбора документа

            if (documentSelectForm.SelectedDocument != null)                            // Проверить выбранный документ
            {
                _documentAfterRelinking = documentSelectForm.SelectedDocument;          // Сохранить выбранный документ в поле
            }

            CopyLinkedDataFromEntity();                                                 // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает человека от связанного документа
        /// </summary>
        private void unlinkDocumentButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать документ?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _documentAfterRelinking  = null;                // Отвязать человека от связанного документа

                CleanDocument();                                // Очистить данные документа

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Задает активность компонентов
        /// </summary>
        protected virtual void SetButtonActivity()
        {
            unlinkDocumentButton.Enabled = (_documentAfterRelinking == null) ? false : true;
            unlinkManButton.Enabled = (_manAfterRelinking == null) ? false : true;
        }

        /// <summary>
        /// Метод. Связывает выбранного человека с клиентом или сотрудником 
        /// </summary>
        private void relinkManButton_Click(object sender, EventArgs e)
        {
            ManSelectForm manSelectForm;                                      // Форма выбора человека
            ManSelectForm.ManSelectType manSelectType;

            if (_client != null)
            {
                manSelectType = ManSelectForm.ManSelectType.SelectForClient;                // Задать цель выбора человека
                manSelectForm = new ManSelectForm(_mans, _client.Man, manSelectType);       // Создать форму выбора человека

                manSelectForm.ShowDialog();                                                 // Отобразить форму выбора человека

                if (manSelectForm.SelectedMan != null)                                      // Проверить выбранного человека
                {
                    _manAfterRelinking = manSelectForm.SelectedMan;                         // Сохранить выбранного человека в поле
                }

                CopyLinkedDataFromEntity();                                                 // Скопировать данные из сущностей, связанных с основной сущностью 
            }

            if (_employee != null)
            {
                manSelectType = ManSelectForm.ManSelectType.SelectForEmployee;              // Задать цель выбора человека
                manSelectForm = new ManSelectForm(_mans, _employee.Man, manSelectType);     // Создать форму выбора человека

                manSelectForm.ShowDialog();                                                 // Отобразить форму выбора человека

                if (manSelectForm.SelectedMan != null)                                      // Проверить выбранного человека
                {
                    _manAfterRelinking = manSelectForm.SelectedMan;                         // Сохранить выбранного человека в поле
                }

                CopyLinkedDataFromEntity();                                                 // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Отвязывает клиента или сотрудника от связанного человека
        /// </summary>
        private void unlinkManButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать человека?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _manAfterRelinking = null;                      // Отвязать клиента ил сотрудника от связанного человека

                CleanDocument();                                // Очистить данные документа
                CleanMan();                                     // Очистить данные человека

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        #endregion

        #region DataValidation

        #region DocumentSeriesTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void documentSeriesTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void documentSeriesTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region DocumentNumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void documentNumberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void documentNumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region NameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));
        }

        #endregion

        #region SurnameTextBox
        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void surnameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void surnameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));
        }

        #endregion

        #region PatronymicTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void patronymicTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void patronymicTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));
        }

        #endregion

        #endregion

        #endregion

        #endregion


    }
}
