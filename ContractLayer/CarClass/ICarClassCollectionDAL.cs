using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface ICarClassCollectionDAL
    {
        bool Create(CarClassDTO carclass);
        bool Delete(int id);
        List<CarClassDTO> GetAll();
        CarClassDTO Get(int Id);
    }
}
