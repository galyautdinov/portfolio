using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class RealEstateFilterApartment : Demand
    {
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public int MinRooms { get; set; }
        public int MaxRooms { get; set; }
        public double MinArea { get; set; }
        public double MaxArea { get; set; }
    }
}
