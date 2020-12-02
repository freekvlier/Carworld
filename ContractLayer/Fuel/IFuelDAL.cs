using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFuelDAL
    {
        bool Update(FuelDTO brandstof);
    }
}
