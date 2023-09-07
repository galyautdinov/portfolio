using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class RealEstate
    {
        public int Id { get; set; }

        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouse { get; set; }
        public string AddressNumber { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
