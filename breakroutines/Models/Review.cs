using System;
using System.Collections.Generic;

#nullable disable

namespace breakroutines.Models
{
    public partial class Review
    {
        public long ReviewId { get; set; }
        public int UserId { get; set; }
        public long TripId { get; set; }
        public string Description { get; set; }
        public byte Score { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual User User { get; set; }
    }
}
