using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. �������
    /// </summary>
    public class Man : Entity, IMan
    {
        /// <summary>
        /// ����������� ����. ��� �� ���������
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// ����������� ����. ������� �� ���������
        /// </summary>
        private static string _defaultSurname;

        /// <summary>
        /// ����������� ����. �������� �� ���������
        /// </summary>
        private static string _defaultPatronymic;

        /// <summary>
        /// ����������� ��������. ��� �� ���������
        /// </summary>
        public static string DefaultName
        {
            get
            {
                return (_defaultName);
            }
            set
            {
                _defaultName = value;
            }
        }

        /// <summary>
        /// ����������� ��������. ������� �� ���������
        /// </summary>
        public static string DefaultPatronymic
        {
            get
            {
                return (_defaultPatronymic);
            }
            set
            {
                _defaultPatronymic = value;
            }
        }

        /// <summary>
        /// ����������� ��������. �������� �� ���������
        /// </summary>
        public static string DefaultSurname
        {
            get
            {
                return (_defaultSurname);
            }
            set
            {
                _defaultSurname = value;
            }
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� IMan � ������ ���� Man
        /// </summary>
        public static Man IManToManConverter(IMan man)
        {
            return ((Man)man);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Man � ������ ���� IMan
        /// </summary>
        public static IMan ManToIManConverter(Man man)
        {
            return ((IMan)man);
        }

        /// <summary>
        /// ����. ���
        /// </summary>
        private string _name;

        /// <summary>
        /// ����. �������
        /// </summary>
        private string _surname;

        /// <summary>
        /// ����. ��������
        /// </summary>
        private string _patronymic;

        /// <summary>
        /// ��������. ������ � ���������� ���
        /// </summary>
        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        public string Surname
        {
            get
            {
                return (_surname);
            }
            set
            {
                _surname = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        public string Patronymic
        {
            get
            {
                return (_patronymic);
            }
            set
            {
                _patronymic = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        public IDocument Document
        {
            get
            {
                return ((IDocument)DocumentForEntityFramework);
            }
            set
            {
                DocumentForEntityFramework = (Document)value;
            }
        }
        
        /// <summary>
        /// ��������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Document DocumentForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        public IClient Client
        {
            get
            {
                return ((IClient)ClientForEntityFramework);
            }
            set
            {
                ClientForEntityFramework = (Client)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������� (������������ � Entity Framework) 
        /// </summary>
        public Client ClientForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����������
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
        /// ��������. ������ � ���������� ���������� (������������ � Entity Framework) 
        /// </summary>
        public Employee EmployeeForEntityFramework { get; set; }

        /// <summary>
        /// �����. ���������� ����� ��������
        /// </summary>
        public override object Clone()
        {
            IMan man;

            man = (IMan)base.Clone();

            man.Name = Name;
            man.Surname = Surname;
            man.Patronymic = Patronymic;
            man.Document = (IDocument)((ICloneable)Document).Clone();

            return ((object)man);
        }
    }
}
