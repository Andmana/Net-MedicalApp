﻿using Med_341A.api.Services;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMAuthController : ControllerBase
    {
        private readonly Med341aContext db;
        private readonly EmailService emailService;
        private readonly AuthService authService;
        private VMResponse response = new VMResponse();

        public apiMAuthController(Med341aContext _db, EmailService _emailService, AuthService _authService)
        {
            this.db = _db;
            this.emailService = _emailService;
            this.authService = _authService;
        }

        [HttpPost("CheckLoginV2")]
        public VMUser? CheckLoginV2(AuthLoginRequestBody loginRequest)
        {
            MUser checkUser = db.MUsers.Where(a => a.IsDelete == false && a.Email == loginRequest.Email).FirstOrDefault()!;

            var isPasswordValid = authService.VerifyPassword(checkUser.Password ?? "", loginRequest.Password);

            VMUser? data = new();

            if (!isPasswordValid)
            {
                if (checkUser.LoginAttempt != null)
                {
                    if (checkUser.LoginAttempt > 5)
                    {
                        checkUser.IsLocked = true;
                    }
                    checkUser.LoginAttempt = checkUser.LoginAttempt + 1;
                }
                else
                {
                    checkUser.LoginAttempt = 1;
                }

                db.Update(checkUser);
                db.SaveChanges();

                data = null;
            }
            else
            {
                data = (from user in db.MUsers
                        join bio in db.MBiodata
                        on user.BiodataId equals bio.Id
                        into biouser
                        from bio in biouser.DefaultIfEmpty()
                        join role in db.MRoles
                        on user.RoleId equals role.Id
                        where user.IsDelete == false && user.Email == loginRequest.Email &&
                        (user.IsLocked == false || user.IsLocked == null)
                        select new VMUser
                        {
                            Id = user.Id,
                            RoleId = user.RoleId,
                            Fullname = bio.Fullname,
                            Email = user.Email,
                            NameRole = role.Name,
                            ImagePath = bio.ImagePath
                        }).FirstOrDefault()!;

                checkUser.LoginAttempt = 0;
                checkUser.LastLogin = DateTime.Now;

                db.Update(checkUser);
                db.SaveChanges();
            }

            return data;
        }

        [HttpPost("CheckPasswordIsValidV2")]
        public bool CheckPasswordIsValidV2(AuthLoginRequestBody loginRequest)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == loginRequest.Email).FirstOrDefault()!;

            if (data != null)
            {
                return authService.VerifyPassword(data.Password ?? "", loginRequest.Password);
            }
            else
            {
                return false;
            }
        }

        [HttpGet("CheckEmailIsRegistered/{email}")]
        public bool CheckEmailIsRegistered(string email)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email).FirstOrDefault()!;

            return data != null;
        }

        // API Register
        [HttpPost("RequestOTP")]
        public VMResponse RequestOTP(OTPValidationRequestBody request)
        {
            var otp = emailService.GenerateOtp();
            var token = new TToken
            {
                Email = request.Email,
                Token = otp,
                ExpiredOn = DateTime.Now.AddMinutes(10),
                IsExpired = false,
                CreatedOn = DateTime.Now,
                UsedFor = request.usedFor
            };
            db.TTokens.Add(token);
            db.SaveChanges();

            // Kirim OTP ke email pengguna
            emailService.SendOtpEmail(request.Email, otp);

            response.Success = true;
            response.Message = "OTP sent to email. Please verify your email.";
            return response;
        }

        // Verify OTP
        [HttpPost("VerifyOTP")]
        public VMResponse VerifyOTP(OTPValidationRequestBody request)
        {
            var token = db.TTokens.Where(t => t.Email == request.Email && t.IsExpired == false && t.UsedFor == request.usedFor)
                                  .OrderByDescending(t => t.CreatedOn)
                                  .FirstOrDefault();

            if (token == null)
            {
                response.Success = false;
                response.Message = "OTP not found or expired.";
                return response;
            }

            if (token.ExpiredOn < DateTime.Now)
            {
                response.Success = false;
                response.Message = "OTP expired.";
                token.IsExpired = true;
                db.SaveChanges();
                return response;
            }

            if (token.Token != request.Otp)
            {
                response.Success = false;
                response.Message = "Incorrect OTP.";
                return response;
            }

            // OTP is valid, mark as expired
            token.IsExpired = true;
            db.SaveChanges();

            response.Success = true;
            response.Message = "OTP verification successful. Proceed to set a new password.";
            return response;
        }


        // Temporary Create New
        [HttpPost("RegisterNewUser")]
        public VMResponse RegisterNewUser(VMUser dataUserProfile)
        {
            bool isEmailHasRegistered = CheckEmailIsRegistered(dataUserProfile.Email ?? "");

            if (!isEmailHasRegistered)
            {
                try
                {
                    // Create biodata data first
                    MBiodatum biodata = new();

                    // manual mapping ke entity biodata
                    biodata.Fullname = dataUserProfile.Fullname;
                    biodata.MobilePhone = dataUserProfile.MobilePhone;
                    biodata.CreatedOn = DateTime.Now;
                    biodata.IsDelete = false;

                    // add to db
                    db.Add(biodata);
                    db.SaveChanges();

                    string hashedPassword = authService.HashPassword(dataUserProfile.Password ?? "");

                    MUser user = new();
                    // manual mapping ke entity user
                    user.BiodataId = biodata.Id;
                    user.Email = dataUserProfile.Email;
                    user.Password = hashedPassword;
                    user.RoleId = dataUserProfile.RoleId;
                    user.CreatedOn = DateTime.Now;
                    user.IsDelete = false;

                    // add to db
                    db.Add(user);
                    db.SaveChanges();

                    // update user createdBy and biodata createdby
                    user.CreatedBy = user.Id;
                    biodata.CreatedBy = user.Id;

                    // update createdBy user
                    db.Update(user);
                    db.SaveChanges();

                    // update createdBy biodata
                    db.Update(biodata);
                    db.SaveChanges();

                    switch (dataUserProfile.RoleId)
                    {
                        case 1:
                            MCustomer customer = new();

                            customer.BiodataId = biodata.Id;
                            customer.CreatedBy = user.Id;
                            customer.CreatedOn = DateTime.Now;
                            customer.IsDelete = false;

                            db.Add(customer);
                            db.SaveChanges();

                            break;
                        case 2:
                            MDoctor doctor = new();

                            doctor.BiodataId = biodata.Id;
                            doctor.CreatedBy = user.Id;
                            doctor.CreatedOn = DateTime.Now;
                            doctor.IsDelete = false;

                            db.Add(doctor);
                            db.SaveChanges();

                            break;
                        default:
                            MAdmin admin = new();

                            admin.BiodataId = biodata.Id;
                            admin.CreatedBy = user.Id;
                            admin.CreatedOn = DateTime.Now;
                            admin.IsDelete = false;

                            db.Add(admin);
                            db.SaveChanges();
                            break;
                    }

                    response.Message = "Berhasil Register";
                }
                catch (Exception ex)
                {

                    response.Message = "Register tidak berhasil " + ex.Message;
                    response.Success = false;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Email telah terdaftar";
            }

            return response;
        }

        [Obsolete("This API is deprecated. Please use the new CheckLoginV2 API.")]
        [HttpGet("CheckLogin/{email}/{password}")]
        public VMUser CheckLogin(string email, string password)
        {
            VMUser data = (from user in db.MUsers
                           join bio in db.MBiodata
                           on user.BiodataId equals bio.Id
                           into biouser
                           from bio in biouser.DefaultIfEmpty()
                           join role in db.MRoles
                           on user.RoleId equals role.Id
                           where user.IsDelete == false && user.Email == email &&
                           (user.IsLocked == false || user.IsLocked == null)
                           select new VMUser
                           {
                               Id = user.Id,
                               RoleId = user.RoleId,
                               Fullname = bio.Fullname,
                               Email = user.Email,
                               NameRole = role.Name,
                               ImagePath = bio.ImagePath

                           }).FirstOrDefault()!;

            return data;
        }

        [Obsolete("This API is deprecated. Please use the new CheckPasswordIsValidV2 API.")]
        [HttpGet("CheckPasswordIsValid/{email}/{password}")]
        public bool CheckPasswordIsValidV2(string email, string password)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email && a.Password == password).FirstOrDefault()!;

            return data != null;
        }
    }

    public class AuthLoginRequestBody
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
