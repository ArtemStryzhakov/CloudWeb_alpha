using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace CloudWeb.Models
{
    public class Company
    {
        public int id { get; set; }
        public string nameCompany { get; set; }

        public DateTime basingDate { get; set; }
        public string Location { get; set; }
        public string directorName { get; set; }
        public string directorSurname { get; set; }
        public enum branch { Software, Website, DevTools }
        public branch productType { get; set; }
    }
}
