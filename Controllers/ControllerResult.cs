using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controllers
{
    public  enum Result
    {
        Successful,
        Error
    }

    public class ControllerResult
    {
        public Result Resultado { get; set; }

        public string Mensaje { get; set; }

        public string Login { get; set; }

        public string MensajeExtra { get; set; }       

        public ControllerResult(string login)
        {
            this.Login = login;
        }

    }

}
