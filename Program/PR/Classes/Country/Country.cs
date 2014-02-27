using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������
    /// </summary>
    public class Country : Entity, ICountry
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
        /// ����������� �����. ����������� ������ ���� ICountry � ������ ���� Country
        /// </summary>
        public static Country ICountryToCountryConverter(ICountry country)
        {
            return ((Country)country);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Country � ������ ���� ICountry
        /// </summary>
        public static ICountry CountryToICountryConverter(Country country)
        {
            return ((ICountry)country);
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
        /// ��������. ������ � ���������� ������ ��������
        /// </summary>
        public List<IRegion> Regions
        {
            get
            {
                return (RegionsForEntityFramework.ConvertAll(Region.RegionToIRegionConverter));
            }
            set
            {
                RegionsForEntityFramework = value.ConvertAll(Region.IRegionToRegionConverter);
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������� (������������ � Entity Framework) 
        /// </summary>
        public List<Region> RegionsForEntityFramework { get; set; }

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
        /// �����������
        /// </summary>
        public Country()
        {
            Regions = new List<IRegion>();      // ������� ������ ��������, ��������� �� �������
        }

        /// <summary>
        /// �����. ���������� ����� ������
        /// </summary>
        public override object Clone()
        {
            ICountry country;

            country = (ICountry)base.Clone();

            country.Name = Name;

            return ((object)country);
        }
    }
}
