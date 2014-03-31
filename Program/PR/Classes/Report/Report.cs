using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. �����
    /// </summary>
    public class Report : Entity, IReport
    {
        /// <summary>
        /// ����������� �����. ����������� ������ ���� IReport � ������ ���� Report
        /// </summary>
        public static Report IReportToReportConverter(IReport report)
        {
            return ((Report)report);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Report � ������ ���� IReport
        /// </summary>
        public static IReport ReportToIReportConverter(Report report)
        {
            return ((IReport)report);
        }

        /// <summary>
        /// ����. ����� ������
        /// </summary>
        private string _reportNumber;

        /// <summary>
        /// ����. ���� ���������� ������
        /// </summary>
        private DateTime _evaluationDate;

        /// <summary>
        /// ����. ���� ����������� ������
        /// </summary>
        private DateTime _reportDate;

        /// <summary>
        /// ����. �������
        /// </summary>
        private string _contract;

        /// <summary>
        /// ����. ���� ���������� ��������
        /// </summary>
        private DateTime _dateOfContract;

        /// <summary>
        /// ��������. ������ � ���������� ����� ������
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
        /// ��������. ������ � ���������� ���� ���������� ������
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
        /// ��������. ������ � ���������� ���� ����������� ������
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
        /// ��������. ������ � ���������� �������
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
        /// ��������. ������ � ���������� ���� ���������� ��������
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
        /// ��������. ������ � ���������� �������
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
        /// ��������. ������ � ���������� ������� (������������ � Entity Framework) 
        /// </summary>
        public Client ClientForEntityFramwork { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������� ��������
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
        /// ��������. ������ � ���������� �������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Company CompanyForEntityFramework { get; set; }

        /// <summary>
        /// �������. ������ � ���������� ����������
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
        /// �������. ������ � ���������� ���������� (������������ � Entity Framework) 
        /// </summary>
        public Employee EmployeeForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������
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
        /// �������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Apartment ApartmentForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������ ��������
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
        /// ��������. ������ � ���������� ������ ������ (������������ � Entity Framework) 
        /// </summary>
        public Object ObjectForEntityFramework { get; set; }


        /// <summary>
        /// �����. ���������� ����� ������
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
