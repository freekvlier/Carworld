using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarCollectionDAL
    {
        bool Create(CarDTO car);
        bool Delete(CarDTO car);
        List<CarDTO> GetAll();
        CarDTO Get(int Id);
    }
}
