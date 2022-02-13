using System;
using System.Collections.Generic;

#nullable disable

namespace breakroutines.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
            TripPhotos = new HashSet<TripPhoto>();
            Trips = new HashSet<Trip>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePic { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TripPhoto> TripPhotos { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
