using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class Brand
    {
        private readonly IBrandDAL brandDAL;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        //Unit test
        public Brand(IBrandDAL brandDAL)
        {
            this.brandDAL = brandDAL;
        }

        //Unit test
        public Brand(IBrandDAL brandDAL, int id, string name, string origin)
        {
            this.Id = id;
            this.Name = name;
            this.Origin = origin;

            this.brandDAL = brandDAL;
        }

        public Brand()
        {
            brandDAL = BrandFactoryDAL.GetDAL();
        }

        public Brand(int id, string name, string origin)
        {
            this.Id = id;
            this.Name = name;
            this.Origin = origin;

            brandDAL = BrandFactoryDAL.GetDAL();
        }

        public bool Update()
        {
            BrandDTO brandDTO = new BrandDTO
            {
                Id = this.Id,
                Name = this.Name,
                Origin = this.Origin
            };

            return brandDAL.Update(brandDTO);
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
