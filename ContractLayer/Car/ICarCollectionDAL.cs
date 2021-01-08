using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarCollectionDAL
    {
        bool Create(CarDTO car);
        bool Delete(int Id);
        List<CarDTO> GetAll();
        CarDTO Get(int Id);
    }
}
