using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class Deal
    {
        public int Id { get; set; }
        public Demand Demand { get; set; }
        public Supply Supply { get; set; }
    }
}
