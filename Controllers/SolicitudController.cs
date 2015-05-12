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
        
        public ControllerResult CrearSolicitud(Solicitud solicitud, string login,string filepath, string fullPathrecibo)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = SolicitudDao.CrearSolicitud(solicitud, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
                MailController mail = new MailController();
                mail.SendMail("Solicitud ServiTarjeta",solicitud.SolicitudID, resultado.Login, solicitud.Nota, solicitud.StatusSolicitudID, solicitud.Monto,solicitud.Monto_Pagado, filepath, fullPathrecibo);
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

        public IList<Solicitud> Solicitudes_Get_ByClient(string LoginCreado)
        {
            return SolicitudDao.GetSolicitudesByClient(LoginCreado);

        }
        public IList<Solicitud> Solicitudes_TarjetaGet_ByClient(string LoginCreado, string tarjeta)
        {
            return SolicitudDao.GetSolicitudesTarjetaByClient(LoginCreado, tarjeta);

        }

        public IList<Solicitud> Solicitudes_EstadoCuentaGet_ByClient(string LoginCreado, string tarjeta ,string mes,string ano)
        {
            return SolicitudDao.GetSolicitudesEstadoCuentaTarjetaByClient(LoginCreado, tarjeta,mes,ano);

        }

        public IList<Solicitud> Solicitudes_TarjetaPagadasGet_ByClient(string LoginCreado,string tarjeta)
        {
            return SolicitudDao.GetSolicitudesTarjetaPagadasByClient(LoginCreado,tarjeta);

        }
        public IList<Solicitud> GetClientesTotalesByClient()
        {
            return SolicitudDao.GetClientesTotalesByClient();

        }
        

        public Solicitud SolicitudesTotales_Get_ByClient(string LoginCreado)
        {
            return SolicitudDao.GetSolicitudesTotalesByClient(LoginCreado);

        }
        public Solicitud SolicitudesTotalesTarjeta_Get_ByClient(string LoginCreado,string Tarjeta)
        {
            return SolicitudDao.GetSolicitudesTotalesTarjetaByClient(LoginCreado,Tarjeta);

        }
       
        public IList<Solicitud> Solicitudes_Get_ByID(string SolicitudID)
        {
            return SolicitudDao.GetSolicitudesByID(SolicitudID);

        }

        public ControllerResult ActualizarStatusSolicitud(Solicitud solicitud, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = SolicitudDao.ActualizarStatusSolicitud(solicitud);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Pago de registro satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }

        public ControllerResult ActualizarSolicitud(Solicitud solicitud, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = SolicitudDao.ActualizarSolicitud(solicitud);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Pago de registro satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }

        

        public IList<Solicitud> Solicitudes_Get_ByClientSolicitudID(int solicitudID)
        {
            return SolicitudDao.GetSolicitudesByClientSolicitudID(solicitudID);

        }

        public IList<Solicitud> SolicitudesAlMes_Get_ByClient(string LoginCreado)
        {
            return SolicitudDao.GetSolicitudesAlMesByClient(LoginCreado);

        }

        public Solicitud Get_IDClient(string LoginCreado)
        {
            return SolicitudDao.GetIDClient(LoginCreado);

        }

        public Solicitud Get_SolicitudID(int SolicitudID)
        {
            return SolicitudDao.GetSolicitudID(SolicitudID);

        }
        public Solicitud GetSolicitudesByClientMontoFactura(string LoginCreado,string tarjeta)
        {
            return SolicitudDao.GetSolicitudesByClientMontoFactura(LoginCreado,tarjeta);

        }
        

    }
}
