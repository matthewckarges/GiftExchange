using System.Collections.Generic;

namespace GE.Data.StoreObjects.Mongo
{
    public class User
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<int> GiftListIds { get; set; }
    }
}
