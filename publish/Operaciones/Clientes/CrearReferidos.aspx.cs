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
using System.Collections.Generic;
using System.Net;
using BusinessObjects;

namespace Web.Operaciones.Clientes
{
    public partial class CrearReferidos : PageBase
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildReferidos();
           
        }

        private void BuildReferidos()
        {
            Controllers.ReferidoController controller = new Controllers.ReferidoController();

            gvReferidos.DataSource = controller.Referidos_Get_ByClient(1);
            gvReferidos.DataBind();
        }



        protected void lbtnActualizarReferido_Click(object sender, EventArgs e)
        {



        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Controllers.ReferidoController controller = new Controllers.ReferidoController();

            Referido referido = new Referido();

            referido.Descripcion = txtDescripcion.Text;
            referido.Telefono = txtTelefono.Text;
            referido.Direccion = txtDireccion.Text;
            referido.Email = txtCorreo.Text;

            Controllers.ControllerResult result = controller.CrearReferido(referido, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            
            txtTelefono.Text = string.Empty;
            BuildReferidos();
            Alert(result.Mensaje);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void gvReferido_Sorting(object sender, GridViewSortEventArgs e)
        {

           //// DataTable dt = Session["DSTraspasoCartaPorte"] as DataTable;

           // if (dt != null)
           // {
           //     //dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
           //     //gvTraspasoCartaPorte.DataSource = Session["DSTraspasoCartaPorte"];
           //     //gvTraspasoCartaPorte.DataBind();

           // }

        }
    }

}
