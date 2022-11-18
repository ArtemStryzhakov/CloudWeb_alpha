using System.ComponentModel.DataAnnotations;

namespace CloudWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }
        public enum gender { mees, emane }
        public gender Gender { get; set; }
    }
}
