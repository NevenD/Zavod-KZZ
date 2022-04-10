using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Extensions;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialPlanAdditionalDocumentsRepository : IRepository<SpatialPlanAdditionalDocument>
    {
        Task<IEnumerable<SpatialPlanAdditionalDocument>> GetAdditionalDocumentsBySpatialPlanId(int id);


        Task AddDocument(List<IFormFile> files, string rootPath,int planDocumentId);


        Task DeleteDocument(int id, string rootPath);


    }

    public class SpatialPlanAdditionalDocumentsRepository : Repository<SpatialPlanAdditionalDocument>, ISpatialPlanAdditionalDocumentsRepository
    {
        public SpatialPlanAdditionalDocumentsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<SpatialPlanAdditionalDocument>> GetAdditionalDocumentsBySpatialPlanId(int id)
        {
            return await _context.SpatialPlanAdditionalDocuments.AsNoTracking()
                .Where(x => x.SpatialPlanDocumentId == id).ToListAsync();
        }


        public async Task AddDocument(List<IFormFile> files, string rootPath, int planDocumentId)
        {
            foreach (var file in files)
            {

                if (file.Length > 0)
                {
                    var filePath = Path.Combine(rootPath, "spatialPlanDocuments");
                    var fileNameWithoutExtension = Path.GetFileName(file.FileName);
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var fileSize = UploadFilesHelper.ConvertBytesToMegabytes(file.Length);


                    var uniqueGuid = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
                    var uniqueId = string.Format("{0}_{1}_{2}_{3}", uniqueGuid, DateTime.Now.Ticks, Guid.NewGuid().ToString(), fileExtension);
                    var fileNameWithPath = string.Format("{0}\\{1}", filePath, uniqueId);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    var spatialGraphics = new SpatialPlanAdditionalDocument
                    {
                        FileName = fileName,
                        UniqueFileName = uniqueId,
                        FileExtension = fileExtension,
                        FileSizeInMb = fileSize,
                        SpatialPlanDocumentId = planDocumentId
                    };

                    await _context.AddAsync(spatialGraphics);
                    await _context.SaveChangesAsync();
                }
            }
        }


        public async Task DeleteDocument(int id, string rootPath)
        {
            var uploadedDocument = await _context.SpatialPlanAdditionalDocuments.FindAsync(id);

            if (uploadedDocument != null)
            {
                var rootPathDocument = Path.Combine(rootPath, "spatialPlanDocuments");

                var documentUniqueName = uploadedDocument.UniqueFileName;

                // napravi provjeru ako postoji navedeni dokument, i onda ga izbrisi ako postoji
                var imagePath = Path.Combine(rootPathDocument, documentUniqueName);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
        }

       
    }

  

}
