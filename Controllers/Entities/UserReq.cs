using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class UserReq
    {        
        [Required]
        [DataMember] public string usuario { get; set; }
        [Required]
        [DataMember] public string clave { get; set; }
    }
}
