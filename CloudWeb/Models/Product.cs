namespace CloudWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public enum productType { Website, Sowtware, Special_Tools }
        public productType ProductType { get; set; }
        /*public string Difficulty { get; set; }
        public enum mainProgLanguages { Python, CSharp, Java, JavaScript, YoptaScript, Rust, Go, Scala, Ruby }
        public mainProgLanguages progLanguages { get; set; }
        
         productName,ProductType
        */

    }
}
