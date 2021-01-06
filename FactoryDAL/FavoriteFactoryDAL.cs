using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;

namespace FactoryDAL
{
    public class FavoriteFactoryDAL
    {
        public static IFavoriteDAL GetDAL()
        {
            return new FavoriteDAL();
        }

        public static IFavoriteCollectionDAL GetCollectionDAL()
        {
            return new FavoriteDAL();
        }
    }
}
