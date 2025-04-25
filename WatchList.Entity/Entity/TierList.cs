using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entity
{
    public class TierList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<TierListItem> Items { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
    public class TierListItem
    {
        public Guid Id { get; set; }
        public Guid TierListId { get; set; }
        public TierList TierList { get; set; }

        public string ItemType { get; set; } // Movie or Series
        public Guid ItemId { get; set; } // MovieId or SeriesId
        public string Tier { get; set; } // S, A, B, C, D, F
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }

}
