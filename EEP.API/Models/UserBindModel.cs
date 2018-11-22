using EEP.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;

namespace EEP.API.Models
{
    public class UserBindModel
    {       
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }    }
}