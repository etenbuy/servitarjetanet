using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data;
using DataObjects.AdoNet;
using System.Data.SqlClient;

namespace DataObjects
{
    public static class DividendoDao
    {
        public static IList<Dividendo> GetDividendosByClient(int clienteid)
        {
           

            string var1 = string.Empty;
            var1 = var1 + "SET DATEFORMAT DMY " + "\n";
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       Fecha, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Tdc, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       StatusID, " + "\n";
            var1 = var1 + "       Dividendo " + "\n";
            var1 = var1 + "FROM   Dividendo  " + "\n";
            var1 = var1 + "WHERE  Dividendo.ClienteID =  " + clienteid + "";


            DataTable drDividendo = Db.GetDataTable(var1);

            IList<Dividendo> list = new List<Dividendo>();

            foreach (DataRow row in drDividendo.Rows)
            {
                if (drDividendo != null)
                {
                    Dividendo dividendo = new Dividendo();
                    dividendo.ClienteID = int.Parse(row["ClienteID"].ToString());
                    dividendo.Dividendo_Obtenido = decimal.Parse(row["Dividendo"].ToString());
                    dividendo.Fecha = DateTime.Parse(row["Fecha"].ToString()); ;
                    dividendo.Monto = decimal.Parse(row["Monto"].ToString());
                    dividendo.Login = row["LoginCreado"].ToString();
                    dividendo.Tdc = row["Tdc"].ToString();
                    dividendo.Status = GetStatus(int.Parse(row["StatusID"].ToString()));

                    list.Add(dividendo);


                }
                else
                {
                    return null;
                }
            }
            return list;
        }

        public static IList<Dividendo> GetDividendos()
        {


            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       Fecha, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Tdc, " + "\n";
            var1 = var1 + "       LoginCreado, " + "\n";
            var1 = var1 + "       StatusID, " + "\n";
            var1 = var1 + "       Dividendo " + "\n";
            var1 = var1 + "FROM   Dividendo  " + "\n";


            DataTable drDividendo = Db.GetDataTable(var1);

            IList<Dividendo> list = new List<Dividendo>();

            Cliente cliente = new Cliente();

            foreach (DataRow row in drDividendo.Rows)
            {
                if (drDividendo != null)
                {
                    Dividendo dividendo = new Dividendo();
                    dividendo.ClienteID = int.Parse(row["ClienteID"].ToString());
                    dividendo.Dividendo_Obtenido = decimal.Parse(row["Dividendo"].ToString());
                    dividendo.Fecha = DateTime.Parse(row["Fecha"].ToString()); ;
                    dividendo.Monto = decimal.Parse(row["Monto"].ToString());
                    dividendo.Login = row["LoginCreado"].ToString();
                    dividendo.Tdc = row["Tdc"].ToString();
                    dividendo.Status = GetStatus(int.Parse(row["StatusID"].ToString()));
                    
                    cliente = ClienteDao.ObtenerCliente(dividendo.ClienteID);
                    if (cliente != null)
                    {
                        dividendo.Cliente = cliente.Descripcion;
                    }
                    list.Add(dividendo);


                }
                else
                {
                    return null;
                }
            }
            return list;
        }

        public static string GetStatus(int statusid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@StatusID", SqlDbType.Int);
            prn.Value = statusid;
            parameters.Add(prn);


            string var1 = string.Empty;

            var1 = var1 + "SELECT StatusID, " + "\n";
            var1 = var1 + "       Descripcion " + "\n";
            var1 = var1 + "FROM   Status  " + "\n";
            var1 = var1 + "WHERE  Status.StatusID =  " + statusid + "";


            DataRow row = Db.GetDataRow(var1);

            if (row != null)
            {
                Status status = new Status();

                if (!string.IsNullOrEmpty(row["StatusID"].ToString()))
                    status.StatusID = int.Parse(row["StatusID"].ToString());

                if (!string.IsNullOrEmpty(row["Descripcion"].ToString()))
                    status.Descripcion = row["Descripcion"].ToString();

                return status.Descripcion;
            }
            else
                return null;
        }

        public static IList<Dividendo> GetDividendosPorFecha(DateTime fecha)
        {
           

            string var1 = string.Empty;
            var1 = var1 + "SET DATEFORMAT DMY " + "\n";
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       Fecha, " + "\n";
            var1 = var1 + "       Monto, " + "\n";
            var1 = var1 + "       Tdc, " + "\n";
            var1 = var1 + "       LoginCreado " + "\n";
            var1 = var1 + "       StatusID " + "\n";
            var1 = var1 + "       Dividendo " + "\n";
            var1 = var1 + "FROM   Dividendo  " + "\n";
            var1 = var1 + "WHERE  Dividendo.fecha =  " + fecha + "";
 

            DataTable drDividendo = Db.GetDataTable(var1);

            IList<Dividendo> list = new List<Dividendo>();

            foreach (DataRow row in drDividendo.Rows)
            {
                if (drDividendo != null)
                {
                    Dividendo dividendo = new Dividendo();
                    dividendo.ClienteID = int.Parse(row["ClienteID"].ToString());
                    dividendo.Dividendo_Obtenido = decimal.Parse(row["Dividendo"].ToString());
                    dividendo.Fecha = DateTime.Parse(row["fecha"].ToString()); ;
                    dividendo.Monto = decimal.Parse(row["Monto"].ToString());
                    dividendo.Login = row["LoginCreado"].ToString();
                    dividendo.Tdc = row["Tdc"].ToString();
                    dividendo.Status = GetStatus(int.Parse(row["StatusID"].ToString()));

                    list.Add(dividendo);


                }
                else
                {
                    return null;
                }
            }
            return list;
        }

        public static DaoResult Dividendo_Delete(int clienteid, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = clienteid;
            parameters.Add(prn);

            prn = new SqlParameter("@Login", SqlDbType.VarChar, 30);
            prn.Value = login;
            parameters.Add(prn);

            return Db.Insert(parameters, "Dividendo_DELETE");

        }

        public static DaoResult Dividendo_Insert(Dividendo dividendo, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
           

            SqlParameter prn = new SqlParameter("@Fecha", SqlDbType.VarChar, 10);
            prn.Value = string.Format("{0:dd/MM/yyyy}", dividendo.Fecha);
            parameters.Add(prn);

            prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = dividendo.ClienteID;
            parameters.Add(prn);          

            prn = new SqlParameter("@Tdc", SqlDbType.VarChar, 50);
            prn.Value = dividendo.Tdc;
            parameters.Add(prn);

            prn = new SqlParameter("@Monto", SqlDbType.Decimal);
            prn.Value = dividendo.Monto;
            parameters.Add(prn);

            prn = new SqlParameter("@Dividendo", SqlDbType.Decimal);
            prn.Value = dividendo.Dividendo_Obtenido;
            parameters.Add(prn);

            prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar, 50);
            prn.Value = login;
            parameters.Add(prn);

            prn = new SqlParameter("@StatusID", SqlDbType.Int);
            prn.Value = 3;
            parameters.Add(prn);

            return Db.Insert(parameters, "Dividendo_INSERT", false, false);

        }

        public static DaoResult Dividendo_Update(Dividendo dividendo, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@Fecha", SqlDbType.VarChar, 10);
            prn.Value = string.Format("{0:dd/MM/yyyy}", dividendo.Fecha);
            parameters.Add(prn);

            prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = dividendo.ClienteID;
            parameters.Add(prn);

            prn = new SqlParameter("@Tdc", SqlDbType.VarChar, 50);
            prn.Value = dividendo.Tdc;
            parameters.Add(prn);

            prn = new SqlParameter("@Monto", SqlDbType.Decimal);
            prn.Value = dividendo.Monto;
            parameters.Add(prn);

            prn = new SqlParameter("@Dividendo", SqlDbType.Decimal);
            prn.Value = dividendo.Dividendo_Obtenido;
            parameters.Add(prn);

            prn = new SqlParameter("@Login", SqlDbType.VarChar, 50);
            prn.Value = dividendo.Login;
            parameters.Add(prn);

            prn = new SqlParameter("@Status", SqlDbType.Int);
            prn.Value = dividendo.Status;
            parameters.Add(prn);

            return Db.Insert(parameters, "Dividendo_UPDATE", false, false);

        }
    }
}
