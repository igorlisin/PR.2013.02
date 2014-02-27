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
