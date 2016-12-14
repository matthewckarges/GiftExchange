using System;
using System.Collections.Generic;

namespace GE.Data.StoreObjects.Mongo
{
    public class Exchange
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<GiftList> GiftLists { get; set; }
    }
}
