using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ���������
    /// </summary>
    public class Employee : Entity, IEmployee
    {
        /// <summary>
        /// ����������� �����. ����������� ������ ���� IEmployee � ������ ���� Employee
        /// </summary>
        public static Employee IEmployeeToEmployeeConverter(IEmployee employee)
        {
            return ((Employee)employee);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Employee � ������ ���� IEmployee
        /// </summary>
        public static IEmployee EmployeeToIEmployeeConverter(Employee employee)
        {
            return ((IEmployee)employee);
        }

        /// <summary>
        /// ����. ���������
        /// </summary>
        private string _position;

        /// <summary>
        /// ����. ������
        /// </summary>
        private string _password;

        /// <summary>
        /// ����. �������� � ���������, �������������� ��������� ���������������� ������ � ������� ��������� ������������
        /// </summary>
        private string _furtherEducation;

        /// <summary>
        /// ����. ���������� � �������� � ���������������� ����������� ���������
        /// </summary>
        private string _membership;

        /// <summary>
        /// ����. �������� �� ������������ ����������� ����������� ���������������
        /// </summary>
        private string _insurance;

        /// <summary>
        /// ����. ���� ������ � ��������� ������������ (����� ���������� �������)
        /// </summary>
        private int _workTime;

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        public IMan Man
        {
            get
            {
                return ((IMan)ManForEntityFramework);
            }
            set
            {
                ManForEntityFramework = (Man)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������
        /// </summary>
        public string Position
        {
            get
            {
                return(_position);
            }
            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������
        /// </summary>
        public string Password
        {
            get
            {
                return(_password);
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �������� � ���������, �������������� ��������� ���������������� ������ � ������� ��������� ������������
        /// </summary>
        public string FurtherEducation
        {
            get
            {
                return (_furtherEducation);
            }
            set
            {
                _furtherEducation = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ���������� � �������� � ���������������� ����������� ���������
        /// </summary>
        public string Membership
        {
            get
            {
                return (_membership);
            }
            set
            {
                _membership = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ��������� �������� �� ������������ ����������� ����������� ���������������
        /// </summary>
        public string Insurance
        {
            get
            {
                return (_insurance);
            }
            set
            {
                _insurance = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������ � ��������� ������������
        /// </summary>
        public int WorkTime
        {
            get
            {
                return (_workTime);
            }
            set
            {
                _workTime = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        public IReport Report
        {
            get
            {
                return ((IReport)ReportForEntityFramwork);
            }
            set
            {
                ReportForEntityFramwork = (Report)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ����� (������������ � Entity Framework) 
        /// </summary>
        public Report ReportForEntityFramwork { get; set; }

        /// <summary>
        /// �����. ���������� ����� ����������
        /// </summary>
        public override object Clone()
        {
            IEmployee employee;

            employee = (IEmployee)base.Clone();

            employee.Man = Man;

            employee.FurtherEducation = FurtherEducation;
            employee.Membership = Membership;
            employee.Insurance = Insurance;
            employee.WorkTime = WorkTime;
            
            return ((object)employee);
        }
    }
}
