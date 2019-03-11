using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessFacade;
using Data;

namespace ViewSec.Data
{
    public class DbInitializer
    {
        public static void Initialize(GmmContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bands.Any())
            {
                return;
            }

            //TODO read data from excel

            Member ozzy = new Member
            {
                Name = "Ozzy Osbourne"
            };
            Band sabbath = new Band
            {
                Name = "Grey Sabbath",
                Members = new List<Member> { ozzy }
            };
            Stage mainstage = new Stage { Name = "Mainstage 1" };
            Tent maintent = new Tent { Name = "MainTENT 1" };
            Kleedkamer boneroom = new Kleedkamer { Name = "Boneroom" };
            ProductieUnit prodUnit = new ProductieUnit { Name = "Pedal that goes twang" };
            Voorziening voorziening = new Voorziening {
                Wasserij = true,
                Coolersband = 3,
                Comments = "All food clearly labeled/nJuicer (x1)"
            };
            Catering catering = new Catering {
                AfterShow = true
            };
            Logistic logistic = new Logistic {
                Verlengkabels = true,
                Voltage110 = 6, 
                Comments = "110V elke KK/nQuick change on stage"
            };
            Special special = new Special {
                HdWitGr = 100, 
                HdZwartKl = 30,
                Runner = 1, 
                Arts = "mogelijk", 
                Zuurstof = 2,
                Comments = "Zuurstof + masker (x2)"
            };

            Optreden sabbOptreden = new Optreden {
                Band = sabbath, 
                Catering = catering, 
                Date = DateTime.Now, 
                Hours = 2, 
                Logistic = logistic, 
                Special = special, 
                Stage = mainstage, 
                Tent = maintent, 
                Voorziening = voorziening
            };
            BandKleedkamers sabbKleedkamer = new BandKleedkamers
            {
                Uurdatum = DateTime.Now,
                Kleedkamers = new List<Kleedkamer> { boneroom }, 
                Optreden = sabbOptreden
            };
            BandProductieUnits sabbProd = new BandProductieUnits
            {
                Uurdatum = DateTime.Now,
                ProductieUnit = prodUnit,
                Optreden = sabbOptreden
            };

            context.Members.AddRange(ozzy);
            context.Bands.AddRange(sabbath);
            context.Stages.Add(mainstage);
            context.Tents.Add(maintent);
            context.Kleedkamers.Add(boneroom);
            context.ProductieUnits.Add(prodUnit);
            context.BandKleedkamers.Add(sabbKleedkamer);
            context.BandProductieUnits.Add(sabbProd);
            context.Voorzienings.Add(voorziening);
            context.Caterings.Add(catering);
            context.Logistics.Add(logistic);
            context.Specials.Add(special);
            context.Optredens.Add(sabbOptreden);

            context.SaveChanges();

            //TODO Inital migration als data in db zit
        }
    }
}
