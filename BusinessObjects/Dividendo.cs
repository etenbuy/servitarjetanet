    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    public class Dividendo: BusinessObject
    {
        public int ClienteID { get; set; }

        public string Login { get; set; }

        public DateTime Fecha { get; set; }

        public string Tdc { get; set; }

        public decimal Monto { get; set; }

        public decimal Dividendo_Obtenido { get; set; }

        public string Status { get; set; }

        public string Cliente { get; set; }
       

    }
}
