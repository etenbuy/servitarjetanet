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
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using BusinessObjects;

namespace Web.Configuracion.Usuarios
{
    public partial class Crear : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindModulos();

            }
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            IList<string> roles = new List<string>();


            foreach (ListItem role in cblModulos.Items)
            {
                if (role.Selected)
                {
                    roles.Add(role.Value);
                }               
            }

            Controllers.Configuracion.Usuarios controller = new Controllers.Configuracion.Usuarios();

            string result = controller.CrearUsuario(txtUsuario.Text, txtContrasena.Text, txtEmail.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, roles);

            Alert(result);

        }

        public void BindModulos()
        {
            cblModulos.DataSource = Roles.GetAllRoles();
            cblModulos.DataBind();

        }
    }
}
