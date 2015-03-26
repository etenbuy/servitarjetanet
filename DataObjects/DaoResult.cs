using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class DaoResult
    {
        public int ErrorCount { get; set; }

        public string ErrorMessage { get; set; }

        public int Identity { get; set; }

        public string ExtraValue { get; set; }

    }
}
