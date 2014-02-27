using System;
using System.Collections;

namespace PR.Classes
{
        /// <summary>
        /// Класс. Перечислитель сущностей
        /// </summary>
        public class EntityEnumerator : IEnumerator
        {
            /// <summary>
            /// Поле. Массив сущностей
            /// </summary>
            private Entity[] _entityArray;

            /// <summary>
            /// Поле. Позиция текущего элемента
            /// </summary>
            int position = -1;

            /// <summary>
            /// Конструктор
            /// </summary>
            public EntityEnumerator(Entity[] entityList)
            {
                _entityArray = entityList;
            }

            /// <summary>
            /// Свойство. Возвращает текущую сущность
            /// </summary>
            public object Current
            {
                get
                {
                    return ((object)_entityArray[position]);
                }
                
            }

            /// <summary>
            /// Метод. Увеличивает текущую позицию на единицу
            /// </summary>
            public bool MoveNext()
            {
                position++;
                return (position < _entityArray.Length);
            }

            /// <summary>
            /// Метод. Сбрасывает текущую позицию
            /// </summary>
            public void Reset()
            {
                position = -1;
            }
        }
}
