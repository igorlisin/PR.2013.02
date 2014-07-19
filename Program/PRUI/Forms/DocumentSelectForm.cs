using System;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма выбора документа
    /// </summary>
    public partial class DocumentSelectForm : TemplateEntitySelectForm
    {
        #region Fields

        /// <summary>
        /// Поле. Список документов
        /// </summary>
        IDocuments _documents;

        /// <summary>
        /// Поле. Текущий документ
        /// </summary>
        IDocument _currentDocument;

        /// <summary>
        /// Поле. Выделенный документ
        /// </summary>
        IDocument _selectedDocument;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает выделенный документ
        /// </summary>
        public IDocument SelectedDocument
        {
            get
            {
                return (_selectedDocument);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentSelectForm(IDocuments documents, IDocument currentDocument)
            : base()
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _documents = documents;                 // Скопировать список документов в поле

            _currentDocument = currentDocument;     // Скопировать текущий документ в поле

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
            DataGridViewCell cellTemplateText;                              // Шаблон ячеек

            DataGridViewColumn columnId;                                    // Колонка "Идентификатор"
            DataGridViewColumn columnType;                                  // Колонка "Тип документа"
            DataGridViewColumn columnSeries;                                // Колонка "Серия"
            DataGridViewColumn columnNumber;                                // Колонка "Номер"

            cellTemplateText = new DataGridViewTextBoxCell();               // Создать шаблон ячеек

            columnId = new DataGridViewColumn(cellTemplateText);            // Создать колонку "Идентификатор"
            columnType = new DataGridViewColumn(cellTemplateText);          // Создать колонку "Тип документа"
            columnSeries = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Серия"
            columnNumber = new DataGridViewColumn(cellTemplateText);        // Создать колонку "Номер"

            columnType.Width = 80;                                         // Задать ширину колонки
            columnType.Name = "type";                                       // Задать название колонки
            columnType.HeaderText = "Тип";                                  // Задать заголовок

            columnSeries.Width = 40;                                        // Задать ширину колонки
            columnSeries.Name = "series";                                   // Задать название колонки
            columnSeries.HeaderText = "Серия";                              // Задать заголовок

            columnNumber.Width = 50;                                        // Задать ширину колонки
            columnNumber.Name = "number";                                   // Задать название колонки
            columnNumber.HeaderText = "Номер";                              // Задать заголовок

            columnId.Width = 50;                                           // Задать ширину колонки
            columnId.Name = "id";                                           // Задать название колонки
            columnId.HeaderText = "Идентификатор";                          // Задать заголовок

            entitiesDataGridView.Columns.Add(columnType);                   // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnSeries);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnNumber);                 // Добавить колонку в элемент отображения списка сущностей
            entitiesDataGridView.Columns.Add(columnId);                     // Добавить колонку в элемент отображения списка сущностей

            base.ConfigureEntitiesDataGridView();                           // Настроить визуальное представление элемента отображения сущностей
        }

        /// <summary>
        /// Метод. Заполняет данными элемент отображения списка сущностей
        /// </summary>
        public void FillEntitiesDataGridView()
        {
            string id;                                                  // Идентификатор
            string type;                                                // Тип  (как текстовая строка)
            string series;                                              // Серия 
            string number;                                              // Номер                                                  

            entitiesDataGridView.Rows.Clear();                          // Очистить элемент отображения списка сущностей

            if (_currentDocument != null)                               // Проверить текущий документ
            {
                id = ((IEntity)_currentDocument).Id.ToString();         // Получить идентификатор
                type = _currentDocument.TypeAsString;                   // Получить тип (как текстовую строку)
                series = _currentDocument.Series.ToString();            // Получить серию
                number = _currentDocument.Number.ToString();            // Получить номер

                entitiesDataGridView.Rows.Add(                          // Добавить строку в элемент отображения списка сущностей
                    type,
                    series,
                    number,
                    id);
            }

            foreach (IDocument document in _documents)                  // Выполнить для всех документов из списка документов
            {
                if (document != _currentDocument)                       // Проверить текущий документ (проверка необходима для того, чтобы текущий документ не попал в список дважды)
                {
                    id = ((IEntity)document).Id.ToString();             // Получить идентификатор

                    if (document.Man == null)                           // Проверить человека связанного с документом
                    {
                        type = document.TypeAsString;                   // Получить тип (как текстовую строку)
                        series = document.Series.ToString();            // Получить серию
                        number = document.Number.ToString();            // Получить номер

                        entitiesDataGridView.Rows.Add(                  // Добавить строку в элемент отображения списка сущностей
                            type,
                            series,
                            number,
                            id);
                    }
                }
            }
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Выбирает документ из списка документов, сохраняет  в поле и закрывает диалоговое окно
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;                                    // Выделенная строка
            int id;                                                         // Идентификатор выделенного документа

            int rowCount;                                                   // Общее количество строк в списке
            int selectedRowIndex;                                           // Индекс выделенной строки

            rowCount = entitiesDataGridView.Rows.Count;                     // Получить общее количество строк в списке

            if (rowCount > 0)                                               // Проверить общее количество строк
            {
                selectedRow = entitiesDataGridView.SelectedRows[0];         // Получить выделенную строку
                selectedRowIndex = selectedRow.Index;                       // Получить индекс выделенной строки
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);        // Получить идентификатор документа в выделенной строке

                _selectedDocument = _documents.GetDocument(id);             // Получить выделенный документ
            }

            CloseForm();                                                    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
