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

            Function tourmanager = new Function
            {
                Name = "TourManager"
            }; Function prodmanager = new Function
            {
                Name = "Production Manager"
            }; Function begeleider = new Function
            {
                Name = "Artiestenbegeleider"
            };

            var members = new List<Member> {
                new Member
                {
                    Name = "Thomas Reitz",
                    Function = tourmanager
                },
                new Member
                {
                    Name = "George Reeves",
                    Function = prodmanager
                },
                new Member
                {
                    Name = "Liesbeth Huber",
                    Function = begeleider
                },
                new Member
                {
                    Name = "Nele Knockaert",
                    Function = begeleider
                }
            };

            Band sabbath = new Band
            {
                Name = "Grey Sabbath",
                Members = members, 
                GroepsColor = 1
            };
            Stage mainstage = new Stage { Name = "Mainstage 1" };
            Tent maintent = new Tent { Name = "MainTENT 1" };
            Kleedkamer[] kleedkamers = new Kleedkamer[] {
                new Kleedkamer { Name = "1" },
                new Kleedkamer { Name = "6" }
            };
            ProductieUnit[] prodUnit = new ProductieUnit[] {
                new ProductieUnit{Name = "P1" },
                new ProductieUnit{Name = "P2" }
            };
            Voorziening voorziening = new Voorziening
            {
                Wasserij = 1,
                Coolersband = 3,
                Comments = "All food clearly labeled/nJuicer (x1)"
            };
            Catering catering = new Catering
            {
                AfterShow = true
            };
            Logistic logistic = new Logistic
            {
                Verlengkabels = true,
                Voltage110 = 6,
                Comments = "110V elke KK/nQuick change on stage"
            };
            Special special = new Special
            {
                HdWitGr = 100,
                HdZwartKl = 30,
                Runner = 1,
                Arts = 1,
                Zuurstof = 2,
                Comments = "Zuurstof + masker (x2)"
            };

            Optreden sabbOptreden = new Optreden
            {
                Band = sabbath,
                Catering = catering,
                Date = DateTime.Now,
                Hours = "None",
                Logistic = logistic,
                Special = special,
                Stage = mainstage,
                Tent = maintent,
                Voorziening = voorziening
            };

            BandKleedkamers[] sabbKleedkamer = new BandKleedkamers[kleedkamers.Length];
            for (int i = 0; i < kleedkamers.Length; i++)
            {
                sabbKleedkamer[i] = new BandKleedkamers
                {
                    Uurdatum = DateTime.Now,
                    Kleedkamer = kleedkamers[i],
                    Optreden = sabbOptreden
                };
            };
            BandProductieUnits[] sabbProd = new BandProductieUnits[prodUnit.Length];
            for (int i = 0; i < prodUnit.Length; i++)
            {
                sabbProd[i] = new BandProductieUnits
                {
                    Uurdatum = DateTime.Now,
                    ProductieUnit = prodUnit[i],
                    Optreden = sabbOptreden
                };
            };

            context.Members.AddRange(members);
            context.Bands.Add(sabbath);
            context.Stages.Add(mainstage);
            context.Tents.Add(maintent);

            context.Kleedkamers.AddRange(kleedkamers);
            context.ProductieUnits.AddRange(prodUnit);
            context.BandKleedkamers.AddRange(sabbKleedkamer);
            context.BandProductieUnits.AddRange(sabbProd);

            context.Voorzienings.Add(voorziening);
            context.Caterings.Add(catering);
            context.Logistics.Add(logistic);
            context.Specials.Add(special);
            context.Optredens.Add(sabbOptreden);

            context.SaveChanges();
        }
    }
}
