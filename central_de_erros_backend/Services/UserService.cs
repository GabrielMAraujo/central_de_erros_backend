using System;
using System.Collections.Generic;
using System.IO;
using central_de_erros_backend.Models;
using Newtonsoft.Json;

namespace central_de_erros_backend.Services
{
    public class UserService
    {
        private readonly CentralContext context;

        public UserService(CentralContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            User ret = context.Add<User>(user).Entity;

            context.SaveChanges();

            return ret;
        }

        public void AddTestUsers()
        {
            string file = File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/TestData/users.json");

            List<User> users = JsonConvert.DeserializeObject<List<User>>(file);
            foreach (User user in users)
            {
                Add(user);
            }
        }
    }
}
