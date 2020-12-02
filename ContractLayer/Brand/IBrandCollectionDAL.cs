using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IBrandCollectionDAL
    {
        bool Create(BrandDTO brand);
        bool Delete(BrandDTO brand);
        List<BrandDTO> GetAll();
        BrandDTO Get(int Id);
    }
}
