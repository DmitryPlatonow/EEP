using AutoMapper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.DAL;
using EEP.Entities;
using EEP.Entities.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EEP.API.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        private IUserService _userService;

        public AccountsController(IUserService userService)
            : base()
        {
            _userService = userService;
        }
        public AccountsController()
        {

        }

        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.UserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.UserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.UserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(RegisterViewModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                DateCreated = DateTime.Now.Date,
            };

            OperationResult addUserResult = await _userService.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return BadRequest(addUserResult.Message);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }
    }
}

    ////
    //// GET: /Account/ConfirmEmail
    //[AllowAnonymous]
    //public async Task<ActionResult> ConfirmEmail(Guid userId, string code)
    //{
    //    if (userId == null || code == null)
    //    {
    //        return View("Error");
    //    }
    //    var result = await _accountService.ConfirmEmail(userId, code);
    //    return View(result.Succeeded ? "ConfirmEmail" : "Error");
    //}

    ////
    //// GET: /Account/ForgotPassword
    //[AllowAnonymous]
    //public ActionResult ForgotPassword()
    //{
    //    return View();
    //}

    ////
    //// POST: /Account/ForgotPassword
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {

    //        OperationResult result = await _accountService.SendCodeToRetrievePassword(model.Email);

    //        if (result.Succeeded)
    //            return RedirectToAction("Index", "Home");
    //        else
    //            ModelState.AddModelError(result.Property, result.Message);
    //    }

    //    return View(model);
    //}

    ////
    //// GET: /Account/ForgotPasswordConfirmation
    //[AllowAnonymous]
    //public ActionResult ForgotPasswordConfirmation()
    //{
    //    return View();
    //}

    ////
    //// GET: /Account/ResetPassword
    //[AllowAnonymous]
    //public ActionResult ResetPassword(string code)
    //{
    //    return code == null ? View("Error") : View();
    //}

    ////
    //// POST: /Account/ResetPassword
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        OperationResult result = await _accountService.ResetPassword(model.Email, model.Code, model.Password);

    //        if (result.Succeeded)
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        else
    //            ModelState.AddModelError(result.Property, result.Message);
    //    }

    //    return View(model);
    //}

    ////
    //// GET: /Account/ResetPasswordConfirmation
    //[AllowAnonymous]
    //public ActionResult ResetPasswordConfirmation()
    //{
    //    return View();
    //}

    ////
    //// POST: /Account/LogOff
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult LogOff()
    //{
    //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    //    return RedirectToAction("Index", "Home", new { area = "" });
    //}

    ////
    //// GET: /Account/ExternalLoginFailure
    //[AllowAnonymous]
    //public ActionResult ExternalLoginFailure()
    //{
    //    return View();
    //}

    //#region Helpers
    //// Used for XSRF protection when adding external logins
    //private const string XsrfKey = "XsrfId";

    //private void AddErrors(IdentityResult result)
    //{
    //    foreach (var error in result.Errors)
    //    {
    //        ModelState.AddModelError("", error);
    //    }
    //}

    //private ActionResult RedirectToLocal(string returnUrl)
    //{
    //    if (Url.IsLocalUrl(returnUrl))
    //    {
    //        return Redirect(returnUrl);
    //    }
    //    return RedirectToAction("Index", "Home", new { area = "" });
    //}

    //internal class ChallengeResult : HttpUnauthorizedResult
    //{
    //    public ChallengeResult(string provider, string redirectUri)
    //        : this(provider, redirectUri, null)
    //    {
    //    }

    //    public ChallengeResult(string provider, string redirectUri, string userId)
    //    {
    //        LoginProvider = provider;
    //        RedirectUri = redirectUri;
    //        UserId = userId;
    //    }

    //    public string LoginProvider { get; set; }
    //    public string RedirectUri { get; set; }
    //    public string UserId { get; set; }

    //    public override void ExecuteResult(ControllerContext context)
    //    {
    //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
    //        if (UserId != null)
    //        {
    //            properties.Dictionary[XsrfKey] = UserId;
    //        }
    //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
    //    }
    //}
    //#endregion
//}
//}
