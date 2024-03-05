﻿using Core.Enums;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
