using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    public partial class DistrictForm : TemplateEntityLocationForm
    {
        #region Fields

        /// <summary>
        /// Поле. Название района
        /// </summary>
        private string _name;

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
        /// Поле. Престижность района
        /// </summary>
        private Prestiges _prestige;

        /// <summary>
        /// Поле. Район
        /// </summary>
        private IDistrict _district;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает название
        /// </summary>
        public string Name
        {
            get
            {
                return (DistrictNameTextBox.Text);
            }
            set
            {
                DistrictNameTextBox.Text = value;
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
        /// Свойство. Задает и возвращает престижность района
        /// </summary>
        public Prestiges Prestige
        {
            get
            {
                return (((KeyValuePair<Prestiges, string>)PrestigeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<Prestiges>(PrestigeComboBox, value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DistrictForm(IDistrict district, ICities cities)
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _district = district;                       // Сохранить район в поле
            _cities = cities;                       // Сохранить список городов в поле

            _cityAfterRelinking = district.City;      // Сохранить город, связанный с районом

            CleanAllData();                         // Очистить компоненты всех групп

            CopyDataFromEntity();                   // Скопировать данные района в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Очищает все данные формы
        /// </summary>
        protected override void CleanAllData()
        {
            base.CleanAllData();        // Очистить все данные

            CleanDistrict();           // Очистить данные района
        }

               /// <summary>
        /// Метод. Очищает данные района
        /// </summary>
        private void CleanDistrict()
        {
            Name = "";
            Banks = "";
            Hospitals = "";
            Kinders = "";
            RestPlaces = "";
            Schools = "";
            Services = "";
            Tradings = "";
            ClearPrestigeList();
            FillPrestigeList();
        }                 

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_district);                 // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_district);        // Скопировать описание

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyDistrictFromEntity(_district);                             // Скопировать данные района
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            IRegion region;                                         // Регион, связанный с городом

            if (_cityAfterRelinking != null)                        // Проверить город, связанный с улицей
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
        /// Метод. Копирует данные сущности в компоненты раойна
        /// </summary>
        private void CopyDistrictFromEntity(IDistrict district)
        {
            Name = district.Name;
            Banks = district.Banks;
            Hospitals = district.Hospitals;
            Kinders = district.Kinders;
            RestPlaces = district.RestPlaces;
            Schools = district.Schools;
            Services = district.Services;
            Tradings = district.Tradings;
            Prestige = district.Prestige;
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_district).Description = Description;       // Скопировать описание

            _district.Name = Name;
            _district.Banks = Banks;
            _district.Hospitals = Hospitals;
            _district.Kinders = Kinders;
            _district.RestPlaces = RestPlaces;
            _district.Schools = Schools;
            _district.Services = Services;
            _district.Tradings = Tradings;
            _district.Prestige = Prestige;

        }

        #endregion

        #endregion

        #region Template methods

        /// <summary>
        /// Шаблонный метод. Выбирает элемент в списке
        /// </summary>
        protected void SetComboBoxElementByType<T>(ComboBox comboBox, T value)
        {
            int count;                                                                          // Количество элементов в списке
            int counter;                                                                        // Счетчик циклов

            T currentElement;                                                                   // Ключ текущего элемента списка

            count = comboBox.Items.Count;                                                       // Получить количество элементов в списке

            for (counter = 0; counter < count; counter++)                                       // Выполнить для всех элементов списка
            {
                KeyValuePair<T, string> keyValuePair;                                           // Пара ключ-значение для текущего элемента списка

                keyValuePair = (KeyValuePair<T, string>)comboBox.Items[counter];                // Получить пару ключ значение для текущего элемента списка

                currentElement = keyValuePair.Key;                                              // Получить значение ключа из пары ключ-значение

                if (currentElement.ToString() == value.ToString())                              // Сравнить значение ключа элемента списка и заданного параметра (обе переменные имеют тип "T", приведение к строковому формату необходимо, так как сравнени "T == T" приводит к ошибке)
                {
                    comboBox.SelectedIndex = counter;                                           // Задать индекс выделенного элемента
                    break;
                }
            }
        }

        #endregion

        #region Prestige list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearPrestigeList()
        {
            PrestigeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddPrestigeToList(Prestiges Prestige, string prestigeDescription)
        {
            PrestigeComboBox.Items.Add(new KeyValuePair<Prestiges, string>(Prestige, prestigeDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetPrestigeDisplayMember(string typeMember)
        {
            PrestigeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillPrestigeList()
        {
            foreach (Prestiges prestigeType in Enum.GetValues(typeof(Prestiges)))               // Выполнить для всех элементов перечисления
            {
                AddPrestigeToList(prestigeType, _district.GetPrestigeAsString(prestigeType));      // Добавить элемент в список
            }

            SetPrestigeDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion
    }
}
