using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
    public class ConditionRequest
    {
        [Required]
        public string State { get; set; }
    }
}
