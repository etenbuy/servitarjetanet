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
            
        
            string usuario = ddlUsuario.Text;

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
    }
}
