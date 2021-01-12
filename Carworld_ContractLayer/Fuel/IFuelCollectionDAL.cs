using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFuelCollectionDAL
    {
        bool Create(FuelDTO fuel);
        bool Delete(int fuelId);
        List<FuelDTO> GetAll();
        FuelDTO Get(int fuelId);
    }
}
