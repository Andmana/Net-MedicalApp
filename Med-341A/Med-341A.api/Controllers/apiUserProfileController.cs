using Azure;
using Med_341A.api.Services;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Threading.Tasks.Dataflow;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiUserProfileController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse respon = new VMResponse();
        private readonly AuthService authService;
        private readonly EmailService emailService;
        public apiUserProfileController(Med341aContext db, AuthService authService, EmailService emailService)
        {
            this.db = db;
            this.authService = authService;
            this.emailService = emailService;
        }

        //Mendapatkan semua data akun dan biodata user berdasarkan id user
        [HttpGet("GetDataUser/{id}")]
        public VMUser GetDataUser(int id)
        {
            VMUser data = (from u in db.MUsers
                           join b in db.MBiodata
                           on u.BiodataId equals b.Id
                           join c in db.MCustomers
                           on b.Id equals c.BiodataId
                           where u.Id == id && u.IsDelete == false
                           select new VMUser
                           {
                               Id = u.Id,
                               Fullname = b.Fullname,
                               BiodataId = u.BiodataId,
                               MobilePhone = b.MobilePhone,
                               ImagePath = b.ImagePath,
                               Dob = c.Dob,
                               Email = u.Email,
                               Password = u.Password,
                               CreatedOn = b.CreatedOn,
                               CreatedBy = b.CreatedBy
                           }).FirstOrDefault()!;
            return data;
        }
        [HttpGet("GetDataGambar/{id}")]
        public VMUploadGambar GetDataGambar(int id)
        {
            VMUploadGambar data = (from u in db.MUsers
                                   join b in db.MBiodata
                                   on u.BiodataId equals b.Id
                                   where u.Id == id && u.IsDelete == false
                                   select new VMUploadGambar
                                   {
                                       Id = u.Id,
                                       BiodataId = u.BiodataId,
                                       ImagePath = b.ImagePath
                                   }).FirstOrDefault()!;
            return data;
        }

        [HttpPost("UpdatePassword")]
        public VMResponse UpdatePassword (VMUser dataAwal)
        {
            MUser data = db.MUsers.Where(a => a.Id == dataAwal.Id).FirstOrDefault();
            TResetPassword updatePassword = new();
            if (data != null)
            {
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = dataAwal.Id;

                updatePassword.CreatedOn = DateTime.Now;
                updatePassword.CreatedBy = dataAwal.Id;
                updatePassword.ResetFor = "Update_Password";

                updatePassword.OldPassword = data.Password;
                updatePassword.IsDelete = false;

                string hashedPassword = authService.HashPassword(dataAwal.Password ?? "");

                data.Password = hashedPassword;
                updatePassword.NewPassword = hashedPassword;

                try
                {
                    db.Add(updatePassword);
                    db.SaveChanges();

                    db.Update(data);
                    db.SaveChanges();

                    respon.Message = "Password berhasil update, silahkan login ulang menggunakan password baru";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Failed Updated" + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Not Found";
            }
            return respon;
        }

        [HttpPut("UbahPribadi")]
        public VMResponse UbahPribadi(VMUser dataAwal)
        {
            MBiodatum dataBio = db.MBiodata.Where(a => a.Id == dataAwal.BiodataId).FirstOrDefault()!;
            MCustomer dataCust = db.MCustomers.Where(a => a.BiodataId == dataAwal.BiodataId).FirstOrDefault()!;
            if (dataBio != null && dataCust != null)
            {
                dataBio.Fullname = dataAwal.Fullname;
                dataBio.MobilePhone = dataAwal.MobilePhone;
                dataBio.ModifiedBy = dataAwal.Id;
                dataBio.ModifiedOn = DateTime.Now;

                dataCust.Dob = dataAwal.Dob;
                dataCust.ModifiedBy = dataAwal.Id;
                dataCust.ModifiedOn = DateTime.Now;
                try
                {
                    db.Update(dataBio);
                    db.Update(dataCust);
                    db.SaveChanges();
                    respon.Message = "Data Success Updated";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Failed Updated" + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Not Found";
            }
            return respon;

        }
        [HttpPut("UbahGambar")]
        public VMResponse UbahGambar([FromForm] VMUploadGambar dataInput)
        {
            MBiodatum data = db.MBiodata.Where(a => a.Id == dataInput.BiodataId).FirstOrDefault()!;
            if (data != null)
            {
                if (dataInput.ImagePath != null)
                {
                    data.ImagePath = dataInput.ImagePath;
                }
                data.ModifiedBy = dataInput.Id;
                data.ModifiedOn = DateTime.Now;
                try
                {
                    db.Update(data);
                    db.SaveChanges();
                    respon.Message = "Unggah Gambar Berhasil";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Gagal Unggah, Pesan Error: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Tidak Ditemukan";
            }
            return respon;
        }
        [HttpGet("CheckEmailIsExist/{email}")]
        public bool CheckEmailIsExist(string email)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email).FirstOrDefault()!;
            return data != null;
        }

        [HttpPost("RequestOTPEmailBaru")]
        public VMResponse RequestOTPEmailBaru(OTPValidationRequestBody request)
        {
            var token = db.TTokens.Where(t => t.Email == request.Email && t.IsExpired == false && t.UsedFor == request.usedFor)
                                  .OrderByDescending(t => t.CreatedOn)
                                  .FirstOrDefault();
            if(token != null)
            {
                token.IsExpired = true;
                token.ModifiedOn = DateTime.Now;
                token.ModifiedBy = request.UserId;
                db.Update(token);
                db.SaveChanges();
            }

            var otp = emailService.GenerateOtp();
            token = new TToken
            {
                Email = request.Email,
                UserId = request.UserId,
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

            respon.Success = true;
            respon.Message = "OTP sudah dikirim ke email, silahkan buka dan masukkan kedalam kolom OTP";
            return respon;
        }

        [HttpPost("VerifikasiOTP")]
        public VMResponse VerifikasiOTP(OTPValidationRequestBody request)
        {
            var token = db.TTokens.Where(t => t.Email == request.Email && t.IsExpired == false && t.UsedFor == request.usedFor)
                                  .OrderByDescending(t => t.CreatedOn)
                                  .FirstOrDefault();
            MUser user = db.MUsers.Where(a => a.Id == request.UserId).FirstOrDefault()!;

            if (token == null)
            {
                respon.Success = false;
                respon.Message = "OTP tidak ditemukan atau kadaluarsa.";
                return respon;
            }

            if (token.ExpiredOn < DateTime.Now)
            {
                respon.Success = false;
                respon.Message = "OTP kadaluarsa.";
                token.IsExpired = true;
                db.Update(token);
                db.SaveChanges();
                return respon;
            }

            if (token.Token != request.Otp)
            {
                respon.Success = false;
                respon.Message = "OTP Salah.";
                return respon;
            }

            // OTP is valid, mark as expired
            token.IsExpired = true;
            user.Email = request.Email;
            user.ModifiedBy = request.UserId;
            user.ModifiedOn = DateTime.Now;
            db.Update(token);
            db.Update(user);
            db.SaveChanges();

            respon.Success = true;
            respon.Message = "Verifikasi OTP berhasil, silahkan login ulang menggunakan email baru";
            return respon;
        }
    }
}
