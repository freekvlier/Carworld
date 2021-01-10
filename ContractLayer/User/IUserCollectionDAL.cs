using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserCollectionDAL
    {
        bool Create(UserDTO user);
        bool Delete(UserDTO user);
        List<UserDTO> GetAll();
        UserDTO Get(int Id);
        int GetId(string username, string password);
    }
}
