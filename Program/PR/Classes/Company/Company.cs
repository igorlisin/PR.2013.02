using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Компания
    /// </summary>
    public class Company : Entity, ICompany 
    {
        /// <summary>
        /// Статический метод. Преобразует объект типа ICompany в объект типа Company
        /// </summary>
        public static Company ICompanyToCompanyConverter(ICompany company)
        {
            return ((Company)company);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Company в объект типа ICompany
        /// </summary>
        public static ICompany CompanyToICompanyConverter(Company company)
        {
            return ((ICompany)company);
        }

        /// <summary>
        /// Поле. Наименование
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Юридический адрес
        /// </summary>
        private string _legalAddress;

        /// <summary>
        /// Поле. Почтовый адрес
        /// </summary>
        private string _postalAddress;

        /// <summary>
        /// Поле. ОГРН
        /// </summary>
        private string _psrn;

        /// <summary>
        /// Свойство. Задает и возвращает наименование
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
        /// Свойство. Задает и возвращает юридический адрес
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
        /// Свойство. Задает и возвращает почтовый адрес
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
        /// Свойство. Задает и возвращает ОГРН
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
        /// Метод. Возвращает копию компании
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
