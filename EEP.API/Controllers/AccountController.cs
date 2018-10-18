using AutoMapper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EEP.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;

            //Todo: This needs to be moved from here.
            this.userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        // POST api/Account/Register
        [AllowAnonymous]
       // [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User();
                    Mapper.Map(userModel, user);

                    var identityResult = await userManager.CreateAsync(user, userModel.Password);

                    if (identityResult.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "User");
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError(error, error);
                        }
                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private async Task<IHttpActionResult> SignInAsync(User user, bool isPersistent)
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _u.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}


    }
}
