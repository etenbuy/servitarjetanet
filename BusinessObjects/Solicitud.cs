    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    public class Solicitud: BusinessObject
    {
        public int SolicitudID { get; set; }

        public int SolicitudTipoID { get; set; }

        public int StatusSolicitudID { get; set; }

        public int ClienteID { get; set; }

        public string LoginCreado { get; set; }

        public string Factura { get; set; }

        public string FechaCreado { get; set; }

        public string Estado { get; set; }

        public string Nota { get; set; }

        public decimal Monto { get; set; }

        public decimal Monto_Pagado { get; set; }
        
       

    }
}
