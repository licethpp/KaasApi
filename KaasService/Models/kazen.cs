﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KaasService.Models
{
    [DataContract(Name = "kaas", Namespace = "")]
    public class kazen
    {
        [DataMember(Name = "id", Order = 1)]
        public int id { get; set; }

        [DataMember(Name = "naam", Order = 2)]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string naam { get; set; }
        [DataMember(Name = "soort", Order = 3)]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string soort { get; set; }


        [DataMember(Name = "smaak", Order = 4)]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string smaak { get; set; }
    }
}
//    { naam: "Costeño", soort:"Duro",smaak:"Salado"}
//}

