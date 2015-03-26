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

namespace Web.Configuracion
{
    public partial class AdministrarUsuarios : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
                  BuildModulos();
                  BuildUsuarios();
            }

        }

        public void BuildModulos()
        {
            cblModulos.DataSource = Roles.GetAllRoles();
            cblModulos.DataBind();
 
        }

        public void BuildUsuarioModulos(string usuario)
        {
            string[] usuarioAccesos = Roles.GetRolesForUser(usuario);
 
            cblModulosUsuario.DataSource = Roles.GetAllRoles();
            cblModulosUsuario.DataBind();

            foreach (ListItem modulo in cblModulosUsuario.Items)
            {
                if (usuarioAccesos.Contains(modulo.Value))
                    modulo.Selected = true; 
            }

        }

        public void BuildUsuarios()
        {
            gvUsuarios.DataSource = Membership.GetAllUsers();
            gvUsuarios.DataBind();

        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {

            MembershipCreateStatus createStatus;
            string CreateAccountResults = string.Empty;
            try
            {
                MembershipUser memUser = Membership.CreateUser(txtUsuario.Text, txtContrasena.Text, txtEmail.Text);

                CreateAccountResults = "La cuenta de usuario fue creada correctamente!";

                foreach (ListItem role in cblModulos.Items)
                {
                    if (role.Selected)
                        Roles.AddUserToRole(memUser.UserName, role.Value);
                }

                LimpiarNuevoUsuario();

                BuildUsuarios();
            }
            catch (MembershipCreateUserException ex)
            {
                createStatus = ex.StatusCode;

                switch (createStatus)
                {

                    case MembershipCreateStatus.DuplicateUserName:
                        CreateAccountResults = "Ya existe una cuenta con este usuario.";
                        break;

                    case MembershipCreateStatus.DuplicateEmail:
                        CreateAccountResults = "Ya existe un usuario con esta cuenta de email.";
                        break;

                    case MembershipCreateStatus.InvalidEmail:
                        CreateAccountResults = "El email que usted introdujo es inválido.";
                        break;

                    case MembershipCreateStatus.InvalidAnswer:
                        CreateAccountResults = "There security answer was invalid.";
                        break;

                    case MembershipCreateStatus.InvalidPassword:
                        CreateAccountResults = "La contraseña  que usted introdujo es inválida. Debe tener al menos 5 dígitos.";
                        break;

                    default:
                        CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
                        break;
                }

                
            }
            catch (Exception ex)
            {
                CreateAccountResults = "Se ha generado un error desconocido; la cuenta NO fue creada.";
            }
            

            Alert(CreateAccountResults);

            


        }

        protected void LimpiarNuevoUsuario()
        {
            txtUsuario.Text = string.Empty;

            txtContrasena.Text = string.Empty;

            txtConfirmeContrasena.Text = string.Empty;

            txtEmail.Text = string.Empty;
            
            BuildModulos();
           
        }

        protected void lbtModulos_Click(object sender, EventArgs e)
        {

            string usuario = ((GridViewRow)((LinkButton)sender).Parent.Parent).Cells[1].Text;

            Session["UsuarioEnEdicion"] = usuario;

            lblUsuario.Text = (string)Session["UsuarioEnEdicion"];

            BuildUsuarioModulos(usuario);

            btnActualizarModulos.Visible = true;
            
            BuildUsuarios();
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usuario = gvUsuarios.Rows[e.RowIndex].Cells[1].Text;
           
            string[] roles = Roles.GetRolesForUser(usuario);
            if(roles.Length>0)
                Roles.RemoveUserFromRoles(usuario, roles);

            Membership.DeleteUser(usuario, true);

            BuildUsuarios();
        }

        protected void btnActualizarModulos_Click(object sender, EventArgs e)
        {
            string[] rolesUsuario = Roles.GetRolesForUser((string)Session["UsuarioEnEdicion"]);
            if (rolesUsuario.Length > 0)
                Roles.RemoveUserFromRoles((string)Session["UsuarioEnEdicion"], rolesUsuario);

            foreach (ListItem role in cblModulosUsuario.Items)
            {
                if (role.Selected)
                    Roles.AddUserToRole((string)Session["UsuarioEnEdicion"], role.Value);
            }
            BuildUsuarios();
        }

        protected void gvUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
            if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.DataItem != null))
            {
                if (((MembershipUser)(e.Row.DataItem)).UserName.ToLower() == "administrador")
                {
                    ((System.Web.UI.WebControls.TableRow)(e.Row)).Cells[2].Visible = false;

                    ((System.Web.UI.WebControls.TableRow)(e.Row)).Cells[3].Visible = false;
                }
            }
            
        }


        public void cbActivo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            string usuario = ((GridViewRow)(((WebControl)(sender)).Parent.Parent)).Cells[1].Text;

            if (checkBox.Checked)
            {
                MembershipUser memUsuario = Membership.GetUser(usuario);
                memUsuario.IsApproved = true;
                Membership.UpdateUser(memUsuario);
            }
            else
            {
                MembershipUser memUsuario = Membership.GetUser(usuario);
                memUsuario.IsApproved = false;
                Membership.UpdateUser(memUsuario);

            }
            BuildUsuarios();
        }

        



    }
}
