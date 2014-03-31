using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Отчет
    /// </summary>
    public class Report : Entity, IReport
    {
        /// <summary>
        /// Статический метод. Преобразует объект типа IReport в объект типа Report
        /// </summary>
        public static Report IReportToReportConverter(IReport report)
        {
            return ((Report)report);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Report в объект типа IReport
        /// </summary>
        public static IReport ReportToIReportConverter(Report report)
        {
            return ((IReport)report);
        }

        /// <summary>
        /// Поле. Номер отчета
        /// </summary>
        private string _reportNumber;

        /// <summary>
        /// Поле. Дата проведения оценки
        /// </summary>
        private DateTime _evaluationDate;

        /// <summary>
        /// Поле. Дата составления отчета
        /// </summary>
        private DateTime _reportDate;

        /// <summary>
        /// Поле. Договор
        /// </summary>
        private string _contract;

        /// <summary>
        /// Поле. Дата заключения договора
        /// </summary>
        private DateTime _dateOfContract;

        /// <summary>
        /// Свойство. Задает и возвращает номер отчета
        /// </summary>
        public string ReportNumber
        {
            get
            {
                return (_reportNumber);
            }
            set
            {
                _reportNumber = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату проведения оценки
        /// </summary>
        public DateTime EvaluationDate
        {
            get
            {
                return (_evaluationDate);
            }
            set
            {
                _evaluationDate = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату составления отчета
        /// </summary>
        public DateTime ReportDate
        {
            get
            {
                return (_reportDate);
            }
            set
            {
                _reportDate = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает договор
        /// </summary>
        public string Contract
        {
            get
            {
                return (_contract);
            }
            set
            {
                _contract = value;
            }

        }

        /// <summary>
        /// Свойство. Задает и возвращает дату заключения договора
        /// </summary>
        public DateTime DateOfContract
        {
            get
            {
                return (_dateOfContract);
            }
            set
            {
                _dateOfContract = value;
            }

        }

        /// <summary>
        /// Свойство. Задает и возвращает клиента
        /// </summary>
        public IClient Client
        {
            get
            {
                return ((IClient)ClientForEntityFramwork);
            }
            set
            {
                ClientForEntityFramwork = (Client)value;
            }

        }

        /// <summary>
        /// Свойство. Задает и возвращает клиента (используется в Entity Framework) 
        /// </summary>
        public Client ClientForEntityFramwork { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает компанию оценщика
        /// </summary>
        public ICompany Company
        {
            get
            {
                return ((ICompany)CompanyForEntityFramework);
            }
            set
            {
                CompanyForEntityFramework = (Company)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает компанию оценщика (используется в Entity Framework) 
        /// </summary>
        public Company CompanyForEntityFramework { get; set; }

        /// <summary>
        /// Свойсво. Задает и возвращает сотрудника
        /// </summary>
        public IEmployee Employee
        {
            get
            {
                return ((IEmployee)EmployeeForEntityFramework);
            }
            set
            {
                EmployeeForEntityFramework = (Employee)value;
            }
        }

        /// <summary>
        /// Свойсво. Задает и возвращает сотрудника (используется в Entity Framework) 
        /// </summary>
        public Employee EmployeeForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает объект оценки
        /// </summary>
        public IObject Object
        {
            get
            {
                return ((IObject)ObjectForEntityFramework);
            }
            set
            {
                ObjectForEntityFramework = (Object)value;
            }
        }


        /// <summary>
        /// Свойсво. Задает и возвращает квартиру (используется в Entity Framework) 
        /// </summary>
        public Apartment ApartmentForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает объект оценки квартира
        /// </summary>
        public IApartment Apartment
        {
            get
            {
                return ((IApartment)ApartmentForEntityFramework);
            }
            set
            {
                ApartmentForEntityFramework = (Apartment)value;
            }
        }
        /// <summary>
        /// Свойство. Задает и возвращает объект оценки (используется в Entity Framework) 
        /// </summary>
        public Object ObjectForEntityFramework { get; set; }


        /// <summary>
        /// Метод. Возвращает копию отчета
        /// </summary>
        public override object Clone()
        {
            IReport report;

            report = (IReport)base.Clone();

            report.Contract = Contract;
            report.DateOfContract = DateOfContract;
            report.Client = Client;
            report.Company = Company;
            report.Employee = Employee;
            report.Object = Object;
            report.Apartment = Apartment;

            return ((object)report);
        }
    }
}
