using System;
using System.Collections.Generic;
using PRInterfaces.Enumerations;
using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Дом
    /// </summary>
    public class Home : Entity, IHome 
    {
        /// <summary>
        /// Статическое поле. Номер по умолчанию
        /// </summary>
        private static string _defaultNumber;

        /// <summary>
        /// Статическое поле. Номер по комплексу по умолчанию
        /// </summary>
        private static string _defaultComplexNumber;

        /// <summary>
        /// Статическое свойство. Номер по умолчанию
        /// </summary>
        public static string DefaultNumber
        {
            get
            {
                return (_defaultNumber);
            }
            set
            {
                _defaultNumber = value;
            }
        }

        /// <summary>
        /// Статическое свойство. Номер по комплексу по умолчанию
        /// </summary>
        public static string DefaultComplexNumber
        {
            get
            {
                return (_defaultComplexNumber);
            }
            set
            {
                _defaultComplexNumber = value;
            }
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа IHome в объект типа Home
        /// </summary>
        public static Home IHomeToHomeConverter(IHome home)
        {
            return ((Home)home);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Home в объект типа IHome
        /// </summary>
        public static IHome HomeToIHomeConverter(Home home)
        {
            return ((IHome)home);
        }

        /// <summary>
        /// Поле. Номер
        /// </summary>
        private string _number;

        /// <summary>
        /// Поле. Номер по комплексу
        /// </summary>
        private string _complexNumber;

        /// <summary>
        /// Поле. 
        /// </summary>
        private string _buildYear;

        /// <summary>
        /// Поле. 
        /// </summary>
        private string _wear;

        /// <summary>
        /// Поле. 
        /// </summary>
        private Condition _roofCondition;

        /// <summary>
        /// Поле. 
        /// </summary>
        private MaterialType _outsideWall;

        /// <summary>
        /// Поле. 
        /// </summary>
        private MaterialType _insideWall;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _lift;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _kapremontYear;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _kapremontPeriod;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _defects;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _garbadge;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _extraFactors;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _conserge;


        /// <summary>
        /// Поле. 
        /// </summary>
        private MaterialType _ceilingType;


        /// <summary>
        /// Поле. 
        /// </summary>
        private Condition _ceilingCondition;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _basement;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _basementWear;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _attic;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _PromzoneDistance;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _stopDistance;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _social;


        /// <summary>
        /// Поле. 
        /// </summary>
        private string _transport;


        /// <summary>
        /// Поле. 
        /// </summary>
        private bool _gaz;



        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        public string Number
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
        /// Свойство. Задает и возвращает номер по комплексу
        /// </summary>
        public string ComplexNumber
        {
            get
            {
                return (_complexNumber);
            }
            set
            {
                _complexNumber = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает улицу
        /// </summary>
        public IStreet Street
        {
            get
            {
                return ((IStreet)StreetForEntityFramework);
            }
            set
            {
                StreetForEntityFramework = (Street)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает улицу (используется в Entity Framework) 
        /// </summary>
        public Street StreetForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс
        /// </summary>
        public IComplex Complex
        {
            get
            {
                return ((IComplex)ComplexForEntityFramework);
            }
            set
            {
                ComplexForEntityFramework = (Complex)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает комплекс (используется в Entity Framework) 
        /// </summary>
        public Complex ComplexForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир
        /// </summary>
        public List<IApartment> Appartments
        {
            get
            {
                return (AppartmentsForEntityFramework.ConvertAll(Apartment.ApartmentToIApartmentConverter));
            }
            set
            {
                AppartmentsForEntityFramework = value.ConvertAll(Apartment.IApartmentToApartmentConverter);
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает список квартир (используется в Entity Framework) 
        /// </summary>
        public List<Apartment> AppartmentsForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает год постройки дома
        /// </summary>
       public string BuildYear { 
            get
            {
               return _buildYear;
            }
            set
            {
                _buildYear = value;
            } 
        }

        /// <summary>
        /// Свойство. Задает и возвращает износ дома
        /// </summary>
       public string Wear
       {
           get
           {
               return _wear;
           }
           set
           {
               _wear = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает состояние крыши
        /// </summary>
       public Condition RoofCondition
       {
           get
           {
               return _roofCondition;
           }
           set
           {
               _roofCondition = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает тип несущих стен дома
        /// </summary>
       public MaterialType OutsideWall
       {
           get
           {
               return _outsideWall;
           }
           set
           {
               _outsideWall = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает перегородорк дома
        /// </summary>
       public MaterialType InsideWall
       {
           get
           {
               return _insideWall;
           }
           set
           {
               _insideWall = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличие лифта
        /// </summary>
       public bool Lift
       {
           get
           {
               return _lift;
           }
           set
           {
               _lift = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает год последнего капремонта
        /// </summary>
       public string KapremontYear
       {
           get
           {
               return _kapremontYear;
           }
           set
           {
               _kapremontYear = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает периодичность капремонта
        /// </summary>
       public string KapremontPeriod
       {
           get
           {
               return _kapremontPeriod;
           }
           set
           {
               _kapremontPeriod = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличия дефектов здания
        /// </summary>
       public bool Defects
       {
           get
           {
               return _defects;
           }
           set
           {
               _defects = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличие мусоропровода
        /// </summary>
       public bool Garbadge
       {
           get
           {
               return _garbadge;
           }
           set
           {
               _garbadge = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает дополнительных факторов
        /// </summary>
       public string ExtraFactors
       {
           get
           {
               return _extraFactors;
           }
           set
           {
               _extraFactors = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличие консьержа
        /// </summary>
       public bool Conserge
       {
           get
           {
               return _conserge;
           }
           set
           {
               _conserge = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает тип перекрытий
        /// </summary>
       public MaterialType CeilingType
       {
           get
           {
               return _ceilingType;
           }
           set
           {
               _ceilingType = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает состояние перекрытий
        /// </summary>
       public Condition CeilingCondition
       {
           get
           {
               return _ceilingCondition;
           }
           set
           {
               _ceilingCondition = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает фундамент
        /// </summary>
       public string Basement
       {
           get
           {
               return _basement;
           }
           set
           {
               _basement = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает износ фундамента
        /// </summary>
       public string BasementWear
       {
           get
           {
               return _basementWear;
           }
           set
           {
               _basementWear = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличие чердака
        /// </summary>
       public bool Attic
       {
           get
           {
               return _attic;
           }
           set
           {
               _attic = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает расстояние от промзоны
        /// </summary>
       public string PromzoneDistance
       {
           get
           {
               return _PromzoneDistance;
           }
           set
           {
               _PromzoneDistance = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает расстояние от остановки
        /// </summary>
       public string StopDistance
       {
           get
           {
               return _stopDistance;
           }
           set
           {
               _stopDistance = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает соц слой жильцов
        /// </summary>
       public string Social
       {
           get
           {
               return _social;
           }
           set
           {
               _social = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает общественный транспорт
        /// </summary>
       public string Transport
       {
           get
           {
               return _transport;
           }
           set
           {
               _transport = value;
           }
       }

        /// <summary>
        /// Свойство. Задает и возвращает наличие газа
        /// </summary>
       public bool Gaz
       {
           get
           {
               return _gaz;
           }
           set
           {
               _gaz = value;
           }
       }


        /// <summary>
        /// Конструктор
        /// </summary>
        public Home()
        {
            Appartments = new List<IApartment>();       // Создать список квартир, связанных домом
        }

        /// <summary>
        /// Метод. Возвращает копию дома
        /// </summary>
        public override object Clone()
        {
            IHome home;

            home = (IHome)base.Clone();

            home.Number = Number;
            home.ComplexNumber = ComplexNumber;
            home.Street = Street;
            home.Complex = Complex;

            return ((object)home);
        }


    }
}
