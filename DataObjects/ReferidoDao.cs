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
    public static class ReferidoDao
    {

        #region ESCRITURA

        public static DaoResult CrearReferido(Referido referido, string Login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@Descripcion", SqlDbType.VarChar, 100);
            prn.Value = referido.Descripcion;
            parameters.Add(prn);

            if (referido.Direccion != null)
            {
                prn = new SqlParameter("@Direccion", SqlDbType.VarChar, 500);
                prn.Value = referido.Direccion;
                parameters.Add(prn);
            }
            if (referido.Telefono != null)
            {
                prn = new SqlParameter("@Telefono", SqlDbType.VarChar, 30);
                prn.Value = referido.Telefono;
                parameters.Add(prn);
            }
            if (referido.Email != null)
            {
                prn = new SqlParameter("@Email", SqlDbType.VarChar, 60);
                prn.Value = referido.Email;
                parameters.Add(prn);
            }
            
            if (Login != null)
            {
                prn = new SqlParameter("@ClienteID", SqlDbType.Int);
                prn.Value = 1;
                parameters.Add(prn);
            }


            DaoResult result = Db.Insert(parameters, "Referido_INSERT", false,false);
            return result;
        }

        




        public static DaoResult EliminarReferido(Referido referido)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@ReferidoID", SqlDbType.Int);
            prn.Value = referido.ReferidoID;
            parameters.Add(prn);


            return Db.Insert(parameters, "Referido_DELETE");

        }

       


        #endregion

        #region LECTURA

        public static IList<Referido> GetReferidosByClient(int clientid)
        {


            IList<Referido> list = new List<Referido>();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID, " + "\n";
            var1 = var1 + "       ReferidoID, " + "\n";
            var1 = var1 + "       Descripcion, " + "\n";
            var1 = var1 + "       Telefono, " + "\n";
            var1 = var1 + "       Email, " + "\n";
            var1 = var1 + "       RIF, " + "\n";
            var1 = var1 + "       Direccion " + "\n";
            var1 = var1 + "FROM   Referido " + "\n";
            var1 = var1 + "WHERE  ClienteID =" + clientid + " " + "\n";


            DataTable dt = Db.GetDataTable(var1);

            foreach (DataRow row in dt.Rows)
            {

                Referido referido = new Referido();
                referido.ClienteID = int.Parse(row["ClienteID"].ToString());
                referido.ReferidoID = int.Parse(row["ClienteID"].ToString());
                referido.Direccion = row["Direccion"].ToString();
                referido.Email = row["Email"].ToString();
                referido.Telefono = row["Telefono"].ToString();
                referido.Descripcion = row["Descripcion"].ToString();

                list.Add(referido);

            }
            
            return list;
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
