using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

namespace Object{
	/// <summary>
	/// Класс. Список объектов оценки
	/// </summary>
	public class Objects : IObjects{
		/// <summary>
		/// Поле. Список объектов оценки
		/// </summary>
		private object _objects ;
		/// <summary>
		/// Метод. Добавляет объект оценки в список объектов оценки
		/// </summary>
		void IObjects.Add(IObject assessObject){
		}
		/// <summary>
		/// Метод. Удаляет объект оценки из списка объектов оценки
		/// </summary>
		void IObjects.Remove(IObject assessObject){
		}
		/// <summary>
		/// Метод. Удаляет объект оценки с указанной позицией из списка объектов оценки
		/// </summary>
		void IObjects.RemoveByIndex(int index){
		}
		/// <summary>
		/// Свойство. Задает и возвращает список объектов оценки
		/// </summary>
		List<IObject> IObjects.Objects(){
		}
		/// <summary>
		/// Метод. Возвращает объект оценки с указанной позицией из списка объектов оценки
		/// </summary>
		IObject IObjects.GetObject(int index){
		}
	}
}
