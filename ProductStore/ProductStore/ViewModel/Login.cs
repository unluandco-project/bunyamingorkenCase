﻿using System.ComponentModel.DataAnnotations;

namespace ProductStore.ViewModel
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
