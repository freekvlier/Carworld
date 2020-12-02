using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;


namespace FactoryDAL
{
    public class CarClassFactoryDAL
    {
        public static ICarClassDAL GetDAL()
        {
            return new CarClassDAL();
        }

        public static ICarClassCollectionDAL GetCollectionDAL()
        {
            return new CarClassDAL();
        }
    }
}
