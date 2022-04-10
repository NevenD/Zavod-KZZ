using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Services.Azure.Interfaces
{
    public interface IBlobService
    {
        Task<IEnumerable<BlobInfoCustom>> GetAllBlobs();
        Task<string> GetBlobGeoJSON(string name);
        Task<IEnumerable<BlobInfoCustom>> GetBlobDocumentsByMetadataId(string id, string containerName);
        Task UploadBlobFile(IFormFile file, BlobMetadata blobMetadata, string containerName);
        Task DeleteContentBlob(string containerName, string blobName);
        Task DeleteBlobById(string containerName, string id);
    }
}
