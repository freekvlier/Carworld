using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarDAL
    {
        bool Update(CarDTO car);
    }
}
