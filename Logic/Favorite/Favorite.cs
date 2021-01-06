using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }

        public Favorite(int id, int userid, int carId)
        {
            this.Id = id;
            this.UserId = userid;
            this.CarId = carId;
        }

        public bool Update()
        {
            FavoriteDTO favoriteDTO = new FavoriteDTO
            {
                Id = this.Id,
                UserId = this.UserId,
                CarId = this.CarId
            };

            if (FavoriteFactoryDAL.GetDAL().Update(favoriteDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }

        public void SetCarId(int carId)
        {
            this.CarId = carId;
        }
    }
}
