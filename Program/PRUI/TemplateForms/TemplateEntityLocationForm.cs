using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;
using PRUI.Forms;

namespace PRUI.TemplateForms
{
    /// <summary>
    /// Форма. Шаблон формы для редактирования сущности определяющей расположение
    /// </summary>
    public partial class TemplateEntityLocationForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Страна
        /// </summary>
        protected ICountry _country;

        /// <summary>
        /// Поле. Регион
        /// </summary>
        protected IRegion _region;

        /// <summary>
        /// Поле. Город
        /// </summary>
        protected ICity _city;

        /// <summary>
        /// Поле. Улица
        /// </summary>
        protected IStreet _street;

        /// <summary>
        /// Поле. Комплекс
        /// </summary>
        protected IComplex _complex;

        /// <summary>
        /// Поле. Дом
        /// </summary>
        protected IHome _home;

        /// <summary>
        /// Поле. Список стран
        /// </summary>
        protected ICountries _countries;

        /// <summary>
        /// Поле. Список регионов
        /// </summary>
        protected IRegions _regions;

        /// <summary>
        /// Поле. Список городов
        /// </summary>
        protected ICities _cities;

        /// <summary>
        /// Поле. Список улиц
        /// </summary>
        protected IStreets _streets;

        /// <summary>
        /// Поле. Список комплексов
        /// </summary>
        protected IComplexes _complexes;

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        protected IHomes _homes;

  

        /// <summary>
        /// Поле. Страна после перепривязки
        /// </summary>
        protected  ICountry _countryAfterRelinking;

        /// <summary>
        /// Поле. Регион после перепривязки
        /// </summary>
        protected IRegion _regionAfterRelinking;

        /// <summary>
        /// Поле. Город после перепривязки
        /// </summary>
        protected ICity _cityAfterRelinking;

        /// <summary>
        /// Поле. Улица после перепривязки
        /// </summary>
        protected IStreet _streetAfterRelinking;

        /// <summary>
        /// Поле. Комплекс после перепривязки
        /// </summary>
        protected IComplex _complexAfterRelinking;

        /// <summary>
        /// Поле. Дом после перепривязки
        /// </summary>
        protected IHome _homeAfterRelinking;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает название страны
        /// </summary>
        protected string CountryName
        {
            get
            {
                return (countryNameTextBox.Text);
            }
            set
            {
                countryNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название региона
        /// </summary>
        protected string RegionName
        {
            get
            {
                return (regionNameTextBox.Text);
            }
            set
            {
                regionNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название города
        /// </summary>
        protected string CityName
        {
            get
            {
                return(cityNameTextBox.Text);
            }
            set
            {
                cityNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название улицы
        /// </summary>
        protected string StreetName
        {
            get
            {
                return(streetNameTextBox.Text);
            }
            set
            {
                streetNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер комплекса
        /// </summary>
        protected string ComplexNumber
        {
            get
            {
                return(complexNumberTextBox.Text);
            }
            set
            {
                complexNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер дома
        /// </summary>
        protected string HomeNumber
        {
            get
            {
                return(homeNumberTextBox.Text);
            }
            set
            {
                homeNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер дома по комплексу
        /// </summary>
        protected string HomeComplexNumber
        {
            get
            {
                return(homeComplexNumberTextBox.Text);
            }
            set
            {
                homeComplexNumberTextBox.Text = value;
            }
        }



        #endregion

        #region Constructors

        public TemplateEntityLocationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Clean

        /// <summary>
        /// Метод. Очищает все данные формы
        /// </summary>
        protected override void CleanAllData()
        {
            base.CleanAllData();        // Очистить все данные

            CleanCountryName();         // Очистить название страны
            CleanRegionName();          // Очистить название региона
            CleanCityName();            // Очистить название города
            CleanStreetName();          // Очистить название улицы
            CleanComplexNumber();       // Очистить номер комплекса
            CleanHomeNumber();          // Очистить номер дома
            CleanComplexNumber();       // Очистить номер дома по комплексу
           
        }

        /// <summary>
        /// Метод. Очищает название страны
        /// </summary>
        protected void CleanCountryName()
        {
            CountryName = "";       // Очистить название страны
        }

        /// <summary>
        /// Метод. Очищает название региона
        /// </summary>
        protected void CleanRegionName()
        {
            RegionName = "";        // Очистить название региона
        }

        /// <summary>
        /// Метод. Очищает название города
        /// </summary>
        protected void CleanCityName()
        {
            CityName = "";      // Очистить название города
        }

        /// <summary>
        /// Метод. Очищает название улицы
        /// </summary>
        protected void CleanStreetName()
        {
            StreetName = "";        // Очистить название улицы
        }

        /// <summary>
        /// Метод. Очищает номер комплекса
        /// </summary>
        protected void CleanComplexNumber()
        {
            ComplexNumber = "";     // Очистить номер комплекса
        }

        /// <summary>
        /// Метод. Очищает номер дома
        /// </summary>
        protected void CleanHomeNumber()
        {
            HomeNumber = "";        // Очистить номер дома
        }

        /// <summary>
        /// Метод. Очищает номер дома по комплексу
        /// </summary>
        protected void CleanHomeComplexNumber()
        {
            HomeComplexNumber = "";     // Очистить номер дома по комплексу
        }

 
           

        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью 
        /// </summary>
        protected virtual void CopyLinkedDataFromEntity()
        {
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты страны
        /// </summary>
        protected void CopyCountryFromEntity(ICountry country)
        {
            CountryName = country.Name;     // Скопировать название страны
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты региона
        /// </summary>
        protected void CopyRegionFromEntity(IRegion region)
        {
            RegionName = region.Name;       // Скопировать название региона
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты города
        /// </summary>
        protected void CopyCityFromEntity(ICity city)
        {
            CityName = city.Name;       // Скопировать название города
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты улицы
        /// </summary>
        protected void CopyStreetFromEntity(IStreet street)
        {
            StreetName = street.Name;       // Скопировать название улицы
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты комлекса
        /// </summary>
        protected void CopyComplexFromEntity(IComplex complex)
        {
            ComplexNumber = Convert.ToString(complex.Number);       // Скопировать номер комплекса
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты дома
        /// </summary>
        protected void CopyHomeFromEntity(IHome home)
        {
            HomeNumber = home.Number;                   // Скопировать номер дома
            HomeComplexNumber = home.ComplexNumber;     // Скопировать номер дома по комплексу


        }

        #endregion

        #region Controls Event Handlers

        #region Click

        /// <summary>
        /// Метод. Связывает регион с выбранной страной
        /// </summary>
        private void relinkCountryButton_Click(object sender, EventArgs e)
        {
            CountrySelectForm countrySelectForm;                                // Форма выбора страны

            countrySelectForm = new CountrySelectForm(_countries);              // Создать форму выбора страны

            countrySelectForm.ShowDialog();                                     // Отобразить форму выбора страны

            if (countrySelectForm.SelectedCountry != null)                      // Проверить выбранную страну
            {
                _countryAfterRelinking = countrySelectForm.SelectedCountry;     // Сохранить выбранную страну в поле
            }

            CopyLinkedDataFromEntity();                                         // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает регион от связанной страны
        /// </summary>
        private void unlinkCountryButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать страну?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _countryAfterRelinking = null;                  // Отвязать регион от связанной страны

                CleanCountryName();                             // Очистить название страны

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Связывает город с выбранным регионом
        /// </summary>
        private void relinkRegionButton_Click(object sender, EventArgs e)
        {
            RegionSelectForm  regionSelectForm;                                 // Форма выбора региона

            regionSelectForm = new RegionSelectForm(_regions);                  // Создать форму выбора региона

            regionSelectForm.ShowDialog();                                      // Отобразить форму выбора региона

            if (regionSelectForm.SelectedRegion != null)                        // Проверить выбранный регион
            {
                _regionAfterRelinking = regionSelectForm.SelectedRegion;        // Сохранить выбранный регион в поле
            }

            CopyLinkedDataFromEntity();                                         // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает город от связанного региона
        /// </summary>
        private void unlinkRegionButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать регион?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _regionAfterRelinking = null;                   // Отвязать город от связанного региона

                CleanCountryName();                             // Очистить название страны
                CleanRegionName();                              // Очистить название региона

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Связывает улицу или комплекс с выбранной улицей
        /// </summary>
        private void relinkCityButton_Click(object sender, EventArgs e)
        {
            CitySelectForm  citySelectForm;                             // Форма выбора города

            citySelectForm = new CitySelectForm(_cities);               // Создать форму выбора города

            citySelectForm.ShowDialog();                                // Отобразить форму выбора города

            if (citySelectForm.SelectedCity != null)                    // Проверить выбранный город
            {
                _cityAfterRelinking = citySelectForm.SelectedCity;      // Сохранить выбранный город в поле
            }

            CopyLinkedDataFromEntity();                                 // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает улицу или комплекс от связанного города
        /// </summary>
        private void unlinkCityButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать город?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _cityAfterRelinking = null;                     // Отвязать улицу или комплекс от связанного города

                CleanCountryName();                             // Очистить название страны
                CleanRegionName();                              // Очистить название региона
                CleanCityName();                                // Очистить название города

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Связывает дом с выбранной улицей
        /// </summary>
        private void relinkStreetButton_Click(object sender, EventArgs e)
        {
            StreetSelectForm streetSelectForm;                              // Форма выбора улицы

            streetSelectForm = new StreetSelectForm(_streets);              // Создать форму выбора улицы

            streetSelectForm.ShowDialog();                                  // Отобразить форму выбора улицы

            if (streetSelectForm.SelectedStreet != null)                    // Проверить выбранную улицу
            {
                _streetAfterRelinking = streetSelectForm.SelectedStreet;    // Сохранить выбранную улицу в поле
            }

            CopyLinkedDataFromEntity();                                     // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает дом от связанной улицы
        /// </summary>
        private void unlinkStreetButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать улицу?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _streetAfterRelinking = null;                   // Отвязать дом от связанной улицы

                CleanCountryName();                             // Очистить название страны
                CleanRegionName();                              // Очистить название региона
                CleanCityName();                                // Очистить название города
                CleanStreetName();                              // Очистить название улицы

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        /// <summary>
        /// Метод. Связывает дом с выбранным комплексом
        /// </summary>
        private void relinkComplexButton_Click(object sender, EventArgs e)
        {
            ComplexSelectForm complexSelectForm;                                // Форма выбора комплекса

            complexSelectForm = new ComplexSelectForm(_complexes);              // Создать форму выбора комплекса

            complexSelectForm.ShowDialog();                                     // Отобразить форму выбора комплекса

            if (complexSelectForm.SelectedComplex != null)                      // Проверить выбранный комплекс
            {
                _complexAfterRelinking = complexSelectForm.SelectedComplex;     // Сохранить выбранный комплекс в поле
            }

            CopyLinkedDataFromEntity();                                         // Скопировать данные из сущностей, связанных с основной сущностью 

        }

        /// <summary>
        /// Метод. Отвязывает дом от связанного комплекса
        /// </summary>
        private void unlinkComplexButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                             // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                        // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать комплекс?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)                  // Проверить результат подтверждения сообщения
            {
                _complexAfterRelinking = null;                      // Отвязать дом от связанного комплекса

                CleanCountryName();                                 // Очистить название страны
                CleanRegionName();                                  // Очистить название региона
                CleanCityName();                                    // Очистить название города
                CleanComplexNumber();                               // Очистить название комплекса

                CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        #endregion

        #endregion

        #region DataValidation

        #region CountryNameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void countryNameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void countryNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region RegionNameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void regionNameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void regionNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region CityNameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void cityNameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void cityNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region StreetNameTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void streetNameTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void streetNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region ComplexNumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void complexNumberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void complexNumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region HomeNumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        protected void homeNumberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        protected void homeNumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region HomeComplexNumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        protected void homeComplexNumberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        protected void homeComplexNumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsNotEmpty(((TextBox)sender).Text));     // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #endregion

        /// <summary>
        /// Метод. Задает активность компонентов
        /// </summary>
        protected virtual void SetButtonActivity()
        {
            unlinkCountryButton.Enabled = (_countryAfterRelinking == null) ? false : true;
            unlinkRegionButton.Enabled = (_regionAfterRelinking == null) ? false : true;
            unlinkCityButton.Enabled = (_cityAfterRelinking == null) ? false : true;
            unlinkStreetButton.Enabled = (_streetAfterRelinking == null) ? false : true;
            unlinkComplexButton.Enabled = (_complexAfterRelinking == null) ? false : true;
        }

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
    }
}
