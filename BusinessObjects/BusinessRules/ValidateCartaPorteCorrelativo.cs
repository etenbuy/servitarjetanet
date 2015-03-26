using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BusinessObjects.BusinessRules
{
    

    /// <summary>
    /// Identity validation rule. 
    /// Value must be integer and greater than zero.
    /// </summary>
    /// 
    public class ValidateCartaPorteCorrelativo : BusinessRule
    {
        private static readonly int Correlativo = int.Parse(ConfigurationManager.AppSettings["CartaporteCorrelativo"]);

        public ValidateCartaPorteCorrelativo(string propertyName)
            : base(propertyName)
        {


            ErrorMessage = propertyName + " o numero de carta de porte debe ser mayor a: " + Correlativo.ToString();
        }

        public ValidateCartaPorteCorrelativo(string propertyName, string errorMessage)
            : base(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                int id = int.Parse(GetPropertyValue(businessObject).ToString());
                return id > Correlativo;
            }
            catch
            {
                return false;
            }
        }
    }
}
