using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Data;

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

        [HttpGet("IsRoleExists/{id}/{name}/{code}")]
        public async Task<VFlagExists> IsRoleExists(int id, string name, string code)
        {
            VFlagExists result = new VFlagExists();


            MRole roleName = new MRole();
            if (id == 0)
                roleName = db.MRoles.Where(a => a.Name.ToLower() == name.ToLower() && a.IsDelete == false).FirstOrDefault()!;
            else
                roleName = db.MRoles.Where(a => a.Name.ToLower() == name.ToLower() && a.IsDelete == false && a.Id != id)
                                      .FirstOrDefault()!;
            if (roleName != null)
            {
                result.isNameExists = true;
                result.Success = false;
            }



            MRole roleCode = new MRole();
            if (id == 0)
                roleCode = db.MRoles.Where(a => a.Code.ToLower() == code.ToLower() && a.IsDelete == false)
                                      .FirstOrDefault()!;
            else
                roleCode = db.MRoles.Where(a => a.Code.ToLower() == code.ToLower() && a.IsDelete == false && a.Id != id)
                                      .FirstOrDefault()!;
            if(roleCode != null) { 
                result.isCodeExists = true;
                result.Success = false;
            }

            return result;
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
