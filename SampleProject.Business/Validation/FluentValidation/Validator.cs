using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SampleProject.Business.Validation.FluentValidation
{
    public class Validator
    {
        public static void Validate(IValidator validator, object validateObject)
        {
            var result = validator.Validate(validateObject);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
