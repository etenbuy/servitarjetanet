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
    public static class SolicitudDao
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
            prn = new SqlParameter("@Monto_Pagado", SqlDbType.Decimal);
            prn.Value = solicitud.Monto_Pagado;
            parameters.Add(prn);
            if (solicitud.Numero_Factura != null)
            {
                prn = new SqlParameter("@Numero_Factura", SqlDbType.VarChar, 30);
                prn.Value = solicitud.Numero_Factura;
                parameters.Add(prn);
            }
           

            if (solicitud.SolicitudTipoID != null)
            {
                prn = new SqlParameter("@SolicitudTipoID", SqlDbType.Int);
                prn.Value = solicitud.SolicitudTipoID;
                parameters.Add(prn);
            }
            
            if (Login != null)
            {
                prn = new SqlParameter("@ClienteID", SqlDbType.Int);
                prn.Value = solicitud.ClienteID;
                parameters.Add(prn);
            }

            
                prn = new SqlParameter("@Factura", SqlDbType.VarChar, 500);
                prn.Value = solicitud.Factura;
                parameters.Add(prn);
            

            
                prn = new SqlParameter("@Factura_1", SqlDbType.VarChar, 50);
                prn.Value = solicitud.Factura_1;
                parameters.Add(prn);
            
                prn = new SqlParameter("@Factura_2", SqlDbType.VarChar, 50);
                prn.Value = solicitud.Factura_2;
                parameters.Add(prn);
            

            
                prn = new SqlParameter("@Recibo_1", SqlDbType.VarChar, 50);
                prn.Value = solicitud.Recibo_1;
                parameters.Add(prn);
            
                prn = new SqlParameter("@Recibo_2", SqlDbType.VarChar, 50);
                prn.Value = solicitud.Recibo_2;
                parameters.Add(prn);
                
              
                    prn = new SqlParameter("@FechaPagado", SqlDbType.VarChar, 30);
                    prn.Value = solicitud.FechaPagado;
                    parameters.Add(prn);
               
                    prn = new SqlParameter("@Ntdc", SqlDbType.VarChar, 30);
                    prn.Value = solicitud.Ntdc;
                    parameters.Add(prn);
               
                    prn = new SqlParameter("@Ndeposito", SqlDbType.VarChar, 30);
                    prn.Value = solicitud.Ndeposito;
                    parameters.Add(prn);

                    prn = new SqlParameter("@Numero_TDC", SqlDbType.VarChar, 50);
                    prn.Value = solicitud.Numero_TDC;
                    parameters.Add(prn);

               
            DaoResult result = Db.Insert(parameters, "Solicitud_INSERT", false,false);
            return result;
        }


        #endregion

        #region LECTURA

        public static IList<Solicitud> GetSolicitudesTarjetaByClient(string LoginCreado,string tarjeta)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       Saldo, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "AND  Numero_TDC ='" + tarjeta + "' " + "\n";
            var1 = var1 + "ORDER BY FechaCreado";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
                // solicitud.FechaCreado = DateTime.ParseExact(row["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                if (row["Fecha_Pagado"].ToString() != "")
                {
                    //solicitud.FechaPagado = DateTime.ParseExact(row["Fecha_Pagado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }

                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.SolicitudTipoID == 1)
                {
                    solicitud.Estado = "+";
                }
                if (solicitud.SolicitudTipoID == 2)
                {
                    solicitud.Estado = "-";
                }
                if (solicitud.SolicitudTipoID == 3)
                {
                    solicitud.Estado = "-";
                }

                solicitud.Saldo = decimal.Parse(row["Saldo"].ToString());
                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }

            return list;
        }


        public static IList<Solicitud> GetSolicitudesByClient(string LoginCreado)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       Saldo, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "ORDER BY FechaCreado";
            

            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
                // solicitud.FechaCreado = DateTime.ParseExact(row["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                if (row["Fecha_Pagado"].ToString() != "")
                {
                    //solicitud.FechaPagado = DateTime.ParseExact(row["Fecha_Pagado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }
               
                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.SolicitudTipoID == 1)
                {
                    solicitud.Estado = "+";
                }
                if (solicitud.SolicitudTipoID == 2)
                {
                    solicitud.Estado = "-";
                }
                if (solicitud.SolicitudTipoID == 3)
                {
                    solicitud.Estado = "-";
                }

                solicitud.Saldo = decimal.Parse(row["Saldo"].ToString());
                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }
            
            return list;
        }

        public static Solicitud GetSolicitudesTotalesByClient(string LoginCreado)
        {

          


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT TOP(1) Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Saldo " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "ORDER BY FechaCreado DESC";


            DataTable dt = Db.GetDataTable(var1);
            Solicitud solicitud = new Solicitud();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Monto_Factura"].ToString() != "")
                {
                    solicitud.Saldo = decimal.Parse(row["Saldo"].ToString());
                    solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                    solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                    solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                }
                else
                {
                    solicitud.Monto_Factura = 0;
                    solicitud.Monto = 0;
                    solicitud.Monto_Pagado = 0;
                    solicitud.Saldo = 0;
                }

            }
            return solicitud;
        }

        public static Solicitud GetSolicitudesTotalesTarjetaByClient(string LoginCreado, string Tarjeta)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT TOP(1) Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Saldo " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "AND  Numero_TDC ='" + Tarjeta + "' " + "\n";
            var1 = var1 + "ORDER BY FechaCreado DESC";


            DataTable dt = Db.GetDataTable(var1);
            Solicitud solicitud = new Solicitud();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Monto_Factura"].ToString() != "")
                {
                    solicitud.Saldo = decimal.Parse(row["Saldo"].ToString());
                    solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                    solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                    solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                }
                else
                {
                    solicitud.Monto_Factura = 0;
                    solicitud.Monto = 0;
                    solicitud.Monto_Pagado = 0;
                    solicitud.Saldo = 0;
                }

            }
            return solicitud;
        }

        public static IList<Solicitud> GetSolicitudesByID(string SolicitudID)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  SolicitudID ='" + SolicitudID + "' " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
                // solicitud.FechaCreado = DateTime.ParseExact(row["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                if (row["Fecha_Pagado"].ToString() != "")
                {
                    //solicitud.FechaPagado = DateTime.ParseExact(row["Fecha_Pagado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }
               
                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.StatusSolicitudID == 1)
                {
                    solicitud.Estado = "EN PROCESO";
                }
                if (solicitud.StatusSolicitudID == 2)
                {
                    solicitud.Estado = "COMPLETADA";
                }
                if (solicitud.StatusSolicitudID == 3)
                {
                    solicitud.Estado = "NO APROBADA";
                }


                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }

            return list;
        }

        public static DaoResult ActualizarSolicitud(Solicitud solicitud)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@MontoPagado", SqlDbType.Decimal);
            prn.Value = solicitud.Monto_Pagado;
            parameters.Add(prn);

            prn = new SqlParameter("@MontoFactura", SqlDbType.Decimal);
            prn.Value = solicitud.Monto_Factura;
            parameters.Add(prn);

            prn = new SqlParameter("@FechaPagado", SqlDbType.VarChar, 30);
            prn.Value = solicitud.FechaPagado;
            parameters.Add(prn);

            prn = new SqlParameter("@Ntdc", SqlDbType.VarChar, 30);
            prn.Value = solicitud.Ntdc;
            parameters.Add(prn);

            prn = new SqlParameter("@Ndeposito", SqlDbType.VarChar,30);
            prn.Value = solicitud.Ndeposito;
            parameters.Add(prn);

            prn = new SqlParameter("@Numero_Factura", SqlDbType.VarChar, 30);
            prn.Value = solicitud.Numero_Factura;
            parameters.Add(prn);

            prn = new SqlParameter("@SolicitudID", SqlDbType.Int);
            prn.Value = solicitud.SolicitudID;
            parameters.Add(prn);

            prn = new SqlParameter("@StatusSolicitudID", SqlDbType.Int);
            prn.Value = solicitud.StatusSolicitudID;
            parameters.Add(prn);

           
            DaoResult result = Db.Insert(parameters, "Solicitud_UPDATE", false, false);
            return result;
        }

        public static IList<Solicitud> GetSolicitudesByClientSolicitudID(int SolicitudID)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Pagar, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  SolicitudID =" + SolicitudID + " " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {
                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
                // solicitud.FechaCreado = DateTime.ParseExact(row["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                if (row["Fecha_Pagado"].ToString() != "")
                {
                    //solicitud.FechaPagado = DateTime.ParseExact(row["Fecha_Pagado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }
               
                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.StatusSolicitudID == 1)
                {
                    solicitud.Estado = "EN PROCESO";
                }
                if (solicitud.StatusSolicitudID == 2)
                {
                    solicitud.Estado = "COMPLETADA";
                }
                if (solicitud.StatusSolicitudID == 3)
                {
                    solicitud.Estado = "NO APROBADA";
                }


                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.Monto_Pagar = decimal.Parse(row["Monto_Pagar"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }

            return list;
        }

        public static Solicitud GetSolicitudesByClientMontoFactura(string LoginCreado,string tarjeta)
        {

            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT sum(Monto) AS Monto " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "AND  Numero_TDC ='" + tarjeta + "' " + "\n";
            var1 = var1 + "AND  StatusSolicitudID = 1 " + "\n";
            var1 = var1 + "AND  datepart(mm, FechaCreado) =datepart(mm,'" + DateTime.Now.ToString("MM/dd/yyyy") + "') " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            Solicitud solicitud = new Solicitud();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Monto"].ToString() != "")
                {
                    solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                }
                else
                {
                    solicitud.Monto = 0;
                }
            }

            return solicitud;
        }

       

        public static IList<Solicitud> GetSolicitudesAlMesByClient(string LoginCreado)
        {


            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       StatusSolicitudID, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";
            var1 = var1 + "AND  datepart(mm, FechaCreado) =datepart(mm,'" + DateTime.Now.ToString("MM/dd/yyyy") + "') " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Solicitud solicitud = new Solicitud();
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
               // solicitud.FechaCreado = DateTime.ParseExact(row["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                if (row["Fecha_Pagado"].ToString() != "")
                {
                    //solicitud.FechaPagado = DateTime.ParseExact(row["Fecha_Pagado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }
                         
                
                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.StatusSolicitudID == 1)
                {
                    solicitud.Estado = "EN PROCESO";
                }
                if (solicitud.StatusSolicitudID == 2)
                {
                    solicitud.Estado = "COMPLETADA";
                }
                if (solicitud.StatusSolicitudID == 3)
                {
                    solicitud.Estado = "NO APROBADA";
                }


                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());


                list.Add(solicitud);

            }

            return list;
        }

        public static Solicitud GetSolicitudID(int SolicitudID)
        {

            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT StatusSolicitudID, " + "\n";
            var1 = var1 + "       ClienteID, " + "\n";
            var1 = var1 + "       FechaCreado, " + "\n";
            var1 = var1 + "       Fecha_Pagado, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       Nota, " + "\n";
            var1 = var1 + "       SolicitudTipoID, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Monto_Pagado, " + "\n";
            var1 = var1 + "       Monto_Factura, " + "\n";
            var1 = var1 + "       Ntdc, " + "\n";
            var1 = var1 + "       Ndeposito, " + "\n";
            var1 = var1 + "       Numero_Factura, " + "\n";
            var1 = var1 + "       SolicitudID " + "\n";
            var1 = var1 + "FROM   Solicitud " + "\n";
            var1 = var1 + "WHERE  SolicitudID ='" + SolicitudID + "' " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            Solicitud solicitud = new Solicitud();
            foreach (DataRow row in dt.Rows)
            {

               
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());
                solicitud.FechaCreado = row["FechaCreado"].ToString().Substring(0, 10);
               
                if (row["Fecha_Pagado"].ToString() != "")
                {
                   
                    solicitud.FechaPagado = row["Fecha_Pagado"].ToString().Substring(0, 10);
                }


                solicitud.LoginCreado = row["LoginCreado"].ToString();
                solicitud.Nota = row["Nota"].ToString();
                solicitud.Monto_Factura = decimal.Parse(row["Monto_Factura"].ToString());
                solicitud.Ntdc = row["Ntdc"].ToString();
                solicitud.Ndeposito = row["Ndeposito"].ToString();
                solicitud.Numero_Factura = row["Numero_Factura"].ToString();


                solicitud.SolicitudTipoID = int.Parse(row["SolicitudTipoID"].ToString());
                solicitud.StatusSolicitudID = int.Parse(row["StatusSolicitudID"].ToString());

                if (solicitud.StatusSolicitudID == 1)
                {
                    solicitud.Estado = "EN PROCESO";
                }
                if (solicitud.StatusSolicitudID == 2)
                {
                    solicitud.Estado = "COMPLETADA";
                }
                if (solicitud.StatusSolicitudID == 3)
                {
                    solicitud.Estado = "NO APROBADA";
                }

                solicitud.Monto = decimal.Parse(row["Monto"].ToString());
                solicitud.Monto_Pagado = decimal.Parse(row["Monto_Pagado"].ToString());
                solicitud.SolicitudID = int.Parse(row["SolicitudID"].ToString());

            }

            return solicitud;
        }


        public static Solicitud GetIDClient(string LoginCreado)
        {

            IList<Solicitud> list = new List<Solicitud>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID " + "\n";          
            var1 = var1 + "FROM   Cliente " + "\n";
            var1 = var1 + "WHERE  LoginCreado ='" + LoginCreado + "' " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            Solicitud solicitud = new Solicitud();
            foreach (DataRow row in dt.Rows)
            {

               
                solicitud.ClienteID = int.Parse(row["ClienteID"].ToString());

            }

            return solicitud;
        }

       


        public static IList<int> GetClientesID()
        {

            DataTable dt = Db.GetDataTable(null, "Clientes_Get");
            IList<int> list = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                int clienteid = 0;
                clienteid = int.Parse(dr["ClienteID"].ToString());

                list.Add(clienteid);
            }
            return list;
        }

        public static IList<Cliente> GetClientes(IList<int> clientesids)
        {

            IList<Cliente> list = new List<Cliente>();

            if (clientesids.Count > 0)
            {

                string clientes = string.Empty;

                int count = 0;

                foreach (int cliente in clientesids)
                {
                    count++;

                    clientes += cliente.ToString();

                    if (count < clientesids.Count)
                        clientes += ", ";

                }

                string var1 = string.Empty;
                var1 = var1 + "SELECT ClienteID, " + "\n";
                var1 = var1 + "       Descripcion, " + "\n";
                var1 = var1 + "       Telefono, " + "\n";
                var1 = var1 + "       Email, " + "\n";
                var1 = var1 + "       RIF, " + "\n";
                var1 = var1 + "       Direccion " + "\n";
                var1 = var1 + "FROM   Cliente " + "\n";
                var1 = var1 + "WHERE  ClienteID IN (" + clientes.ToString() + ") " + "\n";


                DataTable dt = Db.GetDataTable(var1);

                foreach (DataRow row in dt.Rows)
                {

                    Cliente cliente = new Cliente();
                    cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                    cliente.Descripcion = row["Descripcion"].ToString();

                    list.Add(cliente);

                }
            }
            return list;
        }

        public static Cliente ObtenerCliente(int clienteid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = clienteid;
            parameters.Add(prn);

            DataRow row = Db.GetDataRow(parameters, "Cliente_GET");
            if (row != null)
            {

                Cliente cliente = new Cliente();

                cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                cliente.Descripcion = row["Descripcion"].ToString();

                if (!string.IsNullOrEmpty(row["Direccion"].ToString()))
                    cliente.Direccion = row["Direccion"].ToString();
                if (!string.IsNullOrEmpty(row["Email"].ToString()))
                    cliente.Email = row["Email"].ToString();
                if (!string.IsNullOrEmpty(row["RIF"].ToString()))
                    cliente.RIF = row["RIF"].ToString();
                if (!string.IsNullOrEmpty(row["Telefono"].ToString()))
                    cliente.Telefono = row["Telefono"].ToString();

                return cliente;
            }
            else
                return null;



        }
        public static Cliente ObtenerCliente(string descripcion)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@Descripcion", SqlDbType.VarChar, 100);
            prn.Value = descripcion;
            parameters.Add(prn);

            DataRow row = Db.GetDataRow(parameters, "Cliente_GET_DESCRIP");


            if (row != null)
            {

                Cliente cliente = new Cliente();

                cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                cliente.Descripcion = row["Descripcion"].ToString();

                if (!string.IsNullOrEmpty(row["Direccion"].ToString()))
                    cliente.Direccion = row["Direccion"].ToString();
                if (!string.IsNullOrEmpty(row["Email"].ToString()))
                    cliente.Email = row["Email"].ToString();
                if (!string.IsNullOrEmpty(row["RIF"].ToString()))
                    cliente.RIF = row["RIF"].ToString();
                if (!string.IsNullOrEmpty(row["Telefono"].ToString()))
                    cliente.Telefono = row["Telefono"].ToString();


                return cliente;
            }
            else
                return null;

        }



        public static IList<Cliente> Clientes_GET()
        {


            DataTable dtCliente = Db.GetDataTable("Clientes_GET");

            IList<Cliente> list = new List<Cliente>();

            foreach (DataRow row in dtCliente.Rows)
            {
                if (row != null)
                {

                    Cliente cliente = new Cliente();

                    cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                    cliente.Descripcion = row["Descripcion"].ToString();

                    if (!string.IsNullOrEmpty(row["Direccion"].ToString()))
                        cliente.Direccion = row["Direccion"].ToString();
                    if (!string.IsNullOrEmpty(row["Email"].ToString()))
                        cliente.Email = row["Email"].ToString();
                    if (!string.IsNullOrEmpty(row["RIF"].ToString()))
                        cliente.RIF = row["RIF"].ToString();
                    if (!string.IsNullOrEmpty(row["Telefono"].ToString()))
                        cliente.Telefono = row["Telefono"].ToString();

                    list.Add(cliente);
                }
                else
                    return null;
            }

            return list;

        }

     


        #endregion
    }
}
