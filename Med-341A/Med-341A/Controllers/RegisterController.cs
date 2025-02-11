﻿using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class RegisterController : Controller
    {
        public readonly RegisterService registerService;
        public readonly AuthService authService;
        public readonly RoleService roleService;
        public VMResponse response = new();

        public RegisterController(RegisterService _registerService, AuthService _authService, RoleService _roleService)
        {
            this.registerService = _registerService;
            this.authService = _authService;
            this.roleService = _roleService;
        }

        public IActionResult EmailVerification()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateOTP(string email)
        {
            response = await registerService.RequestOTP(email);

            ViewBag.Email = email;

            return PartialView(response);
        }

        [HttpPost]
        public async Task<JsonResult> RetryRequestOTP(string email)
        {
            VMResponse response = await registerService.RequestOTP(email);

            return Json(new { dataResponse = response });
        }

        [HttpPost]
        public async Task<JsonResult> VerifyOTP(string email, string otp)
        {
            VMResponse response = await registerService.VerifyOTP(email, otp);

            if (response.Success)
            {
                HttpContext.Session.SetString("emailToRegister", email);
            }

            return Json(new { dataResponse = response });
        }

        public IActionResult SetPassword()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FormRegisterProfile(string password)
        {
            HttpContext.Session.SetString("passwordToRegister", password);

            ViewBag.DropdownRole = await roleService.GetAll();

            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> SubmitRegister(VMUser dataForm)
        {

            response = await registerService.RegisterNewUser(dataForm);

            if (response.Success)
            {
                HttpContext.Session.Remove("emailToRegister");
                HttpContext.Session.Remove("passwordToRegister");
            }

            return Json(new { dataResponse = response });
        }
    }
}
