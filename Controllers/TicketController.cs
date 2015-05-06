using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class TicketController 
    {
        
       

        public IList<Ticket> GetTickets(decimal MontoFactura)
        {
            return TicketDao.GetMontoPagar(MontoFactura);

        }

      

        public Ticket GetTicketMontoMensual_Porcentaje()
        {
            return TicketDao.GetTicketMontoMensual_Porcentaje();

        }

    }
}
