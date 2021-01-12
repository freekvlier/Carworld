using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFavoriteDAL
    {
        bool Update(FavoriteDTO favorite);
    }
}
