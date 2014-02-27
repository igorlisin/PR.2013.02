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

            CopyDataFromEntity();                   // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Копирует данные комплекса в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_complex);                // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_complex);       // Скопировать описание
            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyComplexFromEntity(_complex);                    // Скопировать данные комплекса 
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
        }

        #endregion
    }
}
