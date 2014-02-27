using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������
    /// </summary>
    public class Region : Entity, IRegion 
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
        /// ����������� �����. ����������� ������ ���� IRegion � ������ ���� Region
        /// </summary>
        public static Region IRegionToRegionConverter(IRegion region)
        {
            return ((Region)region);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Region � ������ ���� IRegion
        /// </summary>
        public static IRegion RegionToIRegionConverter(Region region)
        {
            return ((IRegion)region);
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
        public ICountry Country
        {
            get
            {
                return ((ICountry)CountryForEntityFramework);
            }
            set
            {
                CountryForEntityFramework = (Country)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ (������������ � Entity Framework) 
        /// </summary>
        public Country CountryForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        public List<ICity> Cities
        {
            get
            {
                return (CitiesForEntityFramwork.ConvertAll(City.CityToICityConverter));
            }
            set
            {
                CitiesForEntityFramwork = value.ConvertAll(City.ICityToCityConverter);
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������� (������������ � Entity Framework) 
        /// </summary>
        public List<City> CitiesForEntityFramwork { get; set; }
        
        /// <summary>
        /// �����������
        /// </summary>
        public Region()
        {
            Cities = new List<ICity>();     // ������� ������ �������, ��������� � ��������
        }

        /// <summary>
        /// �����. ���������� ����� �������
        /// </summary>
        public override object Clone()
        {
            IRegion region;

            region = (IRegion)base.Clone();

            region.Name = Name;
            region.Country = Country;

            return ((object)region);
        }
    }
}
