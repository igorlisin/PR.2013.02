using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRInterfaces.Enumerations
{
    
    /// <summary>
    /// Перечисление. 
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
        /// Гипс
        ///</summary>
        Gips = 3,

        /// <summary>
        /// Гипсокартон
        ///</summary>
        Gipsokarton = 4,

        /// <summary>
        /// Дерево
        ///</summary>
        Wood = 5
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
