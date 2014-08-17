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
        /// Класс. Объект оценки 
        /// </summary>
        public class Object :   Entity, IObject
        {
            #region Fields
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
            /// Поле. Документы правообладателей оцениваемого имущества
            /// </summary>
            private string _documents;
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
            /// Поле. Доходность
            /// </summary>
            private float _r ;

            /// <summary>
            /// Поле. Срок реализации объекта по рыночной стоимости
            /// </summary>
            private float _t_r ;

            /// <summary>
            /// Поле. Срок реализации объекта по ликвидационной стоимости
            /// </summary>
            private float _t_l ;

            /// <summary>
            /// Поле. Ухудшение общей экономической ситуации
            /// </summary>
            private float _econSituationDown ;

            /// <summary>
            /// Поле. Увеличение числа конкурирующих объектов
            /// </summary>
            private float _concurentsUp ;

            /// <summary>
            /// Поле. Изменение федерального или местного законодательства
            /// </summary>
            private float _lowChange ;

            /// <summary>
            /// Поле. Природные и антропогенные чрезвычайные ситуации
            /// </summary>
            private float _extremalSituation ;

            /// <summary>
            /// Поле. Ускоренный износ объекта оценки
            /// </summary>
            private float _acceleratedWear ;

            /// <summary>
            /// Поле. Неполучение арендных платежей
            /// </summary>
            private float _noRentalMoney ;

            /// <summary>
            /// Поле. Неэффективный менеджмент
            /// </summary>
            private float _badManagment ;

            /// <summary>
            /// Поле. Криминогенные факторы
            /// </summary>
            private float _criminal ;

            /// <summary>
            /// Поле. Финансовые проверки
            /// </summary>
            private float _financeChecking ;

            /// <summary>
            /// Поле. Неправильное оформление договоров аренды
            /// </summary>
            private float _notCorrect ;

            #endregion

            #region Properties

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
            /// Свойство. Задает и возвращает документы правообладателей оцениваемого имущества
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

            /// <summary>
            /// Свойство. Доходность
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
            /// Свойство. Срок реализации объекта по рыночной стоимости
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
            /// Свойство. Срок реализации объекта по ликвидационной стоимости
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
            /// Свойство. Ухудшение общей экономической ситуации
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
            /// Свойство. Увеличение числа конкурирующих объектов
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
            /// Свойство. Изменение федерального или местного законодательства
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
            /// Свойство. Природные и антропогенные чрезвычайные ситуации
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
            /// Свойство. Ускоренный износ объекта оценки
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
            /// Свойство. Неполучение арендных платежей
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
            /// Свойство. Неэффективный менеджмент
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
            /// Свойство. Криминогенные факторы
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
            /// Свойство. Финансовые проверки
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
            /// Свойство. Неправильное оформление договоров аренды
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

