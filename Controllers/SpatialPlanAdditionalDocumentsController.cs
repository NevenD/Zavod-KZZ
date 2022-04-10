using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Data.Repositories;

namespace ZAVOD_KZZ.Controllers
{
    public class SpatialPlanAdditionalDocumentsController : Controller
    {
        private readonly ISpatialPlanAdditionalDocumentsRepository _spatialPlanAdditionalDocumentsRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SpatialPlanAdditionalDocumentsController(ISpatialPlanAdditionalDocumentsRepository spatialPlanAdditionalDocumentsRepository, IHostingEnvironment hostingEnvironment)
        {
            _spatialPlanAdditionalDocumentsRepository = spatialPlanAdditionalDocumentsRepository;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAdditionalDocument(int id)
        {
            var additionalDocument = await _spatialPlanAdditionalDocumentsRepository.FindById(id);
            string wwwRoot = _hostingEnvironment.WebRootPath;

            if (additionalDocument == null)
            {
                return NotFound();
            }
            await _spatialPlanAdditionalDocumentsRepository.DeleteDocument(id, wwwRoot);
            await _spatialPlanAdditionalDocumentsRepository.Delete(id);

            return Ok();
        }
    }
}