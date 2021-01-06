﻿using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        public Brand(int id, string name, string origin)
        {
            this.Id = id;
            this.Name = name;
            this.Origin = origin;
        }

        public bool Update()
        {
            BrandDTO brandDTO = new BrandDTO
            {
                Id = this.Id,
                Name = this.Name,
                Origin = this.Origin
            };

            if (BrandFactoryDAL.GetDAL().Update(brandDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetOrigin(string origin)
        {
            this.Origin = origin;
        }

    }

}