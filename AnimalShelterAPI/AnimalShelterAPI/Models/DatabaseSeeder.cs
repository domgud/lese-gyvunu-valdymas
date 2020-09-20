using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using AnimalShelterAPI.Models;

namespace AnimalShelterAPI.Database
{
    public class DatabaseSeeder
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Statuses.Any())
                context.Statuses.AddRange(
                    new Status
                    {
                        Name = "Atiduotas"
                    },
                    new Status
                    {
                        Name = "Miręs"
                    },
                    new Status
                    {
                        Name = "Gyvena prieglaudoje"
                    }
                );

            context.SaveChanges();

            if (!context.Animals.Any())
                context.Animals.AddRange(
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2019-06-03"),
                        Birthday = DateTime.Parse("2018-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        SpecialID = "a1s6a1s",
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šilainiai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Vidutinio_ilgio,
                        FurColor = "Juodas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2018-01-03"),
                        Birthday = DateTime.Parse("2017-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        SpecialID = "a1s6a1ssa",
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Naujamiestis",
                        AnimalType = AnimalType.Katė,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Ilgaplaukis,
                        FurColor = "Pilkas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Fluffy, loud",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Klinikų g. 1, Buivydiškės",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-01-03"),
                        Birthday = DateTime.Parse("2019-01-02"),
                        MicrochipIntegrationDate = null,
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        SpecialID = "a1s64529s",
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Moteriška,
                        FurType = FurType.Trumpakailis,
                        FurColor = "Baltas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2019-12-03"),
                        Birthday = DateTime.Parse("2015-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        SpecialID = "a1saassd",
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Vilijampolė",
                        AnimalType = AnimalType.Katė,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Ilgaplaukis,
                        FurColor = "Rudas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Chubby, sweet",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2016-02-03"),
                        Birthday = DateTime.Parse("2016-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1s6asd26",
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Šiurkšičplaukis,
                        FurColor = "Juodas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        Birthday = DateTime.Parse("2014-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1s6515a",
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = AnimalType.Katė,
                        Gender = Gender.Moteriška,
                        FurType = FurType.Trumpakailis,
                        FurColor = "Pilkas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Fluffy, loud",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2017-08-03"),
                        Birthday = DateTime.Parse("2013-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1s6a266as1s",
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Moteriška,
                        FurType = FurType.Šiurkšičplaukis,
                        FurColor = "Rudas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Overall just great",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    }, 
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2016-07-03"),
                        Birthday = DateTime.Parse("2018-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1165s6a1s",
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Trumpakailis,
                        FurColor = "Juodas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    }, 
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-03-03"),
                        Birthday = DateTime.Parse("2018-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1a5ss6a1s",
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = AnimalType.Katė,
                        Gender = Gender.Moteriška,
                        FurType = FurType.Šiurkšičplaukis,
                        FurColor = "Rudas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2018-11-03"),
                        Birthday = DateTime.Parse("2014-01-02"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        SpecialID = "a1s6a5s15a1s",
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = AnimalType.Šuo,
                        Gender = Gender.Vyriška,
                        FurType = FurType.Vidutinio_ilgio,
                        FurColor = "Rudas",
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        TransferOrganisationContacts = "Vardenis Pavardenis, +866216815",
                        StatusDate = null
                    }
                );

            context.SaveChanges();
        }
    }
}
