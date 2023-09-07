using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class RealEstateFilterLand : Demand
    {
        public double MinArea { get; set; }
        public double MaxArea { get; set; }
    }
}
