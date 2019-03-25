using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessFacade;

namespace ViewSec.Areas.User.Models
{
    public class RiderViewModel
    {
        public Band Band { get; set; }
        public Catering Catering { get; set; }
        public ICollection<Kleedkamer> Kleedkamers { get; set; }
        public Logistic Logistic { get; set; }
        public Optreden Optreden { get; set; }
        public ICollection<ProductieUnit> ProductieUnits { get; set; }
        public Special Special { get; set; }
        public Stage Stage { get; set; }
        public Tent Tent { get; set; }
        public Voorziening Voorziening { get; set; }
        public ICollection<BandKleedkamers> BandKleedkamers { get; set; }
        public ICollection<BandProductieUnits> BandProductieUnits { get; set; }
    }
}
