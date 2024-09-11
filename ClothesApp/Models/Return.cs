namespace ClothesApp.Models
{
    public class Return
    {
        public int ReturnID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
    }

}
