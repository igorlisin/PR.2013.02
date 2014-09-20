using System.Collections.Generic;
using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Дом
    /// </summary>
    public interface IHome
    {
        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает этажность дома 
        /// </summary>
        int Floors { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает номер по комплексу
        /// </summary>
        string ComplexNumber { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает улицу
        /// </summary>
        IStreet Street { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс
        /// </summary>
        IComplex Complex { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир
        /// </summary>
        List<IApartment> Appartments { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает год постройки дома
        /// </summary>
        int BuildYear { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает состояние крыши
        /// </summary>
        Condition RoofCondition { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип несущих стен дома
        /// </summary>
        MaterialType OutsideWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает перегородорк дома
        /// </summary>
        MaterialType InsideWall { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие лифта
        /// </summary>
        bool Lift { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает год последнего капремонта
        /// </summary>
        string KapremontYear { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает периодичность капремонта
        /// </summary>
        string KapremontPeriod { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает информацио о капремонте
        /// </summary>
        string KapremontInformation { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличия дефектов здания
        /// </summary>
        bool Defects { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие мусоропровода
        /// </summary>
        bool Garbadge { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает дополнительных факторов
        /// </summary>
        string ExtraFactors { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие консьержа
        /// </summary>
        bool Conserge { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает тип перекрытий
        /// </summary>
        MaterialType CeilingType { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает состояние перекрытий
        /// </summary>
        Condition CeilingCondition { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает фундамент
        /// </summary>
        string Basement { get; set; }
        
        /// <summary>
        /// Свойство. Задает и возвращает износ фундамента
        /// </summary>
        string BasementWear { get; set; }
        
        /// <summary>
        /// Свойство. Задает и возвращает наличие чердака
        /// </summary>
        bool Attic { get; set; }
        
        /// <summary>
        /// Свойство. Задает и возвращает расстояние от промзоны
        /// </summary>
        string PromzoneDistance { get; set; }
        
        /// <summary>
        /// Свойство. Задает и возвращает расстояние от остановки
        /// </summary>
        string StopDistance { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает соц слой жильцов
        /// </summary>
        string Social { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие газа
        /// </summary>
        bool Gaz { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие трамвая
        /// </summary>
        bool Transport { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает название ближайшей остановки
        /// </summary>
        string StopName { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает наличие парковки
        /// </summary>
        bool Parking { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает район
        /// </summary>
        IDistrict District { get; set; }

        #region Methods

        /// <summary>
        /// Метод. Возвращает тип комнат как тестовую строку
        /// </summary>
        string GetMaterialTypeAsString(MaterialType materialType);

        /// <summary>
        /// Метод. Возвращает состояние  как тестовую строку
        /// </summary>
        string GetConditionTypeAsString(Condition ConditionType);

        #endregion
    }
}
