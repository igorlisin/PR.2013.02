using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

namespace Object{
	/// <summary>
	/// �����. ������ �������� ������
	/// </summary>
	public class Objects : IObjects{
		/// <summary>
		/// ����. ������ �������� ������
		/// </summary>
		private object _objects ;
		/// <summary>
		/// �����. ��������� ������ ������ � ������ �������� ������
		/// </summary>
		void IObjects.Add(IObject assessObject){
		}
		/// <summary>
		/// �����. ������� ������ ������ �� ������ �������� ������
		/// </summary>
		void IObjects.Remove(IObject assessObject){
		}
		/// <summary>
		/// �����. ������� ������ ������ � ��������� �������� �� ������ �������� ������
		/// </summary>
		void IObjects.RemoveByIndex(int index){
		}
		/// <summary>
		/// ��������. ������ � ���������� ������ �������� ������
		/// </summary>
		List<IObject> IObjects.Objects(){
		}
		/// <summary>
		/// �����. ���������� ������ ������ � ��������� �������� �� ������ �������� ������
		/// </summary>
		IObject IObjects.GetObject(int index){
		}
	}
}
