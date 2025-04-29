using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Entity.Entities;

namespace WatchList.Entity.Entites
{
    public class TierList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<TierListItem> Items { get; set; }
        public ICollection<Like> Likes { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

    public class TierListItem
    {
        public int Id { get; set; }
        public int TierListId { get; set; }
        public TierList TierList { get; set; }

        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public string Tier { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }

}
