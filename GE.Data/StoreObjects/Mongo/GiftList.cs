using System.Collections.Generic;

namespace GE.Data.StoreObjects.Mongo
{
    public class GiftList
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public ICollection<Gift> Gifts { get; set; }
    }
}
