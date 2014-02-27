using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. �����
    /// </summary>
    public class Street : Entity, IStreet
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
        /// ����������� �����. ����������� ������ ���� IStreet � ������ ���� Street
        /// </summary>
        public static Street IStreetToStreetConverter(IStreet street)
        {
            return ((Street)street);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Street � ������ ���� IStreet
        /// </summary>
        public static IStreet StreetToIStreetConverter(Street street)
        {
            return ((IStreet)street);
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
        public Street()
        {
            Homes = new List<IHome>();          // ������� ������ �����, ��������� � ������
        }

        /// <summary>
        /// �����. ���������� ����� �����
        /// </summary>
        public override object Clone()
        {
            IStreet street;

            street = (IStreet)base.Clone();

            street.Name = Name;
            street.City = City;

            return ((object)street);
        }
    }
}
