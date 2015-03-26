using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;

namespace Controllers
{
    public class ReferidoController
    {

        public ControllerResult CrearReferido(Referido referido, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = ReferidoDao.CrearReferido(referido, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
                MailController mail = new MailController();
                mail.SendMail("Referido ServiTarjeta", resultado.Login, "Nombre: " + referido.Descripcion + " Telefono: " + referido.Telefono + " Correo: " + referido.Email, 10);

                resultado.Mensaje = "Correcto: El Referido se ha creado satisfactoriamente.";
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

        public IList<Referido> Referidos_Get_ByClient(int clienteid)
        {
            return ReferidoDao.GetReferidosByClient(clienteid);

        }

        //public IList<Referido> Referidos_Get()
        //{
        //   // return ReferidoDao.GetReferidos();

        //}
        
    }
}
