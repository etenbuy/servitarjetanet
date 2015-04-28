using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;


namespace Web.Operaciones.Clientes
{
    public partial class EstadosCuentas : System.Web.UI.Page
  
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            string attachmentFile = null;
            if (FileUpload1.HasFile)
            {
                try
                {
                    FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/files/"), FileUpload1.FileName));
                   // attachmentFile = FileUpload1.PostedFile.FileName;
                    attachmentFile = System.IO.Path.Combine(Server.MapPath("~/Images/files/"), FileUpload1.FileName);
                }
                catch (Exception ex)
                {
                    Label1.Text = "File Upload Failed !! " + ex.Message.ToString();
                }

                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("servicios@servitarjeta.com"); //you have to provide your gmail address as from address
                    mail.To.Add("dividendos@servitarjeta.com");
                    mail.Subject = "Estado de Cuentas";
                    mail.Body = message_txt.Text;

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(attachmentFile);
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("servicios@servitarjeta.com", "TerMons$Hp"); //you have to provide you gamil username and password
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    Label1.Visible = true;
                    Label1.Text = "Estado de cuenta enviado correctamente a nuestro departamento de Atencion al Clientes. Espere nuestra respuesta.  MUCHAS GRACIAS";
                }
                catch (Exception ex)
                {
                    Label1.Text = "Fallo !! " + ex.Message.ToString();
                }
            }
            else
            {
                Label1.Text = "Por favor seleccionar algun archivo";
            }
        }
           

            
    }

    
}
