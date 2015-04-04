using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Ticket
    {
        public int TicketID { get; set; }

        public decimal Monto_Desde { get; set; }

        public decimal Monto_Hasta { get; set; }

        public decimal Monto_Pagar { get; set; }

       
    }
}
