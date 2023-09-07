using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class Supply
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public int RealEstateId { get; set; }
    }
}
