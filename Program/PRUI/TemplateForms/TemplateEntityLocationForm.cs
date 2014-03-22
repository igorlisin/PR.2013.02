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
        /// Поле. Год постройки
        /// </summary>
        protected int _buildYear;

        /// <summary>
        /// Поле. Состояние крыши
        /// </summary>
        protected Condition _roofCondition;

        /// <summary>
        /// Поле. Материал несущих стен
        /// </summary>
        protected MaterialType _outsideWall;

        /// <summary>
        /// Поле. материал перегородок
        /// </summary>
        protected MaterialType _insideWall;


        /// <summary>
        /// Поле. Наличие лифта
        /// </summary>
        protected bool _lift;


        /// <summary>
        /// Поле. год последнего капремонта
        /// </summary>
        protected string _kapremontYear;


        /// <summary>
        /// Поле. Периодичность капремонта
        /// </summary>
        protected string _kapremontPeriod;


        /// <summary>
        /// Поле. Наличие дефектов конструкции
        /// </summary>
        protected bool _defects;


        /// <summary>
        /// Поле. Наличие мусоропровода
        /// </summary>
        protected bool _garbadge;


        /// <summary>
        /// Поле. Наличие доп факторов
        /// </summary>
        protected string _extraFactors;


        /// <summary>
        /// Поле. Наличие консьержа
        /// </summary>
        protected bool _conserge;


        /// <summary>
        /// Поле. Тип перекрытий
        /// </summary>
        protected MaterialType _ceilingType;


        /// <summary>
        /// Поле. Состояние перекрытий
        /// </summary>
        protected Condition _ceilingCondition;


        /// <summary>
        /// Поле. Фундамент
        /// </summary>
        protected string _basement;


        /// <summary>
        /// Поле. Износ фундамента
        /// </summary>
        protected string _basementWear;


        /// <summary>
        /// Поле. наличие чердака
        /// </summary>
        protected bool _attic;


        /// <summary>
        /// Поле. Рассотяние до промзоны
        /// </summary>
        protected string _PromzoneDistance;


        /// <summary>
        /// Поле. Расстояние до остановок 
        /// </summary>
        protected string _stopDistance;


        /// <summary>
        /// Поле. Социальный состав жильцов
        /// </summary>
        protected string _social;


        /// <summary>
        /// Поле. Общественный транспорт
        /// </summary>
        protected string _transport;


        /// <summary>
        /// Поле. Наличие газа
        /// </summary>
        protected bool _gaz;

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

        /// <summary>
        /// Свойство. Задает и возвращает год постройки дома
        /// </summary>
        protected int BuildYear
        {
            get
            {
                return (Convert.ToInt32(BuildYearTextBox.Text));
            }
            set
            {
                BuildYearTextBox.Text = Convert.ToString(value);
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает состояние крыши
        /// </summary>
        //protected Condition RoofCondition
        //{
        //    get
        //    {
        //        return (((KeyValuePair<Condition, string>)RoofConditionComboBox.SelectedItem).Key);
        //    }
        //    set
        //    {
        //        SetComboBoxElementByType<Condition>(RoofConditionComboBox, value);
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает тип несущих стен дома
        /// </summary>
        //protected MaterialType OutsideWall
        //{
        //    get
        //    {
        //        return _outsideWall;
        //    }
        //    set
        //    {
        //        _outsideWall = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает перегородорк дома
        /// </summary>
        //protected MaterialType InsideWall
        //{
        //    get
        //    {
        //        return _insideWall;
        //    }
        //    set
        //    {
        //        _insideWall = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает наличие лифта
        /// </summary>
        protected bool Lift
        {
            get
            {
                return (LiftCheckBox.Checked);
            }
            set
            {
                LiftCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает год последнего капремонта
        /// </summary>
        protected string KapremontYear
        {
            get
            {
                return (KapremontYearTextBox.Text);
            }
            set
            {
                KapremontYearTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает периодичность капремонта
        /// </summary>
        protected string KapremontPeriod
        {
            get
            {
                return (KapremontPeriodTextBox.Text);
            }
            set
            {
                KapremontPeriodTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличия дефектов здания
        /// </summary>
        protected bool Defects
        {
            get
            {
                return (DefectsCheckBox.Checked);
            }
            set
            {
                DefectsCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие мусоропровода
        /// </summary>
        protected bool Garbadge
        {
            get
            {
                return (GarbageCheckBox.Checked);
            }
            set
            {
                GarbageCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дополнительных факторов
        /// </summary>
        protected string ExtraFactors
        {
            get
            {
                return (ExtraFactorsTextBox.Text);
            }
            set
            {
                ExtraFactorsTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие консьержа
        /// </summary>
        protected bool Conserge
        {
            get
            {
                return (ConcergeCheckBox.Checked);
            }
            set
            {
                ConcergeCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип перекрытий
        /// </summary>
        //protected MaterialType CeilingType
        //{
        //    get
        //    {
        //        return _ceilingType;
        //    }
        //    set
        //    {
        //        _ceilingType = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает состояние перекрытий
        /// </summary>
        //protected Condition CeilingCondition
        //{
        //    get
        //    {
        //        return _ceilingCondition;
        //    }
        //    set
        //    {
        //        _ceilingCondition = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает фундамент
        /// </summary>
        protected string Basement
        {
            get
            {
                return (BasementTextBox.Text);
            }
            set
            {
                BasementTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает износ фундамента
        /// </summary>
        protected string BasementWear
        {
            get
            {
                return (BasmentWearTextBox.Text);
            }
            set
            {
                BasmentWearTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие чердака
        /// </summary>
        protected bool Attic
        {
            get
            {
                return (AtticCheckBox.Checked);
            }
            set
            {
                AtticCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает расстояние от промзоны
        /// </summary>
        protected string PromzoneDistance
        {
            get
            {
                return (PromDistanceTextBox.Text);
            }
            set
            {
                PromDistanceTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает расстояние от остановки
        /// </summary>
        protected string StopDistance
        {
            get
            {
                return (StopDistanceTextBox.Text);
            }
            set
            {
                StopDistanceTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает соц слой жильцов
        /// </summary>
        protected string Social
        {
            get
            {
                return (SocialTextBox.Text);
            }
            set
            {
                SocialTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает общественный транспорт
        /// </summary>
        //protected string Transport
        //{
        //    get
        //    {
        //        return (TramwayCheckBox.Checked?"Трамвай и автобус":"Автобус");
        //    }
        //    set
        //    {
        //        _transport = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Задает и возвращает наличие газа
        /// </summary>
        protected bool Gaz
        {
            get
            {
                return (GazCheckBox.Checked);
            }
            set
            {
                GazCheckBox.Checked = value;
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
    }
}
