using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Tent")]
    public class Tent
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
