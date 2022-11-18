using System.ComponentModel.DataAnnotations.Schema;

namespace CloudWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public enum developerSpec { Backend_Developer, Frontend_Developer, Designer, QA_Speсialist }
        public developerSpec Specialization { get; set; }
        
        [ForeignKey("Team")]
        public int teamId { get; set; }
        public Team? Team { get; set; }
    }
}
