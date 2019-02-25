using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Logistic")]
    public class Logistic
    {
        public int Id { get; set; }
        public ICollection<Optreden> Optredens { get; set; }
        public bool Verlengkabels { get; set; }
        public int Voltage110 { get; set; }
        public string Comments { get; set; }
    }
}
