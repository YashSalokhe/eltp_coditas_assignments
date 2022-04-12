namespace api.Models
{
    public class RequestInfo
    {
        [Key]
        public int RequiestID { get; set; }
        public string? ControllerName { get; set; }
        public string? RequiestMethode { get; set; }
        public DateTime DateTime { get; set; }

    }
}
