using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelApp.Web.Areas.Identity.Data;

namespace HotelApp.Web.Models
{
    public class Reservation : BaseModel
    {
        public Reservation()
        {
            this.Guests = new List<UsersReservations>();
        }

        //Must have guest to be created!

        [Required]
        public HotelAppWebUser Guest { get; set; }

        [Required]
        public string GuestId { get; set; }

        [Required]
        public DateTime AccomodationDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int NightsCount { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public int AdultsCount { get; set; }

        [Required]
        public int KidsCount { get; set; }

        [Required]
        public bool RoomService { get; set; }

        [Required]
        public int VisitationsCount { get; set; }

        public ICollection<UsersReservations> Guests { get; set; }
    }
}