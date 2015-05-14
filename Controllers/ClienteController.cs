using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using BusinessObjects.BusinessRules;

namespace Controllers
{
    public class ClienteController
    {
        public IList<int> GetClientesID()
        {
            return ClienteDao.GetClientesID();
        }

        public IList<Cliente> GetClientes(IList<int> clientesid)
        {

            return ClienteDao.GetClientes(clientesid);

        }

        public Cliente Get_IdMailClient(string mail)
        {
            return ClienteDao.Get_IdMailClient(mail);

        }

        public Cliente ObtenerCliente(int clienteid)
        {

            return ClienteDao.ObtenerCliente(clienteid);

        }

        public Cliente ObtenerClientePunto(int puntoid)
        {

            return ClienteDao.ObtenerClientePunto(puntoid);

        }

        public Cliente ObtenerCliente(string descripcion)
        {

            return ClienteDao.ObtenerCliente(descripcion);

        }

      


        public ControllerResult CrearCliente(Cliente cliente, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = ClienteDao.CrearCliente(cliente, resultado.Login);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Cliente Nro. " + daoResult.Identity.ToString() + " se ha creado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
                resultado.MensajeExtra =daoResult.Identity.ToString();
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }

        public ControllerResult ActualizarCliente(Cliente cliente, string login)
        {
            ControllerResult resultado = new ControllerResult(login);


            DaoResult daoResult = ClienteDao.ActualizarCliente(cliente);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Cliente Nro. " + cliente.ClienteID + " se ha actualizado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }



        public ControllerResult EliminarCliente(Cliente cliente)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);


            DaoResult daoResult = ClienteDao.EliminarCliente(cliente);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Cliente Nro. " + cliente.ClienteID.ToString() + " se ha Eliminado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }



        public ControllerResult CrearClientePunto(Cliente cliente)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            DaoResult daoResult = ClienteDao.CrearClientePunto(cliente);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Punto de Visita Nro. " + daoResult.Identity.ToString() + " se ha creado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }



        public ControllerResult EliminarClientePunto(Cliente cliente)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);


            DaoResult daoResult = ClienteDao.EliminarClientePunto(cliente);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Punto de Visita Nro. " + cliente.PuntoID.ToString() + " se ha Eliminado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;
        }

        public IList<Cliente> Clientes_GET()
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            IList<Cliente> cliente = ClienteDao.Clientes_GET();

            return cliente;

        }

        public IList<Cliente> ClientesPuntos_GET(int clienteid)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            IList<Cliente> cliente = ClienteDao.ClientesPuntos_GET(clienteid);

            return cliente;

        }
    }
}
