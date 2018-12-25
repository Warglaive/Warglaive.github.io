using HotelApp.Web.Areas.Identity.Data;

namespace HotelApp.Web.Models
{
    public class UsersReservations
    {
        public HotelAppWebUser User { get; set; }
        public string UserId { get; set; }

        public Reservation Reservation { get; set; }
        public string ReservationId { get; set; }
    }
}
