using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract(IsReference = true)]
    public class Tarea
    {
        [DataMember] public int id { get; set; }
        [Required]
        //[DataType(DataType.DateTime)]
        //[JsonConverter(typeof(DateTimeConverter))]
        //[FormatoFecha]
        [DataMember] public DateTime fecha { get; set; }
        //[Required]
        [DataMember] public string descripcion{ get; set; }       
        [DataMember] public double importe { get; set; }
        [DataMember] public string estado { get; set; }
        [DataMember] public Nullable<int> ClienteID { get; set; }
        [DataMember] public string tipo { get; set; }
        [DataMember] public string cliente { get; set; }        

        //[DataMember] public Cliente cliente { get; set; }
    }
}
