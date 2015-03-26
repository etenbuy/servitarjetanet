using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using BusinessObjects;

namespace Controllers
{
    public class CuentaController
    {
        public IList<Cuenta> GetCuentas()
        {
            return CuentaDao.GetCuentas();
        }
        public IList<Cuenta> GetCuentasUsuario(string usuario)
        {
            return CuentaDao.GetCuentasUsuario(usuario);
        }

        public IList<int> GetCuentasByTipo(string tipo)
        {
            return CuentaDao.GetCuentasByTipo(tipo);
        }

        public IList<Cuenta> GetCuentasAll()
        {
            return CuentaDao.GetCuentasAll();
        }
        public IList<int> GetCuentasID()
        {
            return CuentaDao.GetCuentasID();
        }
        public Cuenta GetCuenta(int cuentaid)
        {
            return CuentaDao.GetCuenta(cuentaid);
        }

        public IList<Cuenta> GetCuentas(IList<int> cuentasid)
        {

            return CuentaDao.GetCuentas(cuentasid);

        }

        public IList<Cuenta> GetCuentasAcopio()
        {

            return CuentaDao.GetCuentasAcopio();

        }


        public IList<Cuenta> GetTraspasoCuentas()
        {
            IList<int> cuentas = new List<int>();

            cuentas.Add(2);

            cuentas.Add(3);

            cuentas.Add(4);

            cuentas.Add(5);

            cuentas.Add(6);

            return CuentaDao.GetCuentas(cuentas);

        }
        public ControllerResult Cuenta_INSERT(Cuenta cuenta, string logincreado)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            DaoResult daoResult = CuentaDao.Cuenta_INSERT(cuenta,logincreado);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Cliente " + cuenta.Nombre + " se ha agregado satisfactoriamente.";

                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }
        public ControllerResult Cuenta_Usuario_INSERT(int cuentaid, string logincreado)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            DaoResult daoResult = CuentaDao.Cuenta_Usuario_INSERT(cuentaid, logincreado);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Usuario " + logincreado + " se ha agregado satisfactoriamente.";

                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }


        public ControllerResult Cuenta_UPDATE(Cuenta cuenta, string logincreado)
        {
            ControllerResult resultado = new ControllerResult(string.Empty);

            DaoResult daoResult = CuentaDao.Cuenta_update(cuenta, logincreado);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: El Cliente " + cuenta.Nombre + " se ha actualizado satisfactoriamente.";

                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }
        public ControllerResult EliminarDiferencia(int diferenciaid, string login)
        {
            ControllerResult resultado = new ControllerResult(login);

            DaoResult daoResult = CuentaDao.Diferencia_Delete(diferenciaid, login);

            if (daoResult.ErrorCount == 0)
            {
                resultado.Mensaje = "Correcto: La Diferencia Nro. " + diferenciaid.ToString() + " se ha eliminado satisfactoriamente.";
                resultado.Resultado = Result.Successful;
            }
            else
            {
                resultado.Mensaje = daoResult.ErrorMessage;
                resultado.Resultado = Result.Error;
            }

            return resultado;

        }
    }
}
