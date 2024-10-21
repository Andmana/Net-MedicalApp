using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMRoleController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();

        public apiMRoleController(Med341aContext _db)
        {
            db = _db;
        }

        [HttpGet("GetAll")]
        public List<VRole> GetAll()
        {
            List<VRole> data = (from r in db.MRoles 
                                where r.IsDelete == false
                                select new VRole
                                {
                                    Id = r.Id,
                                    Name = r.Name,
                                    Code = r.Code,
                                    CreatedBy = r.CreatedBy,
                                    CreatedOn = r.CreatedOn,
                                    ModifiedBy = r.ModifiedBy,
                                    ModifiedOn = r.ModifiedOn,
                                }                                
                               ).ToList();
            return data;
        }

        [HttpGet("GetById/{id}")]
        public MRole GetById(int id)
        {
            MRole data = db.MRoles.FirstOrDefault(x => x.Id == id);
            return data;
        }

        [HttpPost("Add")]
        public VMResponse Add(MRole data)
        {
            data.CreatedOn = DateTime.Now;
            data.IsDelete = false;

            try
            {
                db.Add(data);
                db.SaveChanges();
                response.Message = "Tambah data berhasil";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Tambah data gagal : " + ex.Message;
            }

            return response;
        }

        [HttpPut("Edit")]
        public VMResponse Edit(MRole data)
        {
            MRole dt = db.MRoles.FirstOrDefault(a => a.Id == data.Id);

            if (dt == null)
            {
                response.Success = false;
                response.Message = "Data tidak ditemukan";
            }
            else
            {
                dt.Name = data.Name;
                dt.Code = data.Code;
                dt.ModifiedBy = data.ModifiedBy;
                dt.ModifiedOn = DateTime.Now;

                try
                {
                    db.Update(dt);
                    db.SaveChanges();

                    response.Message = "Ubah data berhasil";
                    response.Entity = dt;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ubah data gagal : " + ex.Message;
                }
            }

            return response;
        }


        [HttpDelete("Delete/{id}/{userId}")]
        public VMResponse Delete(int id, int userId)
        {
            MRole dt = db.MRoles.FirstOrDefault(a => a.Id == id);

            if (dt == null)
            {
                response.Success = false;
                response.Message = "Data tidak ditemukan";
            }
            else
            {
                dt.IsDelete = true;
                dt.DeletedBy = userId;
                dt.DeletedOn = DateTime.Now;

                try
                {
                    db.Update(dt);
                    db.SaveChanges();

                    response.Message = "Hapus data berhasil";
                    response.Entity = dt;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Hapus data gagal : " + ex.Message;
                }
            }

            return response;
        }

    }
}
