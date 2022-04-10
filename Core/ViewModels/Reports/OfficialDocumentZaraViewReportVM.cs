using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels.Reports
{
    public class OfficialDocumentZaraViewReportVM
    {
        public IEnumerable<int> Years { get; set; }
        public IEnumerable<DocumentStatusZara> DocumentStatusZara { get; set; }
    }
}
