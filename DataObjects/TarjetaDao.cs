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
    public static class TarjetaDao
    {

        #region LECTURA
        public static Tarjeta Get_tarjeta(string numero)
        {

            Tarjeta tarjeta = new Tarjeta();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID,Numero " + "\n";
            var1 = var1 + "FROM   Tarjeta " + "\n";
            var1 = var1 + "WHERE  Numero ='" + numero + "' " + "\n";


            DataRow row = Db.GetDataRow(var1);

            if (row != null)
            {

                tarjeta.ClienteID = int.Parse(row["ClienteID"].ToString());
                tarjeta.Numero = row["Numero"].ToString();
                
            }

            return tarjeta;
        }

        public static IList<Tarjeta> Tarjetas_GET(int ClienteID)
        {

            IList<Tarjeta> list = new List<Tarjeta>();

            string var1 = string.Empty;


            var1 = var1 + "select Id,ClienteID,Numero from Tarjeta WHERE ClienteID =" + ClienteID  + "";

            DataTable dtTarjetas = Db.GetDataTable(var1);


            foreach (DataRow row in dtTarjetas.Rows)
            {

                Tarjeta tarjetas = new Tarjeta();

                tarjetas.ClienteID = int.Parse(row["ClienteID"].ToString());
                tarjetas.Numero = row["Numero"].ToString();
                tarjetas.Id = int.Parse(row["Id"].ToString());
                list.Add(tarjetas);
                
            }

            return list;

        }

     


        #endregion

        public static DaoResult CrearTarjeta(Tarjeta tarjeta, string Login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = tarjeta.ClienteID;
            parameters.Add(prn);


            prn = new SqlParameter("@Numero", SqlDbType.VarChar,50);
            prn.Value = tarjeta.Numero;
            parameters.Add(prn);
  
            DaoResult result = Db.Insert(parameters, "Tarjeta_INSERT", false, false);
            return result;
        }

        public static DaoResult ActualizarTarjeta(Tarjeta tarjeta, string Login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = tarjeta.ClienteID;
            parameters.Add(prn);


            prn = new SqlParameter("@Numero", SqlDbType.VarChar, 50);
            prn.Value = tarjeta.Numero;
            parameters.Add(prn);

            DaoResult result = Db.Insert(parameters, "Tarjeta_UPDATE", false, false);
            return result;
        }

    }
}
