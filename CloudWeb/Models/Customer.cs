using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("Nimi")]
        public string Name { get; set; }
        [DisplayName("Perenimi")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Sünnikuupäev")]
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }
        public enum gender { mees, emane }
        [DisplayName("Sugu")]
        public gender Gender { get; set; }
    }
}
