﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Helpers
{
    public class PrimeraLetraMayAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return ValidationResult.Success;
                }

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("Letra inicial debe ser mayúscula");
            }

            return base.IsValid(value, validationContext);
        }
    }
}
