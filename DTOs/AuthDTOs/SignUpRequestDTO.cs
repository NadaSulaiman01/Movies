﻿using System.ComponentModel.DataAnnotations;

namespace Movies.DTOs.AuthDTOs
{
    public class SignUpRequestDTO
    {

        public string Email { get; set; }

        public string Username { get; set; } 


        public string Gender { get; set; }

        public string Password { get; set; }


    }
}
