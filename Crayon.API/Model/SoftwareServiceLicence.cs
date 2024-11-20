namespace Crayon.API.Model
{
    public class SoftwareServiceLicence
    {
        public SoftwareService SoftwareService { get; set; }
        public int Id { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Status { get; set; }
    }
}
