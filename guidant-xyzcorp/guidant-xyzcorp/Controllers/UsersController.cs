using guidant_xyzcorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace guidant_xyzcorp.Controllers
{
    public class UsersController : ApiController
    {
        private XyzCorpDbContext context;

        public UsersController(XyzCorpDbContext context)
        {
            this.context = context;
        }

        // GET api/users
        public User[] Get()
        {
            return context.Set<User>().ToArray();
        }

        // GET api/users/5
        public User Get(int id)
        {
            var user = context.Users.SingleOrDefault(u => u.id == id);

            if(user == null)
            {
                throw new ArgumentException($"User Id does not exist: {id}");
            }
            else
            {
                return user;
            }
        }

        // POST api/users
        public int Post([FromBody]User user)
        {
            if(string.IsNullOrEmpty(user.name))
            {
                throw new ArgumentException($"User name is required, canceling insert.");
            }
            else if (context.Users.Any(u => u.name == user.name))
            {
                throw new ArgumentException($"User name already exists, canceling insert: {user.name}");
            }
            else
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user.id;
            }
        }

        [Route("api/setPoints")]
        public string SetPoints([FromBody]User user)
        {
            var u = context.Users.SingleOrDefault(s => s.id == user.id);

            if(u == null)
            {
                throw new ArgumentException($"User Id does not exist: {user.id}");
            }

            u.points = user.points;

            context.SaveChanges();

            return $"Points updated for User '{u.name}' to {u.points}";
        }
    }
}
