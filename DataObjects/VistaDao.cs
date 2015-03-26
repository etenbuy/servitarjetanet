using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObjects.AdoNet;
using System.Data.SqlClient;

namespace DataObjects
{
    public static class VistaDao
    {


        public static DataTable GetSolicitud(int cuentaid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@CuentaID", SqlDbType.Int);
            prn.Value = cuentaid;
            parameters.Add(prn);

            return Db.GetDataTable(parameters, "Solicitud_GET");
        }

        public static DataTable GetPuntoByCartaporte(string cartaporte)
        {
            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT Punto.Nombre,Punto.PuntoID " + "\n";
            var1 = var1 + "       FROM    Punto" + "\n";
            var1 = var1 + "       JOIN    Cartaporte_Punto " + "\n";
            var1 = var1 + "       ON      Cartaporte_Punto.PuntoID = Punto.PuntoID" + "\n";
            var1 = var1 + "      WHERE      Cartaporte_Punto.CartaporteID = '" + cartaporte + "'" + "\n";
            var1 = var1 + "      and       Cartaporte_Punto.Tipo = 1";

            return Db.GetDataTable(var1);
        }

        public static DataTable GetPuntoByCartaporteConsignatario(string cartaporte)
        {
            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT Punto.Nombre,Punto.PuntoID " + "\n";
            var1 = var1 + "       FROM    Punto" + "\n";
            var1 = var1 + "       JOIN    Cartaporte_Punto " + "\n";
            var1 = var1 + "       ON      Cartaporte_Punto.PuntoID = Punto.PuntoID" + "\n";
            var1 = var1 + "      WHERE      Cartaporte_Punto.CartaporteID = '" + cartaporte + "'" + "\n";
            var1 = var1 + "      and       Cartaporte_Punto.Tipo = 2";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_DiferenciasPorFecha(DateTime desde, DateTime hasta)
        {

            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT  DiferenciaID, " + "\n";
            var1 = var1 + "       Fecha, " + "\n";
            var1 = var1 + "       Punto.Nombre AS Nombre, " + "\n";
            var1 = var1 + "       Monto, MontoTransaccion, Descripcion " + "\n";
            var1 = var1 + "       FROM    Diferencia" + "\n";
            var1 = var1 + "       JOIN    Punto " + "\n";
            var1 = var1 + "       ON      Punto.PuntoID = Diferencia.PuntoID" + "\n";

            var1 = var1 + "WHERE  Fecha > '" + string.Format("{0:dd/MM/yyyy}", desde.Date) + "'";
            var1 = var1 + "AND  Fecha < '" + string.Format("{0:dd/MM/yyyy}", hasta.Date) + "'";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetPlacas()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  Descripcion,PlacaID " + "\n";
            var1 = var1 + "       FROM    Placa";

            return Db.GetDataTable(var1);
        }
        public static DataTable VW_GetBancos()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  Descripcion,BANCOID " + "\n";
            var1 = var1 + "       FROM    banco";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetCuentasNumero()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  numero,cnumeroID " + "\n";
            var1 = var1 + "       FROM    cuenta_numero";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetPuntos()
        {

           string var1 = string.Empty;

           var1 = var1 + "SELECT b.Tipo AS Tipo, b.Ruta,p.Nombre,p.PuntoID,p.Numero,c.Nombre AS cuenta,p.Rubroid,r.Definicion as Rubro" + "\n";
           var1 = var1 + "FROM    Punto p" + "\n";
           var1 = var1 + "JOIN Biblia b" + "\n";
           var1 = var1 + "ON b.PuntoID = p.PuntoID ";
           var1 = var1 + "JOIN Cuenta c" + "\n";
           var1 = var1 + "ON c.CuentaID = p.CuentaID  ";
           var1 = var1 + "JOIN Rubro r" + "\n";
           var1 = var1 + "ON r.RubroID = p.RubroID ORDER BY c.Nombre";
           

            return Db.GetDataTable(var1);
        }
        public static DataTable VW_GetPuntosNombres()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  distinct(Ruta) as nombre" + "\n";
            var1 = var1 + "       FROM    Biblia";


            return Db.GetDataTable(var1);
        }
        public static DataTable VW_GetPuntosRubros()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  definicion,rubroid" + "\n";
            var1 = var1 + "       FROM    rubro";


            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetPuntosTipos()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  distinct(tipo) as tipo" + "\n";
            var1 = var1 + "       FROM    Biblia";


            return Db.GetDataTable(var1);
        }
        public static DataTable VW_GetCuentas()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  Nombre,CuentaID " + "\n";
            var1 = var1 + "       FROM    Cuenta";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetCuentasTipo()
        {
           
            string var1 = string.Empty;
            var1 = var1 + " SELECT distinct(Biblia.Tipo)as tipo " + "\n";
            var1 = var1 + " FROM   Punto " + "\n";
            var1 = var1 + " JOIN   Biblia " + "\n";
            var1 = var1 + " ON    Biblia.PuntoID = Punto.PuntoID";
            var1 = var1 + " group by Biblia.Tipo";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetCuentasTipoVab()
        {

            string var1 = string.Empty;
            var1 = var1 + " SELECT distinct(Biblia.Tipo)as tipo " + "\n";
            var1 = var1 + " FROM   Punto " + "\n";
            var1 = var1 + " JOIN   Biblia " + "\n";
            var1 = var1 + " ON    Biblia.PuntoID = Punto.PuntoID";
            var1 = var1 + " where    Biblia.tipo in ('vab','vabmtb','vabt','vabtmtb','vabMLTe','vabtMLTe')";
            var1 = var1 + " group by Biblia.Tipo";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetCajas()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  Nombre,CajaID,Tipo " + "\n";
            var1 = var1 + "       FROM    Caja";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetCajaEfectivo()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  EfectivoID " + "\n";
            var1 = var1 + "       FROM    Efectivo";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_GetOficiales()
        {

            string var1 = string.Empty;
            var1 = var1 + "SELECT  nombre,OficialID,CI " + "\n";
            var1 = var1 + "       FROM    Oficial";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_BOBEDA_SolicitudesPorFecha(DateTime desde, DateTime hasta)
        {

            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.fechacreado, " + "\n";
            var1 = var1 + "       solicitudID, " + "\n";
            var1 = var1 + "       consignadorID, " + "\n";
            var1 = var1 + "       consignatarioID, " + "\n";
            var1 = var1 + "       monto, " + "\n";
            var1 = var1 + "       Cuenta.nombre AS nombrecuenta, " + "\n";
            var1 = var1 + "       StatusSolicitud.descripcion AS status, " + "\n";
            var1 = var1 + "       SolicitudTipo.descripcion AS nombresolicitud, " + "\n";
            var1 = var1 + "       consignador.Nombre as consignador," + "\n";
            var1 = var1 + "       consignatario.Nombre as consignatario" + "\n";

            var1 = var1 + "FROM   solicitud " + "\n";
            var1 = var1 + "       JOIN   Punto consignador" + "\n";
            var1 = var1 + "       ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "       JOIN   Punto consignatario" + "\n";
            var1 = var1 + "       ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";
            var1 = var1 + "       JOIN Cuenta " + "\n";
            var1 = var1 + "       ON solicitud.CuentaID = Cuenta.CuentaID  " + "\n";
            var1 = var1 + "       JOIN StatusSolicitud " + "\n";
            var1 = var1 + "       ON solicitud.StatusSolicitudID = StatusSolicitud.StatusSolicitudID " + "\n";
            var1 = var1 + "       JOIN SolicitudTipo " + "\n";
            var1 = var1 + "       ON solicitud.SolicitudTipoID = SolicitudTipo.SolicitudTipoID " + "\n";


            var1 = var1 + "WHERE  solicitud.fechacreado >= '" + string.Format("{0:dd/MM/yyyy}", desde.Date)  + "' \n";
            var1 = var1 + "AND  solicitud.fechacreado <= '" + string.Format("{0:dd/MM/yyyy}", hasta.Date) + "' \n";
            var1 = var1 + "and  not exists(select * from Solicitud_CartaPorte where Solicitud_CartaPorte.SolicitudID = solicitud.SolicitudID)";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_BOBEDA_SolicitudesPorFechaProcesados(DateTime desde, DateTime hasta)
        {

            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.fechacreado, " + "\n";
            var1 = var1 + "       solicitudID, " + "\n";
            var1 = var1 + "       consignadorID, " + "\n";
            var1 = var1 + "       consignatarioID, " + "\n";
            var1 = var1 + "       monto, " + "\n";
            var1 = var1 + "       Cuenta.nombre AS nombrecuenta, " + "\n";
            var1 = var1 + "       StatusSolicitud.descripcion AS status, " + "\n";
            var1 = var1 + "       SolicitudTipo.descripcion AS nombresolicitud, " + "\n";
            var1 = var1 + "       consignador.Nombre as consignador," + "\n";
            var1 = var1 + "       consignatario.Nombre as consignatario" + "\n";

            var1 = var1 + "FROM   solicitud " + "\n";
            var1 = var1 + "       JOIN   Punto consignador" + "\n";
            var1 = var1 + "       ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "       JOIN   Punto consignatario" + "\n";
            var1 = var1 + "       ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";
            var1 = var1 + "       JOIN Cuenta " + "\n";
            var1 = var1 + "       ON solicitud.CuentaID = Cuenta.CuentaID  " + "\n";
            var1 = var1 + "       JOIN StatusSolicitud " + "\n";
            var1 = var1 + "       ON solicitud.StatusSolicitudID = StatusSolicitud.StatusSolicitudID " + "\n";
            var1 = var1 + "       JOIN SolicitudTipo " + "\n";
            var1 = var1 + "       ON solicitud.SolicitudTipoID = SolicitudTipo.SolicitudTipoID " + "\n";


            var1 = var1 + "WHERE  solicitud.fechacreado >= '" + string.Format("{0:dd/MM/yyyy}", desde.Date) + "' \n";
            var1 = var1 + "AND  solicitud.fechacreado <= '" + string.Format("{0:dd/MM/yyyy}", hasta.Date) + "' \n";
            var1 = var1 + "and  exists(select * from Solicitud_CartaPorte where Solicitud_CartaPorte.SolicitudID = solicitud.SolicitudID)";

            return Db.GetDataTable(var1);
        }

       
        public static DataTable VW_BOBEDA_DepositosPendientePorFecha(DateTime fecha)
        {

            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT Deposito.fecha, " + "\n";
            var1 = var1 + "       Deposito.DepositoID, " + "\n";
            var1 = var1 + "       Deposito.Monto, " + "\n";
            var1 = var1 + "       Deposito.logincreado, " + "\n";
            var1 = var1 + "       Concepto.nombre AS concepto" + "\n";
            var1 = var1 + "FROM   Deposito " + "\n";
            var1 = var1 + "       JOIN Concepto " + "\n";
            var1 = var1 + "       ON Concepto.ConceptoID = Deposito.ConceptoID  " + "\n";
            var1 = var1 + "WHERE  Deposito.fecha = '" + string.Format("{0:dd/MM/yyyy}", fecha.Date) + "' " + "\n";
            var1 = var1 + "AND  Deposito.numero IS NULL";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_BOBEDA_DepositosPorFecha(DateTime fecha)
        {

            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT Deposito.fecha, " + "\n";
            var1 = var1 + "       Deposito.DepositoID, " + "\n";
            var1 = var1 + "       Deposito.Monto, " + "\n";
            var1 = var1 + "       Deposito.logincreado, " + "\n";
            var1 = var1 + "       Deposito.numero, " + "\n";
            var1 = var1 + "       Concepto.nombre AS concepto" + "\n";
            var1 = var1 + "FROM   Deposito " + "\n";
            var1 = var1 + "       JOIN Concepto " + "\n";
            var1 = var1 + "       ON Concepto.ConceptoID = Deposito.ConceptoID  " + "\n";

            var1 = var1 + "WHERE  Deposito.fecha = '" + string.Format("{0:dd/MM/yyyy}", fecha.Date) + "' " + "\n";
            var1 = var1 + "AND  Deposito.numero IS NOT NULL";

            return Db.GetDataTable(var1);
        }


        public static DataTable VW_SolicitudesPorDepartamento(int departamento)
        {

            string var1 = string.Empty;
            
                var1 = var1 + "SET dateformat dmy  " + "\n";
                var1 = var1 + "SELECT solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
                var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
                var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

                var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
                var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
                var1 = var1 + "Solicitud_Accion.Observacion," + "\n";
                var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";
                
                var1 = var1 + "FROM   Solicitud" + "\n";
                var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
                var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
                var1 = var1 + "JOIN   Punto consignador" + "\n";
                var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
                var1 = var1 + "JOIN   Punto consignatario" + "\n";
                var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

                var1 = var1 + "WHERE   Solicitud_accion.bovedaID = " + departamento + "\n";
                var1 = var1 + "AND     Solicitud_accion.LoginCerrado = 'PENDIENTE' " + "\n";
                var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";
                var1 = var1 + "AND     Solicitud_Accion.Secuencia = 1 " + "\n";

                var1 = var1 + "order by solicitud_accion.SolicitudID";


          
            return Db.GetDataTable(var1);
        }

        public static DataTable VW_SolicitudesPendientes(int departamento)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

            var1 = var1 + "WHERE   Solicitud_accion.bovedaID = " + departamento + "\n";
            var1 = var1 + "AND     Solicitud_accion.LoginCerrado = 'NOCOMPRO' " + "\n";
            var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";

            var1 = var1 + "AND   Solicitud_Accion.Observacion ='ASIGNAR A UNA RUTA(ENTRADA)'" + "\n";
            var1 = var1 + "OR    Solicitud_Accion.Observacion ='ASIGNAR A UNA RUTA(EXPRESO)'" + "\n";
            var1 = var1 + "order by solicitud_accion.secuencia";



            return Db.GetDataTable(var1);
        }

        public static DataTable VW_SolicitudesPendientesExpreso(int departamento)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

            var1 = var1 + "WHERE   Solicitud_accion.bovedaID = " + departamento + "\n";
            var1 = var1 + "AND     Solicitud_accion.LoginCerrado = '' " + "\n";
            var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";

            
            var1 = var1 + "AND    Solicitud_Accion.Observacion ='ASIGNAR A UNA RUTA(EXPRESO)'" + "\n";

            var1 = var1 + "order by solicitud_accion.secuencia";



            return Db.GetDataTable(var1);
        }
        public static DataTable VW_SolicitudesPendientesPorTraspasar(int departamento)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT top 1 solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion as Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

            var1 = var1 + "WHERE EXISTS(" + "\n";



            var1 = var1 + "SELECT top 1 solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion as Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";


            
            var1 = var1 + "where Solicitud_accion.bovedaID = " + departamento + "\n";
            var1 = var1 + "AND     Solicitud_accion.LoginCerrado = 'NOCOMPRO' " + "\n";
            var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";
            var1 = var1 + "AND   Solicitud_Accion.Observacion ='RECIBIR CARTAPORTE(ENTRADA)'" + "\n";
            var1 = var1 + "AND Solicitud_Accion.Secuencia in (4)" + "\n";
            var1 = var1 + "order by solicitud_accion.secuencia)";



            return Db.GetDataTable(var1);
        }


        public static DataTable VW_SolicitudesViewObservacion(int departamento)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion as Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

            var1 = var1 + "WHERE   Solicitud_accion.bovedaID = " + departamento + "\n";
            var1 = var1 + "AND     Solicitud_accion.LoginCerrado = '' " + "\n";
            var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";

            var1 = var1 + "AND   Solicitud_Accion.Observacion ='TRASPASAR A ACOPIO(ENTRADA)'" + "\n";
            var1 = var1 + "OR   Solicitud_Accion.Observacion ='CUSTODIAR CARTA DE PORTE(EXPRESO)'" + "\n";

            var1 = var1 + "order by solicitud_accion.secuencia";



            return Db.GetDataTable(var1);
        }

        public static DataTable VW_SolicitudesPendientesPorDeposito(int departamento)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.SolicitudID , solicitud.Monto, consignador.Nombre as Consignador," + "\n";
            var1 = var1 + "consignatario.Nombre as Consignatario," + "\n";
            var1 = var1 + "Solicitud_Accion.Secuencia," + "\n";

            var1 = var1 + "Solicitud_Accion.LoginCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.FechaCerrado," + "\n";
            var1 = var1 + "Solicitud_Accion.Observacion," + "\n";
            var1 = var1 + "Solicitud_Accion.BovedaID" + "\n";

            var1 = var1 + "FROM   Solicitud" + "\n";
            var1 = var1 + "JOIN   Solicitud_Accion" + "\n";
            var1 = var1 + "ON	   Solicitud_Accion.SolicituDId = Solicitud.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";

            var1 = var1 + "WHERE   Solicitud_accion.bovedaID = " + departamento + "\n";
            var1 = var1 + "AND     Solicitud_accion.LoginCerrado = 'NOCOMPRO' " + "\n";
            var1 = var1 + "AND     Solicitud_Accion.SolicitudID = Solicitud.SolicitudID " + "\n";
            var1 = var1 + "AND   Solicitud_Accion.Observacion ='DEPOSITAR EN CUENTA CLIENTE(ENTRADA)'" + "\n";

            var1 = var1 + "order by solicitud_accion.secuencia";



            return Db.GetDataTable(var1);
        }

        public static DataTable VW_EnvasesSolicitud(int solicitudid)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + " SELECT consignador.nombre as consignador,consignatario.nombre as consignatario," + "\n";
            var1 = var1 + "Count(Solicitud_Envase.EnvaseID)as envases," + "\n";
            var1 = var1 + "sum(Solicitud_Envase_Efectivo.piezas) piezas," + "\n";
            var1 = var1 + "sum(Solicitud_Envase_Efectivo.Monto) monto," + "\n";
            var1 = var1 + "Efectivo.Denominacion" + "\n";
            var1 = var1 + "from Solicitud_Envase_Efectivo" + "\n";
            var1 = var1 + "JOIN   Efectivo " + "\n";
            var1 = var1 + "ON     Solicitud_Envase_Efectivo.EfectivoID = Efectivo.EfectivoID " + "\n";
            var1 = var1 + "JOIN   Solicitud_Envase" + "\n";
            var1 = var1 + "ON     Solicitud_Envase.EnvaseID = Solicitud_Envase_Efectivo.EnvaseID" + "\n";
            var1 = var1 + "JOIN   Solicitud" + "\n";
            var1 = var1 + "ON     Solicitud.SolicitudID = Solicitud_Envase.SolicitudID" + "\n";
            var1 = var1 + "JOIN   Punto consignador" + "\n";
            var1 = var1 + "ON     consignador.PuntoID = Solicitud.ConsignadorID" + "\n";
            var1 = var1 + "JOIN   Punto consignatario" + "\n";
            var1 = var1 + "ON     consignatario.PuntoID = Solicitud.ConsignatarioID" + "\n";
            var1 = var1 + "WHERE  Solicitud.SolicitudID =  " + solicitudid + " " + "\n";
            var1 = var1 + "GROUP BY Efectivo.Denominacion," + "\n";
            var1 = var1 + "consignador.nombre," + "\n";
            var1 = var1 + "consignatario.nombre ";
            


            return Db.GetDataTable(var1);
        }

        public static DataTable VW_EnvasesCartaporte(string cartaporte)
        {

            string var1 = string.Empty;

            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + " SELECT envase.Envaseid, envase.nroplomo" + "\n";
           
            var1 = var1 + "from envase" + "\n";

            var1 = var1 + "WHERE  envase.cartaporteid =  '" + cartaporte + "'";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_EnvasesCartaporte(int cartaporteid)
        {

            string var1 = string.Empty;


            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT	   Count(Envase.EnvaseID)as envases," + "\n";
            var1 = var1 + "sum(Envase_Efectivo.piezas) piezas," + "\n";
            var1 = var1 + "sum(Envase_Efectivo.Monto) monto," + "\n";
            var1 = var1 + "Efectivo.Denominacion" + "\n";
            var1 = var1 + "FROM   Envase_Efectivo" + "\n";
            var1 = var1 + "JOIN   Efectivo " + "\n";
            var1 = var1 + "ON     Envase_Efectivo.EfectivoID = Efectivo.EfectivoID " + "\n";
            var1 = var1 + "JOIN   Envase" + "\n";
            var1 = var1 + "ON     Envase.EnvaseID = Envase_Efectivo.EnvaseID" + "\n";
            var1 = var1 + "JOIN   Cartaporte" + "\n";
            var1 = var1 + "ON     Cartaporte.CartaporteID = Envase.CartaporteID" + "\n";
            var1 = var1 + "WHERE  Cartaporte.CartaporteID =  '" + cartaporteid + "'" + "\n";
            var1 = var1 + "GROUP BY Efectivo.Denominacion ";



            return Db.GetDataTable(var1);
        }
        public static DataTable VW_BOBEDA_SolicitudUltimosTreintaDias()
        {
            string var1 = string.Empty;
            var1 = var1 + "SET dateformat dmy  " + "\n";
            var1 = var1 + "SELECT solicitud.fechacreado, " + "\n";
            var1 = var1 + "       solicitudID, " + "\n";
            var1 = var1 + "       monto, " + "\n";
            var1 = var1 + "       Cliente.nombre AS nombrecuenta, " + "\n";
            var1 = var1 + "       StatusSolicitud.descripcion AS status " + "\n";
            var1 = var1 + "FROM   solicitud " + "\n";
            var1 = var1 + "       JOIN Cuenta " + "\n";
            var1 = var1 + "       ON solicitud.cuentaID = Cuenta.CuentaID " + "\n";
            var1 = var1 + "       JOIN StatusSolicitud " + "\n";
            var1 = var1 + "       ON solicitud.StatusSolicitudID = StatusSolicitud.StatusSolicitudID " + "\n";

            var1 = var1 + "WHERE  solicitud.fechacreado >= ( Getdate() - 30 ) ";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_Denominaciones()
        {
            string var1 = string.Empty;
            var1 = var1 + "SELECT Denominacion, " + "\n";
            var1 = var1 + "       efectivoID" + "\n";
            var1 = var1 + "FROM   efectivo  ";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_DenominacionesActuales()
        {
            string var1 = string.Empty;
            var1 = var1 + "SELECT Denominacion, " + "\n";
            var1 = var1 + "       efectivoID" + "\n";
            var1 = var1 + "FROM   efectivo WHERE efectivotipoid in(2,4) ";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_DenominacionesAnteriores()
        {
            string var1 = string.Empty;
            var1 = var1 + "SELECT Denominacion, " + "\n";
            var1 = var1 + "       efectivoID" + "\n";
            var1 = var1 + "FROM   efectivo WHERE efectivotipoid in(1,3) ";

            return Db.GetDataTable(var1);
        }

        public static DataTable VW_Bovedas()
        {
            string var1 = string.Empty;
            var1 = var1 + "SELECT Nombre, " + "\n";
            var1 = var1 + "       BovedaID" + "\n";
            var1 = var1 + "FROM   Boveda ";

            return Db.GetDataTable(var1);
        }

        public static DataTable GetVistaDepartamento(int departamentoid)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter prn = new SqlParameter("@DepartamentoID", SqlDbType.Int);
            prn.Value = departamentoid;
            parameters.Add(prn);

            return Db.GetDataTable(parameters, "Departamento_GET");
        }


        
    }
}
