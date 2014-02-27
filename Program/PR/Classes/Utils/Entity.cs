using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ��������
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        /// ����. �������������
        /// </summary>
        private int _id;

        /// <summary>
        /// ����. ��������
        /// </summary>
        private string _description;

        /// <summary>
        /// ��������. ������ � ���������� �������������
        /// </summary>
        public int Id
        {
            get
            {
                return (_id);
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        public string Description 
        {
            get
            {
                return (_description);
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// �����. ���������� �������� ����� ��������
        /// </summary>
        public virtual object Clone()
        {
            IEntity entity;

            entity = new Entity();

            entity.Id  = Id;
            entity.Description = Description;

            return((object)entity);
        }
    }
}
