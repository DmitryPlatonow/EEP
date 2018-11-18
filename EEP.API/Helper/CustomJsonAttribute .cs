using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;

namespace EEP.API.Helper
{
    public class CustomJsonAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            var formatter = controllerSettings.Formatters.JsonFormatter;

            controllerSettings.Formatters.Remove(formatter);

            formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }
            };

            controllerSettings.Formatters.Insert(0, formatter);

        }
    }
}