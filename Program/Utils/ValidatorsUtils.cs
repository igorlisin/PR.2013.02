using System;

namespace Utils
{
    public class ValidatorsUtils
    {
        /// <summary>
        /// Статический метод. Проверяет является ли строка целым числом
        /// </summary>
        public static bool IsInt(string value)
        {
            int intValue;
            bool isInt;

            isInt = Int32.TryParse(value, out intValue);

            return (isInt);
        }

        /// <summary>
        /// Статический метод. Проверяет является ли строка числом с плавающей точкой (запятой)
        /// </summary>
        public static bool IsSingle(string value)
        {
            float floatValue;
            bool isSingle;

            isSingle = Single.TryParse(value, out floatValue);

            return (isSingle);
        }

        /// <summary>
        /// Статический метод. Проверяет является ли строка датой и временем
        /// </summary>
        public static bool IsDateTime(string value)
        {
            DateTime dateTimeValue;
            bool isDateTime;

            isDateTime = DateTime.TryParse(value, out dateTimeValue);

            return (isDateTime);
        }

        /// <summary>
        /// Статический метод. Проверяет является ли строка пустой
        /// </summary>
        public static bool IsNotEmpty(string value)
        {
            bool isNotNull;

            isNotNull = (value != "") ? true : false;

            return (isNotNull);
        }

    }
}
