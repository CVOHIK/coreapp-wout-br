using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Special")]
    public class Special
    {
        public int Id { get; set; }
        public ICollection<Optreden> Optredens { get; set; }
        [Display(Name = "HD wit gr")]
        public int HdWitGr { get; set; }
        [Display(Name = "HD wit kl")]
        public int HdItKl { get; set; }
        [Display(Name = "HD zwart gr")]
        public int HdZwartGr { get; set; }
        [Display(Name = "HD zwart kl")]
        public int HdZwartKl { get; set; }
        public int Runner { get; set; }
        public int Arts { get; set; }
        public int Zuurstof { get; set; }
        public int Kine { get; set; }
        public int Vervoer { get; set; }
        public string Comments { get; set; }
    }
}
