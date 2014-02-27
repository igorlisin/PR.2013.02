using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ��������
    /// </summary>
    public class Company : Entity, ICompany 
    {
        /// <summary>
        /// ����������� �����. ����������� ������ ���� ICompany � ������ ���� Company
        /// </summary>
        public static Company ICompanyToCompanyConverter(ICompany company)
        {
            return ((Company)company);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Company � ������ ���� ICompany
        /// </summary>
        public static ICompany CompanyToICompanyConverter(Company company)
        {
            return ((ICompany)company);
        }

        /// <summary>
        /// ����. ������������
        /// </summary>
        private string _name;

        /// <summary>
        /// ����. ����������� �����
        /// </summary>
        private string _legalAddress;

        /// <summary>
        /// ����. �������� �����
        /// </summary>
        private string _postalAddress;

        /// <summary>
        /// ����. ����
        /// </summary>
        private string _psrn;

        /// <summary>
        /// ��������. ������ � ���������� ������������
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
        /// ��������. ������ � ���������� ����������� �����
        /// </summary>
        public string LegalAddress
        {
            get
            {
                return (_legalAddress);
            }
            set
            {
                _legalAddress = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �������� �����
        /// </summary>
        public string PostalAddress
        {
            get
            {
                return (_postalAddress);
            }
            set
            {
                _postalAddress = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ����
        /// </summary>
        public string PSRN
        {
            get
            {
                return (_psrn);
            }
            set
            {
                _psrn = value;
            }
        }

        /// <summary>
        /// �����. ���������� ����� ��������
        /// </summary>
        public override object Clone()
        {
            ICompany company;

            company = (ICompany)base.Clone();

            company.Name = Name;
            company.LegalAddress = LegalAddress;
            company.PostalAddress = PostalAddress;
            company.PSRN = PSRN;

            return ((object)company);
        }
    }
}
