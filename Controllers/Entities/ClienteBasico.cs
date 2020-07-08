using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class ClienteBasico
    {
        //[Required]
        //[DataMember] public int id { get; set; }
        [Key]
        [DataMember] public string nombre { get; set; }

    }
}