using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class ClienteSinTareas
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
    }
}
