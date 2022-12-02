using System.ComponentModel;

namespace CloudWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Tootenimi")]
        public string productName { get; set; }
        public enum productType { Website, Software, Special_Tools }
        [DisplayName("Toote tüüp")]
        public productType ProductType { get; set; }
    }
}