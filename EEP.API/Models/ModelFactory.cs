using EEP.BL.Classes;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace EEP.API.Models
{
        public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private UserManager _userManager;

        public ModelFactory(HttpRequestMessage request, UserManager appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _userManager = appUserManager;
        }

        //public UserReturnModel Create(User appUser)
        //{
        //    //return new UserReturnModel
        //    //{
        //    //    Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
        //    //    Id = appUser.Id,
        //    //    UserName = appUser.UserName,
        //    //    FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
        //    //    Email = appUser.Email,
        //    //    EmailConfirmed = appUser.EmailConfirmed,             
        //    //    JoinDate = appUser.DateCreated,
        //    //    Roles = _userManager.GetRolesAsync(appUser.Id).Result,
        //    //    Claims = _userManager.GetClaimsAsync(appUser.Id).Result
        //    //};
        //}
    }
}