using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

namespace Object{
	/// <summary>
	/// �����. ������ ������
	/// </summary>
	private class Object : IObject, Entity{
		/// <summary>
		/// ����. ��� �������
		/// </summary>
		private ObjectTypes _type ;
		/// <summary>
		/// ����. �����
		/// </summary>
		private Place _place ;
		/// <summary>
		/// ����. ���������� ������
		/// </summary>
		private int _numberOfRooms ;
		/// <summary>
		/// ����. ������������� ����� �� ������ ������
		/// </summary>
		private string _property ;
		/// <summary>
		/// ����. ������������ ����������� �����
		/// </summary>
		private string _restriction ;
		/// <summary>
		/// ����. ��������������� ������������ ���������
		/// </summary>
		private object _holders ;
		/// <summary>
		/// ����. ��� ����������� ���������
		/// </summary>
		private object _typeOfValue ;
		/// <summary>
		/// ����. ���� ������
		/// </summary>
		private string _purposeOfTheEvaluation ;
		/// <summary>
		/// ��������. ������ � ���������� ��� �������
		/// </summary>
		int IObject.Type(){
		}
		/// <summary>
		/// ��������. ������ � ���������� �����
		/// </summary>
		IPlace IObject.Place(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ���������� ������
		/// </summary>
		int IObject.NumberOfRooms(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ������������� ����� �� ������ ������
		/// </summary>
		string IObject.Property(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ������������ ����������� �����
		/// </summary>
		string IObject.Restriction(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ���������������� ������������ ���������
		/// </summary>
		List<IMan> IObject.Holders(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ��� ����������� ���������
		/// </summary>
		int IObject.TypeOfValue(){
		}
		/// <summary>
		/// ��������. ������ � ���������� ���� ������
		/// </summary>
		string IObject.PurposeOfTheEvaluation(){
		}
	}
}
