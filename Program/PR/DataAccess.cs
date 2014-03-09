using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PR.Classes;

namespace PR
{
    /// <summary>
    /// Класс. Контекст работы с базой данных
    /// </summary>
    class DatabaseContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает набор документов
        /// </summary>
        public DbSet<Document> Documents { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор людей
        /// </summary>
        public DbSet<Man> Mans { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор клиентов
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор сотрудников
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор стран
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набо регионов
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор городов
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор улиц
        /// </summary>
        public DbSet<Street> Streets { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор комплексов
        /// </summary>
        public DbSet<Complex> Complexes { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор домов
        /// </summary>
        public DbSet<Home> Homes { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор квартир
        /// </summary>
        public DbSet<Apartment> Appartments { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор компаний
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор картинок
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает набор отчетов
        /// </summary>
        public DbSet<Report> Reports { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Задает конфигурацию базы данных и таблиц базы данных
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocumentsTypeConfiguration());          // Добавить конфигурацию для таблицы "Документы"
            modelBuilder.Configurations.Add(new MansTypeConfiguration());               // Добавить конфигурацию для таблицы "Люди"
            modelBuilder.Configurations.Add(new ClientsTypeConfiguration());            // Добавить конфигурацию для таблицы "Клиенты"
            modelBuilder.Configurations.Add(new EmployeesTypeConfiguration());          // Добавить конфигурацию для таблицы "Сотрудники"

            modelBuilder.Configurations.Add(new CountriesTypeConfiguration());          // Добавить конфигурацию для таблицы "Страны"
            modelBuilder.Configurations.Add(new RegionsTypeConfiguration());            // Добавить конфигурацию для таблицы "Регионы"
            modelBuilder.Configurations.Add(new CitiesTypeConfiguration());             // Добавить конфигурацию для таблицы "Города"
            modelBuilder.Configurations.Add(new StreetsTypeConfiguration());            // Добавить конфигурацию для таблицы "Улицы"
            modelBuilder.Configurations.Add(new ComplexesTypeConfiguration());          // Добавить конфигурацию для таблицы "Комплекса"
            modelBuilder.Configurations.Add(new HomesTypeConfiguration());              // Добавить конфигурацию для таблицы "Дома"
            modelBuilder.Configurations.Add(new AppartmentsTypeConfiguration());        // Добавить конфигурацию для таблицы "Квартиры"

            modelBuilder.Configurations.Add(new PicturesTypeConfiguration());           // Добавить конфигурацию для таблицы "Картинки"
            modelBuilder.Configurations.Add(new ReportsTypeConfiguration());            // Добавить конфигурацию для таблицы "Отчеты"


            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Classes

        /// <summary>
        /// Класс. Конфигурация таблицы "Документы"
        /// </summary>
        private class DocumentsTypeConfiguration : EntityTypeConfiguration<Document>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public DocumentsTypeConfiguration()
            {
                HasKey(d => d.Id);

                Property(d => d.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(d => d.Description).IsOptional();
                Property(d => d.Type).IsRequired();
                Property(d => d.Series).IsRequired();
                Property(d => d.Number).IsRequired();
                Property(d => d.DataOfIssue).IsRequired().HasColumnType("datetime2");

                HasOptional(d => d.ManForEntityFramework).WithOptionalDependent(m => m.DocumentForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Люди"
        /// </summary>
        private class MansTypeConfiguration : EntityTypeConfiguration<Man>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public MansTypeConfiguration()
            {
                HasKey(m => m.Id);

                Property(m => m.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(m => m.Description).IsOptional();
                Property(m => m.Name).IsRequired();
                Property(m => m.Surname).IsRequired();
                Property(m => m.Patronymic).IsRequired();

                HasOptional(m => m.ClientForEntityFramework).WithOptionalDependent(c => c.ManForEntityFramework).WillCascadeOnDelete(false);
                HasOptional(m => m.EmployeeForEntityFramework).WithOptionalDependent(e => e.ManForEntityFramework).WillCascadeOnDelete(false);
            }

        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Клиенты"
        /// </summary>
        private class ClientsTypeConfiguration : EntityTypeConfiguration<Client>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public ClientsTypeConfiguration()
            {
                HasKey(c => c.Id);

                Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(c => c.Description).IsOptional();

        //        HasOptional(c => c.ReportForEntityFramwork).WithOptionalDependent(r => r.ClientForEntityFramwork).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Сотрудники"
        /// </summary>
        private class EmployeesTypeConfiguration : EntityTypeConfiguration<Employee>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public EmployeesTypeConfiguration()
            {
                HasKey(e => e.Id);

                Property(e => e.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(e => e.Description).IsOptional();
                Property(e => e.FurtherEducation).IsOptional();
                Property(e => e.Insurance).IsOptional();
                Property(e => e.Membership).IsOptional();
                Property(e => e.WorkTime).IsOptional();

              //  HasOptional(e => e.ReportForEntityFramwork).WithOptionalDependent(r => r.EmployeeForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Страны"
        /// </summary>
        private class CountriesTypeConfiguration : EntityTypeConfiguration<Country>
        {
            public CountriesTypeConfiguration()
            {
                HasKey(c => c.Id);

                Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(c => c.Description).IsOptional();
                Property(c => c.Name).IsRequired();
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Регионы"
        /// </summary>
        private class RegionsTypeConfiguration : EntityTypeConfiguration<Region>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public RegionsTypeConfiguration()
            {
                HasKey(r => r.Id);

                Property(r => r.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(r => r.Description).IsOptional();
                Property(r => r.Name).IsRequired();

                HasOptional(r => r.CountryForEntityFramework).WithMany(c => c.RegionsForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Города"
        /// </summary>
        private class CitiesTypeConfiguration : EntityTypeConfiguration<City>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public CitiesTypeConfiguration()
            {
                HasKey(c => c.Id);

                Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(c => c.Description).IsOptional();
                Property(c => c.Name).IsRequired();

                HasOptional(c => c.RegionForEntityFramework).WithMany(r => r.CitiesForEntityFramwork).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Улицы"
        /// </summary>
        private class StreetsTypeConfiguration : EntityTypeConfiguration<Street>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public StreetsTypeConfiguration()
            {
                HasKey(s => s.Id);

                Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(s => s.Description).IsOptional();
                Property(s => s.Name).IsRequired();

                HasOptional(s => s.CityForEntityFramework).WithMany(c => c.StreetsForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Комплекса"
        /// </summary>
        private class ComplexesTypeConfiguration : EntityTypeConfiguration<Complex>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public ComplexesTypeConfiguration()
            {
                HasKey(c => c.Id);

                Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(c => c.Description).IsOptional();
                Property(c => c.Number).IsRequired();

                HasOptional(c => c.CityForEntityFramework).WithMany(c => c.ComplexesForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Дома"
        /// </summary>
        private class HomesTypeConfiguration : EntityTypeConfiguration<Home>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public HomesTypeConfiguration()
            {
                HasKey(h => h.Id);

                Property(h => h.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(h => h.Description).IsOptional();
                Property(h => h.Number).IsRequired();
                Property(h => h.ComplexNumber).IsOptional();

                HasOptional(h => h.StreetForEntityFramework).WithMany(s => s.HomesForEntityFramework).WillCascadeOnDelete(false);
                HasOptional(h => h.ComplexForEntityFramework).WithMany(s => s.HomesForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Квартиры"
        /// </summary>
        private class AppartmentsTypeConfiguration : EntityTypeConfiguration<Apartment>
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public AppartmentsTypeConfiguration()
            {
                HasKey(a => a.Id);

                Property(a => a.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(a => a.Description).IsOptional();
                Property(a => a.Number).IsRequired();

                HasOptional(a => a.HomeForEntityFramework).WithMany(h => h.AppartmentsForEntityFramework).WillCascadeOnDelete(false);
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Картинки"
        /// </summary>
        private class PicturesTypeConfiguration : EntityTypeConfiguration<Picture>
        {
            public PicturesTypeConfiguration()
            {
                HasKey(p => p.Id);

                Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(p => p.Description).IsOptional();
                Property(p => p.Name).IsRequired();
                Property(p => p.ImageFileName).IsOptional();
                Property(p => p.CreationDate).IsRequired();
            }
        }

        /// <summary>
        /// Класс. Конфигурация таблицы "Отчеты"
        /// </summary>
        private class ReportsTypeConfiguration : EntityTypeConfiguration<Report>
        {
            public ReportsTypeConfiguration()
            {
                HasKey(r => r.Id);

                Property(r => r.ReportNumber).IsRequired();

                Property(r => r.DateOfContract).IsRequired().HasColumnType("datetime2");
                Property(r => r.EvaluationDate).IsRequired().HasColumnType("datetime2");
                Property(r => r.ReportDate).IsRequired().HasColumnType("datetime2");
                HasOptional(e => e.EmployeeForEntityFramework);
            }
        }

        #endregion
    }
}
