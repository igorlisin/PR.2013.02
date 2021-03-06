﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Квартира
    /// </summary>
    public class Apartment : Entity, IApartment
    {
        #region Static Methods

        /// <summary>
        /// Статический метод. Преобразует объект типа IApartment в объект типа Apartment
        /// </summary>
        public static Apartment IApartmentToApartmentConverter(IApartment apartment)
        {
            return ((Apartment)apartment);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Apartment в объект типа IApartment
        /// </summary>
        public static IApartment ApartmentToIApartmentConverter(Apartment apartment)
        {
            return ((IApartment)apartment);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Picture в объект типа IPicture
        /// </summary>
        public static IPicture PictureToIPictureConverter(Picture picture)
        {
            return ((IPicture)picture);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Picture в объект типа IPicture
        /// </summary>
        public static Picture IPictureToPictureConverter(IPicture picture)
        {
            return ((Picture)picture);
        }

        /// <summary>
        /// Статический метод. Возвращает тип комнат как тестовую строку
        /// </summary>
        public static string GetRoomTypeAsStringStatic(RoomTypes roomType)
        {
            string roomTypeAsString;                                // Тип (как тескстовая строка)

            switch (roomType)                                       // Проверить тип
            {
                case RoomTypes.Separate:                            // Сравнить тип 
                    roomTypeAsString = "Раздельные комнаты";        // Задать тип (как текстовую строку)
                    break;
                case RoomTypes.Union:                               // Сравнить тип 
                    roomTypeAsString = "Совмещенные комнаты";       // Задать тип (как текстовую строку)
                    break;
                case RoomTypes.SeparateThrough:                               // Сравнить тип 
                    roomTypeAsString = "Раздельные и проходные комнаты";       // Задать тип (как текстовую строку)
                    break;
                case RoomTypes.Through:                               // Сравнить тип 
                    roomTypeAsString = "Проходные комнаты";       // Задать тип (как текстовую строку)
                    break;
                case RoomTypes.Free:                               // Сравнить тип 
                    roomTypeAsString = "Свободная планировка";       // Задать тип (как текстовую строку)
                    break;
                default:                                            // Тип по умолчанию 
                    roomTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (roomTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает тип санузла как тестовую строку
        /// </summary>
        public static string GetWashroomTypeAsStringStatic(WashroomTypes washroomType)
        {
            string washroomTypeAsString;                                // Тип (как тескстовая строка)

            switch (washroomType)                                       // Проверить тип
            {
                case WashroomTypes.Separate:                            // Сравнить тип 
                    washroomTypeAsString = "Раздельный санузел";        // Задать тип (как текстовую строку)
                    break;
                case WashroomTypes.Union:                               // Сравнить тип 
                    washroomTypeAsString = "Совмещенный санузел";       // Задать тип (как текстовую строку)
                    break;
                case WashroomTypes.Other:                               // Сравнить тип 
                    washroomTypeAsString = "ПРОЧЕЕ!!!!!!!!";       // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    washroomTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (washroomTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает планировку как тестовую строку
        /// </summary>
        public static string GetLayoutAsStringStatic(Layouts layout)
        {
            string layoutAsString;                                  // Тип (как тескстовая строка)

            switch (layout)                                         // Проверить тип
            {
                case Layouts.Standard:                              // Сравнить тип 
                    layoutAsString = "Стандартная планировка";      // Задать тип (как текстовую строку)
                    break;
                case Layouts.Individual:                              // Сравнить тип 
                    layoutAsString = "Индивидуальная планировка";      // Задать тип (как текстовую строку)
                    break;
                default:                                            // Тип по умолчанию 
                    layoutAsString = "--";                          // Задать тип (как текстовую строку)
                    break;
            }

            return (layoutAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает состояние квартиры как тестовую строку
        /// </summary>
        public static string GetApartmentStateAsStringStatic(ApartmentStates apartmentState)
        {
            string apartmentStateAsString;                          // Тип (как тескстовая строка)

            switch (apartmentState)                                 // Проверить тип
            {
                case ApartmentStates.Perfect:                       // Сравнить тип 
                    apartmentStateAsString = "Отличное";           // Задать тип (как текстовую строку)
                    break;
                case ApartmentStates.Good:                          // Сравнить тип 
                    apartmentStateAsString = "Хорошее";             // Задать тип (как текстовую строку)
                    break;
                case ApartmentStates.Normal:                        // Сравнить тип 
                    apartmentStateAsString = "Удовлетворительное";          // Задать тип (как текстовую строку)
                    break;
                case ApartmentStates.Bad:                           // Сравнить тип 
                    apartmentStateAsString = "Неудовлетворительное";              // Задать тип (как текстовую строку)
                    break;
                case ApartmentStates.New:                           // Сравнить тип 
                    apartmentStateAsString = "Новая квартира";              // Задать тип (как текстовую строку)
                    break;
                default:                                            // Тип по умолчанию 
                    apartmentStateAsString = "--";                  // Задать тип (как текстовую строку)
                    break;
            }

            return (apartmentStateAsString);
        }

        /// <summary>
        /// Метод. Возвращает необходимые ремонтные работы как текстовую строку
        /// </summary>
        public static string GetRepairWorkAsStringStatic(RepairWorkTypes repairWorkType)
        {
            string repairWorkAsString;                                          // Тип (как тескстовая строка)

            switch (repairWorkType)                                             // Проверить тип
            {
                case RepairWorkTypes.NeedCosmetic:                                      // Сравнить тип 
                    repairWorkAsString = "Требуются косметический ремонт";          // Задать тип (как текстовую строку)
                    break;
                case RepairWorkTypes.NeedTotal:                                      // Сравнить тип 
                    repairWorkAsString = "Требуются капитальный ремонт";          // Задать тип (как текстовую строку)
                    break;
                case RepairWorkTypes.NeedPartial:                                      // Сравнить тип 
                    repairWorkAsString = "Требуются ремонт отдельных конструктивных элементов";          // Задать тип (как текстовую строку)
                    break;
                case RepairWorkTypes.NeedClear:                                      // Сравнить тип 
                    repairWorkAsString = "Требуются работы по выполнению чистовой отделки";          // Задать тип (как текстовую строку)
                    break;
                case RepairWorkTypes.NotNeed:                                   // Сравнить тип 
                    repairWorkAsString = "Ремонтные работы не требуются";       // Задать тип (как текстовую строку)
                    break;
                case RepairWorkTypes.Other:                                   // Сравнить тип 
                    repairWorkAsString = "ПРОЧЕЕ!!!!!!!!";       // Задать тип (как текстовую строку)
                    break;
                default:                                                        // Тип по умолчанию 
                    repairWorkAsString = "--";                                  // Задать тип (как текстовую строку)
                    break;
            }

            return (repairWorkAsString);
        }

        /// <summary>
        /// Метод. Возвращает качество отделки помещения как текстовую строку
        /// </summary>
        public static string GetRoomFinishingQualityAsStringStatic(RoomFinishingQualities roomFinishingQuality)
        {
            string roomFinishingQualityAsString;                        // Тип (как тескстовая строка)

            switch (roomFinishingQuality)                               // Проверить тип
            {
                case RoomFinishingQualities.Premium:                    // Сравнить тип 
                    roomFinishingQualityAsString = "Премиум";         // Задать тип (как текстовую строку)
                    break;
                case RoomFinishingQualities.Better:                       // Сравнить тип 
                    roomFinishingQualityAsString = "Улучшенная";           // Задать тип (как текстовую строку)
                    break;
                case RoomFinishingQualities.Standart:                     // Сравнить тип 
                    roomFinishingQualityAsString = "Стандартная";        // Задать тип (как текстовую строку)
                    break;
                case RoomFinishingQualities.Simple:                        // Сравнить тип 
                    roomFinishingQualityAsString = "Обычная";            // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    roomFinishingQualityAsString = "--";                // Задать тип (как текстовую строку)
                    break;
            }

            return (roomFinishingQualityAsString);
        }

        /// <summary>
        /// Метод. Возвращает материал отделки пола как тестовую строку
        public static string GetFloorMaterialAsStringStatic(FloorMaterials floorMaterial)
        {
            string floorMaterialAsString;                   // Тип (как тескстовая строка)

            switch (floorMaterial)                          // Проверить тип
            {
                case FloorMaterials.Laminate:               // Сравнить тип 
                    floorMaterialAsString = "Ламинат";      // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.Linoleum:               // Сравнить тип 
                    floorMaterialAsString = "Линолеум";     // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.NoFinishing:                  // Сравнить тип 
                    floorMaterialAsString = "Бетонная стяжка";       // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.Parquet:                // Сравнить тип 
                    floorMaterialAsString = "Паркет";       // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.Kovrolin:                // Сравнить тип 
                    floorMaterialAsString = "Ковролин";       // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.Tile:                   // Сравнить тип 
                    floorMaterialAsString = "Керамическая плитка";       // Задать тип (как текстовую строку)
                    break;
                case FloorMaterials.Other:                   // Сравнить тип 
                    floorMaterialAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                    // Тип по умолчанию 
                    floorMaterialAsString = "--";           // Задать тип (как текстовую строку)
                    break;
            }

            return (floorMaterialAsString);
        }

        /// <summary>
        /// Метод. Возвращает материал отделки стен как тестовую строку
        public static string GetWallMaterialAsStringStatic(WallMaterials wallMaterial)
        {
            string wallMaterialAsString;                        // Тип (как тескстовая строка)

            switch (wallMaterial)                               // Проверить тип
            {
                case WallMaterials.Paint:                       // Сравнить тип 
                    wallMaterialAsString = "Краска";            // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.Wallpaper:                   // Сравнить тип 
                    wallMaterialAsString = "Обои";              // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.Tile:                        // Сравнить тип 
                    wallMaterialAsString = "Плитка";            // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.WallpaperAndTile:            // Сравнить тип 
                    wallMaterialAsString = "Обои и плитка";     // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.PaintAndTile:            // Сравнить тип 
                    wallMaterialAsString = "Краска и плитка";     // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.PVH:            // Сравнить тип 
                    wallMaterialAsString = "Панели ПВХ";     // Задать тип (как текстовую строку)
                    break;
                case WallMaterials.Other:                   // Сравнить тип 
                    wallMaterialAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                        // Тип по умолчанию 
                    wallMaterialAsString = "--";                // Задать тип (как текстовую строку)
                    break;
            }

            return (wallMaterialAsString);
        }

        /// <summary>
        /// Метод. Возвращает материал отделки потолка как тестовую строку
        public static string GetCeilingMaterialAsStringStatic(CeilingMaterials ceilingMaterial)
        {
            string ceilingMaterialAsString;                             // Тип (как тескстовая строка)

            switch (ceilingMaterial)                                    // Проверить тип
            {
                case CeilingMaterials.Paint:                            // Сравнить тип 
                    ceilingMaterialAsString = "Краска";                 // Задать тип (как текстовую строку)
                    break;
                case CeilingMaterials.Whitewash:                        // Сравнить тип 
                    ceilingMaterialAsString = "Побелка";                // Задать тип (как текстовую строку)
                    break;
                case CeilingMaterials.CeilingTiles:                     // Сравнить тип 
                    ceilingMaterialAsString = "Потолочная плитка";      // Задать тип (как текстовую строку)
                    break;
                case CeilingMaterials.Wallpaper:                     // Сравнить тип 
                    ceilingMaterialAsString = "Обои";      // Задать тип (как текстовую строку)
                    break;
                case CeilingMaterials.PVH:                     // Сравнить тип 
                    ceilingMaterialAsString = "Панели ПВХ";      // Задать тип (как текстовую строку)
                    break;
                case CeilingMaterials.Other:                   // Сравнить тип 
                    ceilingMaterialAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    ceilingMaterialAsString = "--";                     // Задать тип (как текстовую строку)
                    break;
            }

            return (ceilingMaterialAsString);
        }

        /// <summary>
        /// Метод. Возвращает подключение к коммуникациям как текстовую строку
        /// </summary>
        public static string GetObjectCommunicationAsStringStatic(ObjectCommunicationTypes objectCommunicationType)
        {
            string objectCommunicationTypeAsString;                         // Тип (как тескстовая строка)

            switch (objectCommunicationType)                                // Проверить тип
            {
                case ObjectCommunicationTypes.Connected:                    // Сравнить тип 
                    objectCommunicationTypeAsString = "Подключен";          // Задать тип (как текстовую строку)
                    break;
                case ObjectCommunicationTypes.NotConnected:                 // Сравнить тип 
                    objectCommunicationTypeAsString = "Не подключен";       // Задать тип (как текстовую строку)
                    break;
                case ObjectCommunicationTypes.Other:                   // Сравнить тип 
                    objectCommunicationTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                    // Тип по умолчанию 
                    objectCommunicationTypeAsString = "--";                 // Задать тип (как текстовую строку)
                    break;
            }

            return (objectCommunicationTypeAsString);
        }

        /// <summary>
        /// Метод. Возвращает систему отопления как текстовую строку
        /// </summary>
        public static string GetHeatingSystemAsStringStatic(HeatingSystemTypes heatingSystemType)
        {
            string heatingSystemTypeAsString;                       // Тип (как тескстовая строка)

            switch (heatingSystemType)                              // Проверить тип
            {
                case HeatingSystemTypes.Central:                    // Сравнить тип 
                    heatingSystemTypeAsString = "Центральное";      // Задать тип (как текстовую строку)
                    break;
                case HeatingSystemTypes.Home:                    // Сравнить тип 
                    heatingSystemTypeAsString = "От общедомового газового котла";      // Задать тип (как текстовую строку)
                    break;
                case HeatingSystemTypes.Other:                   // Сравнить тип 
                    heatingSystemTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                            // Тип по умолчанию 
                    heatingSystemTypeAsString = "--";               // Задать тип (как текстовую строку)
                    break;
            }

            return (heatingSystemTypeAsString);
        }

        /// <summary>
        /// Метод. Возвращает текущее использование как текстовую строку
        /// <returns></returns>
        public static string GetCurrentUsingAsStringStatic(CurrentUsingTypes currentUsingType)
        {
            string currentUsingTypeAsString;                        // Тип (как тескстовая строка)

            switch (currentUsingType)                               // Проверить тип
            {
                case CurrentUsingTypes.LivingAppartment:            // Сравнить тип 
                    currentUsingTypeAsString = "Жилая квартира";    // Задать тип (как текстовую строку)
                    break;
                case CurrentUsingTypes.Other:                   // Сравнить тип 
                    currentUsingTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                            // Тип по умолчанию 
                    currentUsingTypeAsString = "--";                // Задать тип (как текстовую строку)
                    break;
            }

            return (currentUsingTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает тип окон как тестовую строку
        /// </summary>
        public static string GetWindowsTypeAsStringStatic(Windows WindowsType)
        {
            string WindowsTypeAsString;                                // Тип (как тескстовая строка)

            switch (WindowsType)                                       // Проверить тип
            {
                case Windows.Wood:                                      // Сравнить тип 
                    WindowsTypeAsString = "Деревянные простые";        // Задать тип (как текстовую строку)
                    break;
                case Windows.Euro:                                     // Сравнить тип 
                    WindowsTypeAsString = "Деревянные улучшенные";       // Задать тип (как текстовую строку)
                    break;
                case Windows.Plastic:                                     // Сравнить тип 
                    WindowsTypeAsString = "ПВХ-профиль";       // Задать тип (как текстовую строку)
                    break;
                case Windows.Aluminium:                                     // Сравнить тип 
                    WindowsTypeAsString = "Алюминевый профиль";       // Задать тип (как текстовую строку)
                    break;
                case Windows.Other:                   // Сравнить тип 
                    WindowsTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    WindowsTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (WindowsTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает тип дверей как тестовую строку
        /// </summary>
        public static string GetDoorsTypeAsStringStatic(Doors DoorsType)
        {
            string DoorsTypeAsString;                                // Тип (как тескстовая строка)

            switch (DoorsType)                                       // Проверить тип
            {
                case Doors.Wood:                                      // Сравнить тип 
                    DoorsTypeAsString = "Деревянные";        // Задать тип (как текстовую строку)
                    break;
                case Doors.Fil:                                     // Сравнить тип 
                    DoorsTypeAsString = "Филенчатые";       // Задать тип (как текстовую строку)
                    break;
                case Doors.MetalAndWood:                                     // Сравнить тип 
                    DoorsTypeAsString = "Двойная – деревянная и металлическая";       // Задать тип (как текстовую строку)
                    break;
                case Doors.Metal:                                     // Сравнить тип 
                    DoorsTypeAsString = "Металлодеревянная";       // Задать тип (как текстовую строку)
                    break;
                case Doors.Plastic:                                     // Сравнить тип 
                    DoorsTypeAsString = "Пластиковые";       // Задать тип (как текстовую строку)
                    break;
                case Doors.Other:                   // Сравнить тип 
                    DoorsTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    DoorsTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (DoorsTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает тип дверей как тестовую строку
        /// </summary>
        public static string GetPipesTypeAsStringStatic(Pipes PipesType)
        {
            string PipesTypeAsString;                                // Тип (как тескстовая строка)

            switch (PipesType)                                       // Проверить тип
            {
                case Pipes.MetalPlastic:                                      // Сравнить тип 
                    PipesTypeAsString = "Металлопластиковые";        // Задать тип (как текстовую строку)
                    break;
                case Pipes.Plastic:                                     // Сравнить тип 
                    PipesTypeAsString = "Полипропиленовые";       // Задать тип (как текстовую строку)
                    break;
                case Pipes.Metal:                                     // Сравнить тип 
                    PipesTypeAsString = "Металлические";       // Задать тип (как текстовую строку)
                    break;
                case Pipes.Other:                   // Сравнить тип 
                    PipesTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    PipesTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (PipesTypeAsString);
        }

        /// <summary>
        /// Статический метод. Возвращает тип радиаторов как тестовую строку
        /// </summary>
        public static string GetHeaterTypeAsStringStatic(Heaters HeatersType)
        {
            string HeaterTypeAsString;                                // Тип (как тескстовая строка)

            switch (HeatersType)                                       // Проверить тип
            {
                case Heaters.Iron:                                      // Сравнить тип 
                    HeaterTypeAsString = "Чугунные";        // Задать тип (как текстовую строку)
                    break;
                case Heaters.Alumin:                                     // Сравнить тип 
                    HeaterTypeAsString = "Алюминиевые";       // Задать тип (как текстовую строку)
                    break;
                case Heaters.Steel:                                     // Сравнить тип 
                    HeaterTypeAsString = "Стальные";       // Задать тип (как текстовую строку)
                    break;
                case Heaters.Other:                   // Сравнить тип 
                    HeaterTypeAsString = "ПРОЧЕЕ!!!!!!!!";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    HeaterTypeAsString = "--";                        // Задать тип (как текстовую строку)
                    break;
            }

            return (HeaterTypeAsString);
        }

        /// <summary>
        /// Метод. Возвращает качество отделки помещения как текстовую строку
        /// </summary>
        public static string GetConditionAsStringStatic(Condition condition)
        {
            string conditionAsString;                        // Тип (как тескстовая строка)

            switch (condition)                               // Проверить тип
            {
                case Condition.Perfect:                    // Сравнить тип 
                    conditionAsString = "Отличное";         // Задать тип (как текстовую строку)
                    break;
                case Condition.Good:                       // Сравнить тип 
                    conditionAsString = "Хорошее";           // Задать тип (как текстовую строку)
                    break;
                case Condition.Normal:                     // Сравнить тип 
                    conditionAsString = "Удовлетворительное";        // Задать тип (как текстовую строку)
                    break;
                case Condition.Bad:                        // Сравнить тип 
                    conditionAsString = "Неудовлетворительное";            // Задать тип (как текстовую строку)
                    break;
                case Condition.New:                   // Сравнить тип 
                    conditionAsString = "Новая квартира";           // Задать тип (как текстовую строку)
                    break;
                default:                                                // Тип по умолчанию 
                    conditionAsString = "--";                // Задать тип (как текстовую строку)
                    break;
            }

            return (conditionAsString);
        }

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Номер квартиры
        /// </summary>
        private int _number;

        /// <summary>
        /// Поле. Этаж
        /// </summary>
        private int _floor;

        /// <summary>
        /// Поле. Количество комнат
        /// </summary>
        private int _roomNumber;

        /// <summary>
        /// Поле. Тип комнат
        /// </summary>
        private RoomTypes _roomType;

        /// <summary>
        /// Поле. Общая площадь
        /// </summary>
        private float _grossArea;

        /// <summary>
        /// Поле. Общая площадь по СНИП
        /// </summary>
        private float _grossAreaSNIP;

        /// <summary>
        /// Поле. Жилая площадь
        /// </summary>
        private float _livingArea;

        /// <summary>
        /// Поле. Площадь кухни
        /// </summary>
        private float _kitchenArea;

        /// <summary>
        /// Поле. Наличие отдельных от других квартир кухни и санузла
        /// </summary>
        private bool _hasSeparateKitchenOrWashroom;

        /// <summary>
        /// Поле. Наличие балкона/лоджии
        /// </summary>
        private bool _hasBalconyOrLoggia;

        /// <summary>
        /// Поле. Тип санузлов
        /// </summary>
        private WashroomTypes _washroomType;

        /// <summary>
        /// Поле. Высота потолков
        /// </summary>
        private float _ceilingHeight;

        /// <summary>
        /// Поле. Вид из окна
        /// </summary>
        private string _views;

        /// <summary>
        /// Поле. Планировка
        /// </summary>
        private Layouts _layout;

        /// <summary>
        /// Поле. Вспомогательные помещения и площадь
        /// </summary>
        private string _auxiliaryRooms;

        /// <summary>
        /// Поле. Состояние квартиры
        /// </summary>
        private ApartmentStates _apartmentState;

        /// <summary>
        /// Поле. Необходимые ремонтные работы
        /// </summary>
        private RepairWorkTypes _repairWork;

        /// <summary>
        /// Поле. Качество отделки помещения
        /// </summary>
        private RoomFinishingQualities _roomFinishingQuality;

        /// <summary>
        /// Поле. Материал отделки пола в жилых комнатах
        /// </summary>
        private FloorMaterials _finishingMaterialForLivingRoomFloor;

        /// <summary>
        /// Поле. Материал отделки стен в жилых комнатах
        /// </summary>
        private WallMaterials _finishingMaterialForLivingRoomWall;

        /// <summary>
        /// Поле. Материал отделки потолка в жилых комнатах
        /// </summary>
        private CeilingMaterials _finishingMaterialForLivingRoomCeiling;

        /// <summary>
        /// Поле. Материал отделки пола в коридоре
        /// </summary>
        private FloorMaterials _finishingMaterialForHallFloor;

        /// <summary>
        /// Поле. Материал отделки стен в коридоре
        /// </summary>
        private WallMaterials _finishingMaterialForHallWall;

        /// <summary>
        /// Поле. Материал отделки потолка в коридоре
        /// </summary>
        private CeilingMaterials _finishingMaterialForHallCeiling;

        /// <summary>
        /// Поле. Материал отделки пола на кухне
        /// </summary>
        private FloorMaterials _finishingMaterialForKitchenFloor;

        /// <summary>
        /// Поле. Материал отделки стен на кухне
        /// </summary>
        private WallMaterials _finishingMaterialForKitchenWall;

        /// <summary>
        /// Поле. Материал отделки потолка на кухне
        /// </summary>
        private CeilingMaterials _finishingMaterialForKitchenCeiling;

        /// <summary>
        /// Поле. Материал отделки пола в санузле
        /// </summary>
        private FloorMaterials _finishingMaterialForWashroomFloor;

        /// <summary>
        /// Поле. Материал отделки стен в санузле
        /// </summary>
        private WallMaterials _finishingMaterialForWashroomWall;

        /// <summary>
        /// Поле. Материал отделки потолка в санузле
        /// </summary>
        private CeilingMaterials _finishingMaterialForWashroomCeiling;

        /// <summary>
        /// Поле. Подключение к коммуникациям
        /// </summary>
        private ObjectCommunicationTypes _objectCommunication;

        /// <summary>
        /// Поле. Система отопления
        /// </summary>
        private HeatingSystemTypes _heatingSystem;

        /// <summary>
        /// Поле. Наличие слаботочного обеспечения
        /// </summary>
        private bool _hasLowCurrent;

        /// <summary>
        /// Поле. Наличие оборудования для систем коммуникаций и слаботочного обеспечения
        /// </summary>
        private bool _hasDevices;

        /// <summary>
        /// Поле. Соответствие планировки квартиры поэтажному плану БТИ и наличие переоборудований
        /// </summary>
        private string _planMeets;

        /// <summary>
        /// Поле. Мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
        /// </summary>
        private string _viewOnApparment;

        /// <summary>
        /// Поле. Текущее использование
        /// </summary>
        private CurrentUsingTypes _currentUsing;

        /// <summary>
        /// Поле. Комментарии к фотографиям
        /// </summary>
        private string _picturesComment;


        /// <summary>
        /// Поле. Задает и возвращает материал отделки пола 
        /// </summary>
        private FloorMaterials _finishingMaterialForFloors;

        /// <summary>
        /// Поле. Задает и возвращает состояние дверей
        /// </summary>
        private Condition _doorsCondition;

        /// <summary>
        /// Поле. Задает и возвращает состояние отополения
        /// </summary>
        private Condition _heatingCondition;

        /// <summary>
        /// Поле. Задает и возвращает состояние канализации
        /// </summary>
        private Condition _canaliztionCondition;

        /// <summary>
        /// Поле. Задает и возвращает состояние водоснабжения
        /// </summary>
        private Condition _waterCondition;

        /// <summary>
        /// Поле. Задает и возвращает состояние окон
        /// </summary>
        private Condition _windowsCondition;

        /// <summary>
        /// Поле. Задает и возвращает количество санузлов
        /// </summary>
        private string _sanuzelQnt;

        /// <summary>
        /// Поле. Задает и возвращает тип труб отопления 
        /// </summary>
        private Pipes _heatingPipesType;

        /// <summary>
        /// Поле. Задает и возвращает тип труб водоснабжения
        /// </summary>
        private Pipes _waterPipesType;

        /// <summary>
        /// Поле. Задает и возвращает тип труб канализации
        /// </summary>
        private Pipes _canalizationPipesType;

        /// <summary>
        /// Поле. Задает и возвращает тип входной двери
        /// </summary>
        private Doors _mainDoorType;

        /// <summary>
        /// Поле. Задает и возвращает тип межкомнатных дверей
        /// </summary>
        private Doors _roomDoorsType;

        /// <summary>
        /// Поле. Задает и возвращает тип радиаторов
        /// </summary>
        private Heaters _heatersType;

        /// <summary>
        /// Поле. Задает и возвращает тип окон
        /// </summary>
        private Windows _windowsType;

        /// <summary>
        /// Поле. Задает и возвращает приборы 
        /// </summary>
        private string _counters;

        /// <summary>
        /// Поле. Задает и возвращает наличие домофона 
        /// </summary>
        private bool _domofon;

        /// <summary>
        /// Свойство. Задает и возвращает число квартир на этаже
        /// </summary>
        private string _flatsOnFloor;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает номер квартиры
        /// </summary>
        public int Number
        {
            get
            {
                return (_number);
            }
            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает этаж 
        /// </summary>
        public int Floor
        {
            get
            {
                return (_floor);
            }
            set
            {
                _floor = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает количество комнат
        /// </summary>
        public int RoomNumber
        {
            get
            {
                return (_roomNumber);
            }
            set
            {
                _roomNumber = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип комнат
        /// </summary>
        public RoomTypes RoomType
        {
            get
            {
                return (_roomType);
            }
            set
            {
                _roomType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает общую площадь
        /// </summary>
        public float GrossArea
        {
            get
            {
                return (_grossArea);
            }
            set
            {
                _grossArea = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает общую площадь по СНИП
        /// </summary>
        public float GrossAreaSNIP
        {
            get
            {
                return (_grossAreaSNIP);
            }
            set
            {
                _grossAreaSNIP = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает жилую площадь
        /// </summary>
        public float LivingArea
        {
            get
            {
                return (_livingArea);
            }
            set
            {
                _livingArea = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает площадь кухни
        /// </summary>
        public float KitchenArea
        {
            get
            {
                return (_kitchenArea);
            }
            set
            {
                _kitchenArea = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие отдельных от других квартир кухни и санузла
        /// </summary>
        public bool HasSeparateKitchenOrWashroom
        {
            get
            {
                return (_hasSeparateKitchenOrWashroom);
            }
            set
            {
                _hasSeparateKitchenOrWashroom = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие балкона/лоджии
        /// </summary>
        public bool HasBalconyOrLoggia
        {
            get
            {
                return (_hasBalconyOrLoggia);
            }
            set
            {
                _hasBalconyOrLoggia = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип санузлов
        /// </summary>
        public WashroomTypes WashroomType
        {
            get
            {
                return (_washroomType);
            }
            set
            {
                _washroomType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает высоту потолков
        /// </summary>
        public float CeilingHeight
        {
            get
            {
                return (_ceilingHeight);
            }
            set
            {
                _ceilingHeight = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает вид из окна
        /// </summary>
        public string Views
        {
            get
            {
                return (_views);
            }
            set
            {
                _views = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает планировку
        /// </summary>
        public Layouts Layout
        {
            get
            {
                return (_layout);
            }
            set
            {
                _layout = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает вспомогательные помещения и площадь
        /// </summary>
        public string AuxiliaryRooms
        {
            get
            {
                return (_auxiliaryRooms);
            }
            set
            {
                _auxiliaryRooms = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние квартиры
        /// </summary>
        public ApartmentStates ApartmentState
        {
            get
            {
                return (_apartmentState);
            }
            set
            {
                _apartmentState = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает необходимые ремонтные работы
        /// </summary>
        public RepairWorkTypes RepairWork
        {
            get
            {
                return (_repairWork);
            }
            set
            {
                _repairWork = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает качество отделки помещения
        /// </summary>
        public RoomFinishingQualities RoomFinishingQuality
        {
            get
            {
                return (_roomFinishingQuality);
            }
            set
            {
                _roomFinishingQuality = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в жилых комнатах
        /// </summary>
        public FloorMaterials FinishingMaterialForLivingRoomFloor
        {
            get
            {
                return (_finishingMaterialForLivingRoomFloor);
            }
            set
            {
                _finishingMaterialForLivingRoomFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в жилых комнатах
        /// </summary>
        public WallMaterials FinishingMaterialForLivingRoomWall
        {
            get
            {
                return (_finishingMaterialForLivingRoomWall);
            }
            set
            {
                _finishingMaterialForLivingRoomWall = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в жилых комнатах
        /// </summary>
        public CeilingMaterials FinishingMaterialForLivingRoomCeiling
        {
            get
            {
                return (_finishingMaterialForLivingRoomCeiling);
            }
            set
            {
                _finishingMaterialForLivingRoomCeiling = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в коридоре
        /// </summary>
        public FloorMaterials FinishingMaterialForHallFloor
        {
            get
            {
                return (_finishingMaterialForHallFloor);
            }
            set
            {
                _finishingMaterialForHallFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в коридоре
        /// </summary>
        public WallMaterials FinishingMaterialForHallWall
        {
            get
            {
                return (_finishingMaterialForHallWall);
            }
            set
            {
                _finishingMaterialForHallWall = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в коридоре
        /// </summary>
        public CeilingMaterials FinishingMaterialForHallCeiling
        {
            get
            {
                return (_finishingMaterialForHallCeiling);
            }
            set
            {
                _finishingMaterialForHallCeiling = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола на кухне
        /// </summary>
        public FloorMaterials FinishingMaterialForKitchenFloor
        {
            get
            {
                return (_finishingMaterialForKitchenFloor);
            }
            set
            {
                _finishingMaterialForKitchenFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен на кухне
        /// </summary>
        public WallMaterials FinishingMaterialForKitchenWall
        {
            get
            {
                return (_finishingMaterialForKitchenWall);
            }
            set
            {
                _finishingMaterialForKitchenWall = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка на кухне
        /// </summary>
        public CeilingMaterials FinishingMaterialForKitchenCeiling
        {
            get
            {
                return (_finishingMaterialForKitchenCeiling);
            }
            set
            {
                _finishingMaterialForKitchenCeiling = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола в санузле
        /// </summary>
        public FloorMaterials FinishingMaterialForWashroomFloor
        {
            get
            {
                return(_finishingMaterialForWashroomFloor);
            }
            set
            {
                _finishingMaterialForWashroomFloor = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки стен в санузле
        /// </summary>
        public WallMaterials FinishingMaterialForWashroomWall
        {
            get
            {
                return (_finishingMaterialForWashroomWall);
            }
            set
            {
                _finishingMaterialForWashroomWall = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает материал отделки потолка в санузле
        /// </summary>
        public CeilingMaterials FinishingMaterialForWashroomCeiling
        {
            get
            {
                return (_finishingMaterialForWashroomCeiling);
            }
            set
            {
                _finishingMaterialForWashroomCeiling = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает подключение к коммуникациям
        /// </summary>
        public ObjectCommunicationTypes ObjectCommunication
        {
            get
            {
                return (_objectCommunication);
            }
            set
            {
                _objectCommunication = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает систему отопления
        /// </summary>
        public HeatingSystemTypes HeatingSystem
        {
            get
            {
                return (_heatingSystem);
            }
            set
            {
                _heatingSystem = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие слаботочного обеспечения
        /// </summary>
        public bool HasLowCurrent
        {
            get
            {
                return (_hasLowCurrent);
            }
            set
            {
                _hasLowCurrent = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие оборудования для систем коммуникаций и слаботочного обеспечения
        /// </summary>
        public bool HasDevices
        {
            get
            {
                return (_hasDevices);
            }
            set
            {
                _hasDevices = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает соответствие планировки квартиры поэтажносу плану БТИ и наличие переоборудований
        /// </summary>
        public string PlanMeets
        {
            get
            {
                return (_planMeets);
            }
            set
            {
                _planMeets = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает мнение оценщика о возможности регистрации данной перепланировки/переоборудования в установленном законом порядке. Примерная стоимость регистраци перепланировки, либо приведения в первоначальное состояние
        /// </summary>
        public string ViewOnApparment
        {
            get
            {
                return (_viewOnApparment);
            }
            set
            {
                _viewOnApparment = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает текущее использование
        /// </summary>
        public CurrentUsingTypes CurrentUsing
        {
            get
            {
                return (_currentUsing);
            }
            set
            {
                _currentUsing = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает комментарии к фотографиям
        /// </summary>
        public string PicturesComment
        {
            get
            {
                return (_picturesComment);
            }
            set
            {
                _picturesComment = value;
            }
        }


        /// <summary>
        /// Свойство. Задает и возвращает дом
        /// </summary>
        public IHome Home
        {
            get
            {
                return ((IHome)HomeForEntityFramework);
            }
            set
            {
                HomeForEntityFramework = (Home)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дом (используется в Entity Framework) 
        /// </summary>
        public Home HomeForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает 
        /// </summary>

        public IObject Object
        {
            get
            {
                return ((IObject)ObjectForEntityFramework);
            }
            set
            {
                ObjectForEntityFramework = (Object)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает  (используется в Entity Framework) 
        /// </summary>
        
        public virtual Object ObjectForEntityFramework { get; set; }


        /// <summary>
        /// Свойство. Задает и возвращает материал отделки пола 
        /// </summary>
        public FloorMaterials FinishingMaterialForFloors
        { 
            get{
                return _finishingMaterialForFloors;
            } 
            set{
                _finishingMaterialForFloors=value;
            } 
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние дверей
        /// </summary>
        public Condition DoorsCondition
        {
            get
            {
                return _doorsCondition;
            }
            set
            {
                _doorsCondition = value;
            }
        }
        /// <summary>
        /// Свойство. Задает и возвращает состояние отополения
        /// </summary>
        public Condition HeatingCondition
        {
            get
            {
                return _heatingCondition;
            }
            set
            {
                _heatingCondition = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние канализации
        /// </summary>
        public Condition CanaliztionCondition
        {
            get
            {
                return _canaliztionCondition;
            }
            set
            {
                _canaliztionCondition = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние водоснабжения
        /// </summary>
        public Condition WaterCondition
        {
            get
            {
                return _waterCondition;
            }
            set
            {
                _waterCondition = value;
            }
        
        }

        /// <summary>
        /// Свойство. Задает и возвращает состояние окон
        /// </summary>
        public Condition WindowsCondition
        {
            get
            {
                return _windowsCondition;
            }
            set
            {
                _windowsCondition = value;
            }
        
        }

        /// <summary>
        /// Свойство. Задает и возвращает количество санузлов
        /// </summary>
        public string SanuzelQnt
        {
            get
            {
                return _sanuzelQnt;
            }
            set
            {
                _sanuzelQnt = value;
            }
        
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип труб отопления 
        /// </summary>
        public Pipes HeatingPipesType
        {
            get
            {
                return _heatingPipesType;
            }
            set
            {
                _heatingPipesType = value;
            }
        
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип труб водоснабжения
        /// </summary>
        public Pipes WaterPipesType
        {
            get
            {
                return _waterPipesType;
            }
            set
            {
                _waterPipesType = value;
            }
        
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип труб канализации
        /// </summary>
        public Pipes CanalizationPipesType
        {
            get
            {
                return _canalizationPipesType;
            }
            set
            {
                _canalizationPipesType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип входной двери
        /// </summary>
        public Doors MainDoorType
        {
            get
            {
                return _mainDoorType;
            }
            set
            {
                _mainDoorType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип межкомнатных дверей
        /// </summary>
        public Doors RoomDoorsType
        {
            get
            {
                return _roomDoorsType;
            }
            set
            {
                _roomDoorsType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип радиаторов
        /// </summary>
        public Heaters HeatersType
        {
            get
            {
                return _heatersType;
            }
            set
            {
                _heatersType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает тип окон
        /// </summary>
        public Windows WindowsType
        {
            get
            {
                return _windowsType;
            }
            set
            {
                _windowsType = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает приборы учета
        /// </summary>
        public string Counters
        {
            get
            {
                return _counters;
            }
            set
            {
                _counters = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает наличие домофона
        /// </summary>
        public bool Domofon
        {
            get
            {
                return _domofon;
            }
            set
            {
                _domofon = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает число квартир на этаже
        /// </summary>
       public string FlatsOnFloor
        {
            get
            {
                return _flatsOnFloor;
            }
            set
            {
                _flatsOnFloor = value;
            }
        }

       /// <summary>
       /// Свойство. Задает и возвращает картинку
       /// </summary>
       public List<IPicture> Pictures
       {
           get
           {
               return (PictureForEntityFramwork.ConvertAll(Picture.PictureToIPictureConverter));
           }
           set
           {
               PictureForEntityFramwork = value.ConvertAll(Picture.IPictureToPictureConverter);
           }

       }

       /// <summary>
       /// Свойство. Задает и возвращает картинку (используется в Entity Framework) 
       /// </summary>
       public List<Picture> PictureForEntityFramwork { get; set; }

       /// <summary>
       /// Свойство. Задает и возвращает квартиры для сравнения
       /// </summary>
       public List<IComparisonApart> ComparApart
       {
           get
           {
               return (ComparisonForEntityFramwork.ConvertAll(ComparisonApart.ComparisonApartToIComparisonApartConverter));
           }
           set
           {
               ComparisonForEntityFramwork = value.ConvertAll(ComparisonApart.IComparisonApartToComparisonApartConverter);
           }

       }

       /// <summary>
       /// Свойство. Задает и возвращает квартиры для сравнения (используется в Entity Framework) 
       /// </summary>
       public List<ComparisonApart> ComparisonForEntityFramwork { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public Apartment()
        {
            Object Object = new Object();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Возвращает тип комнат как тестовую строку
        /// </summary>
        public string GetRoomTypeAsString(RoomTypes roomType)
        {
            return (Apartment.GetRoomTypeAsStringStatic(roomType));
        }

        /// <summary>
        /// Метод. Возвращает тип санузлов как тестовую строку
        /// </summary>
        public string GetWashroomTypeAsString(WashroomTypes washroomType)
        {
            return (Apartment.GetWashroomTypeAsStringStatic(washroomType));
        }

        /// <summary>
        /// Метод. Возвращает планировку как тестовую строку
        /// </summary>
        public string GetLayoutAsString(Layouts layout)
        {
            return (Apartment.GetLayoutAsStringStatic(layout));
        }

        /// <summary>
        /// Метод. Возвращает состояние квартиры как тестовую строку
        /// </summary>
        public string GetApartmentStateAsString(ApartmentStates apartmentStates)
        {
            return (Apartment.GetApartmentStateAsStringStatic(apartmentStates));
        }

        /// <summary>
        /// Метод. Возвращает необходимые ремонтные работы как текстовую строку
        /// </summary>
        public string GetRepairWorkAsString(RepairWorkTypes repairWorkType)
        {
            return (Apartment.GetRepairWorkAsStringStatic(repairWorkType));
        }

        /// <summary>
        /// Метод. Возвращает качество отделки помещения как текстовую строку
        /// </summary>
        public string GetRoomFinishingQualityAsString(RoomFinishingQualities roomFinishingQuality)
        {
            return (Apartment.GetRoomFinishingQualityAsStringStatic(roomFinishingQuality));
        }

        /// <summary>
        /// Метод. Возвращает материал отделки пола как тестовую строку
        public string GetFloorMaterialAsString(FloorMaterials floorMaterial)
        {
            return (Apartment.GetFloorMaterialAsStringStatic(floorMaterial));
        }

        /// <summary>
        /// Метод. Возвращает материал отделки стен как тестовую строку
        public string GetWallMaterialAsString(WallMaterials wallMaterial)
        {
            return (Apartment.GetWallMaterialAsStringStatic(wallMaterial));
        }

        /// <summary>
        /// Метод. Возвращает материал отделки потолка как тестовую строку
        public string GetCeilingMaterialAsString(CeilingMaterials ceilingMaterial)
        {
            return (Apartment.GetCeilingMaterialAsStringStatic(ceilingMaterial));
        }

        /// <summary>
        /// Метод. Возвращает подключение к коммуникациям как текстовую строку
        /// </summary>
        public string GetObjectCommunicationAsString(ObjectCommunicationTypes objectCommunicationType)
        {
            return (Apartment.GetObjectCommunicationAsStringStatic(objectCommunicationType));
        }

        /// <summary>
        /// Метод. Возвращает систему отопления как текстовую строку
        /// </summary>
        public string GetHeatingSystemAsString(HeatingSystemTypes heatingSystemType)
        {
            return (Apartment.GetHeatingSystemAsStringStatic(heatingSystemType));
        }

        /// <summary>
        /// Метод. Возвращает текущее использование как текстовую строку
        /// <returns></returns>
        public string GetCurrentUsingAsString(CurrentUsingTypes currentUsingType)
        {
            return (Apartment.GetCurrentUsingAsStringStatic(currentUsingType));
        }

        /// <summary>
        /// Метод. Возвращает тип  как тестовую строку
        /// </summary>
        public string GetWindowsTypeAsString(Windows WindowsType)
        {
            return (Apartment.GetWindowsTypeAsStringStatic(WindowsType));
        }

        /// <summary>
        /// Метод. Возвращает тип  как тестовую строку
        /// </summary>
        public string GetDoorsTypeAsString(Doors DoorsType)
        {
            return (Apartment.GetDoorsTypeAsStringStatic(DoorsType));
        }

        /// <summary>
        /// Метод. Возвращает тип  как тестовую строку
        /// </summary>
        public string GetPipesTypeAsString(Pipes PipesType)
        {
            return (Apartment.GetPipesTypeAsStringStatic(PipesType));
        }

        /// <summary>
        /// Метод. Возвращает тип  как тестовую строку
        /// </summary>
        public string GetConditionTypeAsString(Condition ConditionType)
        {
            return (Apartment.GetConditionAsStringStatic(ConditionType));
        }

        /// <summary>
        /// Метод. Возвращает тип  как тестовую строку
        /// </summary>
        public string GetHeaterTypeAsString(Heaters HeaterType)
        {
            return (Apartment.GetHeaterTypeAsStringStatic(HeaterType));
        }
        // TODO: Реализовать метод "Clone" после всех полей и свойств

        #endregion
    }
}
