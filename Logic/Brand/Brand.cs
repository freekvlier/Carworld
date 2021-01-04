using System;
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

        public Brand(int Id, string Name, string Origin)
        {
            this.Id = Id;
            this.Name = Name;
            this.Origin = Origin;
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

        public void setName(string name)
        {
            this.Name = name;
        }

        public void setOrigin(string origin)
        {
            this.Origin = origin;
        }

    }

}
