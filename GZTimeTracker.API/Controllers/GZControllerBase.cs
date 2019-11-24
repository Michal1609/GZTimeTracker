using Microsoft.AspNetCore.Mvc;
using NLog;


namespace GZIT.GZTimeTracker.API.Core
{
    /// <summary>
    /// Base class for api controllers
    /// </summary>
    public abstract class GZControllerBase : ControllerBase
    {
        #region Fields

        /// <summary>
        /// NLog
        /// </summary>
        protected readonly Logger _logger;

        #endregion

        #region Ctor

        public GZControllerBase()
        {            
            _logger = LogManager.GetLogger(this.GetType().ToString());            
        }

        #endregion
    }
}
