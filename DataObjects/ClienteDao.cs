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
    public static class ClienteDao
    {

        #region ESCRITURA

        public static DaoResult CrearCliente(Cliente cliente, string Login)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@Descripcion", SqlDbType.VarChar, 100);
            prn.Value = cliente.Descripcion;
            parameters.Add(prn);

            prn = new SqlParameter("@LoginCreado", SqlDbType.VarChar, 500);
            prn.Value = cliente.LoginCreado;
            parameters.Add(prn);

            if (cliente.Direccion != null)
            {
                prn = new SqlParameter("@Direccion", SqlDbType.VarChar, 500);
                prn.Value = cliente.Direccion;
                parameters.Add(prn);
            }
            if (cliente.Telefono != null)
            {
                prn = new SqlParameter("@Telefono", SqlDbType.VarChar, 30);
                prn.Value = cliente.Telefono;
                parameters.Add(prn);
            }
            if (cliente.Email != null)
            {
                prn = new SqlParameter("@Email", SqlDbType.VarChar, 60);
                prn.Value = cliente.Email;
                parameters.Add(prn);
            }
            if (cliente.RIF != null)
            {
                prn = new SqlParameter("@RIF", SqlDbType.VarChar, 50);
                prn.Value = cliente.RIF;
                parameters.Add(prn);
            }
            if (Login != null)
            {
                prn = new SqlParameter("@Login", SqlDbType.VarChar, 50);
                prn.Value = Login;
                parameters.Add(prn);
            }


            DaoResult result = Db.Insert(parameters, "Cliente_INSERT", true,false);
            return result;
        }

        public static DaoResult ActualizarCliente(Cliente cliente)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@Descripcion", SqlDbType.VarChar, 100);
            prn.Value = cliente.Descripcion;
            parameters.Add(prn);

            prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = cliente.ClienteID;
            parameters.Add(prn);

            if (cliente.Direccion != null)
            {
                prn = new SqlParameter("@Direccion", SqlDbType.VarChar, 500);
                prn.Value = cliente.Direccion;
                parameters.Add(prn);
            }
            if (cliente.Telefono != null)
            {
                prn = new SqlParameter("@Telefono", SqlDbType.VarChar, 30);
                prn.Value = cliente.Telefono;
                parameters.Add(prn);
            }
            if (cliente.Email != null)
            {
                prn = new SqlParameter("@Email", SqlDbType.VarChar, 60);
                prn.Value = cliente.Email;
                parameters.Add(prn);
            }
            if (cliente.RIF != null)
            {
                prn = new SqlParameter("@RIF", SqlDbType.VarChar, 50);
                prn.Value = cliente.RIF;
                parameters.Add(prn);
            }
            


            DaoResult result = Db.Insert(parameters, "Cliente_UPDATE", false, false);
            return result;
        }




        public static DaoResult EliminarCliente(Cliente cliente)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = cliente.ClienteID;
            parameters.Add(prn);


            return Db.Insert(parameters, "Cliente_DELETE");

        }

        public static DaoResult CrearClientePunto(Cliente cliente)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = cliente.ClienteID;
            parameters.Add(prn);

            prn = new SqlParameter("@RutaID", SqlDbType.Int);
            prn.Value = cliente.RutaID;
            parameters.Add(prn);

            prn = new SqlParameter("@NombrePunto", SqlDbType.VarChar, 100);
            prn.Value = cliente.NombrePunto;
            parameters.Add(prn);

            prn = new SqlParameter("@Abreviado", SqlDbType.VarChar, 100);
            prn.Value = cliente.Abreviado;
            parameters.Add(prn);


            DaoResult result = Db.Insert(parameters, "ClientePunto_INSERT", true,false);
            return result;
        }




        public static DaoResult EliminarClientePunto(Cliente cliente)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@PuntoID", SqlDbType.Int);
            prn.Value = cliente.PuntoID;
            parameters.Add(prn);


            return Db.Insert(parameters, "ClientePunto_DELETE");

        }



        #endregion

        #region LECTURA

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

        public static Cliente Get_IdMailClient(string mail)
        {

            Cliente cliente = new Cliente();

            string var1 = string.Empty;
            var1 = var1 + "SELECT ClienteID,LoginCreado " + "\n";
            var1 = var1 + "FROM   Cliente " + "\n";
            var1 = var1 + "WHERE  Email ='" + mail + "' " + "\n";


            DataRow row = Db.GetDataRow(var1);

            if (row != null)
            {

                cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                cliente.LoginCreado = row["LoginCreado"].ToString();
                return cliente;
            }

            return cliente;
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

        public static Cliente ObtenerClientePunto(int puntoid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@PuntoID", SqlDbType.Int);
            prn.Value = puntoid;
            parameters.Add(prn);

            DataRow Row = Db.GetDataRow(parameters, "ClientePunto_GET");

            if (Row != null)
            {

                Cliente cliente = new Cliente();

                cliente.ClienteID = int.Parse(Row["ClienteID"].ToString());
                cliente.NombrePunto = Row["NombrePunto"].ToString();
                cliente.Abreviado = Row["Abreviado"].ToString();
                cliente.PuntoID = int.Parse(Row["PuntoID"].ToString());

                return cliente;

            }
            else
                return null;


        }

        public static IList<Cliente> ClientesPuntos_GET(int clienteid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@ClienteID", SqlDbType.Int);
            prn.Value = clienteid;
            parameters.Add(prn);

            DataTable dtCliente = Db.GetDataTable(parameters, "ClientesPuntos_GET");

            IList<Cliente> list = new List<Cliente>();

            foreach (DataRow row in dtCliente.Rows)
            {
                if (row != null)
                {

                    Cliente cliente = new Cliente();

                    cliente.ClienteID = int.Parse(row["ClienteID"].ToString());
                    cliente.PuntoID = int.Parse(row["PuntoID"].ToString());
                    cliente.NombrePunto = row["NombrePunto"].ToString();
                    cliente.NombreRuta = row["NombreRuta"].ToString();
                    cliente.Abreviado = row["Abreviado"].ToString();

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
