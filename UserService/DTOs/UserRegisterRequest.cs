﻿namespace Llp.User.DTOs
{
    public class UserRegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public int languageId { get; set; } = 1; //default to English
        public string? Contact { get; set; }
        public string? Address { get; set; }
    }
}
