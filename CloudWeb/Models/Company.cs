using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudWeb.Models
{
    public class Company
    {
        public int id { get; set; }
        [DisplayName("Ettevõtte divisjon")]
        public string nameCompany { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Aluskuupäev")]
        public DateTime basingDate { get; set; }
        [DisplayName("Asukoht")]
        public string Location { get; set; }
        [DisplayName("Direktori nimi")]
        public string directorName { get; set; }
        [DisplayName("Direktori Perekonnanimi")]
        public string directorSurname { get; set; }
        public enum branch { Software, Website, DevTools }
        [DisplayName("Toote tüüp")]
        public branch productType { get; set; }
    }
}