using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Channels;
using System.Xml.Linq;
using System;




namespace Blitz.Models
{
    public class UserRepository : IUserRepository
    {
        ProjectDbContext _projectDbContext;
        bool loginResult;



        public UserRepository(ProjectDbContext projectDbContext)
        {
            this._projectDbContext = projectDbContext;
        }


        public IEnumerable<UserModel> GetOrders()
        {
            return _projectDbContext.UsersTable.Select(o => o).ToList();
        }

        public UserModel AddUser(UserModel users)
        {

            _projectDbContext.UsersTable.Add(users);
            _projectDbContext.SaveChanges();
            return null;

        }


        public bool CheckUserLogin(UserModel userLoginModel)
        {
            var users = _projectDbContext.UsersTable.Find(userLoginModel.U_EmailId);
            if (users != null && users.U_EmailId == userLoginModel.U_EmailId && users.U_Password == userLoginModel.U_Password)
            {
                loginResult = true;
            }
            else
            {
                loginResult = false;
            }
            return loginResult;
            
        }

    }
}
