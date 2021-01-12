using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;


namespace FactoryDAL
{
    public class BrandFactoryDAL
    {
        public static IBrandDAL GetDAL()
        {
            return new BrandDAL();
        }

        public static IBrandCollectionDAL GetCollectionDAL()
        {
            return new BrandDAL();
        }
    }
}
