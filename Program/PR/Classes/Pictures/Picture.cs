using System;
using System.Drawing;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
    /// <summary>
    /// �����. ��������
    /// </summary>
    public class Picture : Entity, IPicture
    {
        #region Static fields

        /// <summary>
        /// ����������� ����. �������� �� ���������
        /// </summary>
        private static string _defaultName;

        /// <summary>
        /// ����������� ��������. �������� �� ���������
        /// </summary>
        public static string DefaultName
        {
            get
            {
                return (_defaultName);
            }
            set
            {
                _defaultName = value;
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// ����������� �����. ����������� ������ ���� IPicture � ������ ���� Picture
        /// </summary>
        public static Picture IPictureToPictureConverter(IPicture picture)
        {
            return ((Picture)picture);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Picture � ������ ���� IPicture
        /// </summary>
        public static IPicture PictureToIPictureConverter(Picture picture)
        {
            return ((IPicture)picture);
        }

        /// <summary>
        /// ����������� �����. ���������� ��� �������� ��� ��������� ������
        /// </summary>
        public static string GetPictureTypeAsStringStatic(PictureTypes pictureType)
        {
            string pictureTypeAsString;                         // ��� �������� (��� ���������� ������)

            switch (pictureType)                                // ��������� ��� ��������
            {
                case PictureTypes.document:                      // ��� ��������: ��������
                    pictureTypeAsString = "��������";           // ������ ��� ��������
                    break;
                case PictureTypes.map:                           // ��� ��������: �����
                    pictureTypeAsString = "�����";              // ������ ��� ��������
                    break;
                case PictureTypes.photo:                         // ��� ��������: ����������
                    pictureTypeAsString = "����������";         // ������ ��� ��������
                    break;
                case PictureTypes.screenshot:                    // ��� ��������: ������ ������
                    pictureTypeAsString = "������ ������";      // ������ ��� ��������
                    break;
                case PictureTypes.appartmentMap:                 // ��� ��������: ������ ������
                    pictureTypeAsString = "���� ��������";      // ������ ��� ��������
                    break;
                default:                                        // ��� ��������: �������� �� ���������
                    pictureTypeAsString = "";                   // ������ ��� ��������
                    break;
            }

            return (pictureTypeAsString);
        }

        #endregion

        #region Fields

        /// <summary>
        /// ����. ��������
        /// </summary>
        private string _name;

        /// <summary>
        /// ����. ���
        /// </summary>
        private PictureTypes _type;

        /// <summary>
        /// ����. ��� ����� �����������
        /// </summary>
        private string _imageFileName;

        /// <summary>
        /// ����. ���� ��������
        /// </summary>
        private DateTime _creationDate;

        #endregion

        #region Properties

        /// <summary>
        /// �������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Apartment ApartmentForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������ ��������
        /// </summary>
        public IApartment Apartment
        {
            get
            {
                return ((IApartment)ApartmentForEntityFramework);
            }
            set
            {
                ApartmentForEntityFramework = (Apartment)value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ���
        /// </summary>
        public PictureTypes Type
        {
            get
            {
                return (_type);
            }
            set
            {
                _type = value;
            }

        }
        
        /// <summary>
        /// ��������. ���������� ��� �������� ��� ��������� ������
        /// </summary>
        public string TypeAsString
        {
            get
            {
                return (Picture.GetPictureTypeAsStringStatic(_type));
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����� �����������
        /// </summary>
        public string ImageFileName
        {
            get
            {
                return (_imageFileName);
            }
            set
            {
                _imageFileName = value;
            }

        }

        /// <summary>
        /// ��������. ������ � ���������� ���� ��������
        /// </summary>
        public DateTime CreationDate
        {
            get
            {
                return (_creationDate);
            }
            set
            {
                _creationDate = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// �����. ���������� ����� ��������
        /// </summary>
        public override object Clone()
        {
            IPicture picture;

            picture = (IPicture)base.Clone();

            picture.Type = Type;
            picture.ImageFileName = ImageFileName;

            return ((object)picture);
        }

        /// <summary>
        /// �����. ���������� ��� �������� ��� ��������� ������
        /// </summary>
        public string GetPictureTypeAsString(PictureTypes pictureType)
        {
            return (Picture.GetPictureTypeAsStringStatic(pictureType));
        }

        #endregion
    }
}
