using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class RealEstateApartment : RealEstate
    {
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public double TotalArea { get; set; }
    }
}
