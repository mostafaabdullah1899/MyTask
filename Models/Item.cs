using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Rubikans.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public int Weight { get; set; }
        public int Price { get; set;}
        public int Quantity { get; set; }

        [ForeignKey("Inventory")]        
        public int InventoryId { get; set; }
        public virtual Inventory? Inventory { get; set; }

        public virtual List<ItemTransaction>? ItemTransactions { get; set; }
    }
}
