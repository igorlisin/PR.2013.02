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
    /// Форма. Форма редактирования дома
    /// </summary>
    public partial class HomeForm : TemplateEntityLocationForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public HomeForm(IHome home, IStreets streets, IComplexes complexes)
        {
            InitializeComponent();                      // Инициализировать компоненты формы

            _home = home;                               // Сохранить дом в поле
            _streets = streets;                         // Сохранить список улиц в поле
            _complexes = complexes;                     // Сохранить список комплексов в поле

            _streetAfterRelinking = home.Street;        // Сохранить улицу, связанную с домом в поле
            _complexAfterRelinking = home.Complex;      // Сохранить комплекс, связанный с домом в поле

            CleanAllData();                             // Очистить все данные формы

            CopyDataFromEntity();                       // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods

        #region Copy

        /// <summary>
        /// Метод. Копирует данные в компоненты
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_home);               // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_home);      // Скопировать описание
            CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyHomeFromEntity(_home);                      // Скопировать данные дома
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            ICity city;                                                     // Город, связанный с улицей

            if (_streetAfterRelinking != null)                              // Проверить улицу, связанную с домом
            {
                if (_streetAfterRelinking.City != null)                     // Проверить город, связанный с улицей
                {
                    city = _streetAfterRelinking.City;                       // Получить город, связанный с улицей

                    if (city.Region != null)                                // Проверить регион, связанный с городом
                    {
                        if (city.Region.Country != null)                    // Проверить страну, связанную с регионом
                        {
                            CopyCountryFromEntity(city.Region.Country);     // Скопировать данные страны
                        }
                        CopyRegionFromEntity(city.Region);                  // Скопировать данные региона
                    }
                    CopyCityFromEntity(city);                               // Скопировать данные города
                }
                CopyStreetFromEntity(_streetAfterRelinking);                // Скопировать данные улицы
            }

            if (_complexAfterRelinking != null)                             // Проверить комплекс, связанный с домом
            {
                CopyComplexFromEntity(_complexAfterRelinking);              // Скопировать данные комплекса
            }

            FindDiscrepancy();                                              // Проверить соотвествие города, связанного с улицей и города связанного с комплексом, если это разные города вывести сообщение

            SetButtonActivity();                                            // Задать активность компонентов
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_home).Description = descriptionTextBox.Text;     // Скопировать описание

            _home.Street = _streetAfterRelinking;                       // Скопировать улицу после перепривязки
            _home.Complex = _complexAfterRelinking;                     // Скопировать комплекс после перепривязки

            _home.Number = homeNumberTextBox.Text;                      // Скопировать номер дома
            _home.ComplexNumber = homeComplexNumberTextBox.Text;        // Скопировать номер дома по комплексу
        }

        #endregion

        /// <summary>
        /// Метод. Сравнивает город, связанный с улицей и город связанный с комплексом, если это разные города, то выводит сообщение в поле "Примечание"
        /// </summary>
        private void FindDiscrepancy()
        {
            if ((_streetAfterRelinking != null) && (_complexAfterRelinking != null))        // Проверить улицу и комплекс, связанные с домом
            {
                if (_streetAfterRelinking.City != _complexAfterRelinking.City)              // Проверить является ли город, связанный с улицой и город, связанный с комплексом одним и тем же городом
                {
                    Note = "Ошибка: улица и комплекс расположены в разных городах";         // Вывести сообщение в поле "Примечание"
                }
            }
        }

        #endregion
    }
}
