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
    /// Форма. Форма редактирования улицы
    /// </summary>
    public partial class StreetForm : TemplateEntityLocationForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public StreetForm(IStreet street, ICities cities)
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _street = street;                       // Сохранить улицу в поле
            _cities = cities;                       // Сохранить список городов в поле

            _cityAfterRelinking = street.City;      // Сохранить город, связанный с улицой

            CleanAllData();                         // Очистить все данные формы

            CopyDataFromEntity();                   // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        #region Copy

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_street);                 // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_street);        // Скопировать описание
            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyStreetFromEntity(_street);                      // Скопировать данные улицы 
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
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_street).Description = Description;       // Скопировать описание

            _street.City = _cityAfterRelinking;                 // Скопировать город после перепривязки

            _street.Name = StreetName;                          // Скопировать название улицы
        }

        #endregion

        #endregion
    }
}
