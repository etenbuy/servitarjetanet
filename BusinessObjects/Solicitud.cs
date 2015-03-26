    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    public class Solicitud: BusinessObject
    {

        public int ClienteID { get; set; }

        public string Nota { get; set; }

        public string LoginCreado { get; set; }

        public string FechaCreado { get; set; }


        public int SolicitudTipoID { get; set; }
       

    }
}
