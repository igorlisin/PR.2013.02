using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using PRUI.TemplateForms;

using Utils;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма настроек программы
    /// </summary>
    public partial class ProgramOptionsForm : TemplateDialog
    {
        #region Fields

        /// <summary>
        /// Поле. Флаг необходимости сохранения настроек
        /// </summary>
        private bool _optionsNeedSave;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Возвращает флаг необходимости сохранения настроек
        /// </summary>
        public bool OptionsNeedSave
        {
            get
            {
                return (_optionsNeedSave);
            }
        }

        /// <summary>
        /// Свойство. Путь к папке с изображениями
        /// </summary>
        public string ImagesFolderPath
        {
            get
            {
                return (imagesFolderPathTextBox.Text);
            }
            set
            {
                imagesFolderPathTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Путь к папке с шаблонами отчетов
        /// </summary>
        public string ReportTemplatesFolderPath
        {
            get
            {
                return(reportTemplatesFolderPathTextBox.Text);
            }
            set
            {
                reportTemplatesFolderPathTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Путь к папке с отчетами
        /// </summary>
        public string ReportsFolderPath
        {
            get
            {
                return (reportsFolderPathTextBox.Text);
            }
            set
            {
                reportsFolderPathTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProgramOptionsForm()
            : base()
        {
            InitializeComponent();          // Инициализировать компоненты формы

            _optionsNeedSave = false;       // Сбросить флаг необходимости сохранения настроек
        }

        #endregion

        #region Methods

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Сохраняет изменения данных и закрывает диалоговое окно
        /// </summary>
        public void okButton_Click(object sender, EventArgs e)
        {
            _optionsNeedSave = true;    // Установить флаг необходимости сохранения настроек

            CloseForm();                // Закрыть диалоговое окно   
        }

        /// <summary>
        /// Метод. Сохраняет изменения данных
        /// </summary>
        public void saveButton_Click(object sender, EventArgs e)
        {
            _optionsNeedSave = true;     // Установить флаг необходимости сохранения настроек
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно выбора папки и возвращает путь к выбранной папке
        /// </summary>
        private void browseImagesFolderPathButton_Click(object sender, EventArgs e)
        {
            ImagesFolderPath = GetFolder(ImagesFolderPath);     // Открыть диалоговое окно и выбрать путь к папке
        }

        /// <summary>
        /// Метод. Открывает диалоговое окно выбора папки и возвращает путь к выбранной папке
        /// </summary>
        private void browseReportTemplatesFolderPathButton_Click(object sender, EventArgs e)
        {
            ReportTemplatesFolderPath = GetFolder(ReportTemplatesFolderPath);     // Открыть диалоговое окно и выбрать путь к папке
        }

        /// Метод. Открывает диалоговое окно выбора папки и возвращает путь к выбранной папке
        /// </summary>
        private void browseReportsFolderPathButton_Click(object sender, EventArgs e)
        {
            ReportsFolderPath = GetFolder(ReportsFolderPath);     // Открыть диалоговое окно и выбрать путь к папке
        }


        #endregion

        #endregion

        #region Other

        /// <summary>
        /// Метод. Открывает диалоговое окно выбора папки и возвращает путь к выбранной папке
        /// </summary>
        private string GetFolder(string currentPath)
        {
            FolderBrowserDialog folderBrowseDialog;                                         // Диалоговое окно выбора папки
            DialogResult dialogResult;                                                      // Результат работы диалогового окна выбора папки

            string selectedFolderPath;                                                      // Выбранный путь к папке

            folderBrowseDialog = new FolderBrowserDialog();                                 // Создать диалоговое окно выбора папки
            folderBrowseDialog.ShowNewFolderButton = false;                                 // Скрыть папку "Создать папку" в диалоговом окне выбора папки

            if (Directory.Exists(currentPath))                                              // Проверить путь к папке                         
            {
                folderBrowseDialog.SelectedPath = currentPath;                              // Задать начатьный путь для диалогового окна выбора папки
            }
            else
            {
                folderBrowseDialog.RootFolder = Environment.SpecialFolder.MyComputer;       // Задать стандартный начальный путь для диалогового окна выбора папки
            }

            dialogResult = folderBrowseDialog.ShowDialog();                                 // Отобразить диалоговое окно выбора папки

            selectedFolderPath = currentPath;                                               // Сохранить текущий путь к папке как выбранный

            if (dialogResult == DialogResult.OK)                                            // Проверить результат работы диалогового окна выбора папки
            {
                try
                {
                    selectedFolderPath = folderBrowseDialog.SelectedPath;                   // Сохранить выбранный путь
                }
                catch
                {
                    MessageBox.Show(                                                        // Вывести сообщение об ошибке
                        "Выбрана недопустимая папка", 
                        "Ошибка", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }

            return (selectedFolderPath);
        }

        #endregion





        #endregion
    }
}
