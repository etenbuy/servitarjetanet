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
    }
}
