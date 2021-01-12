using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;


namespace FactoryDAL
{
    public class CarFactoryDAL
    {
        public static ICarDAL GetDAL()
        {
            return new CarDAL();
        }

        public static ICarCollectionDAL GetCollectionDAL()
        {
            return new CarDAL();
        }
    }
}
