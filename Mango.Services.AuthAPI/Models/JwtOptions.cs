﻿namespace Mango.Services.AuthAPI.Models
{
    public class JwtOptions
    {
        public string Issure { get; set; } = string.Empty;
        public string Audience {  get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
    }
}
