using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Feature.Contacts.Controllers
{
    public class CustomContactController : ApiController
    {
        // From <xConnect instance>\App_Config\AppSettings.config
        const string CERTIFICATE_OPTIONS =
            "StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue=???";

        // From your installation
        const string XCONNECT_URL = "https://sitecore-trainingxconnect.dev.local";
        public IHttpActionResult CreateCustomContact()
        {
            return Json("result");
        }
    }
}
