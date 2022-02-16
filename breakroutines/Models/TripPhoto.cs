using System;
using System.Collections.Generic;

#nullable disable

namespace breakroutines.Models
{
    public partial class TripPhoto
    {
        public long TripPhotoId { get; set; }
        public int UserId { get; set; }
        public long TripId { get; set; }
        public string Photo { get; set; }
        public bool IsDefault { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual User User { get; set; }
    }
}
