using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAVOD_KZZ.Services.Azure.Helpers;
using ZAVOD_KZZ.Services.Azure.Interfaces;
using ZAVOD_KZZ.Services.Azure.Models;
using static ZAVOD_KZZ.Services.Azure.Helpers.AzureStorageHelpers;

namespace ZAVOD_KZZ.Services.Azure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient, IHostingEnvironment hostingEnvironment)
        {
            _blobServiceClient = blobServiceClient;
        }
       

        public async Task<string> GetBlobGeoJSON(string name)
        {
            var jsonValue = string.Empty;
            var containerClient = _blobServiceClient.GetBlobContainerClient(BlobContainers.GIS);
            var properties = await containerClient.GetPropertiesAsync();
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadAsync();

            using (var reader = new StreamReader(blobDownloadInfo.Value.Content))
            {
                jsonValue = reader.ReadToEnd();
            }
          
         
            return jsonValue;
        }


        public async Task<IEnumerable<BlobInfoCustom>> GetBlobDocumentsByMetadataId(string id, string containerName)
        {
            var blobInfoCustomList = new List<BlobInfoCustom>();

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobs = containerClient.GetBlobsAsync(BlobTraits.Metadata);
            var enumerator = blobs.GetAsyncEnumerator();

            while (await enumerator.MoveNextAsync())
            {
                var blobItem = enumerator.Current;
                var metaIdValue = enumerator.Current.Metadata.FirstOrDefault(x => x.Value == id).Value;

                if (metaIdValue != null)
                {
                    var blobClient = containerClient.GetBlobClient(blobItem.Name);

                    var blobInfoCustom = new BlobInfoCustom();

                    blobInfoCustom.Name = blobItem.Name;
                    blobInfoCustom.DocumentId = int.Parse(enumerator.Current.Metadata.First().Value);
                    blobInfoCustom.DocumentType = blobItem.Properties.ContentType;
                    blobInfoCustom.DocumentUrl = blobClient.Uri.AbsoluteUri;
                    blobInfoCustomList.Add(blobInfoCustom);
                }

            }

            await enumerator.DisposeAsync();

            return blobInfoCustomList;
        }

        public async Task UploadBlobFile(IFormFile file, BlobMetadata metadata,  string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            BlobHttpHeaders headers = new BlobHttpHeaders
            {
                ContentType = "application/pdf",
                ContentLanguage = "hr-HR",
                ContentEncoding = "UTF-8"
            };

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    stream.Position = 0;

                    var encodedName = Convert.ToBase64String(Encoding.UTF8.GetBytes(metadata.Name));
                    var metadataProperties = new Dictionary<string, string>
                    {
                        { MetadataValues.ForeignKeyId, metadata.ForeignKeyId },
                        { MetadataValues.Name,  encodedName },
                        { MetadataValues.UniqueName, metadata.UniqueName }
                    };

                    var blobClient = containerClient.GetBlobClient(file.FileName);
                    await blobClient.UploadAsync(stream, headers, metadataProperties);
                }
            }

        }

        public async Task DeleteContentBlob(string containerName, string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task DeleteBlobById(string containerName, string id)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobs = containerClient.GetBlobsAsync(BlobTraits.Metadata);
            var enumerator = blobs.GetAsyncEnumerator();

            while (await enumerator.MoveNextAsync())
            {
                var blobItem = enumerator.Current;
                var metaIdValue = enumerator.Current.Metadata.FirstOrDefault(x => x.Value == id).Value;

                if (metaIdValue != null)
                {
                    var blobClient = containerClient.GetBlobClient(blobItem.Name);
                    await blobClient.DeleteIfExistsAsync();
                }
            }
        }

        public async Task<IEnumerable<BlobInfoCustom>> GetAllBlobs()
        {
            var allList = new List<BlobInfoCustom>();

            var containerClientRequired = _blobServiceClient.GetBlobContainerClient(BlobContainers.RequiredDocuments);
            var blobsRequired = containerClientRequired.GetBlobsAsync(BlobTraits.Metadata);
            var enumeratorRequired = blobsRequired.GetAsyncEnumerator();

            var containerClientAdditional = _blobServiceClient.GetBlobContainerClient(BlobContainers.AdditionalDocuments);
            var blobsAdditional = containerClientAdditional.GetBlobsAsync(BlobTraits.Metadata);
            var enumeratorAdditional = blobsAdditional.GetAsyncEnumerator();

            while (await enumeratorRequired.MoveNextAsync())
            {
                var blobItem = enumeratorRequired.Current;

                var blobClient = containerClientRequired.GetBlobClient(blobItem.Name);

                var blobInfoCustom = new BlobInfoCustom();

                blobInfoCustom.Name = blobItem.Name;
                blobInfoCustom.DocumentId = int.Parse(enumeratorRequired.Current.Metadata.First().Value);
                blobInfoCustom.DocumentType = blobItem.Properties.ContentType;
                blobInfoCustom.DocumentUrl = blobClient.Uri.AbsoluteUri;
                blobInfoCustom.ContainerName = "Obavezni dokument";
                allList.Add(blobInfoCustom);
            }


            while (await enumeratorAdditional.MoveNextAsync())
            {
                var blobItem = enumeratorAdditional.Current;
                var blobClient = containerClientAdditional.GetBlobClient(blobItem.Name);
                var blobInfoCustom = new BlobInfoCustom();

                blobInfoCustom.Name = blobItem.Name;
                blobInfoCustom.DocumentId = int.Parse(enumeratorAdditional.Current.Metadata.First().Value);
                blobInfoCustom.DocumentType = blobItem.Properties.ContentType;
                blobInfoCustom.DocumentUrl = blobClient.Uri.AbsoluteUri;
                blobInfoCustom.ContainerName = "Dodatni dokument";
                allList.Add(blobInfoCustom);
            }


            return allList;
        }
    }
}
