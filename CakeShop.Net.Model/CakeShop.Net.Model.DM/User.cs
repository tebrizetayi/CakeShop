using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Net.Model.DM
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserPasswordSalt { get; set; }
        public string UserAlternatePassword { get; set; }
        public System.DateTime UserModifiedDate { get; set; }
        public System.DateTime UserCreatedDate { get; set; }
        public bool UserStatus { get; set; }
        public int UserCreatedBy_UserId { get; set; }
        public int UserModifiedBy_UserId { get; set; }
    }
}
