using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TigerPhoneAPI.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int PlanType { get; set; }
        public int PlanPrice { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; }
        //public virtual ICollection<Device> Devices { get; set; }


    }
}
