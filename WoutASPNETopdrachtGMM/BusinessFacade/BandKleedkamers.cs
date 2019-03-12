using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("BandKleedkamers")]
    public class BandKleedkamers
    {
        public int Id { get; set; }
        public Optreden Optreden { get; set; }
        public Kleedkamer Kleedkamer { get; set; }
        public DateTime Uurdatum { get; set; }

    }
}
