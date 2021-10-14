namespace CRMGURU.Services.Country.Models
{
    public class RestCountryDto
    {
        public RestCountryName Name { get; set; }
        public string Cca2 { get; set; }
        public double Area { get; set; }
        public uint Population { get; set; }
        public string[] Capital { get; set; }
        public string Region { get; set; }
    }

    public class RestCountryName
    {
        public string Common { get; set; }
    }
}
