using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Catering")]
    public class Catering
    {
        public int Id { get; set; }
        public ICollection<Optreden> Optredens { get; set; }
        public bool AfterShow { get; set; }

    }
}
