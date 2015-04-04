using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections;


namespace Controllers
{
    public class StatusController 
    {
        
      

        public IList<Status> Get_Status()
        {
            return StatusDao.Status_GET();

        }


    }
}
