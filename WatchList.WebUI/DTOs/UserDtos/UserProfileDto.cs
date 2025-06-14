﻿namespace WatchList.WebUI.DTOs.UserDtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
