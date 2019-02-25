using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("BandProductieUnits")]
    public class BandProductieUnits
    {
        public int Id { get; set; }
        public Optreden Optreden { get; set; }
        public ProductieUnit ProductieUnit { get; set; }
        public DateTime Uurdatum { get; set; }

    }
}
