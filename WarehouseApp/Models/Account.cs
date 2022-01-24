using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [EmailAddress]
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

