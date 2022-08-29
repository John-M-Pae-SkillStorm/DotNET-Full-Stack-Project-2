using System.ComponentModel.DataAnnotations;

namespace TigerPhoneAPI.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
    }
}
