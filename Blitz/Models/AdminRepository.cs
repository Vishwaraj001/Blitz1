namespace Blitz.Models
{
    public class AdminRepository : IAdminRepository
    {
        ProjectDbContext _projectDbContext;
        bool loginResult;
        public AdminRepository(ProjectDbContext projectDbContext)
        {
            this._projectDbContext = projectDbContext;
        }

       public bool CheckAdminLogin(AdminModel adminLoginModel)
        {
            var admin = _projectDbContext.AdminsTable.Find(adminLoginModel.UserId);
            if (admin != null && admin.UserId == adminLoginModel.UserId && admin.Password == adminLoginModel.Password)

            {
                loginResult = true;
            }
            else 
            {
                loginResult = false;
            }
            return loginResult;
        }
        //public bool CheckUserLogin(UserModel userLoginModel)
        //{
        //    var users = _projectDbContext.UsersTable.Find(userLoginModel.U_EmailId);
        //    if (users != null && users.U_EmailId == userLoginModel.U_EmailId && users.U_Password == userLoginModel.U_Password)
        //    {
        //        loginResult = true;
        //    }
        //    else
        //    {
        //        loginResult = false;
        //    }
        //    return loginResult;

        //}
    }
}
