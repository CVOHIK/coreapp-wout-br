using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    /// <summary>
    /// The Model class for the Data table.
    /// </summary>
    [Table("Optreden")]
    public class Optreden
    {
        public int Id { get; set; }
        public Band Band { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public Stage Stage { get; set; }
        public Tent Tent { get; set; }
        public Catering Catering { get; set; }
        public Logistic Logistic { get; set; }
        public Special Special { get; set; }
        public Voorziening Voorziening { get; set; }
    }
}
