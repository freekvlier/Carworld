using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFavoriteCollectionDAL
    {
        bool Create(FavoriteDTO favorite);
        bool Delete(int favoriteId);
        bool DeleteFromUser(int userId, int carId);
        List<FavoriteDTO> GetAll();
        FavoriteDTO Get(int favoriteId);
        List<FavoriteDTO> GetAllByUserId(int userId);
        bool CheckFavorite(int userId, int carId);
    }
}
