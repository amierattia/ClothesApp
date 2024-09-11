namespace ClothesApp.Models
{
    public class DashHome
    {
        public int ProducSum{ get; set; }
        public int OrderSum{ get; set; }
        public int SalesSum { get; set; }
        public int ReturnSum{ get; set; }
        public List<Sale> OSales { get; set; } = new List<Sale>(); // Updated to List<Sale>

    }
}
