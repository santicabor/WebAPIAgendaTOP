using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIAgendaTOP.Controllers.Entities
{
    [DataContract]
    public class UserToken
    {
        [DataMember] public string token { get; set; }

    }
}
