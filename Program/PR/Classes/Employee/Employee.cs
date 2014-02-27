using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Сотрудник
    /// </summary>
    public class Employee : Entity, IEmployee
    {
        /// <summary>
        /// Статический метод. Преобразует объект типа IEmployee в объект типа Employee
        /// </summary>
        public static Employee IEmployeeToEmployeeConverter(IEmployee employee)
        {
            return ((Employee)employee);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Employee в объект типа IEmployee
        /// </summary>
        public static IEmployee EmployeeToIEmployeeConverter(Employee employee)
        {
            return ((IEmployee)employee);
        }

        /// <summary>
        /// Поле. Должность
        /// </summary>
        private string _position;

        /// <summary>
        /// Поле. Пароль
        /// </summary>
        private string _password;

        /// <summary>
        /// Поле. Сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
        /// </summary>
        private string _furtherEducation;

        /// <summary>
        /// Поле. Информация о членстве в саморегулируемой организации оценщиков
        /// </summary>
        private string _membership;

        /// <summary>
        /// Поле. Сведения об обязательном страховании гражданской ответственности
        /// </summary>
        private string _insurance;

        /// <summary>
        /// Поле. Стаж работы в оценочной деятельности (общее количество месяцев)
        /// </summary>
        private int _workTime;

        /// <summary>
        /// Свойство. Задает и возвращает человека
        /// </summary>
        public IMan Man
        {
            get
            {
                return ((IMan)ManForEntityFramework);
            }
            set
            {
                ManForEntityFramework = (Man)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает человека (используется в Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает должность
        /// </summary>
        public string Position
        {
            get
            {
                return(_position);
            }
            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает пароль
        /// </summary>
        public string Password
        {
            get
            {
                return(_password);
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает сведения о документе, подтверждающем получение профессиональных знаний в области оценочной деятельности
        /// </summary>
        public string FurtherEducation
        {
            get
            {
                return (_furtherEducation);
            }
            set
            {
                _furtherEducation = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает информацию о членстве в саморегулируемой организации оценщиков
        /// </summary>
        public string Membership
        {
            get
            {
                return (_membership);
            }
            set
            {
                _membership = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возващает сведения об обязательном страховании гражданской ответственности
        /// </summary>
        public string Insurance
        {
            get
            {
                return (_insurance);
            }
            set
            {
                _insurance = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает стаж работы в оценочной деятельности
        /// </summary>
        public int WorkTime
        {
            get
            {
                return (_workTime);
            }
            set
            {
                _workTime = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчет
        /// </summary>
        public IReport Report
        {
            get
            {
                return ((IReport)ReportForEntityFramwork);
            }
            set
            {
                ReportForEntityFramwork = (Report)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает отчет (используется в Entity Framework) 
        /// </summary>
        public Report ReportForEntityFramwork { get; set; }

        /// <summary>
        /// Метод. Возвращает копию сотрудника
        /// </summary>
        public override object Clone()
        {
            IEmployee employee;

            employee = (IEmployee)base.Clone();

            employee.Man = Man;

            employee.FurtherEducation = FurtherEducation;
            employee.Membership = Membership;
            employee.Insurance = Insurance;
            employee.WorkTime = WorkTime;
            
            return ((object)employee);
        }
    }
}
