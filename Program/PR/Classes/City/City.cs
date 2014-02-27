using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. �����
    /// </summary>
    public class City : Entity, ICity
    {
        /// <summary>
        /// ����������� ����. �������� �� ���������
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// ����������� ��������. �������� �� ���������
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
        /// ����������� �����. ����������� ������ ���� ICity � ������ ���� City
        /// </summary>
        public static City ICityToCityConverter(ICity city)
        {
            return ((City)city);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� City � ������ ���� ICity
        /// </summary>
        public static ICity CityToICityConverter(City city)
        {
            return ((ICity)city);
        }

        /// <summary>
        /// ����. ��������
        /// </summary>
        private string _name;

        /// <summary>
        /// ��������. ������ � ���������� ��������
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
        /// ��������. ������ � ���������� ������
        /// </summary>
        public IRegion Region
        {
            get
            {
                return ((IRegion)RegionForEntityFramework);
            }
            set
            {
                RegionForEntityFramework = (Region)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ (������������ � Entity Framework) 
        /// </summary>
        public Region RegionForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����
        /// </summary>
        public List<IStreet> Streets
        {
            get
            {
                return (StreetsForEntityFramework.ConvertAll(Street.StreetToIStreetConverter));
            }
            set
            {
                StreetsForEntityFramework = value.ConvertAll(Street.IStreetToStreetConverter);
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ ���� (������������ � Entity Framework) 
        /// </summary>
        public List<Street> StreetsForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����������
        /// </summary>
        public List<IComplex> Complexes
        {
            get
            {
                return (ComplexesForEntityFramework.ConvertAll(Complex.ComplexToIComplexConverter));
            }
            set
            {
                ComplexesForEntityFramework = value.ConvertAll(Complex.IComplexToComplexConverter);
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ ���������� (������������ � Entity Framework) 
        /// </summary>
        public List<Complex> ComplexesForEntityFramework { get; set; }
     
        /// <summary>
        /// �����������
        /// </summary>
        public City()
        {
            Streets = new List<IStreet>();          // ������� ������ ����, ��������� � �������
            Complexes = new List<IComplex>();       // ������� ������ ����������, ��������� � �������
        }

        /// <summary>
        /// �����. ���������� ����� ������
        /// </summary>
        public override object Clone()
        {
            ICity city;

            city = (ICity)base.Clone();

            city.Name = Name;
            city.Region = Region;

            return ((object)city);
        }
    }
}
