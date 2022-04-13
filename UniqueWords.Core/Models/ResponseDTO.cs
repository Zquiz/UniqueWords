using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWords.Core.Models
{
    public class ResponseDTO
    {
        public int DistinctUniqueWords { get; set; }
        public string[] WatchlistWords { get; set; }
    }
}
