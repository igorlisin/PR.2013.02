using System;
using System.Collections.Generic;
using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations.Object;

namespace PR.Classes
{
    
        /// <summary>
        /// Класс. Объект оценки 
        /// </summary>
        public class Object :   Entity, IObject
        {
            /// <summary>
            /// Поле. Тип объекта оценки
            /// </summary>
            private string _type;
            /// <summary>
            /// Поле. Место
            /// </summary>
            //private Place _place;
            /// <summary>
            /// Поле. Количество комнат
            /// </summary>
            //private int _numberOfRooms;
            /// <summary>
            /// Поле. Имущественные права на объект оценки
            /// </summary>
            private string _property;
            /// <summary>
            /// Поле. Существующие ограничения права
            /// </summary>
            private string _restriction;
            /// <summary>
            /// Поле. Правообладатели оцениваемого имущества
            /// </summary>
            private string _holders;
            /// <summary>
            /// Поле. Вид оцениваемой стоимости
            /// </summary>
            private string _typeOfValue;
            /// <summary>
            /// Поле. Оценочная стоимость
            /// </summary>
            private float _price;
            /// <summary>
            /// Поле. Ликвидационная уценка
            /// </summary>
            private float _discount;
            /// <summary>
            /// Поле. Курс доллара
            /// </summary>
            private float _dollar;
            /// <summary>
            /// Поле. Цель оценки
            /// </summary>            
            private string _purposeOfTheEvaluation;
            /// <summary>
            /// Поле. Цель оценки
            /// </summary>            
            private string _destOfTheEvaluation;
            /// <summary>
            /// Свойство. Задает и возвращает тип объекта
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
            /// Свойство. Задает и возвращает имущественные права на объект оценки
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
            /// Свойство. Задает и возвращает существующие ограничения права
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
            /// Свойство. Задает и возвращает правообладателей оцениваемого имущества
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
            /// Свойство. Задает и возвращает вид оцениваемой стоимости
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
            /// Свойство. Задает и возвращает цену
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
            /// Свойство. Задает и возвращает уценку
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
            /// Свойство. Задает и возвращает курс доллара
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
            /// Свойство. Задает и возвращает цель оценки
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
            /// Свойство. Задает и возвращает цель оценки
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

