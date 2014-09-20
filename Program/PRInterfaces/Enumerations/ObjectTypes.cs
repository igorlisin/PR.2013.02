using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRInterfaces.Enumerations
{
    
    /// <summary>
    /// Перечисление. Тип материала стен
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// Железобетон
        /// </summary>
        ArmedBeton = 0,

        /// <summary>
        /// Кирпич
        ///</summary>
        Brick = 1,

        /// <summary>
        /// Газобетон
        ///</summary>
        Gazobeton = 2,

        /// <summary>
        /// Монолитный жб
        ///</summary>
        Monolyte = 3,

        /// <summary>
        /// Гипсокартон
        ///</summary>
        Gipsokarton = 4,

        /// <summary>
        /// Дерево
        ///</summary>
        Wood = 5,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 6
    }

    /// <summary>
    /// Перечисление. Престижность
    /// </summary>
    public enum Prestiges
    {
        /// <summary>
        /// Престижный
        /// </summary>
        HiPrestige = 0,

        /// <summary>
        /// Средней
        /// </summary>
        Middle = 1,

        /// <summary>
        /// Не престижный
        /// </summary>
        NotPrestige = 2,

        /// <summary>
        /// ПРОЧЕЕ!!!!!!!!
        /// </summary>
        Other = 3
    }

    namespace Object
    {
        /// <summary>
        /// Перечисление. Типы объектов оценки
        /// </summary>
        public enum ObjectTypes
        {
            staticHouse
        }
        public enum Place
        {
            
        }
    }
}
