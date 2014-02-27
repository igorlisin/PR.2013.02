using System;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма отображения прогресса выполнения операции
    /// </summary>
    public partial class ProgressBarForm : TemplateDialog 
    {
        /// <summary>
        /// Свойство. Задает процент выполнения операции
        /// </summary>
        public int Progress
        {
            get
            {
                return (progressProgressBar.Value);
            }
            set
            {
                progressProgressBar.Value = value;
                progressLabel.Text = Convert.ToString(value)+ " / 100";
            }
        }

        /// <summary>
        /// Свойство. Задает описание операции
        /// </summary>
        public string Description
        {
            set
            {
                descriptionLabel.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает заголовок окна
        /// </summary>
        public string Caption
        {
            set
            {
                Text = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProgressBarForm()
        {
            InitializeComponent();      // Инициализировать компоненты формы
        }

        /// <summary>
        /// Метод. Обновляет данные и перерисовывает форму
        /// </summary>
        public void RefreshFormData(int progress, string description = null, string caption = null)
        {
            if (description != null)            // Проверить описание операции
            {
                Description = description;      // Задать описание операции
            }

            if (caption != null)                // Проверить заголовок окна
            {
                Caption = caption;              // Задать заголовок окна
            }

            if ((Progress + 1) <= progress)     // Проверить процент выполнения операции (необходимо так как выполянть метод "Refresh" слишком накладно)
            {
                Progress = progress;            // Задать процент выполнения операции
                Refresh();                      // Перерисовать форму
            }

            
        }
    }
}
