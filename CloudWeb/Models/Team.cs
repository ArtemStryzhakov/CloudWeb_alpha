using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudWeb.Models
{
    public class Team
    {
        public int Id { get; set; }
        [DisplayName("Meeskonnanimi")]
        public string TeamName { get; set; }
        [DisplayName("Töötajad")]
        public List<Employee>? Employees { get; set; }
    }
}
