using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string email, string username, string password)
        {
            this.Id = id;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        public bool Update()
        {
            UserDTO user = new UserDTO()
            {
                Id = this.Id,
                Email = this.Email,
                Username = this.Username,
                Password = this.Password
            };

            if (UserFactory.GetDAL().Update(user)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}
