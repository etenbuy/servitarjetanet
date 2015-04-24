using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace BusinessObjects
{
    public class Usuario 
    {
        public string password { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public MembershipUser memUser { get; set; }

        public string usuario { get; set; }

        public int CuentaID { get; set; }

    }
}
