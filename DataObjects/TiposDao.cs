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
    public static class TiposDao
    {

        #region LECTURA


        public static IList<Tipo> Tipos_GET()
        {

            IList<Tipo> list = new List<Tipo>();

            string var1 = string.Empty;


            var1 = var1 + "select Valor,Definicion from Tipo WHERE Valor <> 1";

            DataTable dtTipos = Db.GetDataTable(var1);


            foreach (DataRow row in dtTipos.Rows)
            {

                Tipo tipos = new Tipo();

                tipos.Valor = int.Parse(row["Valor"].ToString());
                tipos.Definicion = row["Definicion"].ToString();
                list.Add(tipos);
                
            }

            return list;

        }

     


        #endregion
    }
}
