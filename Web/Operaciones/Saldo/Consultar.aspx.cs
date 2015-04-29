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

namespace Web.Operaciones.Saldo
{
    public partial class Consultar : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
            if (!Page.IsPostBack)
            {

                BuildSolicitudes();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void lbtnDetalle_Click(object sender, EventArgs e)
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();


            Solicitud solicitud = new Solicitud();
            solicitud = controller.Get_SolicitudID(int.Parse(((HiddenField)((LinkButton)sender).FindControl("hfSolicitud")).Value.ToString()));


            if (solicitud.StatusSolicitudID == 1)
            {
                lblSolicitud.Text = "Solicitud " + ((HiddenField)((LinkButton)sender).FindControl("hfSolicitud")).Value.ToString() + " En Proceso";
                upanPopUp.Update();
                mdlPopup.Show();
            }
            else
            {
                gvDetalles.DataSource = controller.Solicitudes_Get_ByID(((HiddenField)((LinkButton)sender).FindControl("hfSolicitud")).Value.ToString());
                gvDetalles.DataBind();
                upanPopUp.Update();
                mdlPopup.Show();


            }

           

        }


        private void BuildSolicitudes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            gvSolicitudes.DataSource = controller.Solicitudes_Get_ByClient(UsuarioAutenticado.UserName);
            gvSolicitudes.DataBind();
        }

        protected void txtCalFechaDesde_SelectionChanged(object sender, EventArgs e)
        {
        

        }
        protected void txtCalFechaHasta_SelectionChanged(object sender, EventArgs e)
        {
          

        }

        protected void gvSolicitudes_Sorting(object sender, GridViewSortEventArgs e)
        {

          

        }

        protected void gvSolicitudes_DataBound(object sender, EventArgs e)
        {

         /*   if (e.Row.RowType == DataControlRowType.DataRow)
            {
                monto += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString());
                dividendo += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfDividendo")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfDividendo")).Value.ToString());

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[4].Text = monto.ToString("###,###,###,###.00");
                e.Row.Cells[5].Text = dividendo.ToString("###,###,###,###.00");

                e.Row.Font.Bold = true;
            }
            */
        }

        protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {



          
        }
       

      


        protected void kbkPrint_Click(object sender, EventArgs e)
        {
            gvSolicitudes.Visible = true;

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
  
        }
       
    }
}
