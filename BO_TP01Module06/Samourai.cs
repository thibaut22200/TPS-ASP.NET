using System.Collections.Generic;

namespace BO_TP01Module06
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtsMartiaux { get; set; }
    }
}
