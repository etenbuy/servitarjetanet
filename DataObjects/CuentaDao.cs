using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjects;
using DataObjects.AdoNet;
using System.Data.SqlClient;

namespace DataObjects
{
    public static class CuentaDao
    {
        public static Cuenta GetCuenta(int cuentaid)
        {
            string var1 = string.Empty;
            var1 = var1 + "SET DATEFORMAT DMY " + "\n";
            var1 = var1 + "SELECT * " + "\n";
            var1 = var1 + "FROM   cuenta " + "\n";
            var1 = var1 + "WHERE  cuentaid = " + cuentaid.ToString();

            DataRow drCuenta = Db.GetDataRow(var1);
            if (drCuenta != null)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.CuentaID = cuentaid;
                cuenta.co_cli = drCuenta["co_cli"].ToString();
                bool activo = bool.Parse(drCuenta["activo"].ToString());
                if (activo == true)
                {
                    cuenta.Activo = 0;
                }
                else
                {
                    cuenta.Activo = 1;
                }
               
                cuenta.Numero = drCuenta["numero"].ToString();
                cuenta.Nombre = drCuenta["nombre"].ToString();
                cuenta.Saldo = decimal.Parse(drCuenta["saldo"].ToString());

                return cuenta;
            }
            else
            {
                return null;
            }
        }
        public static DaoResult Cuenta_INSERT(Cuenta cuenta, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@Nombre", SqlDbType.VarChar,50);
            prn.Value = cuenta.Nombre;
            parameters.Add(prn);

            prn = new SqlParameter("@Tipo", SqlDbType.VarChar, 50);
            prn.Value = cuenta.Tipo;
            parameters.Add(prn);

            prn = new SqlParameter("@Numero", SqlDbType.VarChar,50);
            prn.Value = cuenta.Numero;
            parameters.Add(prn);

            prn = new SqlParameter("@co_cli", SqlDbType.VarChar, 30);
            prn.Value = cuenta.co_cli;
            parameters.Add(prn);

            prn = new SqlParameter("@Activo", SqlDbType.Int);
            prn.Value = cuenta.Activo;
            parameters.Add(prn);

            prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar,13);
            prn.Value = login;
            parameters.Add(prn);

            return Db.Insert(parameters, "Cuenta_INSERT");

        }

        public static DaoResult Cuenta_Usuario_INSERT(int cuentaid, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@CuentaID", SqlDbType.Int);
            prn.Value = cuentaid;
            parameters.Add(prn);

            prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar, 50);
            prn.Value = login;
            parameters.Add(prn);

            return Db.Insert(parameters, "Cuenta_Usuario_INSERT");

        }
        public static DaoResult Cuenta_update(Cuenta cuenta, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@Nombre", SqlDbType.VarChar, 50);
            prn.Value = cuenta.Nombre;
            parameters.Add(prn);

            prn = new SqlParameter("@Numero", SqlDbType.VarChar,50);
            prn.Value = cuenta.Numero;
            parameters.Add(prn);

            prn = new SqlParameter("@co_cli", SqlDbType.VarChar, 30);
            prn.Value = cuenta.co_cli;
            parameters.Add(prn);

            prn = new SqlParameter("@Activo", SqlDbType.Int);
            prn.Value = cuenta.Activo;
            parameters.Add(prn);

            prn = new SqlParameter("@CuentaID", SqlDbType.Int);
            prn.Value = cuenta.CuentaID;
            parameters.Add(prn);

            prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar, 13);
            prn.Value = login;
            parameters.Add(prn);

            return Db.Insert(parameters, "Cuenta_UPDATE");

        }

        public static DaoResult Diferencia_Delete(int diferenciaid, string login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@DiferenciaID", SqlDbType.Int);
            prn.Value = diferenciaid;
            parameters.Add(prn);

            prn = new SqlParameter("@Login", SqlDbType.VarChar, 30);
            prn.Value = login;
            parameters.Add(prn);

            return Db.Insert(parameters, "Diferencia_DELETE");

        }

        public static IList<Cuenta> GetCuentas()
        {

            DataTable dt = Db.GetDataTable(null, "Cuenta_Get");
            IList<Cuenta> list = new List<Cuenta>();
            foreach (DataRow dr in dt.Rows)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.CuentaID = int.Parse(dr["CuentaID"].ToString());
                cuenta.co_cli = dr["co_cli"].ToString();
                cuenta.Saldo = decimal.Parse(dr["Saldo"].ToString());
                cuenta.FechaCreado = DateTime.ParseExact(dr["FechaCreado"].ToString().Substring(0,10),"dd/MM/yyyy", null);
                cuenta.LoginCreado = dr["LoginCreado"].ToString();
                cuenta.UltimaTransaccionID = int.Parse(dr["UltimaTransaccionID"].ToString());
                cuenta.BovedaID = int.Parse(dr["BovedaID"].ToString());
                cuenta.Nombre = dr["Nombre"].ToString();
                list.Add(cuenta);
            }
            return list;
        }

       

        public static IList<Cuenta> GetCuentasUsuario(string usuario)
        {

            DataTable dt = Db.GetDataTable(null, "Cuenta_Usuario_Get");
            IList<Cuenta> list = new List<Cuenta>();
            foreach (DataRow dr in dt.Rows)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.CuentaID = int.Parse(dr["CuentaID"].ToString());
                cuenta.co_cli = dr["co_cli"].ToString();
                cuenta.Saldo = decimal.Parse(dr["Saldo"].ToString());
                cuenta.FechaCreado = DateTime.ParseExact(dr["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                cuenta.LoginCreado = dr["LoginCreado"].ToString();
                cuenta.UltimaTransaccionID = int.Parse(dr["UltimaTransaccionID"].ToString());
                cuenta.BovedaID = int.Parse(dr["BovedaID"].ToString());
                cuenta.Nombre = dr["Nombre"].ToString();
                list.Add(cuenta);
            }
            return list;
        }
        public static IList<int> GetCuentasByTipo(string tipo)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@tipo", SqlDbType.VarChar,50);
            prn.Value = tipo;
            parameters.Add(prn);


            DataTable dt = Db.GetDataTable(parameters, "Cuenta_By_Tipo_Get");
            IList<int> list = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                int cuentaid = 0;
                //Cuenta cuenta = new Cuenta();
                cuentaid = int.Parse(dr["CuentaID"].ToString());
                //cuenta.co_cli = dr["co_cli"].ToString();
                //cuenta.Saldo = decimal.Parse(dr["Saldo"].ToString());
                //cuenta.FechaCreado = DateTime.ParseExact(dr["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                //cuenta.LoginCreado = dr["LoginCreado"].ToString();
                //cuenta.UltimaTransaccionID = int.Parse(dr["UltimaTransaccionID"].ToString());
                //cuenta.BovedaID = int.Parse(dr["BovedaID"].ToString());
                //cuenta.Nombre = dr["Nombre"].ToString();
                list.Add(cuentaid);
            }
            return list;
        }

        public static IList<Cuenta> GetCuentasAll()
        {

            DataTable dt = Db.GetDataTable(null, "CuentaAll_Get");
            IList<Cuenta> list = new List<Cuenta>();
            foreach (DataRow dr in dt.Rows)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.CuentaID = int.Parse(dr["CuentaID"].ToString());
                cuenta.co_cli = dr["co_cli"].ToString();
                cuenta.Saldo = decimal.Parse(dr["Saldo"].ToString());
                cuenta.FechaCreado = DateTime.ParseExact(dr["FechaCreado"].ToString().Substring(0, 10), "dd/MM/yyyy", null);
                cuenta.LoginCreado = dr["LoginCreado"].ToString();
                cuenta.UltimaTransaccionID = int.Parse(dr["UltimaTransaccionID"].ToString());
                cuenta.BovedaID = int.Parse(dr["BovedaID"].ToString());
                cuenta.Nombre = dr["Nombre"].ToString();
                cuenta.Numero = dr["Numero"].ToString();
                bool activo = bool.Parse(dr["activo"].ToString());
                if (activo == true)
                {
                    cuenta.ActivoDescripcion = "SI";
                }
                else
                {
                    cuenta.ActivoDescripcion = "NO";
                }

                list.Add(cuenta);
            }
            return list;
        }
       
        public static IList<int> GetCuentasID()
        {

            DataTable dt = Db.GetDataTable(null, "Cuenta_Get");
            IList<int> list = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                int cuentaid = 0;
                cuentaid = int.Parse(dr["CuentaID"].ToString());

                list.Add(cuentaid);
            }
            return list;
        }
        
        public static IList<Cuenta> GetCuentas(IList<int> cuentasids)
        {

            IList<Cuenta> list = new List<Cuenta>();

            if (cuentasids.Count > 0)
            {

                string cuentas = string.Empty;

                int count = 0;

                foreach (int cuenta in cuentasids)
                {
                    count++;

                    cuentas += cuenta.ToString();

                    if (count < cuentasids.Count)
                        cuentas += ", ";

                }

                string var1 = string.Empty;
                var1 = var1 + "SET DATEFORMAT DMY " + "\n";
                var1 = var1 + "SELECT nombre, " + "\n";
                var1 = var1 + "       saldo, " + "\n";
                var1 = var1 + "       cuentaID " + "\n";
                var1 = var1 + "FROM   cuenta " + "\n";
                var1 = var1 + "WHERE  cuentaID IN (" + cuentas.ToString() + ") " + "\n";


                DataTable dt = Db.GetDataTable(var1);

                foreach (DataRow row in dt.Rows)
                {
                    Cuenta cuenta = new Cuenta();
                    cuenta.CuentaID = int.Parse(row["CuentaID"].ToString());
                    cuenta.Nombre = row["Nombre"].ToString();
                    cuenta.Saldo = decimal.Parse(row["Saldo"].ToString());


                    list.Add(cuenta);

                }
            }
            return list;
        }

        public static IList<Cuenta> GetCuentasAcopio()
        {

            //IList<Cuenta> list = new List<Cuenta>();


                string cuentas = string.Empty;

                DataTable dt = Db.GetDataTable(null, "CuentaAcopio_Get");
                IList<Cuenta> list = new List<Cuenta>();

                foreach (DataRow dr in dt.Rows)
                {
                    Cuenta cuenta = new Cuenta();

                    cuenta.CuentaID = int.Parse(dr["CuentaID"].ToString());
                    cuenta.Nombre = dr["Nombre"].ToString();
                    cuenta.Saldo = decimal.Parse(dr["Saldo"].ToString());
                    list.Add(cuenta);
                }
                return list;

               
            //    string var1 = string.Empty;
            //    var1 = var1 + "SET DATEFORMAT DMY " + "\n";
            //    var1 = var1 + "SELECT nombre, " + "\n";
            //    var1 = var1 + "       saldo, " + "\n";
            //    var1 = var1 + "       cuentaID " + "\n";
            //    var1 = var1 + "FROM   cuenta " + "\n";


            //    DataTable dt = Db.GetDataTable(var1);

            //    foreach (DataRow row in dt.Rows)
            //    {
            //        Cuenta cuenta = new Cuenta();
            //        cuenta.CuentaID = int.Parse(row["CuentaID"].ToString());
            //        cuenta.Nombre = row["Nombre"].ToString();
            //        cuenta.Saldo = decimal.Parse(row["Saldo"].ToString());


            //        list.Add(cuenta);

            //    }
           
            //return list;
        }
    }
}
