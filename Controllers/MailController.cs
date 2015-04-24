using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using BusinessObjects.BusinessRules;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;

namespace Controllers
{
    public class MailController
    {
        public IList<Ticket> Get_MontoPagar(decimal Monto)
        {
            return TicketDao.GetMontoPagar(Monto);

        }

        public void SendMailRecovery(string Subject, string mail, string pass)
        {

            MailMessage mailrecovery = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mailrecovery.From = new MailAddress("servicios@servitarjeta.com");
            mailrecovery.To.Add(mail);
            mailrecovery.Subject = Subject;
            mailrecovery.Body = "Nueva Contraseña de acceso Servitarjeta.net : " + pass + "";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("servicios@servitarjeta.com", "TerMons$Hp");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mailrecovery);

        }
      

        public void SendMail(string Subject, string Client, string Note, int Tipo, decimal Monto, string filepath, string fullPathrecibo)
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


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("servicios@servitarjeta.com");
            mail.To.Add("sistemas@servitarjeta.com");
            mail.Subject = Subject;
            mail.Body = "Cliente = " + Client + " Tipo: " + tipo + " Mensaje: " + Note + " Monto Factura: " + Monto + " Monto a Pagar: " + monto_pagar + "";

            System.Net.Mail.Attachment attachment;
            System.Net.Mail.Attachment attachmentRecibo;

            if (filepath != "")
            {
                attachment = new System.Net.Mail.Attachment(filepath);
                mail.Attachments.Add(attachment);
            }
            if (fullPathrecibo != "")
            {
                attachmentRecibo = new System.Net.Mail.Attachment(fullPathrecibo);
                mail.Attachments.Add(attachmentRecibo);
            }
            

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("servicios@servitarjeta.com", "TerMons$Hp");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);


/*
           
            // your path may look like Server.MapPath("~/file.ABC")
            

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
            smtp.Send(fromAddress, toAddress, subject, body);*/
        }
      
    }
}
