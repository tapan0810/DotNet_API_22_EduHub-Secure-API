namespace DotNet_API_22_.Entities.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty ;
        public bool AdmissionOpen { get; set; } = false;
    }
}
