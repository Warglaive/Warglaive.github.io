using HotelApp.Web.Areas.Identity.Data;
using HotelApp.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Web.Data
{
    public class HotelAppWebContext : IdentityDbContext<HotelAppWebUser>
    {
        public DbSet<HotelAppWebUser> HotelAppWebUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public HotelAppWebContext(DbContextOptions<HotelAppWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UsersReservations>()
                .HasKey(x => new
                {
                    x.ReservationId,
                    x.UserId
                });

            builder.Entity<UsersReservations>()
                .HasOne(x => x.Reservation)
                .WithMany(x => x.Guests)
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UsersReservations>()
                .HasOne(x => x.User)
                .WithMany(x => x.PreviousReservations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
