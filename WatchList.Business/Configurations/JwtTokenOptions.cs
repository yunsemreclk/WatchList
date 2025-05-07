using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Business.Configurations
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } //api.watchlist.com sağlayıcı
        public string Audience { get; set; } //www.watchlist.com site
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
