using AnimalShelterAPI.Infrastructure.Repositories;
using AnimalShelterAPI.Models;
using AnimalShelterAPI.Services.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Animal> _repository;
        private readonly IReportRepository _reportRepository;

        private readonly Dictionary<int, string> TypeToSpelling = new Dictionary<int, string>()
        {
            { 0, "šunų"},
            { 1, "kačių"},
            { 2, "kitų"}
        };

        private readonly Dictionary<int, string> FurToSpelling = new Dictionary<int, string>()
        {
            { 0, "Trumpakailis"},
            { 1, "Šiurkšičplaukis"},
            { 2, "Vidutinio ilgio"},
            { 3, "Ilgaplaukis" }
        };

        public ReportService(IRepository<Animal> repository, IReportRepository reportRepository)
        {
            _repository = repository;
            _reportRepository = reportRepository;
        }

        public async Task<MemoryStream> GenerateAdmissionAct(int id)
        {
            var templateFile = Directory.GetCurrentDirectory() + "\\Report_templates\\gyvuno_priimimo_aktas.docx";
            var animal = await _repository.GetById(id);

            MemoryStream stream = new MemoryStream();
            byte[] fileBytesArray = File.ReadAllBytes(templateFile);
            stream.Write(fileBytesArray, 0, (int)fileBytesArray.Length);
            stream.Position = 0;

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
            {
                string docText = wordDoc.MainDocumentPart.Document.InnerXml;

                docText = new Regex("{priemimo_data}").Replace(docText, animal.AdmissionDate.ToShortDateString());
                docText = new Regex("{miestas}").Replace(docText, animal.AdmissionCity);
                docText = new Regex("{rajonas}").Replace(docText, animal.AdmissionRegion);
                docText = new Regex("{tipas}").Replace(docText, animal.AnimalType.ToString());
                docText = new Regex("{lytis}").Replace(docText, animal.Gender.ToString());
                docText = new Regex("{amzius}").Replace(docText, animal.Birthday == null ? "-" : FormatAnimalAge((DateTime.Today - animal.Birthday.Value).TotalDays));
                docText = new Regex("{kailis}").Replace(docText, FurToSpelling[(int)animal.FurType]);
                docText = new Regex("{zyme}").Replace(docText, animal.SpecialTags);
                docText = new Regex("{sveikata}").Replace(docText, animal.HealthCondition);
                docText = new Regex("{specialID}").Replace(docText, animal.SpecialID);
                docText = new Regex("{mikroschemos_data}").Replace(docText, animal.MicrochipIntegrationDate == null ? "-" : animal.MicrochipIntegrationDate.ToString().Substring(0, 10));
                docText = new Regex("{skiepo_data}").Replace(docText, animal.VaccinationDate == null ? "-" : animal.VaccinationDate.ToString().Substring(0, 10));
                docText = new Regex("{priimancioKontaktai}").Replace(docText, animal.AdmissionOrganisationContacts);
                docText = new Regex("{perduodancioKontaktai}").Replace(docText, animal.TransferOrganisationContacts);

                wordDoc.MainDocumentPart.Document.InnerXml = docText;
                wordDoc.MainDocumentPart.Document.Save();
            }

            stream.Position = 0;
            return stream;
        }

        public async Task<MemoryStream> GenerateYearReport(int AnimalType, int Year)
        {
            var templateFile = Directory.GetCurrentDirectory() + "\\Report_templates\\metine_ataskaita.docx";
            var report = await _reportRepository.GetAnimalReport(AnimalType, Year);

            MemoryStream stream = new MemoryStream();
            byte[] fileBytesArray = File.ReadAllBytes(templateFile);
            stream.Write(fileBytesArray, 0, (int)fileBytesArray.Length);
            stream.Position = 0;

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
            {
                string docText = wordDoc.MainDocumentPart.Document.InnerXml;

                docText = new Regex("{metai}").Replace(docText, Year.ToString());
                docText = new Regex("{gyvuno_tipas}").Replace(docText, TypeToSpelling[AnimalType]);
                docText = new Regex("{data}").Replace(docText, DateTime.Now.ToShortDateString());
                docText = new Regex("{priimta}").Replace(docText, report.AdmittedCount.ToString());
                docText = new Regex("{padovanota}").Replace(docText, report.GiftedCount.ToString());
                docText = new Regex("{mirciu}").Replace(docText, report.DeadCount.ToString());
                docText = new Regex("{gyvena}").Replace(docText, report.LivingNowCount.ToString());

                wordDoc.MainDocumentPart.Document.InnerXml = docText;
                wordDoc.MainDocumentPart.Document.Save();
            }

            //string generatedFile = "E:\\Dokumentai\\Mokslai\\DevAcadamy2020\\Animal_shelter_app\\chalturcikai\\AnimalShelterAPI\\AnimalShelterAPI\\Report_templates\\sugeneruotas_gyvuno_priimimo_aktas.docx";
            //using (FileStream file = new FileStream(generatedFile, FileMode.CreateNew))
            //    stream.WriteTo(file);

            stream.Position = 0;
            return stream;
        }

        private string FormatAnimalAge(double DayCount)
        {
            double years = Math.Truncate(DayCount / 365);
            double months = Math.Truncate((DayCount % 365) / 30);
            double days = Math.Truncate((DayCount % 365) % 30);
            return string.Format("{0} metų {1} mėnesių {2} dienų", years, months, days);
        }
    }
}
