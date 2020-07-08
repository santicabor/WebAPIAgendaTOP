using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Helpers
{
    public class MiFiltroDeAccion : IActionFilter
    {
        private readonly ILogger<MiFiltroDeAccion> logger;
        public MiFiltroDeAccion(ILogger<MiFiltroDeAccion> logger) //Inyección de dependencias
        {
            this.logger = logger;    
        }
        public void OnActionExecuted(ActionExecutedContext context) //después de la acción
        {
            //throw new NotImplementedException(); Implementación por defecto
            logger.LogError("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context) //Se ejecuta antes de la acción
        {
            //throw new NotImplementedException();
            logger.LogError("OnActionExecuting");
        }
    }
}
