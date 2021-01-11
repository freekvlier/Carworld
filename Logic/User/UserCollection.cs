using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class UserCollection
    {
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            var userList = UserFactory.GetCollectionDAL().GetAll();

            foreach (var user in userList)
            {
                users.Add(new User(user.Id, user.Email, user.Username, user.Password));
            }

            return users;
        }

        public bool Create(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = -1,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };

            if (UserFactory.GetCollectionDAL().Create(userDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };

            if (UserFactory.GetCollectionDAL().Delete(userDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Get(int id)
        {
            var getUser = UserFactory.GetCollectionDAL().Get(id);
            User user = new User(getUser.Id, getUser.Email, getUser.Username, getUser.Password);
            return user;
        }

        public int GetId(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Username = user.Username,
                Password = user.Password
            };
            return UserFactory.GetCollectionDAL().GetId(userDTO);
        }
    }
}
