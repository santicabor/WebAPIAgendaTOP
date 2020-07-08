using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Helpers
{
    public class MiFiltroDeExcepcion: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) //después de la acción
        {
            _ = context.Exception;
        }
    }
}
