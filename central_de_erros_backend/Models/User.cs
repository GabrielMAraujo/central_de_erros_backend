using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace central_de_erros_backend.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string Token { get; set; }

        public List<Alert> Alerts { get; set; }
    }
}
