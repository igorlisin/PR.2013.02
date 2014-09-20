using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ��������
    /// </summary>
    public class Complex : Entity, IComplex 
    {
        /// <summary>
        /// ����������� ����. ����� �� ���������
        /// </summary>
        private static int _defaultNumber;

        /// <summary>
        /// ����. ������ � ���������� ��������� �����������
        /// </summary>
        private string _loacals_1;

        /// <summary>
        /// ����. ������ � ���������� ��������� �����������
        /// </summary>
        private string _loacals_2;

        /// <summary>
        /// ����. ������ � ���������� ������ ������
        /// </summary>
        private string _banks;


        /// <summary>
        /// ����. ������ � ���������� ������ �������
        /// </summary>
        private string _hospitals;


        /// <summary>
        /// ����. ������ � ���������� ������ ��� �����
        /// </summary>
        private string _kinders;


        /// <summary>
        /// ����. ������ � ���������� ������ ���� ������
        /// </summary>
        private string _restPlaces;


        /// <summary>
        /// ����. ������ � ���������� ������ ����
        /// </summary>
        private string _schools;


        /// <summary>
        /// ����. ������ � ���������� ������ ����������� ����
        /// </summary>
        private string _services;


        /// <summary>
        /// ����. ������ � ���������� ������ �������� ��������
        /// </summary>
        private string _tradings;

        /// <summary>
        /// ��������. ������ � ���������� ������ �����
        /// </summary>
        private string _pharmList;

        /// <summary>
        /// ����������� ��������. ����� �� ���������
        /// </summary>
        public static int DefaultNumber
        {
            get
            {
                return (_defaultNumber);
            }
            set
            {
                _defaultNumber = value;
            }
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� IComplex � ������ ���� Complex
        /// </summary>
        public static Complex IComplexToComplexConverter(IComplex complex)
        {
            return ((Complex)complex);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Complex � ������ ���� IComplex
        /// </summary>
        public static IComplex ComplexToIComplexConverter(Complex complex)
        {
            return ((IComplex)complex);
        }

        /// <summary>
        /// ����. �����
        /// </summary>
        private int _number;

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        public int Number
        {
            get
            {
                return (_number);
            }
            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �����������
        /// </summary>
        public string Loacals_1
        {
            get
            {
                return _loacals_1;
            }
            set
            {
                _loacals_1 = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �����������
        /// </summary>
        public string Loacals_2
        {
            get
            {
                return _loacals_2;
            }
            set
            {
                _loacals_2 = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������
        /// </summary>
        public string Banks
        {
            get
            {
                return (_banks);
            }
            set
            {
                _banks = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        public string Hospitals
        {
            get
            {
                return (_hospitals);
            }
            set
            {
                _hospitals = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ ��� �����
        /// </summary>
        public string Kinders
        {
            get
            {
                return (_kinders);
            }
            set
            {
                _kinders = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ ���� ������
        /// </summary>
        public string RestPlaces
        {
            get
            {
                return (_restPlaces);
            }
            set
            {
                _restPlaces = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ ����
        /// </summary>
        public string Schools
        {
            get
            {
                return (_schools);
            }
            set
            {
                _schools = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ ����������� ����
        /// </summary>
        public string Services
        {
            get
            {
                return (_services);
            }
            set
            {
                _services = value;
            }
        }


        /// <summary>
        /// ��������. ������ � ���������� ������ �������� ��������
        /// </summary>
        public string Tradings
        {
            get
            {
                return (_tradings);
            }
            set
            {
                _tradings = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ �����
        /// </summary>
        public string PharmList
        {
            get
            {
                return (_pharmList);
            }
            set
            {
                _pharmList = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        public ICity City
        {
            get
            {
                return ((ICity)CityForEntityFramework);
            }
            set
            {
                CityForEntityFramework = (City)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ����� (������������ � Entity Framework) 
        /// </summary>
        public City CityForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����� 
        /// </summary>
        public List<IHome> Homes
        {
            get
            {
                return (HomesForEntityFramework.ConvertAll(Home.HomeToIHomeConverter));
            }
            set
            {
                HomesForEntityFramework = value.ConvertAll(Home.IHomeToHomeConverter);
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����� (������������ � Entity Framework) 
        /// </summary>
        public List<Home> HomesForEntityFramework { get; set; }

 

        /// <summary>
        /// �����������
        /// </summary>
        public Complex()
        {
            Homes = new List<IHome>();          // ������� ������ �����, ��������� � ����������
        }

        /// <summary>
        /// �����. ���������� ����� ���������
        /// </summary>
        public override object Clone()
        {
            IComplex complex;

            complex = (IComplex)(base.Clone());

            complex.Number = Number;
            complex.City = City;

            return ((object)complex);
        }

 

    }
}
