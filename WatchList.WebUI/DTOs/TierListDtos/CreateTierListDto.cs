﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WebUI.DTOs.TierListDtos
{
    public class CreateTierListDto
    {
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int AppUserId { get; set; }

    }
    public class CreateTierListItemDto
    {
        public int TierListId { get; set; }
        public string ItemType { get; set; }
        public int? MovieId { get; set; } // Nullable MovieId
        public int? SeriesId { get; set; } // Nullable SeriesId
        public string Tier { get; set; } // S, A, B, C, D, F gibi yada kullanıcının kendi oluşturduğu bir tier
    }
}
