using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObjects;

namespace Controllers.Vistas
{
    public class Cuenta
    {

        public DataTable DiferenciasPorFecha(DateTime desde, DateTime hasta)
        {
            return VistaDao.VW_DiferenciasPorFecha(desde, hasta);
        }

        public DataTable GetCuentasTipo()
        {
            return VistaDao.VW_GetCuentasTipo();
        }

        public DataTable GetCuentasTipoVab()
        {
            return VistaDao.VW_GetCuentasTipoVab();
        }

        public DataTable GetCuentas()
        {
            return VistaDao.VW_GetCuentas();
        }
        public DataTable GetCuentasNumero()
        {
            return VistaDao.VW_GetCuentasNumero();
        }
    }
}
