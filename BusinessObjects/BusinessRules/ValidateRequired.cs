using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.BusinessRules
{
    /// <summary>
    /// Represents a validation rules that states that a value is required.
    /// </summary>
    public class ValidateRequired : BusinessRule
    {

        public ValidateRequired(string propertyName)
            : base(propertyName)
        {
            ErrorMessage = propertyName + " es un campo requerido.";
        }

        public ValidateRequired(string propertyName, string errorMessage)
            : base(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                return GetPropertyValue(businessObject).ToString().Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
