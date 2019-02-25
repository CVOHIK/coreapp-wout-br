using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Special")]
    public class Special
    {
        public int Id { get; set; }
        public ICollection<Optreden> Optredens { get; set; }
        public int HdWitGr { get; set; }
        public int HdItKl { get; set; }
        public int HdZwartGr { get; set; }
        public int HdZwartKl { get; set; }
        public int Runner { get; set; }
        public string Arts { get; set; }
        public int Zuurstof { get; set; }
        public bool Kine { get; set; }
        public bool Vervoer { get; set; }
        public string Comments { get; set; }
    }
}
