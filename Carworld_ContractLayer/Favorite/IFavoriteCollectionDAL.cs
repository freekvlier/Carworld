using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFavoriteCollectionDAL
    {
        bool Create(FavoriteDTO favorite);
        bool Delete(int id);
        bool DeleteFromUser(int userId, int carId);
        List<FavoriteDTO> GetAll();
        FavoriteDTO Get(int Id);
        List<FavoriteDTO> GetAllByUserId(int userId);
        bool CheckFavorite(int userId, int carId);
    }
}
