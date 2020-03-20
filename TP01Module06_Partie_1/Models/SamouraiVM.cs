using BO_TP01Module06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP01Module06_Partie_1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdSelectedArme { get; set; }
    }
}