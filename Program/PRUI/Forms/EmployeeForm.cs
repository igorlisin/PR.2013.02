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
    /// Форма. Форма редактирования сотрудника
    /// </summary>
    public partial class EmployeeForm : TemplateEntityPersonForm
    {
        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает должность
        /// </summary>
        public string Position
        {
            get
            {
                return(positionTextBox.Text);
            }
            set
            {
                positionTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
        /// </summary>
        public string FurtherEducation
        {
            get
            {
                return (furtherEducationTextBox.Text);
            }
            set
            {
                furtherEducationTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает информацию о членстве в саморегулируемой организации оценщиков
        /// </summary>
        public string Membership
        {
            get
            {
                return(membershipTextBox.Text);
            }
            set
            {
                membershipTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает сведения об обязательном страховании гражданской ответственности
        /// </summary>
        public string Insurance
        {
            get
            {
                return (insuranceTextBox.Text);
            }
            set
            {
                insuranceTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает стаж работы в оценочной деятельности (общее количество месяцев)
        /// </summary>
        public int WorkTime
        {
            get
            {
                return (Convert.ToInt32(worktimeNumericUpDown.Value));
            }
            set
            {
                worktimeNumericUpDown.Value = Convert.ToDecimal(value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public EmployeeForm(IEmployee employee, IMans mans)
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _employee = employee;                   // Сохранить сотрудника в поле
            _mans = mans;                           // Сохранить список людей в поле

            _manAfterRelinking = employee.Man;      // Сохранить человека, связанного с сотрудником

            CleanAllData();                         // Очистить компоненты всех групп

            CopyDataFromEntity();                   // Скопировать данные сотрудника в компоненты формы
        }

        #endregion

        #region Methods

        #region Clean

        /// <summary>
        /// Метод. Очищает данные сотрудника
        /// </summary>
        private void CleanEmployeee()
        {
            Position = "";              // Очистить должность
            FurtherEducation = "";      // Очистить сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
            Membership = "";            // Очистить информацию о членстве в саморегулируемой организации оценщиков
            Insurance = "";             // Очистить сведения об обязательном страховании гражданской ответственности
            WorkTime = 0;               // Очистить стаж работы в оценочной деятельности (общее количество месяцев)
        }

        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_employee);               // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_employee);      // Скопировать описание

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyEmployeeFromEntity(_employee);                  // Скопировать данные сотрудника
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            if (_manAfterRelinking != null)                                     // Проверить человека, связанного с сотрудником
            {
                if (_manAfterRelinking.Document != null)                        // Проверить документ, связанный с человеком
                {
                    CopyDocumentFromEntity(_manAfterRelinking.Document);        // Скопировать данные документа      
                }
                CopyManFromEntity(_manAfterRelinking);                          // Скопировать данные человека    
            }
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты клиента
        /// </summary>
        private void CopyEmployeeFromEntity(IEmployee employee)
        {
            Position = employee.Position;                       // Скопировать должность
            FurtherEducation = employee.FurtherEducation;       // Скопировать сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
            Membership = employee.Membership;                   // Скопировать информацию о членстве в саморегулируемой организации оценщиков
            Insurance = employee.Insurance;                     // Скопировать сведения об обязательном страховании гражданской ответственности
            WorkTime = employee.WorkTime;                       // Скопировать стаж работы в оценочной деятельности (общее количество месяцев)
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_employee).Description = Description;     // Скопировать описание

            _employee.Man = _manAfterRelinking;                 // Скопировать человека после перепривязки

            _employee.Position = Position;                      // Скопировать должность
            _employee.FurtherEducation = FurtherEducation;      // Скопировать сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
            _employee.Membership = Membership;                  // Скопировать информацию о членстве в саморегулируемой организации оценщиков
            _employee.Insurance = Insurance;                    // Скопировать сведения об обязательном страховании гражданской ответственности
            _employee.WorkTime = WorkTime;                      // Скопировать стаж работы в оценочной деятельности (общее количество месяцев)
        }

        #endregion

        #endregion
    }
}
