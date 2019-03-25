using BusinessFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewSec.Areas.User.ViewModels
{
    public class CreateOptredenViewModel
    {
        public Optreden Optreden { get; set; }
        public SelectList Bands { get; set; }
    }
}
