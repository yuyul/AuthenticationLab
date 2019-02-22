using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationLab.Repositories;
using AuthorizationLab.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationLab.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IAuthorizationService _authorizationService;

        public DocumentController(IDocumentRepository documentRepository,
                                    IAuthorizationService authorizationService)
        {
            _documentRepository = documentRepository;
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View(_documentRepository.Get());
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var document = _documentRepository.Get(id);

            if(document == null)
            {
                return new NotFoundResult();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, document, new EditRequirement());
            if (authorizationResult.Succeeded)
            {
                return View(document);
            } else
            {
                return new ForbidResult();
            }
        }
    }
}