using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }

        public Favorite()
        {

        }

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

            return FavoriteFactoryDAL.GetDAL().Update(favoriteDTO);
            
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
