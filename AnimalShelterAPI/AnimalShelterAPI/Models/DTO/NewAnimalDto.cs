using System;

namespace AnimalShelterAPI.Models.DTO
{
    public class NewAnimalDto
    {
        public string SpecialID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? MicrochipIntegrationDate { get; set; }
        public DateTime? VaccinationDate { get; set; }
        // Birthday calculated based on years and months
        public int Years { get; set; }
        public int Months { get; set; }
        public string AdmissionCity { get; set; }
        public string AdmissionRegion { get; set; }
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
        public FurType FurType { get; set; }
        public string FurColor { get; set; }
        public string SpecialTags { get; set; }
        public string HealthCondition { get; set; }
        public string AdmissionOrganisationContacts { get; set; }
    }
}
