using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WatchList.WebUI.DTOs.SeriesListDtos
{
    public class CreateSeriesListDto
    {
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<int> SeriesIds { get; set; }
    }
    public class CreateSeriesListItemDto
    {
        public int SeriesListId { get; set; }
        public int SeriesId { get; set; }
    }
}
