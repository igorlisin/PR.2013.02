using System.Collections;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Список сущностей
    /// </summary>
    public interface IEntities : IEnumerable
    {
        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        int Count();
    }
}
