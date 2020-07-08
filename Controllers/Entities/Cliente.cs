using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WebAPIAgendaTOP.Helpers;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class Cliente : IValidatableObject
    {
        [DataMember] public int id { get; set; }
        [Required]
        //[PrimeraLetraMayAttribute]
        [DataMember] public string nombre { get; set; }
        [DataMember] public string direccion { get; set; }
        [DataMember] public string poblacion { get; set; }
        [DataMember] public string provincia { get; set; }
        [DataMember] public string telefono1 { get; set; }
        [DataMember] public string telefono2 { get; set; }
        [DataMember] public string email { get; set; }
        //[DataMember] public List<Tarea> Tareas { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                var primeraletra = nombre[0].ToString();

                if (primeraletra != primeraletra.ToUpper())
                {
                    yield return new ValidationResult("El nombre debe empezar con mayúscula", new string[] {nameof(nombre) });
                }
            }
            //throw new NotImplementedException();
        }
    }
}
