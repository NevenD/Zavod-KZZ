using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.Extensions
{
    public class UploadFilesHelper
    {
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return Math.Round(((bytes / 1024f) / 1024f),2);
        }
    }
}
