﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Common.Implementations.Logging;
using WebApi.Web.Common.Implementations.Logging;
using WebApi.Web.Common.Interfaces.DependencyBlock;
using WebApi.Web.Interfaces.Logging;

namespace WebApi.Web.Common.Implementations.Controllers
{
    public class BaseController : ApiController
    {
        #region Fields

        private readonly ILogManager log = new LogManagerAdapter();

        #endregion

        #region Ctor

        public BaseController()
        {

        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Get Methods
        #endregion

        #region Public Post Methods
        #endregion

        #region Public Put Methods
        #endregion

        #region Public Delete Methods
        #endregion

        #region Protected Methods
        #endregion

        #region Properties
        #endregion

    }

		public class BaseController<T> : BaseController
			where T : IDependencyBlock
		{
			#region Fields

			private readonly T modDependencyBlock;

			#endregion

			#region Ctor

			public BaseController(T dependencyBlock)
				: base()
			{
				modDependencyBlock = dependencyBlock;
			}

			#endregion

			#region Private Methods
			#endregion

			#region Public Get Methods
			#endregion

			#region Public Post Methods
			#endregion

			#region Public Put Methods
			#endregion

			#region Public Delete Methods
			#endregion

			#region Protected Methods
			#endregion

			#region Properties
			#endregion

		}
}
