using System;
using System.Collections.Generic;
using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations.Object;

namespace PR.Classes
{
    
        /// <summary>
        /// �����. ������ ������ 
        /// </summary>
        public class Object :   Entity, IObject
        {
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
        }
    }

