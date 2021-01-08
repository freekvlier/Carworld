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
        List<CarDTO> GetAllSorted(string property);
        CarDTO Get(int Id);
    }
}
