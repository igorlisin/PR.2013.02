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
    /// Форма. Форма редактирования страны
    /// </summary>
    public partial class CountryForm : TemplateEntityLocationForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CountryForm(ICountry country)
        {
            InitializeComponent();      // Инициализировать компоненты формы

            _country = country;         // Сохранить страну в поле

            CleanAllData();             // Очистить все данные формы

            CopyDataFromEntity();       // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Копирует данные страны в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_country);                // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_country);       // Скопировать описание
            CopyCountryFromEntity(_country);                    // Скопировать данные страны 
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_country).Description = Description;       // Скопировать описание

            _country.Name = CountryName;                        // Скопировать название страны
        }

        #endregion
    }
}
