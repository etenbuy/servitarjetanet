using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataObjects.AdoNet;
using System.Globalization;
using BusinessObjects;
using BusinessObjects.BusinessRules;

namespace DataObjects
{
    public static class TicketDao
    {

        #region ESCRITURA

        public static DaoResult CrearSolicitud(Solicitud solicitud, string Login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar, 100);
            prn.Value = Login;
            parameters.Add(prn);

            if (solicitud.Monto != null)
            {
                prn = new SqlParameter("@Monto", SqlDbType.Decimal);
                prn.Value = solicitud.Monto;
                parameters.Add(prn);
            }

            if (solicitud.Nota != null)
            {
                prn = new SqlParameter("@Nota", SqlDbType.VarChar, 500);
                prn.Value = solicitud.Nota;
                parameters.Add(prn);
            }
            if (solicitud.SolicitudTipoID != null)
            {
                prn = new SqlParameter("@SolicitudTipoID", SqlDbType.Int);
                prn.Value = 1;
                parameters.Add(prn);
            }
            
            if (Login != null)
            {
                prn = new SqlParameter("@ClienteID", SqlDbType.Int);
                prn.Value = solicitud.ClienteID;
                parameters.Add(prn);
            }


            DaoResult result = Db.Insert(parameters, "Solicitud_INSERT", false,false);
            return result;
        }


        #endregion

        #region LECTURA

        public static IList<Solicitud> GetSolicitudesByClient(string LoginCreado)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
                solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                
                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());
                if (solicitud.StatusSolicitudID == 1)
                {
                    solicitud.Estado = "Solicitado";
                }
                if (solicitud.StatusSolicitudID == 2)
                {
                    solicitud.Estado = "En Proceso";
                }
                if (solicitud.StatusSolicitudID == 3)
                {
                    solicitud.Estado = "Aprobado";
                }
                if (solicitud.StatusSolicitudID == 4)
                {
                    solicitud.Estado = "Terminado";
                }
                if (solicitud.StatusSolicitudID == 5)
                {
                    solicitud.Estado = "No Aprobado";
                }

                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }

            return list;
        }


        public static IList<Ticket> GetMontoPagar(decimal Monto)
        {

            IList<Ticket> list = new List<Ticket>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT TicketID,Monto_Desde,Monto_Hasta, Monto_Pagar " + "\n";          
            var1 = var1 + "FROM   Ticket " + "\n";
            var1 = var1 + "WHERE  Monto_Desde<=" + Monto + " AND Monto_Hasta>=" + Monto  + "\n";

            DataTable dt = Db.GetDataTable(var1);

            Ticket ticket = new Ticket();
            foreach (DataRow row in dt.Rows)
            {

                ticket.TicketID = int.Parse(row["TicketID"].ToString());
                ticket.Monto_Desde = decimal.Parse(row["Monto_Desde"].ToString());
                ticket.Monto_Hasta = decimal.Parse(row["Monto_Hasta"].ToString());
                ticket.Monto_Pagar = decimal.Parse(row["Monto_Pagar"].ToString());

                list.Add(ticket);

            }

            return list;
        }

        public static Ticket GetTicketMonto(string MontoFactura)
        {

            IList<Ticket> list = new List<Ticket>();
            string monto = MontoFactura;
            string var1 = string.Empty;
            var1 = var1 + "SELECT TicketID,Monto_Desde,Monto_Hasta, Monto_Pagar " + "\n";
            var1 = var1 + "FROM   Ticket " + "\n";
            var1 = var1 + "WHERE  Monto_Desde<=" + monto.Replace(",", ".") + " AND Monto_Hasta>=" + monto.Replace(",", ".") + "\n";


            DataTable dt = Db.GetDataTable(var1);

            Ticket ticket = new Ticket();
            foreach (DataRow row in dt.Rows)
            {
                ticket.TicketID = int.Parse(row["TicketID"].ToString());
                ticket.Monto_Desde = decimal.Parse(row["Monto_Desde"].ToString());
                ticket.Monto_Hasta = decimal.Parse(row["Monto_Hasta"].ToString());
                ticket.Monto_Pagar = decimal.Parse(row["Monto_Pagar"].ToString());

            }

            return ticket;
        }
     


        #endregion
    }
}
