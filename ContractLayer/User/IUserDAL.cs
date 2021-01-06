using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserDAL
    {
        bool Update(UserDTO user);
    }
}
