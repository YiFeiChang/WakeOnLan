using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public User[] Get()
        {
            User[] mNoPasswordUsers = new User[0];
            using (ModelsContext mContext = new ModelsContext())
            {
                mNoPasswordUsers = mContext.Users.Select(o => new User() { Id = o.Id, Name = o.Name })
                    .OrderBy(o => o.Id).ToArray();
            }
            return mNoPasswordUsers;
        }
        [HttpGet("/{id}")]
        public User Get(int id)
        {
            User mNoPasswordUser = null;
            using (ModelsContext mContext = new ModelsContext())
            {
                mNoPasswordUser = mContext.Users.Where(o => o.Id == id).Select(o => new User() { Id = o.Id, Name = o.Name }).First();
            }
            return mNoPasswordUser;
        }
        [HttpGet("/{name}")]
        public User Get(string name)
        {
            User mNoPasswordUser = null;
            using (ModelsContext mContext = new ModelsContext())
            {
                mNoPasswordUser = mContext.Users.Where(o => o.Name == name).Select(o => new User() { Id = o.Id, Name = o.Name }).First();
            }
            return mNoPasswordUser;
        }
        [HttpPost]
        public User[] Post([FromBody] User user)
        {
            User[] mNoPasswordUsers = new User[0];
            using (ModelsContext mContext = new ModelsContext())
            {
                mContext.Users.Add(user);
                mContext.SaveChanges();
                mNoPasswordUsers = mContext.Users.Select(o => new User() { Id = o.Id, Name = o.Name })
                    .OrderBy(o => o.Id).ToArray();
            }
            return mNoPasswordUsers;
        }
    }
}
