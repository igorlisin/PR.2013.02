using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

namespace Object{
	/// <summary>
	/// Класс. Объект оценки
	/// </summary>
	private class Object : IObject, Entity{
		/// <summary>
		/// Поле. Тип объекта
		/// </summary>
		private ObjectTypes _type ;
		/// <summary>
		/// Поле. Место
		/// </summary>
		private Place _place ;
		/// <summary>
		/// Поле. Количество комнат
		/// </summary>
		private int _numberOfRooms ;
		/// <summary>
		/// Поле. Имущественные права на объект оценки
		/// </summary>
		private string _property ;
		/// <summary>
		/// Поле. Существующие ограничения права
		/// </summary>
		private string _restriction ;
		/// <summary>
		/// Поле. Правообладатели оцениваемого имущества
		/// </summary>
		private object _holders ;
		/// <summary>
		/// Поле. Вид оцениваемой стоимости
		/// </summary>
		private object _typeOfValue ;
		/// <summary>
		/// Поле. Цель оценки
		/// </summary>
		private string _purposeOfTheEvaluation ;
		/// <summary>
		/// Свойство. Задает и возвращает тип объекта
		/// </summary>
		int IObject.Type(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает место
		/// </summary>
		IPlace IObject.Place(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает количество комнат
		/// </summary>
		int IObject.NumberOfRooms(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает имущественные права на объект оценки
		/// </summary>
		string IObject.Property(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает существующие ограничения права
		/// </summary>
		string IObject.Restriction(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает правообладателей оцениваемого имущества
		/// </summary>
		List<IMan> IObject.Holders(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает вид оцениваемой стоимости
		/// </summary>
		int IObject.TypeOfValue(){
		}
		/// <summary>
		/// Свойство. Задает и возвращает цель оценки
		/// </summary>
		string IObject.PurposeOfTheEvaluation(){
		}
	}
}
