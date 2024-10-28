using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiDokterProfileController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse respon = new VMResponse();
        public apiDokterProfileController(Med341aContext db)
        {
            this.db = db;
        }
        [HttpGet("GetDataDokter/{id}")]
        public VMDoctor GetDataDokter(int id)
        {
            VMDoctor data = (from u in db.MUsers
                             join b in db.MBiodata on u.BiodataId equals b.Id
                             join d in db.MDoctors on b.Id equals d.BiodataId
                             join spesialisasi in db.TCurrentDoctorSpecializations
                             on d.Id equals spesialisasi.DoctorId
                             into spesialisasiJoin
                             from spesialisasi in spesialisasiJoin.DefaultIfEmpty()
                             where u.Id == id && u.IsDelete == false
                             select new VMDoctor
                             {
                                 IdUser = u.Id,
                                 BiodataId = u.BiodataId,
                                 CreatedBy = u.CreatedBy,
                                 CreatedOn = u.CreatedOn,

                                 Fullname = b.Fullname,
                                 ImagePath = b.ImagePath,

                                 IdSpecialisasi = spesialisasi != null ? spesialisasi.Id : null,
                                 SpecializationName = "Tidak Ada Spesialisasi",

                                 Id = d.Id,
                                 Str = d.Str,

                                 listDokterChat = (from chat in db.TCustomerChats
                                                     where chat.DoctorId == d.Id
                                                     select new VMTCustomerChat
                                                     {
                                                         CustomerId = chat.CustomerId,
                                                         DoctorId = chat.DoctorId
                                                     }).ToList(),
                                 listDokterJanji = (from office in db.TDoctorOffices
                                                    join appoinment in db.TAppointments
                                                    on office.Id equals appoinment.DoctorOfficeId
                                                    where office.DoctorId == d.Id
                                                    select new VMTAppointment
                                                    {
                                                        IdDoctor = office.DoctorId,
                                                        Id = office.Id,

                                                        CustomerId = appoinment.CustomerId
                                                    }).ToList()
                             }).FirstOrDefault()!;
            if(data.IdSpecialisasi != null)
            {
                MSpecialization namaSpesialisasi = db.MSpecializations.Where(a => a.Id == data.IdSpecialisasi).FirstOrDefault();
                data.SpecializationName = namaSpesialisasi.Name;
            }
            return data;
        }
        //Id user
        [HttpGet("GetDataDokterEducation/{id}")]
        public List<MDoctorEducation> GetDataDokterEducation(int id)
        {
            VMDoctor data = (from u in db.MUsers
                             join b in db.MBiodata on u.BiodataId equals b.Id
                             join d in db.MDoctors on b.Id equals d.BiodataId
                             where u.Id == id && u.IsDelete == false
                             select new VMDoctor
                             {
                                 Id = d.Id
                             }).FirstOrDefault()!;
            List <MDoctorEducation> education = db.MDoctorEducations
                                               .Where(a => a.DoctorId == data.Id)
                                               .OrderByDescending(a => a.IsLastEducation)
                                               .ThenByDescending(a => a.EndYear).ToList();
            return education;
        }
        [HttpGet("GetDataRiwayatPraktek/{id}")]
        public List<VMRiwayatPraktek> GetDataRiwayatPraktek(int id)
        {
            VMDoctor data = (from u in db.MUsers
                             join b in db.MBiodata on u.BiodataId equals b.Id
                             join d in db.MDoctors on b.Id equals d.BiodataId
                             where u.Id == id && u.IsDelete == false
                             select new VMDoctor
                             {
                                 Id = d.Id
                             }).FirstOrDefault()!;
            List<VMRiwayatPraktek> riwayat = (from office in db.TDoctorOffices
                                              join medicalFacility in db.MMedicalFacilities
                                              on office.MedicalFaciltyId equals medicalFacility.Id
                                              where office.DoctorId == data.Id
                                              select new VMRiwayatPraktek
                                              {
                                                  DoctorId = office.DoctorId,
                                                  Specialization = office.Specialization,
                                                  StartDate = office.StartDate,
                                                  EndDate = office.EndDate,
                                                  NameMedicalFacility = medicalFacility.Name,
                                                  FullAddress = medicalFacility.FullAddress
                                              })
                                              .OrderByDescending(a => a.EndDate)
                                              .ThenByDescending(a => a.NameMedicalFacility)
                                              .ToList();
            return riwayat;
        }
        [HttpGet("GetDataTindakanMedis/{id}")]
        public List<TDoctorTreatment> GetDataTindakanMedis(int id)
        {
            VMDoctor data = (from u in db.MUsers
                             join b in db.MBiodata on u.BiodataId equals b.Id
                             join d in db.MDoctors on b.Id equals d.BiodataId
                             where u.Id == id && u.IsDelete == false
                             select new VMDoctor
                             {
                                 Id = d.Id
                             }).FirstOrDefault()!;
            List<TDoctorTreatment> tindakanMedis = db.TDoctorTreatments.Where(a => a.DoctorId == data.Id)
                                                   .OrderBy(a => a.Name)
                                                   .ToList();
            return tindakanMedis;
        }
    }
}
