using System;

namespace api.Domain
{
    public class Annonce
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string titre { get; set; }
        public int poidDisponible { get; set; }
        public decimal prixKg { get; set; }
        public DateTime dateDepart { get; set; }
        public DateTime dateArrivee { get; set; }
        public string lieuDepart { get; set; }
        public string lieuArrivee { get; set; }
        public string Note { get; set; }


    }
}