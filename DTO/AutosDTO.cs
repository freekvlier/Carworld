using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AutosDTO
    {
        public List<AutoDTO> Autos = new List<AutoDTO>();
        public List<MerkDTO> Merken = new List<MerkDTO>();
        public List<BrandstofDTO> Brandstoffen = new List<BrandstofDTO>();
        public List<KlasseDTO> Klassen = new List<KlasseDTO>();
    }
}
