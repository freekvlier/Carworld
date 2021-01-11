using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carworld.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
    }
}
