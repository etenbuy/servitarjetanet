    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    public class Referido: BusinessObject
    {

        public int ReferidoID { get; set; }
        
        public int ClienteID { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string RIF { get; set; }


       

    }
}
