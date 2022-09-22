﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid fromat email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(20, ErrorMessage = "The {0} must bre at least {2} and at max " + "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
