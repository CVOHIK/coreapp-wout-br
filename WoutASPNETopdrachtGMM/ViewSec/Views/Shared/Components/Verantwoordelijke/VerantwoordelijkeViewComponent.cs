using BusinessFacade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewSec.Views.Shared.Components.Verantwoordelijke
{
    public class VerantwoordelijkeModel
    {
        public ICollection<Member> Members { get; set; }
        public string Functie { get; set; }
    }

    /// <summary>Prints a header with a given Function name and the name(s) of the Members with that Function</summary>
    public class VerantwoordelijkeViewComponent : ViewComponent
    {
        public VerantwoordelijkeViewComponent() { }
        public IViewComponentResult Invoke(ICollection<Member> members, string functie)
        {
            var filteredMembers = members.Where(m => m.Function.Name.Equals(functie)).ToHashSet();
            string viewName = "Default";
            if (filteredMembers.Count == 1)
            {
                viewName = "Enkel";
            }
            else if (filteredMembers.Count > 1)
            {
                viewName = "Meerdere";
            }

            return View(viewName, new VerantwoordelijkeModel
            {
                Members = filteredMembers,
                Functie = functie
            });
        }
    }
}
