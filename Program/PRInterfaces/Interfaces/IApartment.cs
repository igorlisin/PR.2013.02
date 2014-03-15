using System;
using System.Collections.Generic;

using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Квартира
    /// </summary>
    public interface IApartment
    {
        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает номер квартиры
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает этаж 
        /// </summary>
        int Floor { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает этажность дома 
        /// </summary>
        int Floors { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает количество комнат
        /// </summary>
        int RoomNumber { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип комнат
        /// </summary>
        RoomTypes RoomType { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает общую площадь
        /// </summary>
        float GrossArea { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает общую площадь по СНиП
        /// </summary>
        float GrossAreaSNIP { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает жилую площадь
        /// </summary>
        float LivingArea { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает площадь кухни
        /// </summary>
        float KitchenArea { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие отдельных от других квартин кухни и санузла
        /// </summary>
        bool HasSeparateKitchenOrWashroom { get; set; }
        
        /// <summary>
        /// Свойство. Задает и возвращает наличие балкона/лоджии
        /// </summary>
        bool HasBalconyOrLoggia { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип санузлов
        /// </summary>
        WashroomTypes WashroomType { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает высоту потолков
        /// </summary>
        float CeilingHeight { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает вид из окна
        /// </summary>
        string Views { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает планировку
        /// </summary>
        Layouts Layout { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает вспомогательные помещения и площадь
        /// </summary>
        string AuxiliaryRooms { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает состояние квартиры
        /// </summary>
        ApartmentStates ApartmentState { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает необходимые ремонтные работы
        /// </summary>
        RepairWorkTypes RepairWork { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает качество отделки помещения
        /// </summary>
        RoomFinishingQualities RoomFinishingQuality { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в жилых комнатах
        /// </summary>
        FloorMaterials FinishingMaterialForLivingRoomFloor { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в жилых комнатах
        /// </summary>
        WallMaterials FinishingMaterialForLivingRoomWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в жилых комнатах
        /// </summary>
        CeilingMaterials FinishingMaterialForLivingRoomCeiling { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в коридоре
        /// </summary>
        FloorMaterials FinishingMaterialForHallFloor { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в коридоре
        /// </summary>
        WallMaterials FinishingMaterialForHallWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в коридоре
        /// </summary>
        CeilingMaterials FinishingMaterialForHallCeiling { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола на кухне
        /// </summary>
        FloorMaterials FinishingMaterialForKitchenFloor { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен на кухне
        /// </summary>
        WallMaterials FinishingMaterialForKitchenWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка на кухне
        /// </summary>
        CeilingMaterials FinishingMaterialForKitchenCeiling { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в санузле
        /// </summary>
        FloorMaterials FinishingMaterialForWashroomFloor { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в санузле
        /// </summary>
        WallMaterials FinishingMaterialForWashroomWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в санузле
        /// </summary>
        CeilingMaterials FinishingMaterialForWashroomCeiling { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип подключения к коммуникациям
        /// </summary>
        ObjectCommunicationTypes ObjectCommunication { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает систему отопления
        /// </summary>
        HeatingSystemTypes HeatingSystem { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие слаботочного обеспечения
        /// </summary>
        bool HasLowCurrent { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие оборудования для систем коммуникаций и слаботочного обеспечения
        /// </summary>
        bool HasDevices { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает соответствие планировки квартиры поэтажносу плану БТИ и наличие переоборудований
        /// </summary>
        string PlanMeets { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
        /// </summary>
        string ViewOnApparment { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает текущее использование
        /// </summary>
        CurrentUsingTypes CurrentUsing { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает комментарии к фотографиям
        /// </summary>
        string PicturesComment { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>
        IObject Object { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дом
        /// </summary>
        IHome Home { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Метод. Возвращает тип комнат как тестовую строку
        /// </summary>
        string GetRoomTypeAsString(RoomTypes roomType);

        /// <summary>
        /// Метод. Возвращает тип санузлов как тестовую строку
        /// </summary>
        string GetWashroomTypeAsString(WashroomTypes washroomType);

        /// <summary>
        /// Метод. Возвращает планировку как тестовую строку
        /// </summary>
        string GetLayoutAsString(Layouts layout);

        /// <summary>
        /// Метод. Возвращает состояние квартиры как тестовую строку
        /// </summary>
        string GetApartmentStateAsString(ApartmentStates apartmentState);

        /// <summary>
        /// Метод. Возвращает необходимые ремонтные работы как текстовую строку
        /// </summary>
        string GetRepairWorkAsString(RepairWorkTypes repairWorkType);

        /// <summary>
        /// Метод. Возвращает качество отделки помещения как текстовую строку
        /// </summary>
        string GetRoomFinishingQualityAsString(RoomFinishingQualities roomFinishingQuality);

        /// <summary>
        /// Метод. Возвращает материал отделки пола как тестовую строку
        string GetFloorMaterialAsString(FloorMaterials floorMaterial);

        /// <summary>
        /// Метод. Возвращает материал отделки стен как тестовую строку
        string GetWallMaterialAsString(WallMaterials wallMaterial);

        /// <summary>
        /// Метод. Возвращает материал отделки потолка как тестовую строку
        string GetCeilingMaterialAsString(CeilingMaterials ceilingMaterial);

        /// <summary>
        /// Метод. Возвращает подключение к коммуникациям как текстовую строку
        /// </summary>
        string GetObjectCommunicationAsString(ObjectCommunicationTypes objectCommunicationType);
        
        /// <summary>
        /// Метод. Возвращает систему отопления как текстовую строку
        /// </summary>
        string GetHeatingSystemAsString(HeatingSystemTypes heatingSystemType);

        /// <summary>
        /// Метод. Возвращает текущее использование как текстовую строку
        /// <returns></returns>
        string GetCurrentUsingAsString(CurrentUsingTypes currentUsingType);

        #endregion
    }
}
