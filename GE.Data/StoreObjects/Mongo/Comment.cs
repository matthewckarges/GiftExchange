using System;

namespace GE.Data.StoreObjects.Mongo
{
    public class Comment
    {
        public int Id { get; set; }

        public int UserName { get; set; }

        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
