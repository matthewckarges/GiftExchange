using System.Collections.Generic;

namespace GE.Data.TranferObjects.Models
{
    public class GiftListItemDisplay
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public ICollection<GiftDisplay> Gifts { get; set; }
    }
}