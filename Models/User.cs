using System.ComponentModel.DataAnnotations;

namespace TigerPhoneAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }

        public virtual List<Plan> Plans { get; set; }
        public virtual List<Device> Devices { get; set; }

    }
}
