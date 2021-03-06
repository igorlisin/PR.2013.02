using System;
using System.Collections.Generic;
using PRInterfaces.Enumerations;
using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ���
    /// </summary>
    public class Home : Entity, IHome
    {
        #region Static
        /// <summary>
        /// ����������� ����. ����� �� ���������
        /// </summary>
        private static string _defaultNumber;

        /// <summary>
        /// ����������� ����. ����� �� ��������� �� ���������
        /// </summary>
        private static string _defaultComplexNumber;

        /// <summary>
        /// ����������� ��������. ����� �� ���������
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
        /// ����������� ��������. ����� �� ��������� �� ���������
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
        /// ����������� �����. ����������� ������ ���� IHome � ������ ���� Home
        /// </summary>
        public static Home IHomeToHomeConverter(IHome home)
        {
            return ((Home)home);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Home � ������ ���� IHome
        /// </summary>
        public static IHome HomeToIHomeConverter(Home home)
        {
            return ((IHome)home);
        }

        /// <summary>
        /// �����. ����������  ��� �������� ������
        /// </summary>
        public static string GetMaterialAsStringStatic(MaterialType material)
        {
            string materialAsString;                             // ��� (��� ���������� ������)

            switch (material)                                    // ��������� ���
            {
                case MaterialType.ArmedBeton:                            // �������� ��� 
                    materialAsString = "�������������� ������";                 // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Brick:                        // �������� ��� 
                    materialAsString = "������";                // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Gazobeton:                     // �������� ��� 
                    materialAsString = "������������ �����, ������������ ��������";      // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Monolyte:                     // �������� ��� 
                    materialAsString = "���������� �����������";      // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Gipsokarton:                     // �������� ��� 
                    materialAsString = "�����������";      // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Wood:                     // �������� ��� 
                    materialAsString = "����������";      // ������ ��� (��� ��������� ������)
                    break;
                case MaterialType.Other:                     // �������� ��� 
                    materialAsString = "������!!!!!!!!";      // ������ ��� (��� ��������� ������)
                    break;
                default:                                                // ��� �� ��������� 
                    materialAsString = "--";                     // ������ ��� (��� ��������� ������)
                    break;
            }

            return (materialAsString);
        }

        /// <summary>
        /// �����. ���������� �������� ������� ��������� ��� ��������� ������
        /// </summary>
        public static string GetConditionAsStringStatic(Condition condition)
        {
            string conditionAsString;                        // ��� (��� ���������� ������)

            switch (condition)                               // ��������� ���
            {
                case Condition.Perfect:                    // �������� ��� 
                    conditionAsString = "��������";         // ������ ��� (��� ��������� ������)
                    break;
                case Condition.Good:                       // �������� ��� 
                    conditionAsString = "�������";           // ������ ��� (��� ��������� ������)
                    break;
                case Condition.Normal:                     // �������� ��� 
                    conditionAsString = "������������������";        // ������ ��� (��� ��������� ������)
                    break;
                case Condition.Bad:                        // �������� ��� 
                    conditionAsString = "��������������������";            // ������ ��� (��� ��������� ������)
                    break;
                case Condition.New:                   // �������� ��� 
                    conditionAsString = "����� ��������";           // ������ ��� (��� ��������� ������)
                    break;
                default:                                                // ��� �� ��������� 
                    conditionAsString = "--";                // ������ ��� (��� ��������� ������)
                    break;
            }

            return (conditionAsString);
        }

        #endregion

        #region Fields
        /// <summary>
        /// ����. �����
        /// </summary>
        private string _number;

        /// <summary>
        /// ����. ���������
        /// </summary>
        private int _floors;

        /// <summary>
        /// ����. ����� �� ���������
        /// </summary>
        private string _complexNumber;

        /// <summary>
        /// ����. ��� ���������
        /// </summary>
        private int _buildYear;

        /// <summary>
        /// ����. ��������� �����
        /// </summary>
        private Condition _roofCondition;

        /// <summary>
        /// ����. �������� ������� ����
        /// </summary>
        private MaterialType _outsideWall;

        /// <summary>
        /// ����. �������� �����������
        /// </summary>
        private MaterialType _insideWall;

        /// <summary>
        /// ����. ������� �����
        /// </summary>
        private bool _lift;

        /// <summary>
        /// ����. ��� ���������� ����������
        /// </summary>
        private string _kapremontYear;

        /// <summary>
        /// ����. ������������� ����������
        /// </summary>
        private string _kapremontPeriod;

        /// <summary>
        /// ��������. ������ � ���������� ���������� � ����������
        /// </summary>
        private string _kapremontInformation;

        /// <summary>
        /// ����. ������� �������� �����������
        /// </summary>
        private bool _defects;

        /// <summary>
        /// ����. ������� �������������
        /// </summary>
        private bool _garbadge;

        /// <summary>
        /// ����. ������� ��� ��������
        /// </summary>
        private string _extraFactors;

        /// <summary>
        /// ����. ������� ���������
        /// </summary>
        private bool _conserge;

        /// <summary>
        /// ����. ��� ����������
        /// </summary>
        private MaterialType _ceilingType;

        /// <summary>
        /// ����. ��������� ����������
        /// </summary>
        private Condition _ceilingCondition;

        /// <summary>
        /// ����. ���������
        /// </summary>
        private string _basement;

        /// <summary>
        /// ����. ����� ����������
        /// </summary>
        private string _basementWear;

        /// <summary>
        /// ����. ������� �������
        /// </summary>
        private bool _attic;

        /// <summary>
        /// ����. ���������� �� ��������
        /// </summary>
        private string _PromzoneDistance;

        /// <summary>
        /// ����. ���������� �� ��������� 
        /// </summary>
        private string _stopDistance;

        /// <summary>
        /// ����. ������ � ���������� ��������� �����������
        /// </summary>
        private string _stopName;

        /// <summary>
        /// ����. ���������� ������ �������
        /// </summary>
        private string _social;

        /// <summary>
        /// ����. ������� ����
        /// </summary>
        private bool _gaz;

        /// <summary>
        /// ����. ������� �������
        /// </summary>
        private bool _transport;

        /// <summary>
        /// ����. ������ � ���������� ������� ��������
        /// </summary>
        private bool _parking;

 

        #endregion

        #region Properties
        /// <summary>
        /// ��������. ������ � ���������� �����
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
        /// ��������. ������ � ���������� ��������� 
        /// </summary>
        public int Floors
        {
            get
            {
                return (_floors);
            }
            set
            {
                _floors = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ����� �� ���������
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
        /// ��������. ������ � ���������� �����
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
        /// ��������. ������ � ���������� ����� (������������ � Entity Framework) 
        /// </summary>
        public Street StreetForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
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
        /// ��������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Complex ComplexForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������
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
        /// ��������. ������ � ���������� ������ ������� (������������ � Entity Framework) 
        /// </summary>
        public List<Apartment> AppartmentsForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ��������� ����
        /// </summary>
       public int BuildYear { 
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
        /// ��������. ������ � ���������� ��������� �����
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
        /// ��������. ������ � ���������� ��� ������� ���� ����
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
        /// ��������. ������ � ���������� ������������ ����
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
        /// ��������. ������ � ���������� ������� �����
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
        /// ��������. ������ � ���������� ��� ���������� ����������
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
       /// ��������. ������ � ���������� ���������� � ����������
       /// </summary>
       public string KapremontInformation
       {
           get
           {
               return _kapremontInformation;
           }
           set
           {
               _kapremontInformation = value;
           }
       }

        /// <summary>
        /// ��������. ������ � ���������� ������������� ����������
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
        /// ��������. ������ � ���������� ������� �������� ������
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
        /// ��������. ������ � ���������� ������� �������������
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
        /// ��������. ������ � ���������� �������������� ��������
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
        /// ��������. ������ � ���������� ������� ���������
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
        /// ��������. ������ � ���������� ��� ����������
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
        /// ��������. ������ � ���������� ��������� ����������
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
        /// ��������. ������ � ���������� ���������
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
        /// ��������. ������ � ���������� ����� ����������
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
        /// ��������. ������ � ���������� ������� �������
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
        /// ��������. ������ � ���������� ���������� �� ��������
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
        /// ��������. ������ � ���������� ���������� �� ���������
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
        /// ��������. ������ � ���������� ��� ���� �������
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
       /// ��������. ������ � ���������� �������� ��������� ���������
       /// </summary>
       public string StopName
       {
           get
           {
               return _stopName;
           }
           set
           {
               _stopName = value;
           }
       }

        /// <summary>
        /// ��������. ������ � ����������  ������� �������
        /// </summary>
       public bool Transport
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
        /// ��������. ������ � ���������� ������� ����
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
       /// ��������. ������ � ���������� �����
       /// </summary>
       public IDistrict District
       {
           get
           {
               return ((District)DistrictForEntityFramework);
           }
           set
           {
               DistrictForEntityFramework = (District)value;
           }
       }

       /// <summary>
       /// ��������. ������ � ���������� ������� ��������
       /// </summary>
       public bool Parking
       {
           get
           {
               return _parking;
           }
           set
           {
               _parking = value;
           }
       }

 

       /// <summary>
       /// ��������. ������ � ���������� ������ ������� (������������ � Entity Framework) 
       /// </summary>
       public District DistrictForEntityFramework { get; set; }

        #endregion

       #region Constructor
       /// <summary>
        /// �����������
        /// </summary>
        public Home()
        {
            Appartments = new List<IApartment>();       // ������� ������ �������, ��������� �����
        }
        #endregion

        #region Metods
        /// <summary>
        /// �����. ���������� ����� ����
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

        /// <summary>
        /// �����. ���������� ��� ��������� ��� �������� ������
        /// </summary>
        public string GetMaterialTypeAsString(MaterialType materialType)
        {
            return (Home.GetMaterialAsStringStatic(materialType));
        }

        /// <summary>
        /// �����. ���������� ���������  ��� �������� ������
        /// </summary>
        public string GetConditionTypeAsString(Condition ConditionType)
        {
            return (Apartment.GetConditionAsStringStatic(ConditionType));
        }

        #endregion
    }
}
