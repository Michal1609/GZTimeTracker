using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Infrastructure.Data;
using AutoMapper;
using GZIT.GZTimeTracker.Core.Web;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZTimeTracker.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace GZTimeTracker.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;

        public ClientController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRoleServices roleServices) : base(languageServices, unitOfWork, roleServices)
        {
            _mapper = mapper;
        }

        // GET: Client
        public IActionResult Index()
        {  
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var clientsEntity = _unitOfWork.ClientRepository.GetClientsForOwner(owner);

            List<ClientModel> clientModels = new List<ClientModel>();

            foreach (var clientEntity in clientsEntity)
                clientModels.Add(_mapper.Map<ClientModel>(clientEntity));

            return View(clientModels);
        }

        // GET: Client/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get owner
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var client = _unitOfWork.ClientRepository.GetClientForOwner(owner, (int)id);
            if (client == null)
                return BadRequest("Nedostatečná oprávnění");            

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Address,Description,Id")] ClientModel clientModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clientModel);
            }

            //Get owner
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var clientEntity = new ClientEntity()
            {
                Address = clientModel.Address,
                Description = clientModel.Description,
                Name = clientModel.Name,
                Owner = owner
            };

            _unitOfWork.ClientRepository.Insert(clientEntity);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));           
            
        }

        // GET: Client/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get owner
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var clientEntity = _unitOfWork.ClientRepository.GetClientForOwner(owner, (int)id);
            if (clientEntity == null)
            {
                return NotFound();
            }

            var clientModel = _mapper.Map<ClientModel>(clientEntity);
           
            return View(clientModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Address,Description,Id")] ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View(clientModel);

            //Get owner
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var clientEntity = _unitOfWork.ClientRepository.GetClientForOwner(owner, id);
            if (clientEntity == null)
                return BadRequest("Nedostatečná oprávnění");

            clientEntity.Address = clientModel.Address;
            clientEntity.Description = clientModel.Description;
            clientEntity.Name = clientModel.Name;

            _unitOfWork.ClientRepository.Update(clientEntity);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
            
        }

        // GET: Client/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get owner
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var clientEntity = _unitOfWork.ClientRepository.GetClientForOwner(owner, (int)id);
            if (clientEntity == null)
                return BadRequest("Nedostateřná oprávnění");

            _unitOfWork.ClientRepository.Delete(clientEntity.Id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
            
        }       
    }
}
