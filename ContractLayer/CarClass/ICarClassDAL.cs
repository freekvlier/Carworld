using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarClassDAL
    {
        bool Update(CarClassDTO carclass);
    }
}
