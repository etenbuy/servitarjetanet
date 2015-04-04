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
    public static class StatusDao
    {

        #region LECTURA


        public static IList<Status> Status_GET()
        {

            IList<Status> list = new List<Status>();

            string var1 = string.Empty;


            var1 = var1 + "select StatusID,Descripcion from Status";

            DataTable dtStatus = Db.GetDataTable(var1);


            foreach (DataRow row in dtStatus.Rows)
            {
               

                    Status status = new Status();

                    status.StatusID = int.Parse(row["StatusID"].ToString());
                    status.Descripcion = row["Descripcion"].ToString();



                    list.Add(status);
                
            }

            return list;

        }

     


        #endregion
    }
}
