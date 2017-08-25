﻿namespace ArangoDB.Net.Core.Models
{
    public class DatabaseUser
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
