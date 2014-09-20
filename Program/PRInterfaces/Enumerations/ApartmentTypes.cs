namespace PRInterfaces.Enumerations
{
    /// <summary>
    /// Перечисление. Типы комнат
    /// </summary>
    public enum RoomTypes
    {
        /// <summary>
        /// Раздельные комнаты
        /// </summary>
        Separate = 0,

        /// <summary>
        /// Раздельные и проходные комнаты
        /// </summary>
        SeparateThrough = 1,

        /// <summary>
        /// Проходные комнаты
        /// </summary>
        Through = 2,

        /// <summary>
        /// Совмещенные комнаты
        /// </summary>
        Union = 3,

        /// <summary>
        /// Свободная планировка
        /// </summary>
        Free = 4
    }

    /// <summary>
    /// Перечисление. Типы санузлов
    /// </summary>
    public enum WashroomTypes
    {
        /// <summary>
        /// Раздельный санузел
        /// </summary>
        Separate = 0,

        /// <summary>
        /// Совмещенные санузел
        /// </summary>
        Union = 1,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Перечисление. Состояния квартиры
    /// </summary>
    public enum ApartmentStates
    {
        /// <summary>
        /// Идеальное
        /// </summary>
        Perfect = 0,

        /// <summary>
        /// Очень хорошее
        /// </summary>
        VeryGood = 1,

        /// <summary>
        /// Хорошее
        /// </summary>
        Good = 2,

        /// <summary>
        /// Нормальное
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Плохое
        /// </summary>
        Bad = 4,

        /// <summary>
        /// Очень плохое
        /// </summary>
        VeryBad = 5,

        /// <summary>
        /// Ужасное
        /// </summary>
        Terrible = 6,

        /// <summary>
        /// Новая квартира
        /// </summary>
        New = 7
    }

    /// <summary>
    /// Перечисление. Типы необходимых ремонтных работ
    /// </summary>
    public enum RepairWorkTypes
    {  
        /// <summary>
        /// Ремонтные работы не требуются
        /// </summary>
        NotNeed = 0,

        /// <summary>
        /// Требуются косметический ремонтные работы
        /// </summary>
        NeedCosmetic = 1,

        /// <summary>
        /// Требуются капитальные ремонтные работы
        /// </summary>
        NeedTotal = 2,

        /// <summary>
        /// Требуются частичный ремонтные работы
        /// </summary>
        NeedPartial = 3,

        /// <summary>
        /// Требуются чистовая отделка
        /// </summary>
        NeedClear = 4,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 5
    }

    /// <summary>
    /// Перечисление. Типы качества отделки помещений
    /// </summary>
    public enum RoomFinishingQualities
    {
        /// <summary>
        /// Премиум
        /// </summary>
        Premium = 0,

        /// <summary>
        /// Улучшенное
        /// </summary>
        Better = 1,

        /// <summary>
        /// Стандартное
        /// </summary>
        Standart = 2,

        /// <summary>
        /// Простое
        /// </summary>
        Simple = 3
    }

    /// <summary>
    /// Перечисление. Типы состояний
    /// </summary>
    public enum Condition
    {
        /// <summary>
        /// Идеальное
        /// </summary>
        Perfect = 0,

        /// <summary>
        /// Очень хорошее
        /// </summary>
        VeryGood = 1,

        /// <summary>
        /// Хорошее
        /// </summary>
        Good = 2,

        /// <summary>
        /// Нормальное
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Плохое
        /// </summary>
        Bad = 4,

        /// <summary>
        /// Очень плохое
        /// </summary>
        VeryBad = 5,

        /// <summary>
        /// Ужасное
        /// </summary>
        Terrible = 6,

        /// <summary>
        /// Новая квартира
        /// </summary>
        New = 7
    }

    /// <summary>
    /// Перечисление. Материалы отделки пола
    /// </summary>
    public enum FloorMaterials
    {
        /// <summary>
        /// Плитка
        /// </summary>
        Tile = 0,

        /// <summary>
        /// Линолеум
        /// </summary>
        Linoleum = 1,

        /// <summary>
        /// Ламинат
        /// </summary>
        Laminate = 2,

        /// <summary>
        /// Паркет
        /// </summary>
        Parquet = 3,

        /// <summary>
        /// Стяжка
        /// </summary>
        NoFinishing = 4,

        /// <summary>
        /// Ковролин
        /// </summary>
        Kovrolin = 5,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 6
    }

    /// <summary>
    /// Перечисление. Материалы отделки стен
    /// </summary>
    public enum WallMaterials
    {
        /// <summary>
        /// Обои
        /// </summary>
        Wallpaper = 0, 

        /// <summary>
        /// Обои и плитка
        /// </summary>
        WallpaperAndTile = 1,

        /// <summary>
        /// Краска
        /// </summary>
        Paint = 2,

        /// <summary>
        /// Краска и плитка
        /// </summary>
        PaintAndTile = 3,

        /// <summary>
        /// Плитка
        /// </summary>
        Tile = 4,

        /// <summary>
        /// Панели ПВХ
        /// </summary>
        PVH = 5,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 6
    }

    /// <summary>
    /// Перечисление. Материалы отделки потолка
    /// </summary>
    public enum CeilingMaterials
    {
        /// <summary>
        /// Побелка
        /// </summary>
        Whitewash = 0,

        /// <summary>
        /// Потолочная плитка
        /// </summary>
        CeilingTiles = 1,

        /// <summary>
        /// Краска
        /// </summary>
        Paint = 2,

        /// <summary>
        /// Обои
        /// </summary>
        Wallpaper = 3,

        /// <summary>
        /// Панели ПВХ
        /// </summary>
        PVH = 4,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 5
    }

    /// <summary>
    /// Перечисление. Тип подключения к коммуникациям
    /// </summary>
    public enum ObjectCommunicationTypes
    {
        /// <summary>
        /// Подключен
        /// </summary>
        Connected = 0,

        /// <summary>
        /// Неподключен
        /// </summary>
        NotConnected = 1,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Перечисление. Тип системы отопления
    /// </summary>
    public enum HeatingSystemTypes
    {
        /// <summary>
        /// Центральная
        /// </summary>
        Central = 0,

        /// <summary>
        /// От общедомового газового котла
        /// </summary>
        Home = 1,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Перечисление. Тип текущего использования
    /// </summary>
    public enum CurrentUsingTypes
    {
        /// <summary>
        /// Жилай квартира
        /// </summary>
        LivingAppartment = 0,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 1
    }

    /// <summary>
    /// Перечисление. Планировки
    /// </summary>
    public enum Layouts
    {
        /// <summary>
        /// Стандартная планировка 
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Индивидуальная
        /// </summary>
        Individual = 1
    }

    /// <summary>
    /// Перечисление. Двери
    /// </summary>
    public enum Doors
    {
        /// <summary>
        /// Деревянные
        /// </summary>
        Wood = 0,

        /// <summary>
        /// Филенчатые
        /// </summary>
        Fil = 1,

        /// <summary>
        /// Металлические
        /// </summary>
        Metal = 2,

        /// <summary>
        /// 2 двери: металлическая и деревянная
        /// </summary>
        MetalAndWood = 3,

        /// <summary>
        /// Пластиковые
        /// </summary>
        Plastic = 4,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 5
    }

    /// <summary>
    /// Перечисление. Окна
    /// </summary>
    public enum Windows
    {
        /// <summary>
        /// Деревянные
        /// </summary>
        Wood = 0,

        /// <summary>
        /// Деревянные евро
        /// </summary>
        Euro = 1,

        /// <summary>
        /// Пластиковые
        /// </summary>
        Plastic = 2,

        /// <summary>
        /// Алюминевые
        /// </summary>
        Aluminium = 3,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 4
    }

    /// <summary>
    /// Перечисление. Трубы
    /// </summary>
    public enum Pipes
    {
        /// <summary>
        /// пластиковые
        /// </summary>
        Plastic = 0,

        /// <summary>
        /// металопластиковые
        /// </summary>
        MetalPlastic = 1,

        /// <summary>
        /// Металлические
        /// </summary>
        Metal = 2,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 3
    }

    /// <summary>
    /// Перечисление. Радиаторы отопления
    /// </summary>
    public enum Heaters
    {
        /// <summary>
        /// Чугунные
        /// </summary>
        Iron = 0,

        /// <summary>
        /// Алюминиевые
        /// </summary>
        Alumin = 1,

        /// <summary>
        /// Стальные
        /// </summary>
        Steel = 2,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 3
    }
}
