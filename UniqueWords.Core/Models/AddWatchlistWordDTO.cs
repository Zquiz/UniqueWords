using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWords.Core.Models
{
    public class AddWatchlistWordDTO
    {
        [Required(ErrorMessage = "Please enter one or more words")]
        public string Word { get; set; }
    }
}
