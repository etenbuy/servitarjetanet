using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class TarjetaController 
    {
        
      

        public IList<Tarjeta> Get_Tarjetas(int ClienteID)
        {
            return TarjetaDao.Tarjetas_GET(ClienteID);

        }


    }
}
