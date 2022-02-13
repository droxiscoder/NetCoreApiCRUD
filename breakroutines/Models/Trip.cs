using System;
using System.Collections.Generic;

#nullable disable

namespace breakroutines.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Reviews = new HashSet<Review>();
            TripPhotos = new HashSet<TripPhoto>();
        }

        public long TripId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TripPhoto> TripPhotos { get; set; }
    }
}
