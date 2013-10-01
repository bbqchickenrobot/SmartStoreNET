﻿using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SmartStore.Core;
using SmartStore.Core.Data;
using SmartStore.Core.Domain.Localization;
using SmartStore.Core.Infrastructure;
using SmartStore.Web.Framework.Localization;

namespace SmartStore.Web.Framework.Controllers
{
    /// <summary>
    /// Attribute which determines and sets the working culture
    /// </summary>
    public class SetWorkingCultureAttribute : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null || filterContext.HttpContext == null)
                return;

            HttpRequestBase request = filterContext.HttpContext.Request;
            if (request == null)
                return;

            // don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var workingLanguage = workContext.WorkingLanguage;

            CultureInfo culture;
            if (workContext.CurrentCustomer != null && workingLanguage != null)
            {
                culture = new CultureInfo(workingLanguage.LanguageCulture);
            }
            else
            {
                culture = new CultureInfo("en-US");
            }
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //if (filterContext == null || filterContext.HttpContext == null)
        //    //    return;
            
        //    //HttpRequestBase request = filterContext.HttpContext.Request;
        //    //if (request == null)
        //    //    return;

        //    ////don't apply filter to child methods
        //    //if (filterContext.IsChildAction)
        //    //    return;

        //    ////only GET requests
        //    //if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
        //    //    return;

        //    //if (!DataSettingsHelper.DatabaseIsInstalled())
        //    //    return;

        //    //var localizationSettings = EngineContext.Current.Resolve<LocalizationSettings>();
        //    //if (!localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
        //    //    return;

        //    ////ensure that this route is registered and localizable (LocalizedRoute in RouteProvider.cs)
        //    //if (filterContext.RouteData == null || filterContext.RouteData.Route == null || !(filterContext.RouteData.Route is LocalizedRoute))
        //    //    return;


        //    ////process current URL
        //    //var pageUrl = filterContext.HttpContext.Request.RawUrl;
        //    //string applicationPath = filterContext.HttpContext.Request.ApplicationPath;
        //    //if (pageUrl.IsLocalizedUrl(applicationPath, true))
        //    //    //already localized URL
        //    //    return;
        //    ////add language code to URL
        //    //var workContext = EngineContext.Current.Resolve<IWorkContext>();
        //    //pageUrl = pageUrl.AddLanguageSeoCodeToRawUrl(applicationPath, workContext.WorkingLanguage);
        //    //filterContext.Result = new RedirectResult(pageUrl);
        //}

    }
}