using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataObjects.AdoNet;
using BusinessObjects;

namespace DataObjects
{
    public static class ConfiguracionDao
    {
        public static DaoResult ActualizarDatosUsuario(object providerUserKey, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier);
            prn.Value = new Guid(providerUserKey.ToString());
            parameters.Add(prn);

            prn = new SqlParameter("@PrimerNombre", SqlDbType.VarChar, 20);
            prn.Value = primerNombre;
            parameters.Add(prn);

            prn = new SqlParameter("@PrimerApellido", SqlDbType.VarChar, 20);
            prn.Value = primerApellido;
            parameters.Add(prn);


            prn = new SqlParameter("@SegundoNombre", SqlDbType.VarChar, 20);
            prn.Value = segundoNombre;
            parameters.Add(prn);

            prn = new SqlParameter("@SegundoApellido", SqlDbType.VarChar, 20);
            prn.Value = segundoApellido;
            parameters.Add(prn);


            return Db.Insert(parameters, "Configuracion_ActualizarDatosUsuario", false, false);



        }

        public static DataRow GetDatosUsuario(object providerUserKey)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter prn = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier);
            prn.Value = new Guid(providerUserKey.ToString());
            parameters.Add(prn);
                        
            return Db.GetDataRow(parameters, "Configuracion_GetDatosUsuario");



        }
    }


}
