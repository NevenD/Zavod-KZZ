using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Services.Azure.Models
{
    public class BlobInfoCustom
    {

        public string Name { get; set; }

        public int DocumentId { get; set; }

        public DateTime DateUploaded { get; set; }

        public string DocumentType { get; set; }

        public string DocumentUrl { get; set; }

        public string ContainerName { get; set; }
        public string DocumentTypeExtension => DocumentType.Substring(DocumentType.Length - 3);

        public string NameWithoutExtension => Name.Substring(Name.Length - 3);

    }
}
