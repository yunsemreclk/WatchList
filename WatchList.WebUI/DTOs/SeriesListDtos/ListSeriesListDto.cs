using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WebUI.DTOs.SeriesListDtos
{
    public class ListSeriesListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<int> SeriesIds { get; set; }
    }
    public class ListSeriesListItemDto
    {
        public int Id { get; set; }
        public int SeriesListId { get; set; }
        public int SeriesId { get; set; }

    }
}
