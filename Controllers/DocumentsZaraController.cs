using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.Extensions;
using ZAVOD_KZZ.Services.Azure.Helpers;
using ZAVOD_KZZ.Services.Azure.Interfaces;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class DocumentsZaraController : Controller
    {

        #region DI repositories
        private readonly IOfficialDocumentZaraRepository _officialDocumentZaraRepository;
        private readonly IOfficialSpatialNewsNumberRepository _officialSpatialNewsNumberRepository;
        private readonly IDocumentStatusZaraRepository _documentStatusZaraRepository;
        private readonly IDocumentTypeZaraRepository _documentTypeZaraRepository;

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IBlobService _blobService;

        public DocumentsZaraController(
            IOfficialDocumentZaraRepository officialDocumentZaraRepository,
            IOfficialSpatialNewsNumberRepository officialSpatialNewsNumberRepository,
            IDocumentTypeZaraRepository documentTypeZaraRepository,
            IDocumentStatusZaraRepository documentStatusZaraRepository,
            IBlobService blobService,
            IHostingEnvironment hostingEnvironment
            )
        {
            _officialDocumentZaraRepository = officialDocumentZaraRepository;
            _officialSpatialNewsNumberRepository = officialSpatialNewsNumberRepository;
            _documentStatusZaraRepository = documentStatusZaraRepository;
            _documentTypeZaraRepository = documentTypeZaraRepository;
            _hostingEnvironment = hostingEnvironment;
            _blobService = blobService;
        }
        #endregion

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> OfficialDocuments()
        {

            var vmModel = new OfficialZaraDocumentsVM()
            {
                OfficialDocumentsZara = await _officialDocumentZaraRepository.GetAllOfficialZaraDocuments(),
            };
            return View(vmModel);
        }

        public async Task<IActionResult> Create()
        {
            var documentsVM = new OfficialZaraDocumentsVM();
            documentsVM.DocumentStatusesZara = await _documentStatusZaraRepository.GetAll();
            documentsVM.DocumentTypesZara = await _documentTypeZaraRepository.GetAll();
            documentsVM.OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll();

            return View(documentsVM);
        }

        [HttpPost, ActionName(nameof(Create))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOfficialZaraDocument(OfficialZaraDocumentsVM vmModel)
        {

            if (ModelState.IsValid && vmModel.RequiredDocuments != null)
            {
                await _officialDocumentZaraRepository.Create(vmModel.OfficialDocumentZara);
                foreach (var document in vmModel.RequiredDocuments)
                {
                    var blobMetadata = new BlobMetadata
                    {
                        ForeignKeyId = vmModel.OfficialDocumentZara.Id.ToString(),
                        Name = vmModel.OfficialDocumentZara.Name,
                        UniqueName = vmModel.OfficialDocumentZara.UniqueName

                    };

                    await _blobService.UploadBlobFile(document, blobMetadata, AzureStorageHelpers.BlobContainers.RequiredDocuments);
                }


                if (vmModel.AdditionalDocuments != null)
                {
                    foreach (var document in vmModel.AdditionalDocuments)
                    {
                        var blobMetadata = new BlobMetadata
                        {
                            ForeignKeyId = vmModel.OfficialDocumentZara.Id.ToString(),
                            Name = vmModel.OfficialDocumentZara.Name,
                            UniqueName = vmModel.OfficialDocumentZara.UniqueName
                        };

                        await _blobService.UploadBlobFile(document, blobMetadata, AzureStorageHelpers.BlobContainers.AdditionalDocuments);
                    }
                }

                return RedirectToAction(nameof(OfficialDocuments), "DocumentsZara");
            }
            vmModel.DocumentStatusesZara = await _documentStatusZaraRepository.GetAll();
            vmModel.DocumentTypesZara = await _documentTypeZaraRepository.GetAll();
            vmModel.OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll();

            return View(vmModel);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var officialDocument = await _officialDocumentZaraRepository.FindById((int)id);
            if (officialDocument != null)
            {

                var documentsVM = new OfficialZaraDocumentsVM();
                documentsVM.OfficialDocumentZara = officialDocument;
                documentsVM.DocumentStatusesZara = await _documentStatusZaraRepository.GetAll();
                documentsVM.DocumentTypesZara = await _documentTypeZaraRepository.GetAll();
                documentsVM.OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll();
                documentsVM.RequiredAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(id.ToString(), AzureStorageHelpers.BlobContainers.RequiredDocuments);
                documentsVM.AdditionalAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(id.ToString(), AzureStorageHelpers.BlobContainers.AdditionalDocuments);
                return View(documentsVM);
            }
            else
            {
                return NotFound();

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfficialZaraDocumentsVM vmModel)
        {

            if (ModelState.IsValid)
            {
                await _officialDocumentZaraRepository.Update(vmModel.OfficialDocumentZara);

                if (vmModel.RequiredDocuments != null)
                {
                    foreach (var document in vmModel.RequiredDocuments)
                    {
                        var blobMetadata = new BlobMetadata
                        {
                            ForeignKeyId = vmModel.OfficialDocumentZara.Id.ToString(),
                            Name = vmModel.OfficialDocumentZara.Name,
                            UniqueName = vmModel.OfficialDocumentZara.UniqueName

                        };

                        await _blobService.UploadBlobFile(document, blobMetadata, AzureStorageHelpers.BlobContainers.RequiredDocuments);
                    }
                }

             
                if (vmModel.AdditionalDocuments != null)
                {
                    foreach (var document in vmModel.AdditionalDocuments)
                    {

                        var blobMetadata = new BlobMetadata
                        {
                            ForeignKeyId = vmModel.OfficialDocumentZara.Id.ToString(),
                            Name = vmModel.OfficialDocumentZara.Name,
                            UniqueName = vmModel.OfficialDocumentZara.UniqueName
                        };

                        await _blobService.UploadBlobFile(document, blobMetadata, AzureStorageHelpers.BlobContainers.AdditionalDocuments);
                    }
                }

                return RedirectToAction(nameof(OfficialDocuments), "DocumentsZara");

            }
            vmModel.DocumentStatusesZara = await _documentStatusZaraRepository.GetAll();
            vmModel.DocumentTypesZara = await _documentTypeZaraRepository.GetAll();
            vmModel.OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll();
            vmModel.OfficialDocumentZara = vmModel.OfficialDocumentZara;
            vmModel.RequiredAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(vmModel.OfficialDocumentZara.Id.ToString(), AzureStorageHelpers.BlobContainers.RequiredDocuments);
            vmModel.AdditionalAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(vmModel.OfficialDocumentZara.Id.ToString(), AzureStorageHelpers.BlobContainers.AdditionalDocuments);

            return View(vmModel);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var officialDocument = new OfficialZaraDocumentsVM();
            officialDocument.OfficialDocumentZara = await _officialDocumentZaraRepository.FindOfficialDocumentZaraById(id);

            officialDocument.RequiredAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(id.ToString(), AzureStorageHelpers.BlobContainers.RequiredDocuments);
            officialDocument.AdditionalAzureDocuments = await _blobService.GetBlobDocumentsByMetadataId(id.ToString(), AzureStorageHelpers.BlobContainers.AdditionalDocuments);

            return PartialView("_OfficialDocumentDetails", officialDocument);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteAll(int id)
        {

            var zaraDoc = await _officialDocumentZaraRepository.FindOfficialDocumentZaraById(id);
            if (zaraDoc == null)
            {
                return NotFound();
            }

            await _officialDocumentZaraRepository.Delete(zaraDoc.Id);
            return View(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequiredDocument(int documentId, string documentName)
        {
            await _blobService.DeleteContentBlob(AzureStorageHelpers.BlobContainers.RequiredDocuments, documentName);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdditionalDocument(int documentId, string documentName)
        {
            await _blobService.DeleteContentBlob(AzureStorageHelpers.BlobContainers.AdditionalDocuments, documentName);
            return Ok();
        }
    }
}