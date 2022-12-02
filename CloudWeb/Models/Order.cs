using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudWeb.Models
{
    public class Order
    {
        
        public int Id { get; set; }

        [ForeignKey("Team")]
        public int teamId { get; set; }
        [DisplayName("Meeskond")]
        public Team? Team { get; set; }

        [ForeignKey("ProductName")]
        public int productId { get; set; }
        [DisplayName("Tootenimi")]
        public Product? ProductName { get; set; }
        
        [ForeignKey("whoseOrder")]
        public int customerId { get; set; }
        [DisplayName("Kelle tellimus")]
        public Customer? whoseOrder { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Tähtaeg")]
        public DateTime deadLine { get; set; }
    }
}
