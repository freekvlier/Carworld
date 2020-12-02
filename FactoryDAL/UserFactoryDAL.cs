using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using DAL;


namespace FactoryDAL
{
    public class UserFactory
    {
        public static IUserDAL GetDAL()
        {
            return new UserDAL();
        }

        public static IUserDAL GetCollectionDAL()
        {
            return new UserDAL();
        }
    }
}
