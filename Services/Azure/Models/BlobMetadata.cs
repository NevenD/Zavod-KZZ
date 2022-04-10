using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Services.Azure.Models
{
    public class BlobMetadata
    {
        public string ForeignKeyId { get; set; }

        public string Name { get; set; }
        public string UniqueName { get; set; }
    }
}
