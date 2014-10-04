using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список картинок
    /// </summary>
    public class Pictures : IPictures
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка картинок
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор картинок
        /// </summary>
        private DbSet<Picture> _picturesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка картинок
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор картинок
        /// </summary>
        public DbSet<Picture> PicturesDbSet
        {
            get
            {
                return (_picturesDbSet);
            }
            set
            {
                _picturesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Pictures(DbSet<Picture> picturesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _picturesDbSet = picturesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую картинку
        /// </summary>
        public IPicture Create()
        {
            IPicture picture;

            picture = (IPicture)new Picture();

            picture.CreationDate = DateTime.Now;
            picture.Name = Picture.DefaultName;

            return (picture);
        }

        /// <summary>
        /// Метод. Добавляет картинку в набор картинок
        /// </summary>
        public void Add(IPicture picture)
        {
            _picturesDbSet.Add((Picture)picture);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет картинку из набора картинок
        /// </summary>
        public void Remove(IPicture picture)
        {
            _picturesDbSet.Remove((Picture)picture);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет картинку с указанным идентификатором из списка картинок
        /// </summary>
        public void RemoveById(int id)
        {
            IPicture picture;

            picture = GetPicture(id);

            if (picture != null)
            {
                _picturesDbSet.Remove((Picture)picture);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список картинок
        /// </summary>
        public List<IPicture> ToList()
        {
            return (_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToList<IPicture>());
        }

        /// <summary>
        /// Метод. Возвращает массив картинок
        /// </summary>
        public IPicture[] ToArray()
        {
            return (_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToArray<IPicture>());
        }

        /// <summary>
        /// Метод. Возвращает картинку с указанным идентификатором из списка картинок
        /// </summary>
        public IPicture GetPicture(int id)
        {
            return ((IPicture)_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).Where(p => p.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает список картинок для выбранной квартиры
        /// </summary>
        public IPictures PicturesForApartment(IApartment apartment)
        {
            return (IPictures)_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).Where(p => p.Apartment == apartment);
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_picturesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка картинок
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToArray<Picture>()));
        }
    }
}
