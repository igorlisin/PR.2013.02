﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;



namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования квартиры
    /// </summary>
    public partial class ApartmentForm : TemplateEntityForm
    {
        #region Fields

        /// <summary>
        /// Поле. Квартира
        /// </summary>
        private IApartment _apartment;

        /// <summary>
        /// Поле. Дом после перепривязки
        /// </summary>
        private IHome _homeAfterRelinking;

        /// <summary>
        /// Поле. Список домов
        /// </summary>
        private IHomes _homes;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает номер квартиры
        /// </summary>
        private string Number
        {
            get
            {
                return (numberTextBox.Text);
            }
            set
            {
                numberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает этаж
        /// </summary>
        private string Floor
        {
            get
            {
                return (floorTextBox.Text);
            }
            set
            {
                floorTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает количество комнат
        /// </summary>
        private string RoomNumber
        {
            get
            {
                return (roomNumberTextBox.Text);
            }
            set
            {
                roomNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип комнат
        /// </summary>
        private RoomTypes RoomType
        {
            get
            {
                return (((KeyValuePair<RoomTypes, string>)roomTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<RoomTypes>(roomTypeComboBox, value);       
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает общую площадь
        /// </summary>
        private string GrossArea
        {
            get
            {
                return (grossAreaTextBox.Text);
            }
            set
            {
                grossAreaTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает жилую площадь
        /// </summary>
        private string LivingArea
        {
            get
            {
                return (livingAreaTextBox.Text);
            }
            set
            {
                livingAreaTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает площадь кухни
        /// </summary>
        private string KitchenArea
        {
            get
            {
                return (kitchenAreaTextBox.Text);
            }
            set
            {
                kitchenAreaTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие отдельных от других квартир кухни и санузла
        /// </summary>
        private bool HasSeparateKitchenOrWashroom
        {
            get
            {
                return (hasSeparateKitchenOrWashroomCheckBox.Checked);
            }
            set
            {
                hasSeparateKitchenOrWashroomCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие балкона/лоджии
        /// </summary>
        private bool HasBalconyOrLoggia
        {
            get
            {
                return (hasBalconyOrLoggiaCheckBox.Checked);
            }
            set
            {
                hasBalconyOrLoggiaCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип санузлов
        /// </summary>
        private WashroomTypes WashroomType
        {
            get
            {
                return (((KeyValuePair<WashroomTypes, string>)washroomTypeComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<WashroomTypes>(washroomTypeComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает высоту потолков
        /// </summary>
        private string CeilingHeight
        {
            get
            {
                return(ceilingHeightTextBox.Text);
            }
            set
            {
                ceilingHeightTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает вид из окна
        /// </summary>
        private string Views
        {
            get
            {
                return(viewsTextBox.Text);
            }
            set
            {
                viewsTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает планировку
        /// </summary>
        private Layouts Layout
        {
            get
            {
                return (((KeyValuePair<Layouts, string>)layoutComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<Layouts>(layoutComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает вспомогательные помещения и площадь
        /// </summary>
        private string AuxiliaryRooms
        {
            get
            {
                return (auxiliaryRoomsTextBox.Text);
            }
            set
            {
                auxiliaryRoomsTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние квартиры
        /// </summary>
        private ApartmentStates ApartmentState
        {
            get
            {
                return (((KeyValuePair<ApartmentStates, string>)apartmentStateComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<ApartmentStates>(apartmentStateComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает необходимые ремонтные работы
        /// </summary>
        private RepairWorkTypes RepairWork
        {
            get
            {
                return (((KeyValuePair<RepairWorkTypes, string>)repairWorkComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<RepairWorkTypes>(repairWorkComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает качество отделки помещения
        /// </summary>
        private RoomFinishingQualities RoomFinishingQuality
        {
            get
            {
                return (((KeyValuePair<RoomFinishingQualities, string>)roomFinishingQualityComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<RoomFinishingQualities>(roomFinishingQualityComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в жилых комнатах
        /// </summary>
        private FloorMaterials FinishingMaterialForLivingRoomFloor
        {
            get
            {
                return (((KeyValuePair<FloorMaterials, string>)finishingMaterialForLivingRoomFloorComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<FloorMaterials>(finishingMaterialForLivingRoomFloorComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в жилых комнатах
        /// </summary>
        private WallMaterials FinishingMaterialForLivingRoomWall
        {
            get
            {
                return (((KeyValuePair<WallMaterials, string>)finishingMaterialForLivingRoomWallComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<WallMaterials>(finishingMaterialForLivingRoomWallComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в жилых комнатах
        /// </summary>
        private CeilingMaterials FinishingMaterialForLivingRoomCeiling
        {
            get
            {
                return (((KeyValuePair<CeilingMaterials, string>)finishingMaterialForLivingRoomCeilingComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<CeilingMaterials>(finishingMaterialForLivingRoomCeilingComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в коридоре
        /// </summary>
        private FloorMaterials FinishingMaterialForHallFloor
        {
            get
            {
                return (((KeyValuePair<FloorMaterials, string>)finishingMaterialForHallFloorComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<FloorMaterials>(finishingMaterialForHallFloorComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в коридоре
        /// </summary>
        private WallMaterials FinishingMaterialForHallWall
        {
            get
            {
                return (((KeyValuePair<WallMaterials, string>)finishingMaterialForHallWallComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<WallMaterials>(finishingMaterialForHallWallComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в коридоре
        /// </summary>
        private CeilingMaterials FinishingMaterialForHallCeiling
        {
            get
            {
                return (((KeyValuePair<CeilingMaterials, string>)finishingMaterialForHallCeilingComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<CeilingMaterials>(finishingMaterialForHallCeilingComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола на кухне
        /// </summary>
        private FloorMaterials FinishingMaterialForKitchenFloor
        {
            get
            {
                return (((KeyValuePair<FloorMaterials, string>)finishingMaterialForKitchenFloorComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<FloorMaterials>(finishingMaterialForKitchenFloorComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен на кухне
        /// </summary>
        private WallMaterials FinishingMaterialForKitchenWall
        {
            get
            {
                return (((KeyValuePair<WallMaterials, string>)finishingMaterialForKitchenWallComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<WallMaterials>(finishingMaterialForKitchenWallComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка на кухне
        /// </summary>
        private CeilingMaterials FinishingMaterialForKitchenCeiling
        {
            get
            {
                return (((KeyValuePair<CeilingMaterials, string>)finishingMaterialForKitchenCeilingComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<CeilingMaterials>(finishingMaterialForKitchenCeilingComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в ванной
        /// </summary>
        private FloorMaterials FinishingMaterialForWashroomFloor
        {
            get
            {
                return (((KeyValuePair<FloorMaterials, string>)finishingMaterialForWashroomFloorComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<FloorMaterials>(finishingMaterialForWashroomFloorComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в ванной
        /// </summary>
        private WallMaterials FinishingMaterialForWashroomWall
        {
            get
            {
                return (((KeyValuePair<WallMaterials, string>)finishingMaterialForWashroomWallComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<WallMaterials>(finishingMaterialForWashroomWallComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в ванной
        /// </summary>
        private CeilingMaterials FinishingMaterialForWashroomCeiling
        {
            get
            {
                return (((KeyValuePair<CeilingMaterials, string>)finishingMaterialForWashroomCeilingComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<CeilingMaterials>(finishingMaterialForWashroomCeilingComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает подключение к коммуникациям
        /// </summary>
        private ObjectCommunicationTypes ObjectCommunication
        {
            get
            {
                return (((KeyValuePair<ObjectCommunicationTypes, string>)objectCommunicationComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<ObjectCommunicationTypes>(objectCommunicationComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает систему отопления
        /// </summary>
        private HeatingSystemTypes HeatingSystem
        {
            get
            {
                return (((KeyValuePair<HeatingSystemTypes, string>)heatingSystemComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<HeatingSystemTypes>(heatingSystemComboBox, value);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие слаботочного обеспечения
        /// </summary>
        private bool HasLowCurrent
        {
            get
            {
                return (hasLowCurrentCheckBox.Checked);
            }
            set
            {
                hasLowCurrentCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие оборудования для систем коммуникаций и слаботочного обеспечения
        /// </summary>
        private bool HasDevices
        {
            get
            {
                return (hasDevicesCheckBox.Checked);
            }
            set
            {
                hasDevicesCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает cоответствие планировки квартиры поэтажному плану БТИ и наличие переоборудований
        /// </summary>
        private string PlanMeets
        {
            get
            {
                return (planMeetsTextBox.Text);
            }
            set
            {
                planMeetsTextBox.Text = value;
            }
        }

        /// <summary>
        ///Свойство. Задает и возвращает мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
        /// </summary>
        private string ViewOnApparment
        {
            get
            {
                return(viewOnApparmentTextBox.Text);
            }
            set
            {
                viewOnApparmentTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает текущее использование
        /// </summary>
        private CurrentUsingTypes CurrentUsing
        {
            get
            {
                return (((KeyValuePair<CurrentUsingTypes, string>)currentUsingComboBox.SelectedItem).Key);
            }
            set
            {
                SetComboBoxElementByType<CurrentUsingTypes>(currentUsingComboBox, value);
            }
        }

        /// <summary>
        ///Свойство. Задает и возвращает комментарии к фотографиям
        /// </summary>
        private string PicturesComment
        {
            get
            {
                return (picturesCommentTextBox.Text);
            }
            set
            {
                picturesCommentTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название страны
        /// </summary>
        private string CountryName
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
        private string RegionName
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
        /// Свойство. Задает и возвращает название района
        /// </summary>
        private string DistrictName
        {
            get
            {
                return (districtNameTextBox.Text);
            }
            set
            {
                districtNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название города
        /// </summary>
        private string CityName
        {
            get
            {
                return (cityNameTextBox.Text);
            }
            set
            {
                cityNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает название улицы
        /// </summary>
        private string StreetName
        {
            get
            {
                return (streetNameTextBox.Text);
            }
            set
            {
                streetNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер комплекса
        /// </summary>
        private string ComplexNumber
        {
            get
            {
                return (complexNumberTextBox.Text);
            }
            set
            {
                complexNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер дома
        /// </summary>
        private string HomeNumber
        {
            get
            {
                return (homeNumberTextBox.Text);
            }
            set
            {
                homeNumberTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер дома по комплексу
        /// </summary>
        private string HomeComplexNumber
        {
            get
            {
                return (homeComplexNumberTextBox.Text);
            }
            set
            {
                homeComplexNumberTextBox.Text = value;
            }
        }

        #region Apartment man picture

        /// <summary>
        /// Свойство. Задает и возвращает название картинки с планом квартиры
        /// </summary>
        private string ApartmentMapPictureName
        {
            get
            {
                return(apartmentMapPictureNameTextBox.Text);
            }
            set
            {
                apartmentMapPictureNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает картинку с планом квартиры
        /// </summary>
        private Image ApartmentMapPicture
        {
            get
            {
                return(apartmentMapPictureBox.Image);
            }
            set
            {
                apartmentMapPictureBox.Image = value;
            }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApartmentForm(IApartment apartment, IHomes homes)
        {
            InitializeComponent();                      // Инициализировать компоненты формы

            _apartment = apartment;                     // Сохранить квартиру в поле
            _homes = homes;                             // Сохранить список домов воле

            _homeAfterRelinking = apartment.Home;       // Сохранить дом, связанный с квартиров в поле

            CleanAllData();                             // Очистить компоненты всех групп

            CopyDataFromEntity();                       // Скопировать данные человека в компоненты формы
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

            CleanApartment();           // Очистить данные квартиры
            CleanCountry();         // Очистить название страны
            CleanRegion();          // Очистить название региона
            CleanDistrict();        // Очистить название района
            CleanCity();            // Очистить название города
            CleanStreet();          // Очистить название улицы
            CleanComplex();       // Очистить номер комплекса
            CleanHome();          // Очистить номер дома
            CleanComplex();       // Очистить номер дома по комплексу
        }
        /// <summary>
        /// Метод. Очищает данные квартиры
        /// </summary>
        private void CleanApartment()
        {
            Number = "";                                                                    // Очистить номер квартиры
            Floor = "";                                                                     // Очистить этаж
            RoomNumber = "";                                                                // Очистить количество комнат

            ClearRoomTypeList();                                                            // Очистить список "Тип комнат"
            FillRoomTypeList();                                                             // Заполнить данными список "Тип комнат"

            GrossArea = "";                                                                 // Очистить общую площадь
            LivingArea = "";                                                                // Очистить жилую площадь
            KitchenArea = "";                                                               // Очистить площадь кухни
            HasSeparateKitchenOrWashroom = false;                                           // Очистить наличие отдельных от других квартир кухни и санузла
            HasBalconyOrLoggia = false;                                                     // Очистить наличие балкона/лоджии

            ClearWashroomTypeList();                                                        // Очистить список "Тип санузлов"
            FillWashroomTypeList();                                                         // Заполнить данными список "Тип санузлов"

            CeilingHeight = "";                                                             // Очистить высоту потолков
            Views = "";                                                                     // Очистить вид из окна

            ClearLayoutList();                                                              // Очистить список "Планироваки"
            FillLayoutList();                                                               // Заполнить данными список "Планироваки"

            AuxiliaryRooms = "";                                                            // Очистить вспомогательные помещения и площадь

            ClearLayoutList();                                                              // Очистить список "Планировка"
            FillLayoutList();                                                               // Заполнить данными список "Планировака"

            ClearApartmentStateList();                                                      // Очистить список "Состояние квартиры"
            FillApartmentStateList();                                                       // Заполнить данными список "Состояние квартиры"

            ClearRepairWorkList();                                                          // Очистить список "Необходимые ремонтные работы"
            FillRepairWorkList();                                                           // Заполнить данными список "Необходимые ремонтные работы"

            ClearRoomFinishingQualityList();                                                // Очистить список "Качество отделки помещения"
            FillRoomFinishingQualityList();                                                 // Заполнить данными список "Качество отделки помещения"

            ClearRoomFinishingQualityList();                                                // Очистить список "Качество отделки помещения"
            FillRoomFinishingQualityList();                                                 // Заполнить данными список "Качество отделки помещения"

            ClearFloorMaterialList(finishingMaterialForLivingRoomFloorComboBox);            // Очистить список "Материал отделки пола в жилых комнатах"
            FillFloorMaterialList(finishingMaterialForLivingRoomFloorComboBox);             // Заполнить данными список "Материал отделки пола в жилых комнатах" 

            ClearWallMaterialList(finishingMaterialForLivingRoomWallComboBox);              // Очистить список "Материал отделки стен в жилых комнатах"
            FillWallMaterialList(finishingMaterialForLivingRoomWallComboBox);               // Заполнить данными список "Материал отделки стен в жилых комнатах" 

            ClearCeilingMaterialList(finishingMaterialForLivingRoomCeilingComboBox);        // Очистить список "Материал отделки потолка в жилых комнатах"
            FillCeilingMaterialList(finishingMaterialForLivingRoomCeilingComboBox);         // Заполнить данными список "Материал отделки потолка в жилых комнатах" 

            ClearFloorMaterialList(finishingMaterialForHallFloorComboBox);                  // Очистить список "Материал отделки пола в коридоре"
            FillFloorMaterialList(finishingMaterialForHallFloorComboBox);                   // Заполнить данными список "Материал отделки пола в коридоре" 

            ClearWallMaterialList(finishingMaterialForHallWallComboBox);                    // Очистить список "Материал отделки стен в коридоре"
            FillWallMaterialList(finishingMaterialForHallWallComboBox);                     // Заполнить данными список "Материал отделки стен в коридоре" 

            ClearCeilingMaterialList(finishingMaterialForHallCeilingComboBox);              // Очистить список "Материал отделки потолка в коридоре"
            FillCeilingMaterialList(finishingMaterialForHallCeilingComboBox);               // Заполнить данными список "Материал отделки потолка в коридоре" 

            ClearFloorMaterialList(finishingMaterialForKitchenFloorComboBox);               // Очистить список "Материал отделки пола на кухне"
            FillFloorMaterialList(finishingMaterialForKitchenFloorComboBox);                // Заполнить данными список "Материал отделки пола на кухне" 

            ClearWallMaterialList(finishingMaterialForKitchenWallComboBox);                 // Очистить список "Материал отделки стен на кухне"
            FillWallMaterialList(finishingMaterialForKitchenWallComboBox);                  // Заполнить данными список "Материал отделки стен на кухне" 

            ClearCeilingMaterialList(finishingMaterialForKitchenCeilingComboBox);           // Очистить список "Материал отделки потолка на кухне"
            FillCeilingMaterialList(finishingMaterialForKitchenCeilingComboBox);            // Заполнить данными список "Материал отделки потолка на кухне" 

            ClearFloorMaterialList(finishingMaterialForWashroomFloorComboBox);              // Очистить список "Материал отделки пола в санузле"
            FillFloorMaterialList(finishingMaterialForWashroomFloorComboBox);               // Заполнить данными список "Материал отделки пола в санузле" 

            ClearWallMaterialList(finishingMaterialForWashroomWallComboBox);                // Очистить список "Материал отделки стен в санузле"
            FillWallMaterialList(finishingMaterialForWashroomWallComboBox);                 // Заполнить данными список "Материал отделки стен в санузле" 

            ClearCeilingMaterialList(finishingMaterialForWashroomCeilingComboBox);          // Очистить список "Материал отделки потолка в санузле"
            FillCeilingMaterialList(finishingMaterialForWashroomCeilingComboBox);           // Заполнить данными список "Материал отделки потолка в санузле" 

            ClearObjectCommunicationList();                                                 // Очистить список "Подключение к коммуникациям"
            FillObjectCommunicationList();                                                  // Заполнить данными список "Подключение к коммуникациям" 

            ClearHeatingSystemList();                                                       // Очистить список "Система отопления"
            FillHeatingSystemList();                                                        // Заполнить данными список "Система отопления" 

            HasLowCurrent = false;                                                          // Очистить наличие слаботочного обеспечения
            HasDevices = false;                                                              // Очистить наличие оборудования для систем коммуникаций и слаботочного обеспечения
            PlanMeets = "";                                                                 // Очистить соответствие планировки квартиры поэтажному плану БТИ и наличие переоборудований
            ViewOnApparment = "";                                                           // Очистить мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние

            ClearCurrentUsingList();                                                        // Очистить список "Текущее использование"
            FillCurrentUsingList();                                                         // Заполнить данными список "Текущее использование" 

            PicturesComment = "";                                                           // Очистить омментарии к фотографиям
        }

        /// <summary>
        /// Метод. Очищает данные страны
        /// </summary>
        private void CleanCountry()
        {
            CountryName = "";       // Очистить название страны
        }

        /// <summary>
        /// Метод. Очищает данные региона
        /// </summary>
        private void CleanRegion()
        {
            RegionName = "";        // Очистить название региона
        }

        /// <summary>
        /// Метод. Очищает данные района
        /// </summary>
        private void CleanDistrict()
        {
            DistrictName = "";      // Очистить название района
        }

        /// <summary>
        /// Метод. Очищает данные города
        /// </summary>
        private void CleanCity()
        {
            CityName = "";      // Очистить название города
        }

        /// <summary>
        /// Метод. Очищает данные улицы
        /// </summary>
        private void CleanStreet()
        {
            StreetName = "";        // Очистить название улицы
        }

        /// <summary>
        /// Метод. Очищает данные комплекса
        /// </summary>
        private void CleanComplex()
        {
            ComplexNumber = "";     // Очистить номер комплекса
        }

        /// <summary>
        /// Метод. Очищает данные дома
        /// </summary>
        private void CleanHome()
        {
            HomeNumber = "";            // Очистить номер дома
            HomeComplexNumber = "";     // Очистить номер дома по комплексу
        }

        #endregion

        #region Copy

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_apartment);              // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_apartment);     // Скопировать описание

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyApartmentFromEntity(_apartment);                // Скопировать данные квартиры

        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        private void CopyLinkedDataFromEntity()
        {
            if (_homeAfterRelinking != null)                                                                // Проверить дом, связанный с квартирой
            {
                if (_homeAfterRelinking.Street != null)                                                     // Проверить улицу, связанную с домом
                {
                    if (_homeAfterRelinking.Street.City != null)                                            // Проверить город, связанный с улицей
                    {
                        if (_homeAfterRelinking.Street.City.Region != null)                                 // Проверить регион, связанный с городом
                        {
                            if (_homeAfterRelinking.Street.City.Region.Country != null)                     // Проверить страну, связанную с регионом
                            {
                                CopyCountryFromEntity(_homeAfterRelinking.Street.City.Region.Country);      // Скопировать данные страны
                            }
                            CopyRegionFromEntity(_homeAfterRelinking.Street.City.Region);                   // Скопировать данные региона
                        }
                        CopyCityFromEntity(_homeAfterRelinking.Street.City);                                // Скопировать данные города
                    }
                    CopyStreetFromEntity(_homeAfterRelinking.Street);                                       // Скопировать данные улицы
                }

                if (_homeAfterRelinking.Complex != null)                                                    // Проверить комплекс, связанный с домом
                {
                    CopyComplexFromEntity(_homeAfterRelinking.Complex);                                     // Скопировать данные комплекса
                }

                CopyHomeFromEntity(_homeAfterRelinking);                                                    // Скопировать данные дома
            }   
            
            SetButtonActivity();                                                                            // Задать активность компонентов
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_apartment).Description = Description;        // Скопировать описание

            CopyApartmentToEntity(_apartment);                      // Скопировать данные квартиры

            _apartment.Home = _homeAfterRelinking;                  // Скопировать дом после перепривязки
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты квартиры
        /// </summary>
        private void CopyApartmentFromEntity(IApartment apartment)
        {
            Number = Convert.ToString(apartment.Number);                                                    // Скопировать номер квартиры
            Floor = Convert.ToString(apartment.Floor);                                                      // Скопировать этаж
            RoomNumber = Convert.ToString(apartment.RoomNumber);                                            // Скопировать количество комнат
            RoomType = apartment.RoomType;                                                                  // Скопировать тип комнат
            GrossArea = Convert.ToString(apartment.GrossArea);                                              // Скопировать общую площадь
            LivingArea = Convert.ToString(apartment.LivingArea);                                            // Скопировать жилую площадь
            KitchenArea = Convert.ToString(apartment.KitchenArea);                                          // Скопировать площадь кухни
            HasSeparateKitchenOrWashroom = apartment.HasSeparateKitchenOrWashroom;                          // Скопировать наличие отдельных от других квартир кухни и санузла
            HasBalconyOrLoggia = apartment.HasBalconyOrLoggia;                                              // Скопировать наличие балкона/лоджии
            WashroomType = apartment.WashroomType;                                                          // Скопировать тип санузла
            CeilingHeight = Convert.ToString(apartment.CeilingHeight);                                      // Скопировать высоту потолков
            Views = apartment.Views;                                                                        // Скопировать вид из окна
            Layout = apartment.Layout;                                                                      // Скопировать планировку
            AuxiliaryRooms = apartment.AuxiliaryRooms;                                                      // Скопировать вспомогательные помещения и площадь
            ApartmentState = apartment.ApartmentState;                                                      // Скопировать состояние квартиры
            RepairWork = apartment.RepairWork;                                                              //Скопировать необходимые ремонтные работы
            RoomFinishingQuality = apartment.RoomFinishingQuality;                                          // Скопировать качество отделки помещения
            FinishingMaterialForLivingRoomFloor = apartment.FinishingMaterialForLivingRoomFloor;            // Скопировать материал отделки пола в жилых комнатах
            FinishingMaterialForLivingRoomWall = apartment.FinishingMaterialForLivingRoomWall;              // Скопировать материал отделки стен в жилых комнатах
            FinishingMaterialForLivingRoomCeiling = apartment.FinishingMaterialForLivingRoomCeiling;        // Скопировать материал отделки потолка в жилых комнатах
            FinishingMaterialForHallFloor = apartment.FinishingMaterialForHallFloor;                        // Скопировать материал отделки пола в коридоре
            FinishingMaterialForHallWall = apartment.FinishingMaterialForHallWall;                          // Скопировать материал отделки стен в коридоре
            FinishingMaterialForHallCeiling = apartment.FinishingMaterialForHallCeiling;                    // Скопировать материал отделки потолка в коридоре
            FinishingMaterialForKitchenFloor = apartment.FinishingMaterialForKitchenFloor;                  // Скопировать материал отделки пола на кухне
            FinishingMaterialForKitchenWall = apartment.FinishingMaterialForKitchenWall;                    // Скопировать материал отделки стен на кухне
            FinishingMaterialForKitchenCeiling = apartment.FinishingMaterialForKitchenCeiling;              // Скопировать материал отделки потолка на кухне
            FinishingMaterialForWashroomFloor = apartment.FinishingMaterialForWashroomFloor;                // Скопировать материал отделки пола в санузле
            FinishingMaterialForWashroomWall = apartment.FinishingMaterialForWashroomWall;                  // Скопировать материал отделки стен в санузле
            FinishingMaterialForWashroomCeiling = apartment.FinishingMaterialForWashroomCeiling;            // Скопировать материал отделки потолка в санузле  
            ObjectCommunication = apartment.ObjectCommunication;                                            // Скопировать подключение к коммуникациям
            HeatingSystem = apartment.HeatingSystem;                                                        // Скопировать систему отопления
            HasLowCurrent = apartment.HasLowCurrent;                                                        // Скопировать наличие слаботочного обеспечения
            HasDevices = apartment.HasDevices;                                                               // Скопировать наличие оборудования для систем коммуникаций и слаботочного обеспечения
            PlanMeets = apartment.PlanMeets;                                                                // Скопировать соответствие планировки квартиры поэтажному плану БТИ и наличие переоборудований
            ViewOnApparment = apartment.ViewOnApparment;                                                    // Скопировать мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
            CurrentUsing = apartment.CurrentUsing;                                                          // Скопировать текущее использование
            PicturesComment = apartment.PicturesComment;                                                    // Скопировать комментарии к фотографиям
        }

        /// <summary>
        /// Метод. Копирует данные компонентов квартиры в данные сущности
        /// </summary>
        private void CopyApartmentToEntity(IApartment apartment)
        {
            apartment.Number = Convert.ToInt32(Number);                                                     // Скопировать номер квартиры
            apartment.Floor = Convert.ToInt32(Floor);                                                       // Скопировать этаж
            apartment.RoomNumber = Convert.ToInt32(RoomNumber);                                             // Скопировать количество комнат
            apartment.RoomType = RoomType;                                                                  // Скопировать тип комнат
            apartment.GrossArea = Convert.ToSingle(GrossArea);                                              // Скопировать общую площадь
            apartment.LivingArea = Convert.ToSingle(LivingArea);                                            // Скопировать жилую площадь
            apartment.KitchenArea = Convert.ToSingle(KitchenArea);                                          // Скопировать площадь кухни
            apartment.HasSeparateKitchenOrWashroom = HasSeparateKitchenOrWashroom;                          // Скопировать наличие отдельных от других квартир кухни и санузла
            apartment.HasBalconyOrLoggia = HasBalconyOrLoggia;                                              // Скопировать наличие балкона/лоджии
            apartment.WashroomType = WashroomType;                                                          // Скопировать тип санузла
            apartment.CeilingHeight = Convert.ToSingle(CeilingHeight);                                      // Скопировать высоту потолков
            apartment.Views = Views;                                                                        // Скопировать вид из окна
            apartment.Layout = Layout;                                                                      // Скопировать планировку
            apartment.AuxiliaryRooms = AuxiliaryRooms;                                                      // Скопировать вспомогательные помещения и площадь
            apartment.ApartmentState = ApartmentState;                                                      // Скопировать состояние квартиры
            apartment.RepairWork = RepairWork;                                                              //Скопировать необходимые ремонтные работы
            apartment.RoomFinishingQuality = RoomFinishingQuality;                                          // Скопировать качество отделки помещения
            apartment.FinishingMaterialForLivingRoomFloor = FinishingMaterialForLivingRoomFloor;            // Скопировать материал отделки пола в жилых комнатах
            apartment.FinishingMaterialForLivingRoomWall = FinishingMaterialForLivingRoomWall;              // Скопировать материал отделки стен в жилых комнатах
            apartment.FinishingMaterialForLivingRoomCeiling = FinishingMaterialForLivingRoomCeiling;        // Скопировать материал отделки потолка в жилых комнатах
            apartment.FinishingMaterialForHallFloor = FinishingMaterialForHallFloor;                        // Скопировать материал отделки пола в коридоре
            apartment.FinishingMaterialForHallWall = FinishingMaterialForHallWall;                          // Скопировать материал отделки стен в коридоре
            apartment.FinishingMaterialForHallCeiling = FinishingMaterialForHallCeiling;                    // Скопировать материал отделки потолка в коридоре
            apartment.FinishingMaterialForKitchenFloor = FinishingMaterialForKitchenFloor;                  // Скопировать материал отделки пола на кухне
            apartment.FinishingMaterialForKitchenWall = FinishingMaterialForKitchenWall;                    // Скопировать материал отделки стен на кухне
            apartment.FinishingMaterialForKitchenCeiling = FinishingMaterialForKitchenCeiling;              // Скопировать материал отделки потолка на кухне
            apartment.FinishingMaterialForWashroomFloor = FinishingMaterialForWashroomFloor;                // Скопировать материал отделки пола в санузле
            apartment.FinishingMaterialForWashroomWall = FinishingMaterialForWashroomWall;                  // Скопировать материал отделки стен в санузле
            apartment.FinishingMaterialForWashroomCeiling = FinishingMaterialForWashroomCeiling;            // Скопировать материал отделки потолка в санузле  
            apartment.ObjectCommunication = ObjectCommunication;                                            // Скопировать подключение к коммуникациям
            apartment.HeatingSystem = HeatingSystem;                                                        // Скопировать систему отопления
            apartment.HasLowCurrent = HasLowCurrent;                                                        // Скопировать наличие слаботочного обеспечения
            apartment.HasDevices = HasDevices;                                                              // Скопировать наличие оборудования для систем коммуникаций и слаботочного обеспечения
            apartment.PlanMeets = PlanMeets;                                                                // Скопировать соответствие планировки квартиры поэтажному плану БТИ и наличие переоборудований
            apartment.ViewOnApparment = ViewOnApparment;                                                    // Скопировать мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
            apartment.CurrentUsing = CurrentUsing;                                                          // Скопировать текущее использование
            apartment.PicturesComment = PicturesComment;                                                    // Скопировать комментарии к фотографиям
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты страны
        /// </summary>
        private void CopyCountryFromEntity(ICountry country)
        {
            CountryName = country.Name;     // Скопировать название страны
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты региона
        /// </summary>
        private void CopyRegionFromEntity(IRegion region)
        {
            RegionName = region.Name;       // Скопировать название региона
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты района
        /// </summary>
        private void CopyDistrictFromEntity(IDistrict district)
        {
            DistrictName = district.Name;       // Скопировать название региона
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты города
        /// </summary>
        private void CopyCityFromEntity(ICity city)
        {
            CityName = city.Name;       // Скопировать название города
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты улицы
        /// </summary>
        private void CopyStreetFromEntity(IStreet street)
        {
            StreetName = street.Name;       // Скопировать название улицы
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты комлекса
        /// </summary>
        private void CopyComplexFromEntity(IComplex complex)
        {
            ComplexNumber = Convert.ToString(complex.Number);       // Скопировать номер комплекса
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты дома
        /// </summary>
        private void CopyHomeFromEntity(IHome home)
        {
            HomeNumber = home.Number;                   // Скопировать номер дома
            HomeComplexNumber = home.ComplexNumber;     // Скопировать номер дома по комплексу
        }

        #endregion

        #region Template methods

        /// <summary>
        /// Шаблонный метод. Выбирает элемент в списке
        /// </summary>
        private void SetComboBoxElementByType<T>(ComboBox comboBox, T value)
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

        #region Other

        #region Room type list

        /// <summary>
        /// Метод. Очищает список "Тип комнат"
        /// </summary>
        protected void ClearRoomTypeList()
        {
            roomTypeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Тип комнат"
        /// </summary>
        private void AddRoomTypeToList(RoomTypes roomType, string roomTypeDescription)
        {
            roomTypeComboBox.Items.Add(new KeyValuePair<RoomTypes, string>(roomType, roomTypeDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Тип комнат"
        /// </summary>
        private void SetRoomTypeListDisplayMember(string typeMember)
        {
            roomTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Тип комнат"
        /// </summary>
        protected void FillRoomTypeList()
        {
            foreach (RoomTypes roomType in Enum.GetValues(typeof(RoomTypes)))               // Выполнить для всех элементов перечисления
            {
                AddRoomTypeToList(roomType, _apartment.GetRoomTypeAsString(roomType));      // Добавить элемент в список
            }

            SetRoomTypeListDisplayMember("Value");                                          // Задать отображаемое поле 
        }

        #endregion

        #region Washroom type list

        /// <summary>
        /// Метод. Очищает список "Тип санузлов"
        /// </summary>
        protected void ClearWashroomTypeList()
        {
            washroomTypeComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Тип санузлов"
        /// </summary>
        private void AddWashroomTypeToList(WashroomTypes washroomType, string washroomTypeDescription)
        {
            washroomTypeComboBox.Items.Add(new KeyValuePair<WashroomTypes, string>(washroomType, washroomTypeDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Тип санузлов"
        /// </summary>
        private void SetWashroomTypeListDisplayMember(string typeMember)
        {
            washroomTypeComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Тип санузлов"
        /// </summary>
        protected void FillWashroomTypeList()
        {
            foreach (WashroomTypes washroomType in Enum.GetValues(typeof(WashroomTypes)))                   // Выполнить для всех элементов перечисления
            {
                AddWashroomTypeToList(washroomType, _apartment.GetWashroomTypeAsString(washroomType));      // Добавить элемент в список  
            }

            SetWashroomTypeListDisplayMember("Value");                                                      // Задать отображаемое поле 
        }

        #endregion

        #region Layout

        /// <summary>
        /// Метод. Очищает список "Планировка"
        /// </summary>
        protected void ClearLayoutList()
        {
            layoutComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Планировка"
        /// </summary>
        private void AddLayoutToList(Layouts layout, string layoutDescription)
        {
            layoutComboBox.Items.Add(new KeyValuePair<Layouts, string>(layout, layoutDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Планировка"
        /// </summary>
        private void SetLayoutListDisplayMember(string typeMember)
        {
            layoutComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Планировка"
        /// </summary>
        protected void FillLayoutList()
        {
            foreach (Layouts layout in Enum.GetValues(typeof(Layouts)))             // Выполнить для всех элементов перечисления
            {
                AddLayoutToList(layout, _apartment.GetLayoutAsString(layout));      // Добавить элемент в список  
            }

            SetLayoutListDisplayMember("Value");                                    // Задать отображаемое поле 
        }

        #endregion

        #region Apartment state list

        /// <summary>
        /// Метод. Очищает список "Состояние квартиры"
        /// </summary>
        protected void ClearApartmentStateList()
        {
            apartmentStateComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Состояние квартиры"
        /// </summary>
        private void AddApartmentStateToList(ApartmentStates apartmentState, string apartmentStateDescription)
        {
            apartmentStateComboBox.Items.Add(new KeyValuePair<ApartmentStates, string>(apartmentState, apartmentStateDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Состояние квартиры"
        /// </summary>
        private void SetApartmentStateListDisplayMember(string typeMember)
        {
            apartmentStateComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Состояние квартиры"
        /// </summary>
        protected void FillApartmentStateList()
        {
            foreach (ApartmentStates apartmentState in Enum.GetValues(typeof(ApartmentStates)))                     // Выполнить для всех элементов перечисления
            {
                AddApartmentStateToList(apartmentState, _apartment.GetApartmentStateAsString(apartmentState));     // Добавить элемент в список  
            }

            SetApartmentStateListDisplayMember("Value");                                                            // Задать отображаемое поле 
        }

        #endregion

        #region Repair work list

        /// <summary>
        /// Метод. Очищает список "Необходимые ремонтные работы"
        /// </summary>
        protected void ClearRepairWorkList()
        {
            repairWorkComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Необходимые ремонтные работы"
        /// </summary>
        private void AddRepairWorkToList(RepairWorkTypes repairWork, string repairWorkDescription)
        {
            repairWorkComboBox.Items.Add(new KeyValuePair<RepairWorkTypes, string>(repairWork, repairWorkDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Необходимые ремонтные работы"
        /// </summary>
        private void SetRepairWorkListDisplayMember(string typeMember)
        {
            repairWorkComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Необходимые ремонтные работы"
        /// </summary>
        protected void FillRepairWorkList()
        {
            foreach (RepairWorkTypes repairWork in Enum.GetValues(typeof(RepairWorkTypes)))         // Выполнить для всех элементов перечисления
            {
                AddRepairWorkToList(repairWork, _apartment.GetRepairWorkAsString(repairWork));      // Добавить элемент в список  
            }

            SetRepairWorkListDisplayMember("Value");                                                // Задать отображаемое поле 
        }

        #endregion

        #region Room finishing quality list

        /// <summary>
        /// Метод. Очищает список "Качество отделки помещения"
        /// </summary>
        protected void ClearRoomFinishingQualityList()
        {
            roomFinishingQualityComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Качество отделки помещения"
        /// </summary>
        private void AddRoomFinishingQualityToList(RoomFinishingQualities roomFinishingQuality, string roomFinishingQualityDescription)
        {
            roomFinishingQualityComboBox.Items.Add(new KeyValuePair<RoomFinishingQualities, string>(roomFinishingQuality, roomFinishingQualityDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Качество отделки помещения"
        /// </summary>
        private void SetRoomFinishingQualityListDisplayMember(string typeMember)
        {
            roomFinishingQualityComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Качество отделки помещения"
        /// </summary>
        protected void FillRoomFinishingQualityList()
        {
            foreach (RoomFinishingQualities roomFinishingQuality in Enum.GetValues(typeof(RoomFinishingQualities)))                         // Выполнить для всех элементов перечисления
            {
                AddRoomFinishingQualityToList(roomFinishingQuality, _apartment.GetRoomFinishingQualityAsString(roomFinishingQuality));      // Добавить элемент в список  
            }

            SetRoomFinishingQualityListDisplayMember("Value");                                                                              // Задать отображаемое поле 
        }

        #endregion

        #region Floor material list

        /// <summary>
        /// Метод. Очищает список "Материал отделки пола"
        /// </summary>
        protected void ClearFloorMaterialList(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Материал отделки пола"
        /// </summary>
        private void AddFloorMaterialToList(ComboBox comboBox, FloorMaterials floorMaterial, string floorMaterialDescription)
        {
            comboBox.Items.Add(new KeyValuePair<FloorMaterials, string>(floorMaterial, floorMaterialDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Материал отделки пола"
        /// </summary>
        private void SetFloorMaterialListDisplayMember(ComboBox comboBox, string typeMember)
        {
            comboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Материал отделки пола"
        /// </summary>
        protected void FillFloorMaterialList(ComboBox comboBox)
        {
            foreach (FloorMaterials floorMaterial in Enum.GetValues(typeof(FloorMaterials)))                                // Выполнить для всех элементов перечисления
            {
                AddFloorMaterialToList(comboBox, floorMaterial, _apartment.GetFloorMaterialAsString(floorMaterial));        // Добавить элемент в список  
            }

            SetFloorMaterialListDisplayMember(comboBox, "Value");                                                           // Задать отображаемое поле 
        }

        #endregion

        #region Wall material list

        /// <summary>
        /// Метод. Очищает список "Материал отделки стен"
        /// </summary>
        protected void ClearWallMaterialList(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Материал отделки стен"
        /// </summary>
        private void AddWallMaterialToList(ComboBox comboBox, WallMaterials wallMaterial, string wallMaterialDescription)
        {
            comboBox.Items.Add(new KeyValuePair<WallMaterials, string>(wallMaterial, wallMaterialDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Материал отделки стен"
        /// </summary>
        private void SetWallMaterialListDisplayMember(ComboBox comboBox, string typeMember)
        {
            comboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Материал отделки стен"
        /// </summary>
        protected void FillWallMaterialList(ComboBox comboBox)
        {
            foreach (WallMaterials wallMaterial in Enum.GetValues(typeof(WallMaterials)))                               // Выполнить для всех элементов перечисления
            {
                AddWallMaterialToList(comboBox, wallMaterial, _apartment.GetWallMaterialAsString(wallMaterial));        // Добавить элемент в список  
            }

            SetWallMaterialListDisplayMember(comboBox, "Value");                                                        // Задать отображаемое поле 
        }

        #endregion

        #region Ceiling material list

        // TODO: Найти способ отключить кирилические символы в именах переменных и методов

        /// <summary>
        /// Метод. Очищает список "Материал отделки потолка"
        /// </summary>
        protected void ClearCeilingMaterialList(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Материал отделки потолка"
        /// </summary>
        private void AddCeilingMaterialToList(ComboBox comboBox, CeilingMaterials ceilingMaterial, string ceilingMaterialDescription)
        {
            comboBox.Items.Add(new KeyValuePair<CeilingMaterials, string>(ceilingMaterial, ceilingMaterialDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Материал отделки потолка"
        /// </summary>
        private void SetCeilingMaterialListDisplayMember(ComboBox comboBox, string typeMember)
        {
            comboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Материал отделки потолка"
        /// </summary>
        protected void FillCeilingMaterialList(ComboBox comboBox)
        {
            foreach (CeilingMaterials ceilingMaterial in Enum.GetValues(typeof(CeilingMaterials)))                                  // Выполнить для всех элементов перечисления
            {
                AddCeilingMaterialToList(comboBox, ceilingMaterial, _apartment.GetCeilingMaterialAsString(ceilingMaterial));        // Добавить элемент в список  
            }

            SetCeilingMaterialListDisplayMember(comboBox, "Value");                                                                 // Задать отображаемое поле 
        }

        #endregion

        #region Object communication list

        /// <summary>
        /// Метод. Очищает список "Подключение к коммуникациям"
        /// </summary>
        protected void ClearObjectCommunicationList()
        {
            objectCommunicationComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Подключение к коммуникациям"
        /// </summary>
        private void AddObjectCommunicationToList(ObjectCommunicationTypes objectCommunication, string objectCommunicationDescription)
        {
            objectCommunicationComboBox.Items.Add(new KeyValuePair<ObjectCommunicationTypes, string>(objectCommunication, objectCommunicationDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Подключение к коммуникациям"
        /// </summary>
        private void SetObjectCommunicationListDisplayMember(string typeMember)
        {
            objectCommunicationComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Подключение к коммуникациям"
        /// </summary>
        protected void FillObjectCommunicationList()
        {
            foreach (ObjectCommunicationTypes objectCommunication in Enum.GetValues(typeof(ObjectCommunicationTypes)))                  // Выполнить для всех элементов перечисления
            {
                AddObjectCommunicationToList(objectCommunication, _apartment.GetObjectCommunicationAsString(objectCommunication));      // Добавить элемент в список  
            }

            SetObjectCommunicationListDisplayMember("Value");                                                                           // Задать отображаемое поле 
        }

        #endregion

        #region Heating system list

        /// <summary>
        /// Метод. Очищает список "Система отопления"
        /// </summary>
        protected void ClearHeatingSystemList()
        {
            heatingSystemComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Система отопления"
        /// </summary>
        private void AddHeatingSystemToList(HeatingSystemTypes heatingSystem, string heatingSystemDescription)
        {
            heatingSystemComboBox.Items.Add(new KeyValuePair<HeatingSystemTypes, string>(heatingSystem, heatingSystemDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Система отопления"
        /// </summary>
        private void SetHeatingSystemListDisplayMember(string typeMember)
        {
            heatingSystemComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Система отопления"
        /// </summary>
        protected void FillHeatingSystemList()
        {
            foreach (HeatingSystemTypes heatingSystem in Enum.GetValues(typeof(HeatingSystemTypes)))            // Выполнить для всех элементов перечисления
            {
                AddHeatingSystemToList(heatingSystem, _apartment.GetHeatingSystemAsString(heatingSystem));      // Добавить элемент в список  
            }

            SetHeatingSystemListDisplayMember("Value");                                                     // Задать отображаемое поле 
        }

        #endregion

        #region Current using list

        /// <summary>
        /// Метод. Очищает список "Текущее использование"
        /// </summary>
        protected void ClearCurrentUsingList()
        {
            currentUsingComboBox.Items.Clear();
        }

        /// <summary>
        /// Метод. Добавляет элемент в список "Текущее использование"
        /// </summary>
        private void AddCurrentUsingToList(CurrentUsingTypes currentUsing, string currentUsingDescription)
        {
            currentUsingComboBox.Items.Add(new KeyValuePair<CurrentUsingTypes, string>(currentUsing, currentUsingDescription));
        }

        /// <summary>
        /// Метод. Задает отображаемое поле для списка "Текущее использование"
        /// </summary>
        private void SetCurrentUsingListDisplayMember(string typeMember)
        {
            currentUsingComboBox.DisplayMember = typeMember;
        }

        /// <summary>
        /// Метод. Заполняет данными список "Текущее использование"
        /// </summary>
        protected void FillCurrentUsingList()
        {
            foreach (CurrentUsingTypes currentUsing in Enum.GetValues(typeof(CurrentUsingTypes)))           // Выполнить для всех элементов перечисления
            {
                AddCurrentUsingToList(currentUsing, _apartment.GetCurrentUsingAsString(currentUsing));      // Добавить элемент в список  
            }

            SetCurrentUsingListDisplayMember("Value");                                                      // Задать отображаемое поле 
        }

        #endregion

        /// <summary>
        /// Метод. Задает активность компонентов
        /// </summary>
        private void SetButtonActivity()
        {
            unlinkHomeButton.Enabled = (_homeAfterRelinking == null) ? false : true;
        }


        #endregion

        #region Controls Event Handlers

        #region Clicks

        /// <summary>
        /// Метод. Связывает выбранный дом с квартирой 
        /// </summary>
        private void relinkHomeButton_Click(object sender, EventArgs e)
        {
            HomeSelectForm homeSelectForm;                                  // Форма выбора дома

                homeSelectForm = new HomeSelectForm(_homes);                // Создать форму выбора дома

                homeSelectForm.ShowDialog();                                // Отобразить форму выбора дома

                if (homeSelectForm.SelectedHome != null)                    // Проверить выбранный дом
                {
                    _homeAfterRelinking = homeSelectForm.SelectedHome;      // Сохранить выбранный дом в поле
                }

                CopyLinkedDataFromEntity();                                 // Скопировать данные из сущностей, связанных с основной сущностью 
        }

        /// <summary>
        /// Метод. Отвязывает квартиру от связанного дома
        /// </summary>
        private void unlinkHomeButton_Click(object sender, EventArgs e)
        {
            DialogResult unlinkConfirm;                         // Результат подтверждения сообщения

            unlinkConfirm = MessageBox.Show(                    // Отобразить окно сообщения с подтверждением и сохранить результат подтверждения
                "Вы действительно хотите отвязать дом?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (unlinkConfirm == DialogResult.Yes)              // Проверить результат подтверждения сообщения
            {
                _homeAfterRelinking  = null;                    // Отвязать квартиру от связанного дома

                CleanCountry();                                 // Очистить данные страны
                CleanRegion();                                  // Очистить данные региона
                CleanDistrict();                                // Очистить данные района
                CleanCity();                                    // Очистить данные города
                CleanStreet();                                  // Очистить данные улицы
                CleanComplex();                                 // Очистить данные комплекса
                CleanHome();                                    // Очистить данные дома

                CopyLinkedDataFromEntity();                     // Скопировать данные из сущностей, связанных с основной сущностью 
            }
        }

        #endregion

        #region DataValidation

        #region NumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void numberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void numberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region FloorTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void floorTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void floorTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region RoomNumberTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void roomNumberTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void roomNumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsInt(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region GrossAreaTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void grossAreaTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void grossAreaTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsSingle(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region LivingAreaTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void livingAreaTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void livingAreaTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsSingle(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region KitchenAreaTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void kitchenAreaTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void kitchenAreaTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsSingle(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #region CeilingHeightTextBox

        /// <summary>
        /// Метод. Сохраняет значение текстового поля для последующего восстановления
        /// </summary>
        private void ceilingHeightTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter((TextBox)sender);      // Сохранить значение текстового поля
        }

        /// <summary>
        /// Метод. Проверяет введенное пользователем тестовое значение и восстанавливает предыдущее при необходимости
        /// </summary>
        private void ceilingHeightTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave((TextBox)sender, p => ValidatorsUtils.IsSingle(((TextBox)sender).Text));      // Проверить значение текстового поля и восстановить при необходимости
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}