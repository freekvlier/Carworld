using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFavoriteCollectionDAL
    {
        bool Create(FavoriteDTO favorite);
        bool Delete(FavoriteDTO favorite);
        List<FavoriteDTO> GetAll();
        FavoriteDTO Get(int Id);
    }
}
