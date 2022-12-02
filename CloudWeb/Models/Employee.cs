using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Nimi")]
        public string Name { get; set; }
        [DisplayName("Perenimi")]
        public string Surname { get; set; }
        public enum developerSpec { Backend_Developer, Frontend_Developer, Designer, QA_Speсialist }
        [DisplayName("Spetsialiseerumine")]
        public developerSpec Specialization { get; set; }
        
        [ForeignKey("Team")]
        public int teamId { get; set; }
        [DisplayName("Meeskond")]
        public Team? Team { get; set; }
    }
}
