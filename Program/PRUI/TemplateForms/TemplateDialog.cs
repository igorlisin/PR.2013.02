using System;
using System.Windows.Forms;

namespace PRUI.TemplateForms
{
    /// <summary>
    /// Форма. Основной шаблон форм
    /// </summary>
    public partial class TemplateDialog : Form
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public TemplateDialog()
        {
            InitializeComponent();      // Инициализровать компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        ///  Метод. Закрывает диалоговое окно
        /// </summary>
        protected void CloseForm()
        {
            Close();        // Закрыть диалоговое окно
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Закрывает диалоговое окно
        /// </summary>
        protected void closeButton_Click(object sender, EventArgs e)
        {
            CloseForm();    // Закрыть диалоговое окно
        }

        #endregion

        #endregion
    }
}
