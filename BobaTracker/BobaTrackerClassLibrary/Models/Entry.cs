using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BobaTrackerClassLibrary.Models
{
    public class Entry
    {
        [Key]
        public DateTime DateTimeId { get; set; }
        public bool HasPooped { get; set; }
        public bool HasPeed { get; set; }

    }
}
