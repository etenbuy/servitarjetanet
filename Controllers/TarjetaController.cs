using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class TarjetaController 
    {
        
      

        public IList<Tarjeta> Get_Tarjetas(int ClienteID)
        {
            return TarjetaDao.Tarjetas_GET(ClienteID);

        }
        public Tarjeta ObtenerTarjeta(string numero)
        {

            return TarjetaDao.Get_tarjeta(numero);

        }

        public ControllerResult ActualizarTarjeta(Tarjeta tarjeta, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = TarjetaDao.ActualizarTarjeta(tarjeta, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {

                resultado.Mensaje = "Correcto: Tarjeta actualizada correctamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }
        public ControllerResult CrearTarjeta(Tarjeta tarjeta,string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = TarjetaDao.CrearTarjeta(tarjeta, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
               
                resultado.Mensaje = "Correcto: La Tarjeta afiliada correctamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }


    }
}
