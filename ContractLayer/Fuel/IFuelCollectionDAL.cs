﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IFuelCollectionDAL
    {
        bool Create(FuelDTO fuel);
        bool Delete(FuelDTO fuel);
        List<FuelDTO> GetAll();
        FuelDTO Get(int Id);
    }
}
