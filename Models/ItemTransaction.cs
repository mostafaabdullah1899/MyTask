using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Rubikans.Models
{
    public class ItemTransaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QtyBefore{ get; set; }
        public int Quantity { get; set; }
        public int QtyAfter { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}
