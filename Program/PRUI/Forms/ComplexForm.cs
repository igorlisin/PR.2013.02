using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования комлпекса
    /// </summary>
    public partial class ComplexForm : TemplateEntityLocationForm
    {
        #region Fields
        /// <summary>
        /// Поле. Локальные особенности 1
        /// </summary>
        private string _local1;

        /// <summary>
        /// Поле. Локальные особенности 1
        /// </summary>
        private string _local2;

        /// <summary>
        /// Поле. Название ближайшей остановки
        /// </summary>
        private string _closestStop;

        /// <summary>
        /// Поле. Наличие паркинга
        /// </summary>
        private bool _parking;

        /// <summary>
        /// Поле. Список банков
        /// </summary>
        private string _banks;

        /// <summary>
        /// Поле. Список больниц
        /// </summary>
        private string _hospitals;

        /// <summary>
        /// Поле. Список дет садов
        /// </summary>
        private string _kinders;

        /// <summary>
        /// Поле. Список мест отдыха
        /// </summary>
        private string _restPlaces;

        /// <summary>
        /// Поле. Список Школ
        /// </summary>
        private string _schools;

        /// <summary>
        /// Поле. Список предприятий быта
        /// </summary>
        private string _services;

        /// <summary>
        /// Поле. Список объектов торговли
        /// </summary>
        private string _tradings;

        /// <summary>
        /// Поле. Список аптек
        /// </summary>
        private string _pharmacy;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности 1
        /// </summary>
        protected string Local1
        {
            get
            {
                return (Local1TextBox.Text);
            }
            set
            {
                Local1TextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает локальные особенности 2
        /// </summary>
        protected string Local2
        {
            get
            {
                return (Local2TextBox.Text);
            }
            set
            {
                Local2TextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список банков
        /// </summary>
        public string Banks
        {
            get
            {
                return (BanksTextBox.Text);
            }
            set
            {
                BanksTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список больниц
        /// </summary>
        public string Hospitals
        {
            get
            {
                return (HospitalsTextBox.Text);
            }
            set
            {
                HospitalsTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список дет садов
        /// </summary>
        public string Kinders
        {
            get
            {
                return (KindersTextBox.Text);
            }
            set
            {
                KindersTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список мест отдыха
        /// </summary>
        public string RestPlaces
        {
            get
            {
                return (RestPlacesTextBox.Text);
            }
            set
            {
                RestPlacesTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список школ
        /// </summary>
        public string Schools
        {
            get
            {
                return (SchoolsTextBox.Text);
            }
            set
            {
                SchoolsTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список предприятий быта
        /// </summary>
        public string Services
        {
            get
            {
                return (ServicesTextBox.Text);
            }
            set
            {
                ServicesTextBox.Text = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает список объектов торговли
        /// </summary>
        public string Tradings
        {
            get
            {
                return (TradingsTextBox.Text);
            }
            set
            {
                TradingsTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список объектов торговли
        /// </summary>
        public string Pharmacy
        {
            get
            {
                return (PharmacyTextBox.Text);
            }
            set
            {
                PharmacyTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ComplexForm(IComplex complex, ICities cities)
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _complex = complex;                     // Сохранить комплекс в поле
            _cities = cities;                       // Сохранить список городов в поле

            _cityAfterRelinking = complex.City;     // Сохранить город, связанный с комплексом

            CleanAllData();                         // Очистить все данные формы
            CleanLocData();
            CopyDataFromEntity();                   // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Очищает характеристики дома 
        /// </summary>
        protected void CleanLocData()
        {
            Local1 = "";
            Local2 = "";
            Banks = "";
            Hospitals = "";
            Kinders = "";
            RestPlaces = "";
            Schools = "";
            Services = "";
            Tradings = "";
            Pharmacy = "";
        }

        /// <summary>
        /// Метод. Копирует данные комплекса в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_complex);                // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_complex);       // Скопировать описание
            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyComplexFromEntity(_complex);                    // Скопировать данные комплекса 
            CopyLocDataFromEntity();
        }

        /// <summary>
        /// Метод. Копирует данные о доме в компоненты
        /// </summary>
        protected void CopyLocDataFromEntity()
        {
            Local1 = _complex.Loacals_1;                       // Скопировать локальные особенности 1
            Local2 = _complex.Loacals_2;                       // Скопировать локальные особенности 2
            Banks = _complex.Banks;
            Hospitals = _complex.Hospitals;
            Kinders = _complex.Kinders;
            RestPlaces = _complex.RestPlaces;
            Services = _complex.Services;
            Schools = _complex.Schools;
            Tradings = _complex.Tradings;
            Pharmacy = _complex.PharmList;
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            IRegion region;                                         // Регион, связанный с городом

            if (_cityAfterRelinking != null)                        // Проверить город, связанный с комплексом
            {
                if (_cityAfterRelinking.Region != null)             // Проверить регион, связанный с городом
                {
                    region = _cityAfterRelinking.Region;            // Получить регион, связанный с городом

                    if (region.Country != null)                     // Проверить регион, связанный с городом
                    {
                        CopyCountryFromEntity(region.Country);      // Скопировать данные страны
                    }
                    CopyRegionFromEntity(region);                   // Скопировать данные региона
                }
                CopyCityFromEntity(_cityAfterRelinking);            // Скопировать данные города
            }

            SetButtonActivity();                                    // Задать активность компонентов
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_complex).Description = Description;          // Скопировать описание

            _complex.City = _cityAfterRelinking;                    // Скопировать город после перепривязки

            _complex.Number = Convert.ToInt32(ComplexNumber);       // Скопировать номер комплекса

            _complex.Loacals_1 = Local1;                                   // Скопировать локальные особенности 1
            _complex.Loacals_2 = Local2;                                   // Скопировать локальные особенности 2
            _complex.Banks = Banks;
            _complex.Hospitals = Hospitals;
            _complex.Kinders = Kinders;
            _complex.RestPlaces = RestPlaces;
            _complex.Schools = Schools;
            _complex.Services = Services;
            _complex.Tradings = Tradings;
            _complex.PharmList = Pharmacy;
        }

        #endregion
    }
}
