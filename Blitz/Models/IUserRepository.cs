namespace Blitz.Models
{
    public interface IUserRepository
    {
        UserModel AddUser(UserModel users);
        bool CheckUserLogin(UserModel userLoginModel);

    }
}
