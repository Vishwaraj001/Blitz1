namespace Blitz.Models
{
    public interface IAdminRepository
    {
        bool CheckAdminLogin(AdminModel adminLoginModel);
    }
}
