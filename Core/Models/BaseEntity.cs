using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class BaseEntity
    {
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
