using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class TipoController 
    {
        
      

        public IList<Tipo> Get_Tipos()
        {
            return TiposDao.Tipos_GET();

        }


    }
}
