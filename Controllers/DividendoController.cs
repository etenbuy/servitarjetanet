using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;

namespace Controllers
{
    public class DividendoController
    {

        public ControllerResult CrearDividendo(Dividendo dividendo, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = DividendoDao.Dividendo_Insert(dividendo, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Dividendo se ha creado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
                resultado.MensajeExtra = daoResult.Identity.ToString();
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }

        public IList<Dividendo> Dividendos_Get_ByClient(int clienteid)
        {
            return DividendoDao.GetDividendosByClient(clienteid);

        }

        public IList<Dividendo> Dividendos_Get()
        {
            return DividendoDao.GetDividendos();

        }
        
    }
}
