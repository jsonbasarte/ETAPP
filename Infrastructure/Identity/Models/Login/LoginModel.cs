﻿using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Identity.Models.Login;

public class LoginModel
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
