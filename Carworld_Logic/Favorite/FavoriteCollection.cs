using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class FavoriteCollection
    {
        public List<Favorite> GetAll()
        {
            List<Favorite> favoriteList = new List<Favorite>();
            var favorites = FavoriteFactoryDAL.GetCollectionDAL().GetAll();

            foreach (var favorite in favorites)
            {
                favoriteList.Add(new Favorite(favorite.Id, favorite.UserId, favorite.CarId));
            }

            return favoriteList;
        }

        public bool Create(Favorite favorite)
        {
            FavoriteDTO favoriteDTO = new FavoriteDTO()
            {
                Id = 0,
                UserId = favorite.UserId,
                CarId = favorite.CarId
            };

            return FavoriteFactoryDAL.GetCollectionDAL().Create(favoriteDTO);
        }

        public bool Delete(int id)
        {
            return FavoriteFactoryDAL.GetCollectionDAL().Delete(id);
        }


        public bool DeleteFromUser(int userId, int carId)
        {
            return FavoriteFactoryDAL.GetCollectionDAL().DeleteFromUser(userId, carId);
        }

        public Favorite Get(int id)
        {
            var favoriteGet = FavoriteFactoryDAL.GetCollectionDAL().Get(id);
            Favorite favorite = new Favorite(favoriteGet.Id, favoriteGet.UserId, favoriteGet.CarId);

            return favorite;
        }

        public List<Favorite> GetAllByUserId(int userId)
        {
            List<Favorite> favoriteList = new List<Favorite>();
            var favorites = FavoriteFactoryDAL.GetCollectionDAL().GetAllByUserId(userId);

            foreach (var favorite in favorites)
            {
                favoriteList.Add(new Favorite(favorite.Id, favorite.UserId, favorite.CarId));
            }

            return favoriteList;
        }

        public bool CheckFavorite(int userId, int carId)
        {
            return FavoriteFactoryDAL.GetCollectionDAL().CheckFavorite(userId, carId);
        }
    }
}
