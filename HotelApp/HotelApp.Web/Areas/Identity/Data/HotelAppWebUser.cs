using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelApp.Web.Models;
using HotelApp.Web.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace HotelApp.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the HotelAppWebUser class
    public class HotelAppWebUser : IdentityUser
    {
        public HotelAppWebUser()
        {
            this.PreviousReservations = new List<UsersReservations>();
        }

        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }

        [ForeignKey("Reservation")]
        public string ReservationId { get; set; }

        [Required]
        public Role Role { get; set; }

        public ICollection<UsersReservations> PreviousReservations { get; set; }
    }
}