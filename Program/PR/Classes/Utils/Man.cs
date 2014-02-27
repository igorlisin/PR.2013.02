using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Человек
    /// </summary>
    public class Man : Entity, IMan
    {
        /// <summary>
        /// Статическое поле. Имя по умолчанию
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// Статическое поле. Фамилия по умолчанию
        /// </summary>
        private static string _defaultSurname;

        /// <summary>
        /// Статическое поле. Отчество по умолчанию
        /// </summary>
        private static string _defaultPatronymic;

        /// <summary>
        /// Статическое свойство. Имя по умолчанию
        /// </summary>
        public static string DefaultName
        {
            get
            {
                return (_defaultName);
            }
            set
            {
                _defaultName = value;
            }
        }

        /// <summary>
        /// Статическое свойство. Фамилия по умолчанию
        /// </summary>
        public static string DefaultPatronymic
        {
            get
            {
                return (_defaultPatronymic);
            }
            set
            {
                _defaultPatronymic = value;
            }
        }

        /// <summary>
        /// Статическое свойство. Отчество по умолчанию
        /// </summary>
        public static string DefaultSurname
        {
            get
            {
                return (_defaultSurname);
            }
            set
            {
                _defaultSurname = value;
            }
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа IMan в объект типа Man
        /// </summary>
        public static Man IManToManConverter(IMan man)
        {
            return ((Man)man);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Man в объект типа IMan
        /// </summary>
        public static IMan ManToIManConverter(Man man)
        {
            return ((IMan)man);
        }

        /// <summary>
        /// Поле. Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Поле. Отчество
        /// </summary>
        private string _patronymic;

        /// <summary>
        /// Свойство. Задает и возвращает имя
        /// </summary>
        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает фамилию
        /// </summary>
        public string Surname
        {
            get
            {
                return (_surname);
            }
            set
            {
                _surname = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчество
        /// </summary>
        public string Patronymic
        {
            get
            {
                return (_patronymic);
            }
            set
            {
                _patronymic = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает документ
        /// </summary>
        public IDocument Document
        {
            get
            {
                return ((IDocument)DocumentForEntityFramework);
            }
            set
            {
                DocumentForEntityFramework = (Document)value;
            }
        }
        
        /// <summary>
        /// Свойство. Задает и возвращает документ (используется в Entity Framework) 
        /// </summary>
        public Document DocumentForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает клиента
        /// </summary>
        public IClient Client
        {
            get
            {
                return ((IClient)ClientForEntityFramework);
            }
            set
            {
                ClientForEntityFramework = (Client)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает клиента (используется в Entity Framework) 
        /// </summary>
        public Client ClientForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает сотрудника
        /// </summary>
        public IEmployee Employee
        {
            get
            {
                return ((IEmployee)EmployeeForEntityFramework);
            }
            set
            {
                EmployeeForEntityFramework = (Employee)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает сотрудника (используется в Entity Framework) 
        /// </summary>
        public Employee EmployeeForEntityFramework { get; set; }

        /// <summary>
        /// Метод. Возвращает копию человека
        /// </summary>
        public override object Clone()
        {
            IMan man;

            man = (IMan)base.Clone();

            man.Name = Name;
            man.Surname = Surname;
            man.Patronymic = Patronymic;
            man.Document = (IDocument)((ICloneable)Document).Clone();

            return ((object)man);
        }
    }
}
