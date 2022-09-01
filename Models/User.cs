using System.ComponentModel.DataAnnotations;

namespace TigerPhoneAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }

        public List<Plan> Plans { get; set; }
        public Device Device { get; set; }

    }
}
