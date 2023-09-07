using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp
{
    //Оптимизация: Изменение регистра с целью предотвращения нарушения наименования (id => Id)
    public class Demand
    {
        public int Id { get; set; }

        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouse { get; set; }
        public string AddressNumber { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public int AgentId { get; set; }
        public int ClientId { get; set; }

        public int RealEstateFilterId { get; set; }
        public string RealEstateType { get; set; }
    }
}
