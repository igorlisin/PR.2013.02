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
    /// Форма. Форма редактирования отчета
    /// </summary>
    public partial class ReportForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Отчет
        /// </summary>
        private IReport _report;

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        private IClients _clients;

        /// <summary>
        /// Поле. Список сотрудников
        /// </summary>
        private IEmployees _employees;

        /// <summary>
        /// Поле. Клиент после перепривязки
        /// </summary>
        private IClient _clientAfterRelinking;

        /// <summary>
        /// Поле. Сотрудник после перепривязки
        /// </summary>
        private IEmployee _employeeAfterRelinking;

        /// <summary>
        /// Поле. Объект после перепривязки
        /// </summary>
        private IApartment _apartmentAfterRelinking;

        /// <summary>
        /// Поле. Список квартир
        /// </summary>
        IApartments _apartments;

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        IHomes _homes;

        /// <summary>
        /// Поле. Человек
        /// </summary>
        IMans _man;

        /// <summary>
        /// Поле. Документ
        /// </summary>
        IDocuments _document;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает номер отчета
        /// </summary>
        private string ReportNumber
        {
            get
            {
                return (reportNumberTextBox.Text);
            }
            set
            {
                reportNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату оценки
        /// </summary>
        private DateTime EvaluationDate
        {
            get
            {
                return (evaluationDateDateTimePicker.Value);
            }
            set
            {
                evaluationDateDateTimePicker.Value = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату формирования отчета
        /// </summary>
        private DateTime ReportDate
        {
            get
            {
                return (reportDateDateTimePicker.Value);
            }
            set
            {
                reportDateDateTimePicker.Value = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает имя клиента
        /// </summary>
        private string ClientName
        {
            get
            {
                return (clientNameTextBox.Text);
            }
            set
            {
                clientNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает фамилию клиента
        /// </summary>
        private string ClientSurname
        {
            get
            {
                return (clientSurnameTextBox.Text);
            }
            set
            {
                clientSurnameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчество клиента
        /// </summary>
        private string ClientPatronymic
        {
            get
            {
                return (clientPatronymicTextBox.Text);
            }
            set
            {
                clientPatronymicTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает имя сотрудника
        /// </summary>
        private string EmployeeName
        {
            get
            {
                return (employeeNameText.Text);
            }
            set
            {
                employeeNameText.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает фамилию сотрудника
        /// </summary>
        private string EmployeeSurname
        {
            get
            {
                return (employeeSurnameTextBox.Text);
            }
            set
            {
                employeeSurnameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчество сотрудника
        /// </summary>
        private string EmployeePatronymic
        {
            get
            {
                return (employeePatronymicTextBox.Text);
            }
            set
            {
                employeePatronymicTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectType
        {
            get
            {
                return (ObjectTypeTextBox.Text);
            }
            set
            {
                ObjectTypeTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectCity
        {
            get
            {
                return (ObjectCityTextBox.Text);
            }
            set
            {
                ObjectCityTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectStreet
        {
            get
            {
                return (ObjectStreetTextBox.Text);
            }
            set
            {
                ObjectStreetTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectHome
        {
            get
            {
                return (ObjectHouseTextBox.Text);
            }
            set
            {
                ObjectHouseTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectFlat
        {
            get
            {
                return (ObjectFlatTextBox.Text);
            }
            set
            {
                ObjectFlatTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        private string ObjectComplex
        {
            get
            {
                return (ObjectKomplexTextBox.Text);
            }
            set
            {
                ObjectKomplexTextBox.Text = value;
            }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ReportForm(IReport report, IClients clients, IEmployees employees, IApartments apartments, IHomes homes, IMans man, IDocuments document)
        {
            InitializeComponent();                          // Инициализировать компоненты формы

            _report = report;                               // Сохранить отчет в поле
            _clients = clients;                             // Сохранить список клиентов в поле
            _employees = employees;                         // Сохранить список сотрудников в поле

            _clientAfterRelinking = report.Client;          // Сохранить клиента связанного с отчетов
            _employeeAfterRelinking = report.Employee;      // Сохранить сотрудника связанного с отчетов
            _apartmentAfterRelinking = report.Apartment;    // Сохранить квартиру связанного с отчетов

            _apartments = apartments;                       // Сохранить список квартир в поле

            _homes = homes;                                 // Сохранить список домов с поле

            _man = man;                                     // Сохранить чловека
            _document = document;                           // Сохранить документ

            CleanAllData();                                 // Очистить компоненты всех групп

            CopyDataFromEntity();                           // Скопировать данные человека в компоненты формы
        }

        #endregion

        #region Methods

        #region Clean

        /// <summary>
        /// Метод. Очищает все данные формы
        /// </summary>
        protected override void CleanAllData()
        {
            base.CleanAllData();        // Очистить все данные

            CleanReport();              // Очистить данные отчета
            CleanClient();              // Очистить данные клиента
            CleanEmployee();            // Очистить данные сотрудника
            CleanApartment();           // Очистить данные по квартире
            
        }

        /// <summary>
        /// Метод. Очищает данные отчета
        /// </summary>
        private void CleanReport()
        {
            ReportNumber = "";      // Очистить номер отчета
        }

        /// <summary>
        /// Метод. Очищает данные клиента
        /// </summary>
        private void CleanClient()
        {
            ClientName = "";                // Очистить имя клиента
            ClientSurname = "";             // Очистить фамилию клиента
            ClientPatronymic = "";          // Очистить отчество клиента
        }

        /// <summary>
        /// Метод. Очищает данные сотрудника
        /// </summary>
        private void CleanEmployee()
        {
            EmployeeName = "";              // Очистить имя сотрудника
            EmployeeSurname = "";           // Очистить фамилию сотрудника
            EmployeePatronymic = "";        // Очистить отчество сотрудника
        }

        /// <summary>
        /// Метод. Очищает данные сотрудника
        /// </summary>
        private void CleanApartment()
        {
            ObjectType = "";        // Очистить тип
            ObjectCity = "";        // Очистить город
            ObjectStreet = "";      // Очистить улица
            ObjectComplex = "";     // Очистить комплекс
            ObjectHome = "";        // Очистить дом
            ObjectFlat = "";        // Очистить квартира
        }

        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_report);                 // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_report);        // Скопировать описание

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyReportFromEntity(_report);                      // Скопировать данные отчета 
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_report).Description = Description;       // Скопировать описание

            _report.ReportNumber = ReportNumber;                // Скопировать номер отчета
            _report.EvaluationDate = EvaluationDate;            // Скопировать дату оценки
            _report.ReportDate = ReportDate;                    // Скопировать дату формирования отчета


            _report.Client = _clientAfterRelinking;             // Скопировать клиента после перепривязки
            _report.Employee = _employeeAfterRelinking;         // Скопировать сотрудника после перепривязки
            _report.Apartment = _apartmentAfterRelinking;       // Скопировать квартиру после перепривязки
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью 
        /// </summary>
        protected virtual void CopyLinkedDataFromEntity()
        {
            if (_clientAfterRelinking != null)                          // Проверить клиента, связанного с отчетом
            {
                CopyClientFromEntity(_clientAfterRelinking);            // Скопировать данные клиента
            }

            if (_employeeAfterRelinking != null)                        // Проверить сотрудника, связанного с отчетом
            {
                CopyEmployeeFromEntity(_employeeAfterRelinking);        // Скопировать данные сотрудника
            }

            if (_apartmentAfterRelinking != null)                        // Проверить квартиру, связанного с отчетом
            {
                CopyApartmentFromEntity(_apartmentAfterRelinking);        // Скопировать данные квартиры
            }
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты отчета
        /// </summary>
        protected void CopyReportFromEntity(IReport report)
        {
            ReportNumber = report.ReportNumber;         // Скопировать номер отчета

            EvaluationDate = report.EvaluationDate;     // Скопировать дату оценки
            ReportDate = report.ReportDate;             // Скопировать дату формирования отчета
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты клиента
        /// </summary>
        protected void CopyClientFromEntity(IClient client)
        {
            ClientName = client.Man.Name;                   // Скопировать имя
            ClientSurname = client.Man.Surname;             // Скопировать фамилию
            ClientPatronymic = client.Man.Patronymic;       // Скопировать отчество
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты сотрудника
        /// </summary>
        protected void CopyEmployeeFromEntity(IEmployee employee)
        {
            EmployeeName = employee.Man.Name;                   // Скопировать имя
            EmployeeSurname = employee.Man.Surname;             // Скопировать фамилию
            EmployeePatronymic = employee.Man.Patronymic;       // Скопировать отчество
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты квартира
        /// </summary>
        protected void CopyApartmentFromEntity(IApartment apartment)
        {
            ObjectType = Convert.ToString(apartment.RoomNumber);                       // Скопировать тип квартиры
            ObjectCity = apartment.Home.Street.City.Name;                       // Скопировать город
            ObjectStreet = apartment.Home.Street.Name;                          // Скопировать улица
            ObjectComplex = Convert.ToString(apartment.Home.ComplexNumber);     // Скопировать комплекс
            ObjectHome = apartment.Home.Number;                                 // Скопировать номер дома
            ObjectFlat = apartment.Number.ToString();                           // Скопировать номер квартиры
        }

        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Связывает выбранного клиента с отчетом 
        /// </summary>
        private void relinkClientButton_Click(object sender, EventArgs e)
        {
            ClientSelectForm clientSelectForm;                                              // Форма выбора клиента

            clientSelectForm = new ClientSelectForm(_clients, _clientAfterRelinking);       // Создать форму выбора клиента

            clientSelectForm.ShowDialog();                                                  // Отобразить форму выбора клиента

            if (clientSelectForm.SelectedClient != null)                                    // Проверить выбранного клиента
            {
                _clientAfterRelinking = clientSelectForm.SelectedClient;                    // Сохранить выбранного клиента в поле
            }

            CopyLinkedDataFromEntity();                                                     // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает отчет от связанного клиента
        /// </summary>
        private void unlinkClientButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать клиента?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _clientAfterRelinking = null;                   // Отвязать отчет от связанного клиента

                CleanClient();                                  // Очистить данные клиента

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Задает активность компонентов
        /// </summary>
        protected virtual void SetButtonActivity()
        {
            unlinkClientButton.Enabled = (_clientAfterRelinking == null) ? false : true;
            unlinkEmployeeButton.Enabled = (_employeeAfterRelinking == null) ? false : true;
        }

        #endregion

        private void relinkEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeSelectForm employeeSelectForm;                                              // Форма выбора сотрудника
            employeeSelectForm = new EmployeeSelectForm(_employees);                            // Создать форму
            employeeSelectForm.ShowDialog();                                                    // Показать окно
            if (employeeSelectForm.selectedEmployee != null)                                    // Проверить выбранного работника
            {
                _employeeAfterRelinking = employeeSelectForm.selectedEmployee;                  // Сохранить выбранного работника в поле
            }

            CopyLinkedDataFromEntity();                                                          // Скопировать данные из сущностей, связанных с основной сущностью
        }

        #endregion

        private void relinkObjectButton_Click(object sender, EventArgs e)
        {
            ApartmentSelectForm objectSelectForm;                                               // Форма выбора квартиры
            objectSelectForm = new ApartmentSelectForm(_apartments);                                       // Создание формы
            objectSelectForm.ShowDialog();                                                      // Открытие диалогового окна

           if (objectSelectForm.SelectedApartment != null)                                    // Проверить выбранного квартиры
            {
                _apartmentAfterRelinking = objectSelectForm.SelectedApartment;                  // Сохранить выбранного квартиры в поле
            }

            CopyLinkedDataFromEntity();                                                          // Скопировать данные из сущностей, связанных с основной сущностью
        }


        #endregion


        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            IApartment apartment;                                       // Квартира
            IHome home;                                                 // Дом, связанный с квартирой
            ApartmentForm apartmentForm;                                // Форма редактирования квартиры
            bool entityNeedSave;                                        // Флаг необходимости сохранения сущности

            apartment = _apartments.Create();                           // Создать квартиру
            home = _homes.Create();                                     // Создать дом, связанный с квартирой
            apartment.Home = home;                                      // Связать дом с квартирой

            apartmentForm = new ApartmentForm(apartment, _homes);       // Создать форму для редактирования квартиры

            apartmentForm.ShowDialog();                                 // Отобразить форму для редактирования квартиры

            entityNeedSave = apartmentForm.EntityNeedSave;              // Получить значение флага необходимости сохранения сущности

            if (entityNeedSave == true)                                 // Проверить флаг необходимости сохранения сущности
            {
                _apartments.Add(apartment);                             // Добавить созданный квартира в список
            }


        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            IMan man;                                               // Человек
            IDocument document;                                     // Документ
            IClient client;                                         // Клиент

            man = _man.Create();                                    // Создать человек
            document = _document.Create();                          // Создать документ
            client = _clients.Create();                             // Создать клиент

            man.Name = clientNameTextBox.Text;                      // Присвоить Имя с текстового поля
            man.Surname = clientSurnameTextBox.Text;                // Присвоить Фамилия с текстового поля
            man.Patronymic = clientPatronymicTextBox.Text;          // Присвоить Отчество с текстового поля

            document.Series = Convert.ToInt32(clientDocSeriesTextBox.Text);             // Присвоить Серия документа с текстового поля
            document.Number = Convert.ToInt32(clientDocNumberTextBox.Text);             // Присвоить Номер документа с текстового поля

            document.DataOfIssue = Convert.ToDateTime(clientDocDataIssueTextBox.Text);  // Присвоить Дата получения документа с текстового поля

            document.PlaceOfIssue = clientDocGivesTextBox.Text;                         // Присвоить Кем выдан с текстового поля

            client.Man = man;                                       // Присвоить Клиента с текстового поля

            _man.Add(man);                                          // Добавить в базу человека
            _document.Add(document);                                // Добавить в базу документ
            _clients.Add(client);                                   // Добавить в базу клиента

            _clientAfterRelinking = client;                         // Привязывание клиента

        }


        private void unlinkEmployeeButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать сотрудника?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _employeeAfterRelinking = null;                   // Отвязать отчет от связанного работника

                CleanEmployee();                                  // Очистить данные работника

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }
    }
}
