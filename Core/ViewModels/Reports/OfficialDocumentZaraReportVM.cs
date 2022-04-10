using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Core.ViewModels.Reports
{
    public class OfficialDocumentZaraReportVM
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentStatus { get; set; }
        public string OfficialNews { get; set; }
        public string OfficialNewsNumber { get; set; }
        public string OfficialNewsUrl { get; set; }
        public string DateEffective { get; set; }
        public string DateIneffective { get; set; }
        public string DocumentRemark { get; set; }

        public IEnumerable<BlobInfoCustom> RequiredDocumentsZara { get; set; }

        public IEnumerable<BlobInfoCustom> AdditionalDocumentsZara { get; set; }

    }
}
