using System.Collections.Generic;

namespace GE.Data.StoreObjects.Mongo
{
    public class Gift
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? Rank { get; set; }

        public string Link { get; set; }

        public bool Active { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
