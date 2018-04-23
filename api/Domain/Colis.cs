using System.Collections.Generic;

namespace covalisage.Domain
{
    public class Colis
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Poid { get; set; }
        public decimal Prix { get; set; }
        public string note { get; set; }
        public ICollection<Item> listeItems { get; set; }
    }
}