using SQLite;
namespace T_ShirtApp
{
    public class Orders
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public int DateOfOrder { get; set; }
        public string ShippingAddress { get; set; }
    }
}
