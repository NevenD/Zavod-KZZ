using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.OfficialDocumentsZaraExtension
{
    public class OfficialDocumentZaraHelper
    {
        public static string GetOfficialDocumentStatusClass(int id)
        {
            string className;
            switch (id)
            {
                case (int)Enums.Enums.ZaraDocumentStatus.IN_PROGRESS:
                    className = "spatial-status-inprogress";
                    break;
                case (int)Enums.Enums.ZaraDocumentStatus.INVALID:
                    className = "spatial-status-invalid";
                    break;
                case (int)Enums.Enums.ZaraDocumentStatus.VALID:
                    className = "spatial-status-valid";
                    break;
                default:
                    className = string.Empty;
                    break;
            }

            return className;
        }

        public static string GetOfficialDocumentStatusStyle(int id)
        {
            string className;
            switch (id)
            {
                case (int)Enums.Enums.ZaraDocumentStatus.IN_PROGRESS:
                    className = "border-left: 7px solid #03a9f4;";
                    break;
                case (int)Enums.Enums.ZaraDocumentStatus.INVALID:
                    className = "border-left: 7px solid #dd3333";
                    break;
                case (int)Enums.Enums.ZaraDocumentStatus.VALID:
                    className = "border-left: 7px solid #29c272";
                    break;
                default:
                    className = string.Empty;
                    break;
            }

            return className;
        }
    }
}
