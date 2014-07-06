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
        #region Fields

        /// <summary>
        /// Поле. Год постройки
        /// </summary>
        private int _buildYear;

        /// <summary>
        /// Поле. Состояние крыши
        /// </summary>
        private Condition _roofCondition;

        /// <summary>
        /// Поле. Материал несущих стен
        /// </summary>
        private MaterialType _outsideWall;

        /// <summary>
        /// Поле. материал перегородок
        /// </summary>
        private MaterialType _insideWall;


        /// <summary>
        /// Поле. Наличие лифта
        /// </summary>
        private bool _lift;


        /// <summary>
        /// Поле. год последнего капремонта
        /// </summary>
        private string _kapremontYear;


        /// <summary>
        /// Поле. Периодичность капремонта
        /// </summary>
        private string _kapremontPeriod;


        /// <summary>
        /// Поле. Наличие дефектов конструкции
        /// </summary>
        private bool _defects;


        /// <summary>
        /// Поле. Наличие мусоропровода
        /// </summary>
        private bool _garbadge;


        /// <summary>
        /// Поле. Наличие доп факторов
        /// </summary>
        private string _extraFactors;


        /// <summary>
        /// Поле. Наличие консьержа
        /// </summary>
        private bool _conserge;

        /// <summary>
        /// Поле. Тип перекрытий
        /// </summary>
        private MaterialType _ceilingType;


        /// <summary>
        /// Поле. Состояние перекрытий
        /// </summary>
        private Condition _ceilingCondition;


        /// <summary>
        /// Поле. Фундамент
        /// </summary>
        private string _basement;


        /// <summary>
        /// Поле. Износ фундамента
        /// </summary>
        private string _basementWear;


        /// <summary>
        /// Поле. наличие чердака
        /// </summary>
        private bool _attic;


        /// <summary>
        /// Поле. Рассотяние до промзоны
        /// </summary>
        private string _PromzoneDistance;


        /// <summary>
        /// Поле. Расстояние до остановок 
        /// </summary>
        private string _stopDistance;


        /// <summary>
        /// Поле. Социальный состав жильцов
        /// </summary>
        private string _social;


        /// <summary>
        /// Поле. Общественный транспорт
        /// </summary>
        private bool _transport;


        /// <summary>
        /// Поле. Наличие газа
        /// </summary>
        private bool _gaz;

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


        #endregion

        #region Properties
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
        protected Condition RoofCondition
        {
            get
            {
                return (((KeyValuePair<Condition, string>)RoofConditionComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<Condition>(RoofConditionComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип несущих стен дома
        /// </summary>
        protected MaterialType OutsideWall
        {
            get
            {
                return (((KeyValuePair<MaterialType, string>)MainWallTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<MaterialType>(MainWallTypeComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает перегородорк дома
        /// </summary>
        protected MaterialType InsideWall
        {
            get
            {
                return (((KeyValuePair<MaterialType, string>)RoomWallTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<MaterialType>(RoomWallTypeComboBox, value);
            }
        }

        ///// <summary>
        ///// Свойство. Задает и возвращает состояние стен
        ///// </summary>
        //protected Condition WallCondition
        //{
        //    get
        //    {
        //        return (((KeyValuePair<Condition, string>)WallConditionComboBox.SelectedItem).Key);
        //    }
        //    set
        //    {
        //        SetComboBoxElementByType<Condition>(WallConditionComboBox, value);
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
        protected MaterialType CeilingType
        {
            get
            {
                return (((KeyValuePair<MaterialType, string>)CeilingTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<MaterialType>(CeilingTypeComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние перекрытий
        /// </summary>
        protected Condition CeilingCondition
        {
            get
            {
                return (((KeyValuePair<Condition, string>)CeilingConditionComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<Condition>(CeilingConditionComboBox, value);
            }
        }

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
        protected bool Transport
        {
            get
            {
                return (TramwayCheckBox.Checked);
            }
            set
            {
                TramwayCheckBox.Checked = value;
            }
        }

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

        /// <summary>
        /// Свойство. Задает и возвращает паркинга
        /// </summary>
        protected bool Parking
        {
            get
            {
                return (ParkingCheckBox.Checked);
            }
            set
            {
                ParkingCheckBox.Checked = value;
            }
        }

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
        /// Свойство. Задает и возвращает название ближайшей остановки
        /// </summary>
        protected string ClosestStop
        {
            get
            {
                return (ClosestStopTextBox.Text);
            }
            set
            {
                ClosestStopTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public HomeForm(IHome home, IStreets streets, IComplexes complexes, IDistricts  districts)
        {
            InitializeComponent();                      // Инициализировать компоненты формы

            _home = home;                               // Сохранить дом в поле
            _streets = streets;                         // Сохранить список улиц в поле
            _complexes = complexes;                     // Сохранить список комплексов в поле
            _districts = districts;

            _streetAfterRelinking = home.Street;        // Сохранить улицу, связанную с домом в поле
            _complexAfterRelinking = home.Complex;      // Сохранить комплекс, связанный с домом в поле
            _districtAfterRelinking = home.District;    // Сохранить район, связанную с домом в поле

            CleanAllData();                             // Очистить все данные формы
            CleanLocationData();                        // Очистить данные характеристик дома
            CopyDataFromEntity();                       // Скопировать данные из сущности в компоненты формы
        }

        #endregion

        #region Methods
        #region Clean
        /// <summary>
        /// Метод. Очищает характеристики дома 
        /// </summary>
        protected void CleanLocationData()
        {
            BuildYear = 1900;
            Lift = false;
            KapremontYear = "";
            KapremontPeriod = "";
            Defects = false;
            Garbadge = false;
            ExtraFactors = "";
            Conserge = false;
            Basement = "";
            BasementWear = "";
            Attic = false;
            PromzoneDistance = "";
            StopDistance = "";
            Social = "";
            Transport = false;
            Gaz = false;
            Parking = false;
            Local1 = "";
            Local2 = "";
            ClosestStop = "";

            ClearRoofConditionList();
            FillRoofConditionList();

            ClearOutsideWallMaterialTypeList();
            FillOutsideWallMaterialList();

            ClearInsideWallMaterialTypeList();
            FillInsideWallMaterialList();

            //ClearWallConditionList();
            //FillWallConditionList();

            ClearCeilingMaterialTypeList();
            FillCeilingMaterialList();

            ClearCeilingConditionList();
            FillCeilingConditionList();



        }
        #endregion
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
            CopyLocationDataFromEntity();                   // Скопировать характеристики дома

        }

        /// <summary>
        /// Метод. Копирует данные о доме в компоненты
        /// </summary>
        protected void CopyLocationDataFromEntity()
        {
            BuildYear = _home.BuildYear;                    // Скопировать год постройки
            RoofCondition = _home.RoofCondition;            // Скопировать состояние крыши
            OutsideWall = _home.OutsideWall;                // Скопировать тип несущей стены
            InsideWall = _home.InsideWall;                  // Скопировать тип материала перегородок
            Lift = _home.Lift;                              // Скопировать наличие лифта
            KapremontYear = _home.KapremontYear;            // Скопировать год капремонта
            KapremontPeriod = _home.KapremontPeriod;        // Скопировать периодичность капремонта
            Defects = _home.Defects;                        // Скопировать дефекты конструкции
            Garbadge = _home.Garbadge;                      // Скопировать наличие мусоропровода
            ExtraFactors = _home.ExtraFactors;              // Скопировать дополнительные факторы
            Conserge = _home.Conserge;                      // Скопировать наличие консьержа
            CeilingType = _home.CeilingType;                // Скопировать тип материала перекрытий
            CeilingCondition = _home.CeilingCondition;      // Скопировать состояние перекрытий
            Basement = _home.Basement;                      // Скопировать фундамент
            BasementWear = _home.BasementWear;              // Скопировать износ фундамента
            Attic = _home.Attic;                            // Скопировать наличие чердак
            PromzoneDistance = _home.PromzoneDistance;      // Скопировать расстояние до промзоны
            StopDistance = _home.StopDistance;              // Скопировать расстояние до остановки
            Social = _home.Social;                          // Скопировать социальный слой жильцов
            Transport = _home.Transport;                    // Скопировать наличие трамвая
            Gaz = _home.Gaz;                                // Скопировать наличие газа
            Parking = _home.Parking;                        // Скопировать наличие паркинга
            Local1 = _home.Loacals_1;                       // Скопировать локальные особенности 1
            Local2 = _home.Loacals_2;                       // Скопировать локальные особенности 2
            ClosestStop = _home.StopName;                   // Скопировать название ближайшей остановки
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

            if (_districtAfterRelinking != null)                             // Проверить район, связанный с домом
            {
                CopyDistrictFromEntity(_districtAfterRelinking);              // Скопировать данные района
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
            _home.District = _districtAfterRelinking;                   // Скопировать район после перепривязки

            _home.Number = homeNumberTextBox.Text;                      // Скопировать номер дома
            _home.ComplexNumber = homeComplexNumberTextBox.Text;        // Скопировать номер дома по комплексу

            _home.BuildYear = BuildYear;                                // Скопировать год постройки дома
            _home.RoofCondition = RoofCondition;                        // Скопировать состояние крыши
            _home.OutsideWall = OutsideWall;                            // Скопировать тип несущей стены
            _home.InsideWall = InsideWall;                              // Скопировать тип материала перегородок
            _home.Lift = Lift;                                          // Скопировать наличие лифта
            _home.KapremontYear = KapremontYear;                        // Скопировать год капремонта
            _home.KapremontPeriod = KapremontPeriod;                    // Скопировать периодичность капремонта
            _home.Defects = Defects;                                    // Скопировать дефекты конструкции
            _home.Garbadge = Garbadge;                                  // Скопировать наличие мусоропровода
            _home.ExtraFactors = ExtraFactors;                          // Скопировать дополнительные факторы
            _home.Conserge = Conserge;                                  // Скопировать наличие консьержа
            _home.CeilingType = CeilingType;                            // Скопировать тип материала перекрытий
            _home.CeilingCondition = CeilingCondition;                  // Скопировать состояние перекрытий
            _home.Basement = Basement;                                  // Скопировать фундамент
            _home.BasementWear = BasementWear;                          // Скопировать износ фундамента
            _home.Attic = Attic;                                        // Скопировать наличие чердак
            _home.PromzoneDistance = PromzoneDistance;                  // Скопировать расстояние до промзоны
            _home.StopDistance = StopDistance;                          // Скопировать расстояние до остановки
            _home.Social = Social;                                      // Скопировать социальный слой жильцов
            _home.Transport = Transport;                                // Скопировать наличие трамвая
            _home.Gaz = Gaz;                                            // Скопировать наличие газа
            _home.Parking = Parking;                                    // Скопировать наличие паркинга
            _home.Loacals_1 = Local1;                                   // Скопировать локальные особенности 1
            _home.Loacals_2 = Local2;                                   // Скопировать локальные особенности 2
            _home.StopName = ClosestStop;                               // Скопировать название ближайшей остановки
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

        /// <summary>
        /// Метод. Сохраняет изменения данных и закрывает диалоговое окно
        /// </summary>
        public override void okButton_Click(object sender, EventArgs e)
        {
            DialogResult noRegMsg;                         // Результат подтверждения сообщения

            if (_districtAfterRelinking == null)
            {
                noRegMsg = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы забыли привязать район",
                "Предупреждение",
                MessageBoxButtons.OKCancel);
            }
            else
                base.okButton_Click(sender, e);
        }

        /// <summary>
        /// Метод. Сохраняет изменения данных и закрывает диалоговое окно
        /// </summary>
        public override void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult noRegMsg;                         // Результат подтверждения сообщения

            if (_districtAfterRelinking == null)
            {
                noRegMsg = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы забыли привязать район",
                "Предупреждение",
                MessageBoxButtons.OKCancel);
            }
            else
                base.saveButton_Click(sender, e);
        }
        #endregion

        #region House Wall Type list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearOutsideWallMaterialTypeList()
        {
            MainWallTypeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddOutsideWallMaterialToList(MaterialType OutsideWall, string outsideWallDescription)
        {
            MainWallTypeComboBox.Items.Add(new KeyValuePair<MaterialType, string>(OutsideWall, outsideWallDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetOutsideWallMaterialDisplayMember(string typeMember)
        {
            MainWallTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillOutsideWallMaterialList()
        {
            foreach (MaterialType ousideWallType in Enum.GetValues(typeof(MaterialType)))               // Выполнить для всех элементов перечисления
            {
                AddOutsideWallMaterialToList(ousideWallType, _home.GetMaterialTypeAsString(ousideWallType));      // Добавить элемент в список
            }

            SetOutsideWallMaterialDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion

        #region Room Wall Type list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearInsideWallMaterialTypeList()
        {
            RoomWallTypeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddInsideWallMaterialToList(MaterialType InsideWall, string insideWallDescription)
        {
            RoomWallTypeComboBox.Items.Add(new KeyValuePair<MaterialType, string>(InsideWall, insideWallDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetInsideWallMaterialDisplayMember(string typeMember)
        {
            RoomWallTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillInsideWallMaterialList()
        {
            foreach (MaterialType insideWallType in Enum.GetValues(typeof(MaterialType)))               // Выполнить для всех элементов перечисления
            {
                AddInsideWallMaterialToList(insideWallType, _home.GetMaterialTypeAsString(insideWallType));      // Добавить элемент в список
            }

            SetInsideWallMaterialDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion

        #region Ceiling Type list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearCeilingMaterialTypeList()
        {
            CeilingTypeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddCeilingMaterialToList(MaterialType ceilingType, string ceilingDescription)
        {
            CeilingTypeComboBox.Items.Add(new KeyValuePair<MaterialType, string>(ceilingType, ceilingDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetCeilingMaterialDisplayMember(string typeMember)
        {
            CeilingTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillCeilingMaterialList()
        {
            foreach (MaterialType ceilingType in Enum.GetValues(typeof(MaterialType)))               // Выполнить для всех элементов перечисления
            {
                AddCeilingMaterialToList(ceilingType, _home.GetMaterialTypeAsString(ceilingType));      // Добавить элемент в список
            }

            SetCeilingMaterialDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion

        //#region Wall Condition list

        ///// <summary>
        ///// Метод. Очищает список
        ///// </summary>
        //protected void ClearWallConditionList()
        //{
        //    WallConditionComboBox.Items.Clear();
        //}

        ///// <summary>
        ///// Метод. Добавляет элемент в список 
        ///// </summary>
        //private void AddWallConditionToList(Condition WallCondition, string wallConditionDescription)
        //{
        //    WallConditionComboBox.Items.Add(new KeyValuePair<Condition, string>(WallCondition, wallConditionDescription));
        //}

        ///// <summary>
        ///// Метод. Задает отображаемое поле для списка 
        ///// </summary>
        //private void SetWallConditionDisplayMember(string typeMember)
        //{
        //    WallConditionComboBox.DisplayMember = typeMember;
        //}

        ///// <summary>
        ///// Метод. Заполняет данными список 
        ///// </summary>
        //protected void FillWallConditionList()
        //{
        //    foreach (Condition wallCondition in Enum.GetValues(typeof(Condition)))               // Выполнить для всех элементов перечисления
        //    {
        //        AddWallConditionToList(wallCondition, _home.GetConditionTypeAsString(wallCondition));      // Добавить элемент в список
        //    }

        //    SetWallConditionDisplayMember("Value");                                          // Задать отображаемое поле 
        //}

        //#endregion

        #region Ceiling Condition list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearCeilingConditionList()
        {
            CeilingConditionComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddCeilingConditionToList(Condition CeilingCondition, string CeilingConditionDescription)
        {
            CeilingConditionComboBox.Items.Add(new KeyValuePair<Condition, string>(CeilingCondition, CeilingConditionDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetCeilingConditionDisplayMember(string typeMember)
        {
            CeilingConditionComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillCeilingConditionList()
        {
            foreach (Condition CeilingCondition in Enum.GetValues(typeof(Condition)))               // Выполнить для всех элементов перечисления
            {
                AddCeilingConditionToList(CeilingCondition, _home.GetConditionTypeAsString(CeilingCondition));      // Добавить элемент в список
            }

            SetCeilingConditionDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion

        #region Roof Condition list

        /// <summary>
        /// Метод. Очищает список
        /// </summary>
        protected void ClearRoofConditionList()
        {
            RoofConditionComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список 
        /// </summary>
        private void AddRoofConditionToList(Condition RoofCondition, string RoofConditionDescription)
        {
            RoofConditionComboBox.Items.Add(new KeyValuePair<Condition, string>(RoofCondition, RoofConditionDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка 
        /// </summary>
        private void SetRoofConditionDisplayMember(string typeMember)
        {
            RoofConditionComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список 
        /// </summary>
        protected void FillRoofConditionList()
        {
            foreach (Condition RoofCondition in Enum.GetValues(typeof(Condition)))               // Выполнить для всех элементов перечисления
            {
                AddRoofConditionToList(RoofCondition, _home.GetConditionTypeAsString(RoofCondition));      // Добавить элемент в список
            }

            SetRoofConditionDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion




    }
}
