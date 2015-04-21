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

namespace Web.Development.Clientes
{
    public partial class CrearSolicitud : PageBase
    {



        protected void Page_Load(object sender, EventArgs e)
        {


        }






        protected void btnCrear_Click(object sender, EventArgs e)
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            Solicitud solicitud = new Solicitud();

            solicitud.SolicitudTipoID = int.Parse(ddlServicio.SelectedValue);

            solicitud.Nota = txtNota.Text;

            Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtNota.Text = string.Empty;
            
            Alert(result.Mensaje);


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


        }

       

       



    }
}
