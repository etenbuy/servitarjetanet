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
using System.IO;
using System.Text;
using System.Drawing;

namespace Web.Operaciones.Saldo
{
    public partial class Consultar : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                solicitud = null;
                BuildTarjetas();
                BuildSolicitudes();
                builTotales();
            }
        }

        public Solicitud solicitud
        {
            get
            {
                return Session["Solicitud"] as Solicitud;
            }
            set
            {
                Session["Solicitud"] = value;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            btnPrint.Visible = true;
            string value = gvSolicitudes.SelectedValue.ToString();

            Controllers.SolicitudController controller = new Controllers.SolicitudController();


            solicitud = controller.Get_SolicitudID(int.Parse(value));


            if (solicitud.StatusSolicitudID == 1)
            {
                lblSolicitud.ForeColor = System.Drawing.Color.Orange;
                lblSolicitud.Font.Bold = true;
                lblSolicitud.Text = "Solicitud NRO " + value.ToString() + " En Proceso";
                upanPopUp.Update();
                mdlPopup.Show();
                lblsolicitudid.Text = string.Empty;
                lblFechaCreado.Text = string.Empty;
                lblNumero_Factura.Text = string.Empty;
                lblMonto_Factura.Text = string.Empty;
                lblNtdc.Text = string.Empty;
                lblNdeposito.Text = string.Empty;
                lblMonto_Pagado.Text = string.Empty;
                lblFechaPagado.Text = string.Empty;
                btnPrint.Visible = false;
             
            }
            if (solicitud.StatusSolicitudID == 3)
            {
                lblSolicitud.ForeColor = System.Drawing.Color.Orange;
                lblSolicitud.Font.Bold = true;
                lblSolicitud.Text = "Solicitud NRO " + value.ToString() + " NO APROBADA";
                upanPopUp.Update();
                mdlPopup.Show();
                lblsolicitudid.Text = string.Empty;
                lblFechaCreado.Text = string.Empty;
                lblNumero_Factura.Text = string.Empty;
                lblMonto_Factura.Text = string.Empty;
                lblNtdc.Text = string.Empty;
                lblNdeposito.Text = string.Empty;
                lblMonto_Pagado.Text = string.Empty;
                lblFechaPagado.Text = string.Empty;
                btnPrint.Visible = false;

            }
            if (solicitud.StatusSolicitudID == 2)
            {
                lblSolicitud.ForeColor = System.Drawing.Color.LightGreen;
                lblSolicitud.Font.Bold = true;
                pnlPopup.Visible = true;
                lblSolicitud.Text = "Solicitud NRO " + value.ToString() + " COMPLETADA";
                solicitud = controller.Get_SolicitudID(int.Parse(value));
                lblsolicitudid.Text = solicitud.SolicitudID.ToString();
                lblFechaCreado.Text = solicitud.FechaCreado.ToString();
                lblNumero_Factura.Text = solicitud.Numero_Factura.ToString();
                lblMonto_Factura.Text = solicitud.Monto_Factura.ToString();
                lblNtdc.Text = solicitud.Ntdc.ToString();
                lblNdeposito.Text = solicitud.Ndeposito.ToString();
                lblMonto_Pagado.Text = solicitud.Monto_Pagado.ToString();
                lblFechaPagado.Text = solicitud.FechaPagado.ToString();
                //gvDetalles.DataSource = controller.Solicitudes_Get_ByID(((HiddenField)((LinkButton)sender).FindControl("hfSolicitud")).Value.ToString());
                //gvDetalles.DataBind();
               
                upanPopUp.Update();
                mdlPopup.Show();


            }
        
        }
        protected void lbtnDetalle_Click(object sender, EventArgs e)
        {


        }

        private void builTotales()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            Solicitud solicitud = new Solicitud();
           // solicitud = controller.SolicitudesTotales_Get_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);
            solicitud = controller.SolicitudesTotalesTarjeta_Get_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);

            if (solicitud.Saldo != null)
            {
                lblTotalProceso.Text = string.Format("{0:###,###,###,###.00}", solicitud.Saldo); 
            }
            else
            {
                lblTotalProceso.Text = "0";
            }
            
            

        
        }
        private void BuildTarjetas()
        {
            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            cliente = controllerCliente.ObtenerCliente(UsuarioAutenticado.UserName);

            Controllers.TarjetaController controllerTarjeta = new Controllers.TarjetaController();
            ddlTarjetas.DataSource = controllerTarjeta.Get_Tarjetas(cliente.ClienteID);

            ddlTarjetas.DataTextField = "Numero";
            ddlTarjetas.DataValueField = "Id";
            ddlTarjetas.DataBind();

            ddlTarjetas.Items.Insert(0, new ListItem("Seleccionar...", ""));
        }
        private void BuildSolicitudes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

           
            DataTable dtSolicitudes = CollectionHelper.ConvertTo<Solicitud>(controller.Solicitudes_TarjetaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text));

            Session["DSSolicitudes"] = dtSolicitudes;

            gvSolicitudes.DataSource = controller.Solicitudes_TarjetaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);
            gvSolicitudes.DataBind();

            foreach (GridViewRow row in gvSolicitudes.Rows)
            {
                

                if (row.Cells[2].Text.Contains("PAGO A CLIENTE"))
                {
                    row.Cells[2].ForeColor = Color.Blue;
                    row.Cells[2].Font.Bold = true;
                }
                if (row.Cells[2].Text.Contains("SOLICITUD RECHAZADA"))
                {
                    row.Cells[2].ForeColor = Color.Red;
                    row.Cells[2].Font.Bold = true;
                }
                
            }
        }

        protected void txtCalFechaDesde_SelectionChanged(object sender, EventArgs e)
        {
        

        }
        protected void txtCalFechaHasta_SelectionChanged(object sender, EventArgs e)
        {
          

        }

        protected void gvSolicitudes_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = Session["DSSolicitudes"] as DataTable;
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvSolicitudes.DataSource = Session["DSSolicitudes"];
                gvSolicitudes.DataBind();

                /*foreach (GridViewRow row in gvSolicitudes.Rows)
                {
                    if (row.Cells[6].Text == "COMPLETADA")
                    {
                        row.Cells[6].ForeColor = Color.Green;
                    }
                    if (row.Cells[6].Text == "EN PROCESO")
                    {
                        row.Cells[6].ForeColor = Color.Orange;
                    }
                    if (row.Cells[6].Text == "NO APROBADA")
                    {
                        row.Cells[6].ForeColor = Color.Red;
                    }
                }*/

            }

        }

      

        decimal Monto_Pagado = 0;
        decimal monto = 0;

       /* protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

          

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Monto_Pagado += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfMonto_Pagado")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfMonto_Pagado")).Value.ToString());
                monto += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString());
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[5].Text = Monto_Pagado.ToString();

                e.Row.Font.Bold = true;


                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[4].Text = monto.ToString();

                e.Row.Font.Bold = true;
            }
  
        }
        */
      

       


        protected void kbkPrint_Click(object sender, EventArgs e)
        {
            

         /*   gvSolicitudes.Visible = true;

            gvSolicitudes.UseAccessibleHeader = true;
            gvSolicitudes.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvSolicitudes.FooterRow.TableSection = TableRowSection.TableFooter;
            gvSolicitudes.Attributes["style"] = "border-collapse:separate";
            foreach (GridViewRow row in gvSolicitudes.Rows)
            {
                if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                {
                    row.Attributes["style"] = "page-break-after:always;";
                }
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            

            gvSolicitudes.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gvSolicitudes);

            page.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            string style = "<style type = 'text/css'>thead {display:table-header-group;} tfoot{display:table-footer-group;}</style>";
            sb.Append(style + gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();");
            sb.Append("};");
            sb.Append("</script>");
           ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
           // gvSolicitudes.AllowPaging = true;
           // gvSolicitudes.DataBind();
            */
             
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;

        }

        protected void ddlTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildSolicitudes();
            builTotales();
        }

    }
}
