using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class RealEstateFilterHouse : Demand
    {
        public int MinFloors { get; set; }
        public int MaxFloors { get; set; }
        public int MinRooms { get; set; }
        public int MaxRooms { get; set; }
        public double MinArea { get; set; }
        public double MaxArea { get; set; }
    }
}
