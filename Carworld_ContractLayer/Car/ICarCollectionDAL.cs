using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarCollectionDAL
    {
        int Create(CarDTO car);
        bool Delete(int carId);
        List<CarDTO> GetAll();
        List<CarDTO> GetAllSorted(string property);
        CarDTO Get(int carId);
    }
}
