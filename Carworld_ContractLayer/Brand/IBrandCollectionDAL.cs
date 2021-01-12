using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IBrandCollectionDAL
    {
        bool Create(BrandDTO brand);
        bool Delete(int id);
        List<BrandDTO> GetAll();
        BrandDTO Get(int Id);
    }
}
