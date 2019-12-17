using GZIT.GZTimeTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Cache
{

    public class CacheService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CacheService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void LoadStartupData()
        {
            LoadInstaledLanguages();
            LoadSystemRoles();
        }

        private void LoadInstaledLanguages()
        {
            WebWorker.InstalledLanguages = _unitOfWork.LanguageRepository.GetAll();
        }

        private void LoadSystemRoles()
        {
            WebWorker.SystemRoles = _unitOfWork.SystemRoleRepository.GetAll();
        }
    }
}
