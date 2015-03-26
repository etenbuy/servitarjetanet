using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class SolicitudController 
    {
        
        public ControllerResult CrearSolicitud(Solicitud solicitud, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = SolicitudDao.CrearSolicitud(solicitud, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
                MailController mail = new MailController();
                mail.SendMail("Solicitud ServiTarjeta", resultado.Login, solicitud.Nota, solicitud.SolicitudTipoID);
                resultado.Mensaje = "Correcto: La Solicitud se ha creado satisfactoriamente.";
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
