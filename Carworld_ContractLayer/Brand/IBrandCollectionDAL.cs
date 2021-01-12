using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IBrandCollectionDAL
    {
        bool Create(BrandDTO brand);
        bool Delete(int brandId);
        List<BrandDTO> GetAll();
        BrandDTO Get(int brandId);
    }
}
