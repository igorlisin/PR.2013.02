using System;
using System.Collections.Generic;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;
using PRParser;
using System.Data.Entity;

using PR.Classes;

using PRUI.Forms;
using PRUI.TemplateForms;
using PRParser;

using PRDocument;

namespace PR
{
    public partial class Debug : TemplateDialog
    {
        ObjectModel _objectModel;
        DatabaseContext _databaseContext;

        public Debug()
        {
            InitializeComponent();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());

            _objectModel = new ObjectModel();
            _databaseContext = new DatabaseContext();
            
            _objectModel.Documents = new Documents(_databaseContext.Documents, new Documents.SaveChangesDelegate(Save));
            _objectModel.Mans = new Mans(_databaseContext.Mans, new Mans.SaveChangesDelegate(Save));
            _objectModel.Clients = new Clients(_databaseContext.Clients, new Clients.SaveChangesDelegate(Save));
            _objectModel.Employees = new Employees(_databaseContext.Employees, new Employees.SaveChangesDelegate(Save));

            _objectModel.Countries = new Countries(_databaseContext.Countries, new Countries.SaveChangesDelegate(Save));
            _objectModel.Regions = new Regions(_databaseContext.Regions, new Regions.SaveChangesDelegate(Save));
            _objectModel.Cities = new Cities(_databaseContext.Cities, new Cities.SaveChangesDelegate(Save));
            _objectModel.Streets = new Streets(_databaseContext.Streets, new Streets.SaveChangesDelegate(Save));
            _objectModel.Complexes = new Complexes(_databaseContext.Complexes, new Complexes.SaveChangesDelegate(Save));
            _objectModel.Homes = new Homes(_databaseContext.Homes, new Homes.SaveChangesDelegate(Save));
            _objectModel.Appartments = new Appartments(_databaseContext.Appartments, new Appartments.SaveChangesDelegate(Save));
            _objectModel.Objects = new Objects(_databaseContext.Objects, new Objects.SaveChangesDelegate(Save));
            _objectModel.Districts = new Districts(_databaseContext.Districts, new Districts.SaveChangesDelegate(Save));

            _objectModel.Pictures = new Pictures(_databaseContext.Pictures, new Pictures.SaveChangesDelegate(Save));
            _objectModel.Reports = new Reports(_databaseContext.Reports, new Reports.SaveChangesDelegate(Save));
            _objectModel.ComparisonAppartments = new ComparisonAparts(_databaseContext.ComparisonApartments, new ComparisonAparts.SaveChangesDelegate(Save));

            SetClassDefaultValue();
        }

        private void SetClassDefaultValue()
        {
            Man.DefaultName = "-";
            Man.DefaultSurname = "-";
            Man.DefaultPatronymic = "-";

            Country.DefaultName = "-";

            PR.Classes.Region.DefaultName = "-";

            City.DefaultName = "-";
            Street.DefaultName = "-";

            Picture.DefaultName = "-";
        }

        public void Save()
        {
            try
            {
                _databaseContext.SaveChanges();
            }
            catch
            {
            }
        }

        private void documentsButton_Click(object sender, EventArgs e)
        {
            DocumentsForm documentForm = new DocumentsForm(_objectModel.Documents);
            documentForm.ShowDialog();
        }

        private void mansButton_Click(object sender, EventArgs e)
        {
            MansForm mansForm = new MansForm(_objectModel.Mans, _objectModel.Documents);
            mansForm.ShowDialog();
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm(_objectModel.Clients, _objectModel.Mans);
            clientsForm.ShowDialog();
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(_objectModel.Employees, _objectModel.Mans);
            employeesForm.ShowDialog();
        }

        private void countriesButton_Click(object sender, EventArgs e)
        {
            CountriesForm countriesForm = new CountriesForm(_objectModel.Countries);
            countriesForm.ShowDialog();
        }

        private void regionsButton_Click(object sender, EventArgs e)
        {
            RegionsForm regionsForm = new RegionsForm(_objectModel.Regions, _objectModel.Countries);
            regionsForm.ShowDialog();
        }

        private void citiesButton_Click(object sender, EventArgs e)
        {
            CitiesForm citiesForm = new CitiesForm(_objectModel.Cities, _objectModel.Regions);
            citiesForm.ShowDialog();
        }

        private void streetsButton_Click(object sender, EventArgs e)
        {
            StreetsForm streetsForm = new StreetsForm(_objectModel.Streets, _objectModel.Cities);
            streetsForm.ShowDialog();
        }

        private void complexesButton_Click(object sender, EventArgs e)
        {
            //ComplexesForm complexesForm = new ComplexesForm(_objectModel.Complexes, _objectModel.Cities);
            //complexesForm.ShowDialog();
        }

        private void homesButton_Click(object sender, EventArgs e)
        {
            HomesForm homesForm = new HomesForm(_objectModel.Homes, _objectModel.Streets, _objectModel.Complexes, _objectModel.Districts);
            homesForm.ShowDialog();
        }

         private void picturesButton_Click(object sender, EventArgs e)
        {
            PicturesForm picturesForm = new PicturesForm(_objectModel.Pictures, _objectModel.Appartments, Properties.Settings.Default.imagesFolderPath);
            picturesForm.ShowDialog();
        }

        private void programOptionsButton_Click(object sender, EventArgs e)
        {
            ProgramOptionsForm programOptionsForm;

            programOptionsForm = new ProgramOptionsForm();

            programOptionsForm.ImagesFolderPath = Properties.Settings.Default.imagesFolderPath;
            programOptionsForm.ReportTemplatesFolderPath = Properties.Settings.Default.reportTemplatesFolderPath;
            programOptionsForm.ReportsFolderPath = Properties.Settings.Default.reportsFolderPath;
            
            programOptionsForm.ShowDialog();

            if (programOptionsForm.OptionsNeedSave == true)
            {
                Properties.Settings.Default.imagesFolderPath = programOptionsForm.ImagesFolderPath;
                Properties.Settings.Default.reportTemplatesFolderPath = programOptionsForm.ReportTemplatesFolderPath;
                Properties.Settings.Default.reportsFolderPath = programOptionsForm.ReportsFolderPath;

                Properties.Settings.Default.Save();
            }
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm a = new ReportsForm(
                _objectModel.Reports,
                _objectModel.Clients,
                _objectModel.Employees,
                _objectModel.Appartments,
                _objectModel.Objects,
                _objectModel.Homes,
                _objectModel.Mans,
                _objectModel.Documents,
                Properties.Settings.Default.reportTemplatesFolderPath,
                Properties.Settings.Default.reportsFolderPath,
                new ReportsForm.CreateReportDocument(ReportGenerator.Generate));
            a.ShowDialog();
        }

        private void apartmentsButton_Click(object sender, EventArgs e)
        {
            ApartmentsForm a = new ApartmentsForm(_objectModel.Appartments, _objectModel.Homes, _objectModel.Objects);
            a.ShowDialog();
        }

        private void DistrictButton_Click(object sender, EventArgs e)
        {
            DistrictsForm districtsForm = new DistrictsForm(_objectModel.Districts, _objectModel.Cities);
            districtsForm.ShowDialog();
        }

        private void CompareApartsButton_Click(object sender, EventArgs e)
        {
            IApartment apartAfterRelinking;

            ApartmentSelectForm ApartSelectForm = new ApartmentSelectForm(_objectModel.Appartments);
            ApartSelectForm.ShowDialog();

            if (ApartSelectForm.SelectedApartment != null)
            {
                apartAfterRelinking = ApartSelectForm.SelectedApartment;

                ParserForm parserForm = new PRParser.ParserForm(apartAfterRelinking,_objectModel.Objects, _objectModel.ComparisonAppartments);

                parserForm.ShowDialog();
            }
        }
    }
}
