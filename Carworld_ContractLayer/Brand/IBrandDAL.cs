using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IBrandDAL
    {
        bool Update(BrandDTO brand);
    }
}
