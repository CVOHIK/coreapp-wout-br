using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Voorziening")]
    public class Voorziening
    {
        public int Id { get; set; }
        public ICollection<Optreden> Optredens { get; set; }
        public bool Wasserij { get; set; }
        public int Busstock { get; set; }
        public int Coolersband { get; set; }
        public int CoolersGMM { get; set; }
        public string Comments { get; set; }
    }
}
