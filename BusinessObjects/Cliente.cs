using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    public class Cliente : BusinessObject
    {
        public int ClienteID { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string LoginCreado { get; set; }

        public string RIF { get; set; }

        public Cliente()
        {
            AddRule(new ValidateId("ClienteID"));
        }

        public string NombrePunto { get; set; }

        public string NombreRuta { get; set; }

        public string Abreviado { get; set; }

        public int PuntoID { get; set; }

        public int PaisID { get; set; }

        public int RutaID { get; set; }

    }
}
