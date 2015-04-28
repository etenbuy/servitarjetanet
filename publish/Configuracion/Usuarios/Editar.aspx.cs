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
using System.Collections.Generic;

namespace Web.Configuracion.Usuarios
{
    public partial class Editar : PageBase
    {
        public Usuario usuario
        {
            get
            {
                return Session["Usuario"] as Usuario;
            }
            set
            {
                Session["Usuario"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindUsuarios();
            }

        }

        private void BindUsuarios()
        {
            MembershipUserCollection usuarios = Membership.GetAllUsers();

            trvUsuarios.Nodes.Clear();
            trvUsuarios.Nodes.Add(new TreeNode("Usuarios"));
            TreeNode tNode = new TreeNode();
            tNode = trvUsuarios.Nodes[0];


            foreach (MembershipUser usuario in usuarios)
            {
                tNode.ChildNodes.Add(new TreeNode(usuario.UserName.ToUpper()));


            }

        }

        private void BindUser(string login)
        {
            Controllers.Configuracion.Usuarios controller = new Controllers.Configuracion.Usuarios();
            usuario = controller.GetUsuario(login);
            if (usuario != null)
            {
                txtEmail.Text = usuario.memUser.Email.ToLower();
                txtPrimerNombre.Text = usuario.PrimerNombre;
                txtSegundoNombre.Text = usuario.SegundoNombre;
                txtPrimerApellido.Text = usuario.PrimerApellido;
                txtSegundoApellido.Text = usuario.SegundoApellido;
                cblModulos.DataSource = Roles.GetAllRoles();
                cblModulos.DataBind();

                foreach (ListItem item in cblModulos.Items)
                {
                    if (Roles.IsUserInRole(usuario.memUser.UserName, item.Text))
                        item.Selected = true;
                }
                cbActivarUsuario.Checked = usuario.memUser.IsApproved;
            }

        }

        protected void trvUsuarios_SelectedNodeChanged(object sender, EventArgs e)
        {
            BindUser(trvUsuarios.SelectedValue.ToString());

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            usuario.memUser.Email = txtEmail.Text;

            if (cbActivarUsuario.Checked)
            {
                usuario.memUser.IsApproved = true;
            }
            else
            {
                usuario.memUser.IsApproved = false;
            }

            usuario.PrimerNombre = txtPrimerNombre.Text;
            usuario.SegundoNombre = txtSegundoNombre.Text;
            usuario.PrimerApellido = txtPrimerApellido.Text;
            usuario.SegundoApellido = txtSegundoApellido.Text;

            IList<string> roles = new List<string>();
            foreach (ListItem role in cblModulos.Items)
            {
                if (role.Selected)
                {
                    roles.Add(role.Value);
                }
            }

            Controllers.Configuracion.Usuarios controller = new Controllers.Configuracion.Usuarios();
            string result = controller.ActualizarUsuario(usuario, roles);

            Alert(result);

            BindUser(trvUsuarios.SelectedValue.ToString());

        }



    }
}
