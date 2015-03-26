using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Cuenta : BusinessObject
    {
        
        public int CuentaID { get; set; }

        public string Numero { get; set; }

        public string co_cli { get; set; }

        public decimal Saldo { get; set; }

        public DateTime FechaCreado { get; set; }

        public string LoginCreado { get; set; }

        public int UltimaTransaccionID { get; set; }

        public int BovedaID { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public int Activo { get; set; }

        public string ActivoDescripcion { get; set; }
    
        public Cuenta()
        {

        }
    }
}
