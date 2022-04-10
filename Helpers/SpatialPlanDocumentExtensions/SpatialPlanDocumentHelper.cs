using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.SpatialPlanDocumentExtensions
{
    public class SpatialPlanDocumentHelper
    {
        public static string GetPlanStatusClassStyle(string nameStatus)
        {
            string className;
            switch (nameStatus)
            {
                case "U izradi":
                    className = "spatial-status-inprogress";
                    break;
                case "Van snage":
                    className = "spatial-status-invalid";
                    break;
                case "Na snazi":
                    className = "spatial-status-valid";
                    break;
                default:
                    className = string.Empty;
                    break;
            }

            return className;
        }
    }
}
