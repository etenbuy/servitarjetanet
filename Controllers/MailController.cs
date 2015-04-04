using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using BusinessObjects.BusinessRules;
using System.Data;

namespace Controllers
{
    public class MailController
    {
        public IList<Ticket> Get_MontoPagar(decimal Monto)
        {
            return TicketDao.GetMontoPagar(Monto);

        }

        public void SendMail(string Subject, string Client,string Note, int Tipo , decimal Monto)
        {
            string tipo="";
            if (Tipo == 1)
            {
                tipo = "Proteccion Financiera";
            }
            if (Tipo == 2)
            {
                tipo = "Seguro de Viajes";
            }
            if (Tipo == 10)
            {
                tipo = "Referido";
            }

           
            IList<Ticket> ticket = Get_MontoPagar(Monto);

            decimal monto_pagar = 0;

            for (int i = 0; i < ticket.Count; ++i)
            {
                
               monto_pagar = ticket[i].Monto_Pagar;

            }

           

            // Gmail Address from where you send the mail
            var fromAddress = "servicios@servitarjeta.com";
            // any address where the email will be sending
            var toAddress = "sistemas@servitarjeta.com";
            //Password of your gmail address
            const string fromPassword = "TerMons$Hp";
            // Passing the values and make a email formate to display
            string subject = Subject;
            string body = "Cliente = " + Client + " Tipo: " + tipo + " Mensaje: " + Note + " Monto Factura: " + Monto + " Monto a Pagar: " + monto_pagar + "";
           
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }
      
    }
}
