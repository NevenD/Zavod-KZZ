using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class OfficialZaraDocumentsVM
    {
        public OfficialDocumentZara OfficialDocumentZara { get; set; }

        public IEnumerable<OfficialDocumentZara> OfficialDocumentsZara { get; set; }
        public IEnumerable<DocumentStatusZara> DocumentStatusesZara { get; set; }
        public IEnumerable<DocumentTypeZara> DocumentTypesZara { get; set; }
        public IEnumerable<OfficalSpatialNews> OfficalSpatialNews { get; set; }

        public IEnumerable<BlobInfoCustom> RequiredAzureDocuments { get; set; }
        public IEnumerable<BlobInfoCustom> AdditionalAzureDocuments { get; set; }


        public List<IFormFile> RequiredDocuments { get; set; }
        public List<IFormFile> AdditionalDocuments { get; set; }

    }
}
