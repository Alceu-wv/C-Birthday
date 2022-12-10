using Microsoft.EntityFrameworkCore;

namespace BirthdayAT.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
