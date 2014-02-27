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
    /// Форма. Форма редактирования региона
    /// </summary>
    public partial class RegionForm: TemplateEntityLocationForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public RegionForm(IRegion region, ICountries countries)
        {
            InitializeComponent();                          // Инициализировать компоненты формы

            _region = region;                               // Сохранить регион в поле
            _countries = countries;                         // Сохранить список стран в поле

            _countryAfterRelinking = region.Country;        // Сохранить страну, связанную с регионом

            CleanAllData();                                 // Очистить все данные формы

            CopyDataFromEntity();                           // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Копирует данные региона в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_region);                 // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_region);        // Скопировать описание
            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyRegionFromEntity(_region);                      // Скопировать данные региона 
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            if (_countryAfterRelinking  != null)                    // Проверить страну, связанную с регионом
            {
                CopyCountryFromEntity(_countryAfterRelinking);      // Скопировать данные страны
            }

            SetButtonActivity();                                    // Задать активность компонентов
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_region).Description = Description;       // Скопировать описание

            _region.Country  = _countryAfterRelinking;          // Скопировать страну после перепривязки

            _region.Name = RegionName;                          // Скопировать название региона
        }

        #endregion
    }
}
