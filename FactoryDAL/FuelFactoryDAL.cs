using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;


namespace FactoryDAL
{
    public static class FuelFactoryDAL
    {
        public static IFuelDAL GetDAL()
        {
            return new FuelDAL();
        }

        public static IFuelCollectionDAL GetCollectionDAL()
        {
            return new FuelDAL();
        }
    }
}
