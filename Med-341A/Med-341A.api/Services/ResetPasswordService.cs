using Med_341A.datamodels;

namespace Med_341A.api.Services
{
    public class ResetPasswordService
    {
        private readonly Med341aContext db;
        private readonly AuthService authService;

        public ResetPasswordService(Med341aContext _db, AuthService _authService)
        {
            db = _db;
            authService = _authService;
        }

        public async Task<bool> IsEqual_PrevPass(long idUser, string password)
        {
            List<TResetPassword> datas = db.TResetPasswords.Where(a => a.CreatedBy == idUser)
                                                            .OrderByDescending(t => t.CreatedOn)
                                                            .Take(3)
                                                            .ToList();

            foreach (TResetPassword data in datas)
            {
                if (authService.VerifyPassword(data.OldPassword, password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
