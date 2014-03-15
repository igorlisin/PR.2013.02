using System;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PR.Classes;

namespace PR
{
    /// <summary>
    /// Класс. Объектная модель
    /// </summary>
    public class ObjectModel
    {
        /// <summary>
        /// Поле. Список документов
        /// </summary>
        private IDocuments _documents;

        /// <summary>
        /// Поле. Список людей
        /// </summary>
        private IMans _mans;

        /// <summary>
        /// Поле. Список клиентов
        /// </summary>
        private IClients _clients;

        /// <summary>
        /// Поле. Список сотрудников
        /// </summary>
        private IEmployees _employees;

        /// <summary>
        /// Поле. Список стран
        /// </summary>
        private ICountries _countries;

        /// <summary>
        /// Поле. Список регионов
        /// </summary>
        private IRegions _regions;

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        private ICities _cities;

        /// <summary>
        /// Поле. Список улиц
        /// </summary>
        private IStreets _streets;

        /// <summary>
        /// Поле. Список комплексов
        /// </summary>
        private IComplexes _complexes;

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        private IHomes _homes;

        /// <summary>
        /// Поле. Список квартир
        /// </summary>
        private IApartments _appartments;

        /// <summary>
        /// Поле. Список квартир
        /// </summary>
        private IObjects _objects;

        /// <summary>
        /// Поле. Список компаний
        /// </summary>
        private ICompanies _companies;

        /// <summary>
        /// Поле. Список картинок
        /// </summary>
        private IPictures _pictures;

        /// <summary>
        /// Поле. Список отчетов
        /// </summary>
        private IReports _reports;

        /// <summary>
        /// Свойство. Задает и возвращает список документов
        /// </summary>
        public IDocuments Documents
        {
            get
            {
                return(_documents);
            }
            set
            {
                _documents = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список людей
        /// </summary>
        public IMans Mans
        {
            get
            {
                return (_mans);
            }
            set
            {
                _mans = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список клиентов
        /// </summary>
        public IClients Clients
        {
            get
            {
                return (_clients);
            }
            set
            {
                _clients = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список сотрудников
        /// </summary>
        public IEmployees Employees
        {
            get
            {
                return (_employees);
            }
            set
            {
                _employees = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список стран
        /// </summary>
        public ICountries Countries
        {
            get
            {
                return (_countries);
            }
            set
            {
                _countries = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список регионов
        /// </summary>
        public IRegions Regions
        {
            get
            {
                return (_regions);
            }
            set
            {
                _regions = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список городов
        /// </summary>
        public ICities Cities
        {
            get
            {
                return (_cities);
            }
            set
            {
                _cities = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список улиц
        /// </summary>
        public IStreets Streets
        {
            get
            {
                return (_streets);
            }
            set
            {
                _streets = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список комплексов
        /// </summary>
        public IComplexes Complexes
        {
            get
            {
                return (_complexes);
            }
            set
            {
                _complexes = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список домов
        /// </summary>
        public IHomes Homes
        {
            get
            {
                return (_homes);
            }
            set
            {
                _homes = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир
        /// </summary>
        public IApartments Appartments
        {
            get
            {
                return (_appartments);
            }
            set
            {
                _appartments = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список объектов оценки
        /// </summary>
        public IObjects Objects
        {
            get
            {
                return (_objects);
            }
            set
            {
                _objects = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список компаний
        /// </summary>
        public ICompanies Companies
        {
            get
            {
                return (_companies);
            }
            set
            {
                _companies = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список картинок
        /// </summary>
        public IPictures Pictures
        {
            get
            {
                return (_pictures);
            }
            set
            {
                _pictures = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список отчетов
        /// </summary>
        public IReports Reports
        {
            get
            {
                return (_reports);
            }
            set
            {
                _reports = value;
            }
        }
    }
}
