using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessFacade;

namespace ViewSec.Models
{
    public class RiderViewModel
    {
        public Band Band { get; set; }
        public Catering Catering { get; set; }
        public List<Kleedkamer> Kleedkamers { get; set; }
        public Logistic Logistic { get; set; }
        public Optreden Optreden { get; set; }
        public List<ProductieUnit> ProductieUnits { get; set; }
        public Special Special { get; set; }
        public Stage Stage { get; set; }
        public Tent Tent { get; set; }
        public Voorziening Voorziening { get; set; }
    }
}
