using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRInterfaces.Interfaces
{
   public interface IComparisonAparts:IEntities
    {
        /// <summary>
        /// Метод. Создает и возвращает новую квартиру для сравнения
        /// </summary>
        IComparisonApart Create();

        /// <summary>
        /// Метод. Добавляет улицу в список квартиру для сравнения
        /// </summary>
        void Add(IComparisonApart comparisonApart);

        /// <summary>
        /// Метод. Удаляет улицу из списка квартиру для сравнения
        /// </summary>
        void Remove(IComparisonApart comparisonApart);

        /// <summary>
        /// Метод. Удаляет улицу с указанным идентификатором из списка квартиру для сравнения
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// Метод. Возвращает список квартиру для сравнения
        /// </summary>
        List<IComparisonApart> ToList();

        /// <summary>
        /// Метод. Возвращает массив квартиру для сравнения
        /// </summary>
        IComparisonApart[] ToArray();

        /// <summary>
        /// Метод. Возвращает квартиру для сравнения с указанным идентификатором из списка квартиру для сравнения
        /// </summary>
        IComparisonApart GetComparisonApart(int id);

        /// <summary>
        /// Метод. Сохраняет изменения списка квартиру для сравнения
        /// </summary>
        void SaveChanges();
    }
}
