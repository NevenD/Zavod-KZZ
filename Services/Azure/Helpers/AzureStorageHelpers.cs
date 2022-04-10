using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Services.Azure.Helpers
{
    public class AzureStorageHelpers
    {
        public static class BlobContainers
        {
            public static string GIS => "gis";
            public static string RequiredDocuments => "obavezniakti";
            public static string AdditionalDocuments => "dodatniakti";


        }

        public static class StorageFileName
        {
            public static string CultureFileJSON => "culture.json";
            public static string RailJSON => "zeljeznica.json";
            public static string RoadJSON => "razvrstane_ceste.json";
            public static string RoadPlannedJSON => "planirane_ceste.json";

        }


        public static class MetadataValues
        {
            public static string Id => "Id";
            public static string ForeignKeyId => "ForeignKeyId";
            public static string Name => "Name";
            public static string UniqueName => "UniqueName";

        }


        public static IEnumerable<BlobInfoCustom> GenerateBlobCustomItemForClientSide(IEnumerable<BlobItem> blobItems)
        {

            var blobInfoCustom = new List<BlobInfoCustom>();

            return blobInfoCustom;
        }
    }
}
