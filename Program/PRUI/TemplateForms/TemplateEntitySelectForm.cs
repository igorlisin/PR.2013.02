using System.Windows.Forms;

using Utils;

namespace PRUI.TemplateForms
{
    /// <summary>
    /// Форма. Шаблон формы выбора сущности
    /// </summary>
    public partial class TemplateEntitySelectForm : TemplateDialog
    {
        #region  Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public TemplateEntitySelectForm()
        {
            InitializeComponent();      // Инициализировать компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Конфигурирует элемент отображения списка сущностей
        /// </summary>
        protected void ConfigureEntitiesDataGridView()
        {
            entitiesDataGridView.ScrollBars = ScrollBars.Vertical;                                                          // Задать отображения вертикальной полосы прокрутки

            entitiesDataGridView.Size = new System.Drawing.Size(this.ClientSize.Width - 24, entitiesDataGridView.Height);   // Задать размер элемента отображения списка сущностей
            entitiesDataGridView.Left = 12;                                                                                 // Задать положение элемента отображения списка сущностей

            DataGridViewUtils.SetLastColumnWidth(entitiesDataGridView);                                                     // Задать ширину последнего столбца элемента отображения списка сущностей                                                                        
        }

        /// <summary>
        /// Метод. Задает активность элементов управления
        /// </summary>
        protected void SetButtonActivity()
        {
            if (entitiesDataGridView.Rows.Count > 0)        // Проверить количество строк
            {
                selectButton.Enabled = true;                // Активировать кнопку "Выбрать"
            }
            else
            {
                selectButton.Enabled = false;               // Деактивировать кнопку "Выбрать"
            }
        }

        /// <summary>
        /// Метод. Выделяет строку в элементе отображения списка сущностей
        /// </summary>
        protected void SelectRow(int rowIndex)
        {
            DataGridViewUtils.SelectRow(entitiesDataGridView, rowIndex);        // Выделить строку в элементе отображения списка сущностей
        }

        #endregion
    }
}
