using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class User
    {
        [DataMember] public int id { get; set; }
        [Required]
        [DataMember] public string usuario { get; set; }
        [Required]
        [DataMember] public string clave { get; set; }
    }
}
