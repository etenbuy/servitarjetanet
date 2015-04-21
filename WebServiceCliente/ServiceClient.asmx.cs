using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessObjects;
using System.Web.UI.WebControls;

namespace WebServiceCliente
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/webService", Name="webServiceClient",Description="Servicio web para ingreso de clientes nuevos")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceClient : System.Web.Services.WebService
    {

        [WebMethod]
       
        public void CreateClient(string usuario,string clave,string mail,string nombre, string segundonombre,string primerapellido,string segundoapellido)
        {

            IList<string> roles = new List<string>();
            CheckBoxList cblModulos = new CheckBoxList();
            cblModulos.Items.Add(new ListItem("BENEFICIOS"));
            cblModulos.Items.Add(new ListItem("ESTADOSDECUENTA"));
            cblModulos.Items.Add(new ListItem("SALDOS"));
            cblModulos.Items.Add(new ListItem("SERVICIOS"));

            foreach (ListItem role in cblModulos.Items)
            {
                if (role.Selected)
                {
                    roles.Add(role.Value);
                }
            }

            Controllers.Configuracion.Usuarios controller = new Controllers.Configuracion.Usuarios();

            string result = controller.CrearUsuario(usuario, clave, mail, nombre, segundonombre, primerapellido, segundoapellido, roles);


            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            cliente.LoginCreado = usuario;
            cliente.Descripcion = nombre;
            cliente.Telefono = "";
            cliente.Direccion = "";
            cliente.Email = mail;
            cliente.RIF = "";
            Controllers.ControllerResult result2 = controllerCliente.CrearCliente(cliente, "juan.delgado");
          
        }
    }
}
