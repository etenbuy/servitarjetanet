using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BusinessObjects;
using System.IO;
using System.Collections.Generic;
using Controllers;


namespace Web
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          
            if (!IsPostBack)
            {
                //txtUsuario.Focus();
                BindUsuarios();
            }

        }

        protected void BindUsuarios()
        {
            ddlUsuario.DataSource = Membership.GetAllUsers();
            ddlUsuario.DataMember = "UserName";
            ddlUsuario.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
        
            //string usuario = ddlUsuario.Text;

            string usuario = txtUsuario.Text;

            string contrasena = txtContrasena.Text;

            Controllers.Configuracion.CustomMembershipProvider controller = new Controllers.Configuracion.CustomMembershipProvider();

           if (controller.ValidateUser(usuario, contrasena))
            {
                Session["usuario"] = Membership.GetUser(usuario);

                Session["accesos"] = Roles.GetRolesForUser(usuario);


                FormsAuthentication.RedirectFromLoginPage(usuario, true);
            }
            else
            {
                this.LiteralError.Text = "Usuario o Password Incorrectos.";

            }

        }

        protected void btnpassreturn_Click(object sender, EventArgs e)
        {

        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {

        }

        protected void ResetPassword_OnClick(object sender, EventArgs e)
        {

            string newPassword;

             System.Web.Security.MembershipUser u = Membership.GetUser(txtRecover.Text, false);

            if (u == null)
            {
                Msg.Text = "Usuario " + Server.HtmlEncode(txtRecover.Text) + " No encontrado.";
                return;
            }

            try
            {
                newPassword = u.ResetPassword();
            }
            catch (MembershipPasswordException)
            {
                Msg.Text = "Respuesta Invalida.";
                return;
            }
            catch (Exception)
            {
                //Msg.Text = e.Message;
                return;
            }

            if (newPassword != null)
            {
                MailController mail = new MailController();
                mail.SendMailRecovery("Solicitud Cambio de Clave ServiTarjeta", txtRecover.Text, Server.HtmlEncode(newPassword));
                Msg.Text = "Correcto: Enviada la nueva contraseña a su correo electronico.";
                Msg.ForeColor = System.Drawing.Color.Red;
   

               // Msg.Text = "Contraseña reseteada. Su nueva Clave es: " + Server.HtmlEncode(newPassword);
            }
            else
            {
                Msg.Text = "Recuperacion de Contraseña fallido.";
            }
        }

       


    }
}
