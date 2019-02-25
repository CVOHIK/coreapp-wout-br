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

            Member one = new Member
            {
                Name = "Ozzy Osbourne"
            };
            context.Members.AddRange(
                one
                );
            context.Bands.AddRange(
                new Band
                {
                    Name = "Black Sabbath",
                    Members = new List<Member>{ one }
                });
            context.SaveChanges();

            //TODO Inital migration als data in db zit
        }
    }
}
