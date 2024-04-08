using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingGarage.Domain.Entities.Enums;
using System.Text.Json.Serialization;

namespace ParkingGarage.Domain.Entities
{
    [Table("user")]
    public class User : IdentityUser
    {
        public string Login
        {
            get => UserName;
            set => UserName = value;
        }

        [JsonIgnore] public virtual ICollection<UserRole> UserRoles { get; set; }

        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Url]
        [StringLength(256)]
        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}
