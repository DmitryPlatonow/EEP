﻿using AutoMapper;
using EEP.API.Helper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EEP.API.Controllers
{
    [CustomJson]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountsController : BaseApiController
    {
        private IUserService _userService;

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }


        public AccountsController(IUserService userService)
            : base()
        {
            _userService = userService;

        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var result = UserManager.Users.ToList();
            List<UserBindModel> listReturnUser = new List<UserBindModel>();
            
           
            foreach (var item in result)
            {

                UserBindModel returnVievUser = new UserBindModel();
                Mapper.Map(item, returnVievUser);
                listReturnUser.Add(returnVievUser);

            }
            return Ok(result);
        }

      //  [Authorize]
        //[Route("user/{id:guid}", Name = "GetUserById")]
        //public async Task<IHttpActionResult> GetUserById(string id)
        //{
        //    var user = await _userService.GetByIdAsync(id);
        //    // var user2 = await UserManager.GetByIdAsync(Id);
        //    if (user != null)
        //    {
        //        return Ok(this.TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

        //[Authorize]
        //[Route("user/{username}")]
        //public async Task<IHttpActionResult> GetUserByName(string username)
        //{
        //    var user = await UserManager.FindByNameAsync(username);

        //    if (user != null)
        //    {
        //        return Ok(TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

       // [Authorize(Roles = "Admin")]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(RegisterBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User();
            Mapper.Map(createUserModel, user);

            var result = await _userService.CreateAsync(user, createUserModel.Role);        


            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }



        //[HttpGet]
        //[Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        //public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        //{
        //    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
        //    {
        //        ModelState.AddModelError("", "User Id and Code are required");
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);

        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return GetErrorResult(result);
        //    }
        //}

        //[Authorize]
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        [Authorize(Roles = "Admin")] 
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(Guid id)
        {

            var appUser = await UserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                return Ok();
            }
            return NotFound();
        }

        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
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







