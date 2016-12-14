using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GE.Data.TranferObjects.Models
{
    public class ExchangeDisplay
    {
        public string Name { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<GiftListItemDisplay> GiftLists { get; set; }
    }
}
