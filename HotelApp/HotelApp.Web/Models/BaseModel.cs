using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; }
    }
}