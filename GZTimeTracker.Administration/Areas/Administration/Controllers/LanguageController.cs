using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZTimeTracker.Administration.Areas.Administration.Models;
using GZTimeTracker.Administration.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace GZTimeTracker.Administration.Areas.Administration.Controllers
{
    [Area("Administration")]
    [AutoValidateAntiforgeryToken]
    public class LanguageController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LanguageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var langugaes = await _unitOfWork.LanguageRepository.GetAllAsync();

            var languageModels = new List<LanguageModel>();
            foreach(var language in langugaes)
            {
                languageModels.Add(new LanguageModel()
                {
                    Id = language.Id,
                    Name = language.Name,
                    Code = language.Code.ToLower(),
                    Version = language.Version
                });

            }

            return View(languageModels);
        }


        [HttpPost]        
        public IActionResult ImportFromDisk(IFormFile file)
        {
            if (file == null)
                RedirectToAction(nameof(Index));

            // covert language file content to string
            string languageJsonContent;
            using (var stream = file.OpenReadStream())
            {
                MemoryStream memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                var array = memoryStream.ToArray();
                languageJsonContent = Encoding.UTF8.GetString(array, 0, array.Length);
            }
            

            // validate input file
            var languageSchema = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Core", "Language-schema.json"));            
            JSchema schema = JSchema.Parse(languageSchema);
            JObject langaugeObject = JObject.Parse(languageJsonContent);
            IList<string> messages;

            bool valid = langaugeObject.IsValid(schema, out messages);

            if (valid)
            {         
                var languagePack = JsonConvert.DeserializeObject<LanguagePack>(languageJsonContent);
                SaveLanguage(languagePack);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id <= 1)
                RedirectToAction(nameof(Index));

            var language = _unitOfWork.LanguageRepository.GetSingle(a => a.Id == id);
            if (language == null)
                RedirectToAction(nameof(Index));
            
            // delete translates
            _unitOfWork.LocaleStringResourceRepository.Delete(_unitOfWork.LocaleStringResourceRepository.Get(a => a.LanguageId == language.Id));

            // delete language
            _unitOfWork.LanguageRepository.Delete(language.Id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        private void SaveLanguage(LanguagePack languagePack)
        {
            // Check versions compatibility
            var systemInformation = _unitOfWork.SystemInformationRepository.GetAll().FirstOrDefault();
            if (systemInformation.Version != Decimal.Parse(languagePack.SupportedVersion.Replace('.', ',')))
                return; // version of language pack and system are incompatible

            // Check language exist in DB
            var languageEntity = _unitOfWork.LanguageRepository.GetSingle(a => a.Code == languagePack.Code.ToLower());

            // Clear language if exist
            if (languageEntity != null)           
            {
                // Delete all translations for existing language
                _unitOfWork.LocaleStringResourceRepository.DeleteByLanguageId(languageEntity.Id);
                _unitOfWork.Save();
                _unitOfWork.LanguageRepository.Delete(languageEntity.Id);    
                _unitOfWork.Save();                
            }

            // Save new language
            languageEntity = new LanguageEntity()
            {
                Code = languagePack.Code.ToLower(),
                Name = languagePack.Name,
                Version = Decimal.Parse(languagePack.PackVersion.Replace('.', ','))
            };

            _unitOfWork.LanguageRepository.Insert(languageEntity);
            _unitOfWork.Save();

            // Save all new translations
            var resourcesEntity = new List<LocaleStringResourceEntity>();
            foreach (var res in languagePack.Resources)
            {
                resourcesEntity.Add(
                new LocaleStringResourceEntity()
                {
                    LanguageId = languageEntity.Id,
                    Name = res.Name,
                    Value = res.Value
                });
            }

            _unitOfWork.LocaleStringResourceRepository.Insert(resourcesEntity);
            _unitOfWork.Save(); 
        }
    }
}