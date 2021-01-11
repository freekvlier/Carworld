using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
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

            if (FavoriteFactoryDAL.GetCollectionDAL().Create(favoriteDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (FavoriteFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteFromUser(int userId, int carId)
        {
            if (FavoriteFactoryDAL.GetCollectionDAL().DeleteFromUser(userId, carId))
            {
                return true;
            }
            else
            {
                return false;
            }
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
