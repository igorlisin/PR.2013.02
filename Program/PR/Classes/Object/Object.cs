using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations.Object;


namespace PR.Classes
{
    
        /// <summary>
        /// �����. ������ ������ 
        /// </summary>
        public class Object :   Entity, IObject
        {
            #region Fields
            /// <summary>
            /// ����. ��� ������� ������
            /// </summary>
            private string _type;
            /// <summary>
            /// ����. �����
            /// </summary>
            //private Place _place;
            /// <summary>
            /// ����. ���������� ������
            /// </summary>
            //private int _numberOfRooms;
            /// <summary>
            /// ����. ������������� ����� �� ������ ������
            /// </summary>
            private string _property;
            /// <summary>
            /// ����. ������������ ����������� �����
            /// </summary>
            private string _restriction;
            /// <summary>
            /// ����. ��������������� ������������ ���������
            /// </summary>
            private string _holders;
            /// <summary>
            /// ����. ��������� ���������������� ������������ ���������
            /// </summary>
            private string _documents;
            /// <summary>
            /// ����. ��� ����������� ���������
            /// </summary>
            private string _typeOfValue;
            /// <summary>
            /// ����. ��������� ���������
            /// </summary>
            private float _price;
            /// <summary>
            /// ����. �������������� ������
            /// </summary>
            private float _discount;
            /// <summary>
            /// ����. ���� �������
            /// </summary>
            private float _dollar;
            /// <summary>
            /// ����. ���� ������
            /// </summary>            
            private string _purposeOfTheEvaluation;
            /// <summary>
            /// ����. ���� ������
            /// </summary>            
            private string _destOfTheEvaluation;

            /// <summary>
            /// ����. ����������
            /// </summary>
            private float _r ;

            /// <summary>
            /// ����. ���� ���������� ������� �� �������� ���������
            /// </summary>
            private float _t_r ;

            /// <summary>
            /// ����. ���� ���������� ������� �� �������������� ���������
            /// </summary>
            private float _t_l ;

            /// <summary>
            /// ����. ��������� ����� ������������� ��������
            /// </summary>
            private float _econSituationDown ;

            /// <summary>
            /// ����. ���������� ����� ������������� ��������
            /// </summary>
            private float _concurentsUp ;

            /// <summary>
            /// ����. ��������� ������������ ��� �������� ����������������
            /// </summary>
            private float _lowChange ;

            /// <summary>
            /// ����. ��������� � ������������� ������������ ��������
            /// </summary>
            private float _extremalSituation ;

            /// <summary>
            /// ����. ���������� ����� ������� ������
            /// </summary>
            private float _acceleratedWear ;

            /// <summary>
            /// ����. ����������� �������� ��������
            /// </summary>
            private float _noRentalMoney ;

            /// <summary>
            /// ����. ������������� ����������
            /// </summary>
            private float _badManagment ;

            /// <summary>
            /// ����. ������������� �������
            /// </summary>
            private float _criminal ;

            /// <summary>
            /// ����. ���������� ��������
            /// </summary>
            private float _financeChecking ;

            /// <summary>
            /// ����. ������������ ���������� ��������� ������
            /// </summary>
            private float _notCorrect ;

            #endregion

            #region Properties

            /// <summary>
            /// ��������. ������ � ���������� ��� �������
            /// </summary>
            public string ObjectType
            {
                get
                {
                    return (_type);
                }
                set
                {
                    _type = value;
                }
            }

            /// <summary>
            /// ��������. ������ � ���������� ������������� ����� �� ������ ������
            /// </summary>
            public string Property
            {
                get
                {
                    return (_property);
                }
                set
                {
                    _property = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ������������ ����������� �����
            /// </summary>
            public string Restriction
            {
                get
                {
                    return (_restriction);
                }
                set
                {
                    _restriction = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ���������������� ������������ ���������
            /// </summary>
            public string Holders
            {
                get
                {
                    return (_holders);
                }
                set
                {
                    _holders = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ��������� ���������������� ������������ ���������
            /// </summary>
            public string Documents
            {
                get
                {
                    return (_documents);
                }
                set
                {
                    _documents = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ��� ����������� ���������
            /// </summary>
            public string TypeOfValue
            {
                get
                {
                    return (_typeOfValue);
                }
                set
                {
                    _typeOfValue = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ����
            /// </summary>
            public float Price
            {
                get
                {
                    return (_price);
                }
                set
                {
                    _price = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ������
            /// </summary>
            public float Discount
            {
                get
                {
                    return (_discount);
                }
                set
                {
                    _discount = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ���� �������
            /// </summary>
            public float Dollar
            {
                get
                {
                    return (_dollar);
                }
                set
                {
                    _dollar = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ���� ������
            /// </summary>
            public string PurposeOfTheEvaluation
            {
                get
                {
                    return (_purposeOfTheEvaluation);
                }
                set
                {
                    _purposeOfTheEvaluation = value;
                }
            }
            /// <summary>
            /// ��������. ������ � ���������� ���� ������
            /// </summary>
            public string DestOfTheEvaluation
            {
                get
                {
                    return (_destOfTheEvaluation);
                }
                set
                {
                    _destOfTheEvaluation = value;
                }
            }

            /// <summary>
            /// ��������. ����������
            /// </summary>
            public float R
            {
                get
                {
                    return (_r);
                }
                set
                {
                    _r = value;
                }
            }

            /// <summary>
            /// ��������. ���� ���������� ������� �� �������� ���������
            /// </summary>
            public float T_r
            {
                get
                {
                    return (_t_r);
                }
                set
                {
                    _t_r = value;
                }
            }

            /// <summary>
            /// ��������. ���� ���������� ������� �� �������������� ���������
            /// </summary>
            public float T_l
            {
                get
                {
                    return (_t_l);
                }
                set
                {
                    _t_l = value;
                }
            }

            /// <summary>
            /// ��������. ��������� ����� ������������� ��������
            /// </summary>
            public float EconSituationDown
            {
                get
                {
                    return (_econSituationDown);
                }
                set
                {
                    _econSituationDown = value;
                }
            }

            /// <summary>
            /// ��������. ���������� ����� ������������� ��������
            /// </summary>
            public float ConcurentsUp
            {
                get
                {
                    return (_concurentsUp);
                }
                set
                {
                    _concurentsUp = value;
                }
            }

            /// <summary>
            /// ��������. ��������� ������������ ��� �������� ����������������
            /// </summary>
            public float LowChange
            {
                get
                {
                    return (_lowChange);
                }
                set
                {
                    _lowChange = value;
                }
            }

            /// <summary>
            /// ��������. ��������� � ������������� ������������ ��������
            /// </summary>
            public float ExtremalSituation
            {
                get
                {
                    return (_extremalSituation);
                }
                set
                {
                    _extremalSituation = value;
                }
            }

            /// <summary>
            /// ��������. ���������� ����� ������� ������
            /// </summary>
            public float AcceleratedWear
            {
                get
                {
                    return (_acceleratedWear);
                }
                set
                {
                    _acceleratedWear = value;
                }
            }

            /// <summary>
            /// ��������. ����������� �������� ��������
            /// </summary>
            public float NoRentalMoney
            {
                get
                {
                    return (_noRentalMoney);
                }
                set
                {
                    _noRentalMoney = value;
                }
            }

            /// <summary>
            /// ��������. ������������� ����������
            /// </summary>
            public float BadManagment
            {
                get
                {
                    return (_badManagment);
                }
                set
                {
                    _badManagment = value;
                }
            }

            /// <summary>
            /// ��������. ������������� �������
            /// </summary>
            public float Criminal
            {
                get
                {
                    return (_criminal);
                }
                set
                {
                    _criminal = value;
                }
            }

            /// <summary>
            /// ��������. ���������� ��������
            /// </summary>
            public float FinanceChecking
            {
                get
                {
                    return (_financeChecking);
                }
                set
                {
                    _financeChecking = value;
                }
            }

            /// <summary>
            /// ��������. ������������ ���������� ��������� ������
            /// </summary>
            public float NotCorrect
            {
                get
                {
                    return (_notCorrect);
                }
                set
                {
                    _notCorrect = value;
                }
            }

        #endregion
        }
    }

