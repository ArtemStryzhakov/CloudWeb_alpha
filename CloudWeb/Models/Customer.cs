namespace CloudWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }
        public enum gender { mees, emane }
        public gender Gender { get; set; }
    }
}
