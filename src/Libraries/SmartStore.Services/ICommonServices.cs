﻿using System;
using System.Collections.Generic;
using System.Linq;
using SmartStore.Core;
using SmartStore.Core.Caching;
using SmartStore.Core.Data;
using SmartStore.Core.Events;
using SmartStore.Services.Localization;
using SmartStore.Core.Logging;

namespace SmartStore.Services
{
	
	public interface ICommonServices
	{
		ICacheManager Cache 
		{ 
			get;
		}

		IDbContext DbContext
		{
			get;
		}

		IStoreContext StoreContext
		{
			get;
		}

		IWebHelper WebHelper
		{
			get;
		}

		IWorkContext WorkContext
		{
			get;
		}

		IEventPublisher EventPublisher
		{
			get;
		}

		ILocalizationService Localization
		{
			get;
		}

		ICustomerActivityService CustomerActivity
		{
			get;
		}
	}

}