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
    /// Форма. Форма редактирования города
    /// </summary>
    public partial class CityForm : TemplateEntityLocationForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public CityForm(ICity city, IRegions regions)
        {
            InitializeComponent();                      // Инициализировать компоненты формы

            _city = city;                               // Сохранить город в поле
            _regions = regions;                         // Сохранить список регионов в поле

            _regionAfterRelinking = city.Region;        // Сохранить регион, связанный с городом

            CleanAllData();                             // Очистить все данные формы

            CopyDataFromEntity();                       // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Копирует данные города в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_city);               // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_city);      // Скопировать описание
            CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyCityFromEntity(_city);                      // Скопировать данные города 
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            if (_regionAfterRelinking != null)                                  // Проверить регион, связанный с городом
            {
                if (_regionAfterRelinking.Country != null)                      // Проверить страну, связанную с регионом
                {
                    CopyCountryFromEntity(_regionAfterRelinking.Country);       // Скопировать данные страны
                }
                CopyRegionFromEntity(_regionAfterRelinking);                    // Скопировать данные региона
            }

            SetButtonActivity();                                                // Задать активность компонентов
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_city).Description = Description;     // Скопировать описание

            _city.Region = _regionAfterRelinking;           // Скопировать регион после перепривязки

            _city.Name = CityName;                          // Скопировать название города
        }

        #endregion
    }
}
